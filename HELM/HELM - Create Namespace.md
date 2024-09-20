#HELM #KUBERNETES 

# HELM Create namespace

In some cases, a new namespace is required for deploying the Helm release within it. 

To do so, you can specify the namespace and create it in the `helm install` command: 

> Note: Namespace will only be created if doesn't exist, it wont replace it 


Format: 

```bash
helm install <release-name> ./<path> --namespace <ns-name> --create-namespace
```

* `<release-name>` specify the name of the release to be deployed in Kubernetes
* `<ns-name>` is the namespace name



### Terraform 

If using terraform for deploying Helm releases using the helm provider, you can set the `create_namespace` attribute to true, so namespace will be created if doesn't exists. 

```hcl
resource "helm_release" "velero" {
  name       = ...
  repository = ...
  chart      = ...
  namespace  = <ns-name>
  create_namespace = true
}
```