#TERRAFORM 


This is the list of some of the available providers sources for Terraform: 

```
* AWS --> hashicorp/aws
* AKS --> hashicorp/azurerm
* AzureAD --> hashicorp/azuread
* Helm --> hashicorp/helm
* DOCKER --> kreuzwerker/docker
* Kubernetes --> hashicorp/kubernetes
* Random --> hashicorp/random
```

This providers need to be defined in a block like the following: 

```hcl
terraform{
	required_providers{

		<provider_name> = {
			source = "<provider>/<resource>"
			version = "X.XX.X"
		}
		# More providers
	}
}
```
