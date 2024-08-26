#TERRAFORM 

Kubernetes provider has `hashicorp/kubernetes` source. 

```terraform
terraform {
  required_providers {
    kubernetes = {
      source = "hashicorp/kubernetes"
	  version = "..."
    }
  }
  
  # Provider functions require Terraform 1.8 and later.
  required_version = ">= 1.8.0"
}
```


In the <span style="color:orange;">provider block</span>, the credentials must be configured. 

The configuration must have: 

* Defined the kubeconfig path or the host, client certificate and key and cluster ca certificate defined

