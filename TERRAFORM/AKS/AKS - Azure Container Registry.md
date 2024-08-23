#AZURE #AKS #TERRAFORM 

To create an Azure Container Registry using terraform you need to use an `azurerm_container_registry` resource from `azure` provider. 

This is an example of how to declare it: 

```hcl
resource "azurerm_container_registry" "acr" {
  name                = "boilerplateacr1"
  resource_group_name = azurerm_resource_group.azure-boilerplate-aks.name
  location            = var.location
  sku                 = "Basic"

  identity {
    type = "SystemAssigned"
  }
  
  admin_enabled = true
}   
```

* `admin_enabled` is set to true to be able to have an admin username and password to access the container registry when pulling and pushing images into the registry
