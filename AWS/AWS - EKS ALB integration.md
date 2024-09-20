#AWS 

# EKS ALB integration

Configuring an Application Load Balancer or ALB for an Amazon Elastic Kubernetes Service or EKS requires several steps in order to set up the corret target group for making the ALB to balance and route the traffic to the EKS. 

Also the EKS requires the appropriate IAM roles and policies in order to be able to interact with the ALB. 

#### Prerequisites

* An EKS cluster running with worker nodes
* ALB installed within the cluster
* IAM roles and policies appropriates for the EKS cluster. 


#### How to install IAM OIDC

The AWS ALB requires to access the EKS in order to convert Kubernetes ingress[^ing] resources into ALB configurations. 

This can be done with the following command, by providing the correct `region`, `cluster-name`: 
```bash
eksctl utils associate-iam-oidc-provider --region <region> --cluster <cluster-name> --approve
```

Create the IAM policy: 

```bash
curl -o iam_policy.json https://raw.githubusercontent.com/kubernetes-sigs/aws-load-balancer-controller/main/docs/install/iam_policy.json
aws iam create-policy --policy-name AWSLoadBalancerControllerIAMPolicy --policy-document file://iam_policy.json
```

Create an IAM service account within the cluster: 

```bash
eksctl create iamserviceaccount \
  --cluster=<cluster-name> \
  --namespace=kube-system \
  --name=aws-load-balancer-controller \
  --attach-policy-arn=arn:aws:iam::<account-id>:policy/AWSLoadBalancerControllerIAMPolicy \
  --approve

```

Install the Load Balancer Controller within the cluster: 

```bash
helm repo add eks https://aws.github.io/eks-charts
helm repo update

helm install aws-load-balancer-controller eks/aws-load-balancer-controller \
  -n kube-system \
  --set clusterName=<cluster-name> \
  --set serviceAccount.create=false \
  --set serviceAccount.name=aws-load-balancer-controller \
  --set region=<region> \
  --set vpcId=<vpc-id>
```

Once this AWS load balancer controller is installed using helm, we can see the resources running with: 

```bash
kubectl get deployment -n kube-system aws-load-balancer-controller
NAME                           READY   UP-TO-DATE   AVAILABLE   AGE
aws-load-balancer-controller   2/2     2            2           84s
```
#### How to create ingresses for the ALB

The ingresses must be created with the following tags: 

```yaml
apiVersion: networking.k8s.io/v1
kind: Ingress
metadata:
  name: example-ingress
  namespace: default
  annotations:
    # Use the ALB ingress controller to manage this resource
    kubernetes.io/ingress.class: alb
    # Specify the health check path
    alb.ingress.kubernetes.io/healthcheck-path: "/"
    # Allow access from the internet
    alb.ingress.kubernetes.io/scheme: internet-facing
    # Use IP-based target groups (required for EKS)
    alb.ingress.kubernetes.io/target-type: ip
spec:
  rules:
    - host: example.com
      http:
        paths:
          - path: /
            pathType: Prefix
            backend:
              service:
                name: example-service
                port:
                  number: 80

```

The following tags must be provided in order to be able to register into the ALB within AWS. 
- `kubernetes.io/ingress.class: alb`
- `alb.ingress.kubernetes.io/target-type: ip`

In case of requiring certificates, this ones can be provided by: 
`alb.ingress.kubernetes.io/certificate-arn: arn:aws:acm:region:account-id:certificate/certificate-id`

If the private subnets are not tagged with `_` and the public with `_`, you must need to specify the subnets from where the Ingress is available in order to deploy the target group. For doing this, you must specify the subnets in the `ingress.metadata.annotations` with `alb.ingress.kubernetes.io/subnets: "subnet-xxxxx , subnet-xxxxxx"`   

[^ing]: Ingress kubernetes resources [[KUBERNETES - Ingress]]