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

