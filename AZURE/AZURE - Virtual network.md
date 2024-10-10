#AKS #TERRAFORM #NETWORKING

# AZURE Virtual Network

An Azure virtual network is an essential block for a private network that allows a resource (VMs) or a resource group to be able to communicate with others or over the internet.

Allow: 
* Communication Azure resources --> Internet
* Communication Azure resources <--> Azure resources
* Communication with on-premise resources (Point-to-site VPN, site-to-site or Azure express route ) 
* Filtering network traffic   (Network security groups)[^1]
* Routing network traffic    (Route tables and border gateway protocol routes)
* Integration with azure services
### Create a virtual network

In azure with terraform you can create a virtual network \[`"azurerm_virtual_network"`\] for a resource group: 

```yaml
resource "azurerm_resource_group" "example" {
  name     = "example-resources"
  location = "West Europe"
}

resource "azurerm_virtual_network" "example" {
  name                = "example-network"
  #assign virtual network to a resource group
  resource_group_name = azurerm_resource_group.example.name
  location            = azurerm_resource_group.example.location
  address_space       = ["10.0.0.0/16"]
}
```

[^1]: Network Security Groups [[AZURE - Network Security Group]]