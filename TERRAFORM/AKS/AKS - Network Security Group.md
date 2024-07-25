#AKS #TERRAFORM #NETWORKING 

# AKS network security group

Manages a network security group that contains a list network security rules. 
This groups enable inbound or outbound traffic to be enabled or denied. 


In order to use this group, the set of rules that apply to it, need to be defined afterwards [[AKS - Network Security Rule]]. 

This is the format to create the `azurerm_network_security_group` resource: 

```json
resource "azurerm_network_security_group" "aks_main_nsg" {
  name                = "aks-main-security-group"
  location            = "France Central"
  resource_group_name = azurerm_resource_group.main_rg.name
}
```

##### Take into account

If the network security group and its rules are going to be applied into a subnet, add a `azurerm_subnet_network_security_group_association` item that associate both together

```hcl
resource "azurerm_subnet_network_security_group_association" "example" {
  subnet_id                 = azurerm_subnet.example.id
  network_security_group_id = azurerm_network_security_group.example.id
}
```