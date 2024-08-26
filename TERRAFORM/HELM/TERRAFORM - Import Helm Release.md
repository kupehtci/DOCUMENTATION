#HELM #TERRAFORM #KUBERNETES 

### Import Helm Release

When a Helm resource that has been deployed via Helm and wants to be managed / imported to terraform or even when this resource is restored or created in the Cluster via Velero[^vele] or ArgoCD deployment, we need to import it to be able to manage it with terraform. 

For importing all kind of resources in Terraform, we need to have defined al least the resource: 

```hcl
resource "helm_release" "example_release"{
	name = ""
	# ... 
}
```

For importing a Helm Release, firstly we need to list all the charts deployed in order to identify the one that we want to import and see the namespace that it belongs to: 

```bash

> helm list -A
NAME             NAMESPACE      CHART                  	          APP VERSION 
example          main           example-cd-12.3.0                 v12.03.01        

# Import the resource
> terraform import helm_release.example_release nginx/nginx
```

#### Example

```bash
# List all the helm managed charts
> helm list -A
NAME             NAMESPACE      CHART                  	          APP VERSION
aks-managed-wi   kube-system    workload-identity-addon-0.1.08             
argocd           argocd         argo-cd-7.4.0                     vX.XX.X    
nginx            nginx          ingress-nginx-4.11.1              X.XX.X    
prometheus       monitor        kube-prometheus-stack-61.8.0      vX.XX.X    
velero           velero         velero-7.0.0                      X.XX.X    

# Import the resource
> terraform import helm_release.nginx_controller_app nginx/nginx

```


[^vele]: Velero Disaster Recovery application for Kubernetes resources. [[VELERO - Disaster Recovery]]