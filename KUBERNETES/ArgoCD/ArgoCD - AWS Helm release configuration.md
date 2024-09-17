#ArgoCD 

# ArgoCD Helm release configuration

This is a basic documentation about how to configure ArgoCD helm release for AWS. 

ArgoCD is configured to use AWS ALB[^ALB]. 

### Resources Namespace

The namespace is not needed to be set in the different `.yaml` configuration file due to its settled by Helm release by specifying it in the `helm_release.argocd.namespace` resource.

If this is changed, make sure that if exist previous to the deployment, set `create_namespace` to false and set the new namespace for argocd resources in the `namespace` attribute. 

### ALB configuration for ingress resource

For exposing to the internet the ArgoCD server pod, which is the one in charge of showing the Dashboards for applications management, we need to set the following: 

```
set{
    name = "server.ingress.annotations"
    value = join("\n", [
        # Other annotations 
        "alb.ingress.kubernetes.io/backend-protocol: HTTPS",   
        "alb.ingress.kubernetes.io/healthcheck-protocol: HTTPS", 
        "alb.ingress.kubernetes.io/listen-ports: '[{\"HTTPS\":443}]"
        "alb.ingress.kubernetes.io/certificate-arn: arn:aws:...
    ])
  }
}
```

* 
	* instance mode: ingress traffic starts in AWL and reached the node through each service's NodePort. 
	* ip mode: Starts traffic at ALB and reaches the pods directly

* `alb.ingress.kubernetes.io/backend-protocol: HTTPS` this is set to HTTP or HTTP depending on the backend protocol used. Same as `alb.ingress.kubernetes.io/healthcheck-protocol`
* `alb.ingress.kubernetes.io/listen-ports: '[{\"HTTPS\":443}]` must be set to `{"HTTPS":443}` to listen to HTTPS port for this pod. 
* `alb.ingress.kubernetes.io/certificate-arn` must be set to the ARN of the certificate for the HTTPS connection. 

The resulting ArgoCD server ingress must look like this: 

```yaml
apiVersion: networking.k8s.io/v1
kind: Ingress
metadata:
  name: argocd-ingress
  namespace: argocd
  annotations:
    alb.ingress.kubernetes.io/scheme: internet-facing
    alb.ingress.kubernetes.io/target-type: ip
    alb.ingress.kubernetes.io/backend-protocol: HTTPS
    alb.ingress.kubernetes.io/healthcheck-protocol: HTTPS
    alb.ingress.kubernetes.io/listen-ports: '[{"HTTPS":443}]'
    alb.ingress.kubernetes.io/subnets: subnet-01db3b02f92f0f0a1, subnet-0c3c5ace6d4d6393b, subnet-089a3d8616bfef73f
    alb.ingress.kubernetes.io/certificate-arn: arn:aws:acm:ap-south-1:XXXXXXXXXXXXXX:certificate/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX
spec:
  ingressClassName: alb
  rules:
    - host: example.devops.world
      http:
        paths:
          - path: /
            pathType: Prefix
            backend:
              service:
                name: argocd-server
                port:
                  number: 443
```

### Repo authentication

In order for ArgoCD to be able to authenticate with the Git repository, it need some secret stored in a Kubernetes Secret. This can be configured in the `.yaml` file or before in the dashboard. 

Depending on the client used and if its an personalized client version, you must need to specify it as known hosts and set the ssh key: 

```yaml
data:
      ssh_known_hosts: |
        bitbucket.org ssh-rsa .........key...........
        github.com ssh-rsa .........key...........
        gitlab.com ecdsa-sha2-nistp256 .........key...........
        gitlab.com ssh-ed25519 .........key...........
        gitlab.com ssh-rsa .........key...........
        ssh.dev.azure.com ssh-rsa .........key...........
        vs-ssh.visualstudio.com ssh-rsa .........key...........
```

To configure it, you need to set the secret depending on the Git Client that is going to be used. Set one or various of the following credential secrets. In case of Azure Devops, a username and password must be set. 

```yaml

    ###  Webhook Configs

    ## Shared secret for authenticating GitHub webhook events
    githubSecret: ""

    ## Shared secret for authenticating GitLab webhook events
    gitlabSecret: ""

    ## Shared secret for authenticating BitbucketServer webhook events
    bitbucketServerSecret: ""

    ## UUID for authenticating Bitbucket webhook events
    bitbucketUUID: ""

    ## Shared secret for authenticating Gogs webhook events
    gogsSecret: ""

    ## Azure DevOps
    azureDevops:
      ## Shared secret username for authenticating Azure DevOps webhook events
      username: ""
      ## Shared secret password for authenticating Azure DevOps webhook events
      password: ""
```

### ArgoCD password

ArgoCD by default, the password can be set by defining it in the `.yaml`. It expects a bcrypt hashed password. This one can be created on demand by using the following command: 

`htpasswd -nbBC 10 "" $ARGO_PWD | tr -d ':\n' | sed 's/$2y/$2a/` 

And place the generated hashed password in the `configs.secret.argocdServerAdminPassword` variable: 

```yaml
 argocdServerAdminPassword: "$2a$10$vE6OGtN69SIQ7XFI5pzdqOAbqxI.yvt1D46BTQV96NvkZwLyuP5IK"
```

This is the hashed password set by default. 


[^ALB]: Application Load Balancer [[AWS - ALB Application Load Balancer]]
