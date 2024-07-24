#AKS #TERRAFORM #NETWORKING 

# Network Security Rule

This network security rules are rules that allow or deny the inbound or outbound traffic.

The rules need to be assigned to a <span style="color:orange;">Network Security Group</span> in order to manage the group of resources to which this rules apply. 

#### Definition

This rules can be defined inside the `azurerm_network_security_group` in a `security_rule` block or in separated `azurerm_network_security_rule` and link them with the group by the parameter `network_security_group_name`. 

Take into account that using in-line security rules and block ones can cause conflicts and overwrite some rules.  

To define it using <span style="color:grey;">in-line format</span> within the network security group declaration:  

```json
resource "azurerm_network_security_group" "aks_main_nsg"{
	name = "aks_main_resource_group"
	location = "France Central"
	resource_group_name = azurerm_resource_group.main_rg.name

	// in this block, the rule is defined
	security_rule {
	    name                       = "test123"
	    priority                   = 100
	    direction                  = "Inbound"
	    access                     = "Allow"
	    protocol                   = "Tcp"
	    source_port_range          = "*"
	    destination_port_range     = "*"
	    source_address_prefix      = "*"
	    destination_address_prefix = "*"
  }
}
```

To define it in <span style="color:grey;">resource block</span> format: 

```json
resource "azurerm_network_security_group" "aks_main_nsg" {
  name                = "aks-main-security-group"
  location            = "France Central"
  resource_group_name = azurerm_resource_group.main_rg.name
}

resource "azurerm_resource_group" "aks_rg"{
	name = "${var.enviroment}-resource-group"
	location = var.location
	
}

resource "azurerm_network_security_rule" "allow_inbound_traffic"{
	name = "allow_inbound_traffic"
	description = "Allow the inbound traffic HTTPS"
	name                        = "test123"
	priority                    = 100
	direction                   = "Outbound"
	access                      = "Allow"
	protocol                    = "Tcp"
	source_port_range           = "*"
	destination_port_range      = "*"
	source_address_prefix       = "*"
	destination_address_prefix  = "*"
	resource_group_name         = azurerm_resource_group.aks_main_nsg.name
	network_security_group_name = azurerm_network_security_group.aks_main_nsg.name
}
```

The configuration parameters for the Network security rule are: 
* `name`: name that identifies the resource
* `description`: description of the resource
* `priority`: the priority of the rule that can be $\in [100, 4096]$. 
* `direction`: if the rule is evaluated on incoming or outgoing traffic. (`Inbound` or `Outbound`)
* `access`: Specify if this rule `Allow` or `Deny` the specified traffic. 
* `protocol`: network protocol that this rule applied to. 
* `source_port_range`:  source port or range that this rule apply to $\in [100, 65535]$.  
* `destination_port_range`: destination port or range that this rule apply to $\in [100, 65535]$.
* `source_address_prefix`:  CIDR or source IP range or `*` to match the IPs that this rule apply to. 
* `destination_address_prefix`: CIDR or destination IP range or `*` to match any IPs that this rule apply to. 



This is the empty template for fulfill the security rules: 

```
resource "azurerm_network_security_rule" "name"{
	name                        = ""
	description                 = ""
	priority                    = 100
	direction                   = "Outbound" | "Inbound"
	access                      = "Allow" | "Deny"
	protocol                    = "Tcp" 
	source_port_range           = "*"
	destination_port_range      = "*"
	source_address_prefix       = "*"
	destination_address_prefix  = "*"
	resource_group_name         = azurerm_resource_group.resource_name.name
	network_security_group_name = azurerm_network_security_group.resource_name.name
}
```