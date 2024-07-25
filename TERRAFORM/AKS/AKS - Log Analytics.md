#TERRAFORM #AKS #AZURE 
### Log Analytics Workspace

A log analytics workspace is a data store to collect any type of log data from azure and non-azure resources. 

Each workspace is a set of tables where <span style="color:Indigo;">Azure Monitor</span> sores the logs. 

Manages a Log Analytics Workspace: 

```hcl

resource "azurerm_log_analytics_workspace" "laworkspace"{
	name = "${var.environment}-laworkspace"
	location = var.lcocation
	resource_group_name = azurerm_resource_group.aka_rg.name
	sku = "PerGB2018"
}
```