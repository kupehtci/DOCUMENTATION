#AKS #AZURE 

### Terraform Azure subnet 

An azure subnet can be defined as : 

```json
// resource group declaration
resource "azurerm_resource_group" "rg" {
  name     = "${var.environment}-rg"
  location = var.location
  tags     = var.tags
}
//subnet declaration
resource "azurerm_subnet" "name_subnet"{
	name = "example"
	resource_group_name = azure_resource_group.rg.name
}
```