#AKS #AZURE #CLOUD

### Terraform Azure subnet 

An azure subnet can be defined as : 

```hcl
// resource group declaration
resource "azurerm_resource_group" "rg" {
  name     = "${var.environment}-rg"
  location = var.location
  tags     = var.tags
}

# Virtual network declaration
resource "azurerm_virtual_network" "vnet"{
 name                = "example-vnet"
  address_space       = ["10.0.0.0/16"]
  location            = azurerm_resource_group.example.location
  resource_group_name = azurerm_resource_group.example.name
}

# subnet declaration
resource "azurerm_subnet" "name_subnet"{
	name                 = "example"
	resource_group_name  = azure_resource_group.rg.name
	virtual_network_name = azurerm_virtual_network.vnet.name
	address_prefixes     = ["10.0.1.0/24"]
}
```