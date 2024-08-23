#AZURE #AKS 


The apps are deployed to the Kubernetes cluster by using Helm provider of terraform. 

Deploys the application from a remote helm charts repository by selecting the version and overwrite values in the default `values.yaml` provided in the repository, through the yaml file in the terraform repository. 

### NGINX Configuration

Nginx by default is configured to listen and control all the ingresses that include the alias `ingressClassName:nginx`. 

Its configured to act as Load Balancer. This can be set to "LoadBalancer", "NodePort" or "ClusterIP" in `service.type`

To use an specified IP, can be set in `service.loadBalancerIP:"XXX.XXX.XXX.XXX"`, by default te Load Balancer will automatically deploy a Public IP resource depending on the provider and use this IP as Load Balancer entry point. 

NGINX **auto-scaling** can be enabled by setting `autoscaling.enabled: true` and configuring the autoscaler with `autoscaling.minReplicas`, `autoscaling.maxReplicas` and resources targets: 

```yaml
autoscaling:
  enabled: false
  minReplicas: ""
  maxReplicas: ""
  targetCPU: ""
  targetMemory: ""
```

By default **network policy** is enabled. This default policy allows external access to the pods and egress access to the same ones. 

The update strategy for the deployment of NGINX is Rolling. This can be modified in `updateStrategy.type` 

The default values are in: [nginx 18.1.10 · bitnami/bitnami (artifacthub.io)](https://artifacthub.io/packages/helm/bitnami/nginx?modal=values)


### ArgoCD configuration

There are different ArgoCD deploy properties that can be adjusted: 

The ArgoCD `server` is the main dashboard service that can be configured. By default, its `autoscaling` is not enabled. 

To configure ArgoCD ingress through NGINX service: 

```yaml
global:
  domain: argocd.example.com

certificate:
  enabled: true

server:
  ingress:
    enabled: true
    ingressClassName: nginx
    annotations:
      nginx.ingress.kubernetes.io/force-ssl-redirect: "true"
      nginx.ingress.kubernetes.io/ssl-passthrough: "true"
    tls: true
```

For configuring the ingress without NGINX checkout documentation about AKS / AWS / GKE Load Balancing ingress in [argo-cd 7.4.5 · argoproj/argo (artifacthub.io)](https://artifacthub.io/packages/helm/argo/argo-cd)  

ArgoCD's Custom Resource Definitions (CRD) are installed via terraform kubernetes provider before deploying ArgoCD chart. This avoid possible versioned error 
