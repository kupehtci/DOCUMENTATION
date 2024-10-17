#AKS #TERRAFORM 

### AKS - Subnet network security group association

Associates a Network Security Group (NSG) with a Subnet within a virtual network. 
A network security group contains a list of network security rules. 

It uses this rules in order to enable or deny inbound or outbound traffic. 

### Terraform definition

This is an example of the format to create a subnet nsg: 

```json
resource "azurerm_resource_group" "aks_rg" {
  name     = "pre-rg"
  location = "France Central"
  tags     = "pre"
}

resource "azurerm_network_security_group" "aks_nsg" {
  name                = "aks-security-group"
  location            = var.location
  resource_group_name = azurerm_resource_group.aks_rg.name
}

// Referemces to the net nsg and subnet that belongs to 
resource "azurerm_subnet_network_security_group_association"
"aks_nsg_subnet_association" {
  subnet_id                 = azurerm_subnet.aks_subnet.id
  network_security_group_id = azurerm_network_security_group.aks_nsg.id
}
```