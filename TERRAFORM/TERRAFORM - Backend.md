#TERRAFORM #AKS #AZURE 

### TERRAFORM - Backend

A <span style="color:orange;">backend</span> defined where Terraform stores its state data files. 

Terraform uses a persistent data to keep track of the managed resources. This data can be stored in HCP Terraform or use a backend remote storage like Azure Storage Account[^1]

In case of store the `terraform.tfstate` in the cloud, as example in an Azure Storage Account[^2] you need to define the container as: 

```hcl
terraform {
  backend "azurerm" {
    resource_group_name      = "<rg-name>"
    storage_account_name     = "<storage_account_name>"
    container_name           = "<sa_container_name"
    key                      = "terraform.tfstate"
  }
}
```

* In case you have Managed Service Identity as an authentication method, this values need to be included within the `backend` resource: 

```hcl
	use_msi = true
    subscription_id          = "<your_subscription\_id>"
    tenant_id                = "<your_tenant_id>"
```

* otherwise if the authentication method is via a Storage Account Access key or a SAS token, the values can be defined as: 

```hc
access_key               = "<your_storage_account_access_key>"
# or 
sas_token                = "<your_storage_account_sas_token>"
```

In case of store the `terraform.tfstate` <span style="color:orange;">locally</span> you can define as: 
```hcl

# Configure the path of the backend

terraform {
  backend "local" {
    path = "relative/path/to/terraform.tfstate"
  }
}

data "terraform_remote_state" "foo" {
  backend = "local"

  config = {
    path = "${path.module}/../../terraform.tfstate"
  }
}
```

#### Take into account

Something to take into account when configuring a backend: 

* backend stores the configuration in two plain text files, that are not updated, so time restricted credentials better be passed as environmental variables. 
* If the configuration contains a `cloud` component, cannot include a `backend` block. 



[^1]: Azure storage account for persistent data [[AZURE - Storage Account]]]]