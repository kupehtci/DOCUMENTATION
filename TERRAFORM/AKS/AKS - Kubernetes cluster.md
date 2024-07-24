#TERRAFORM #AZURE #AKS

### Azure Terraform - Kubernetes cluster

Manages a managed kubernetes cluster also known as <span style="color:orange;">AKS</span>. 

Format: 

```json
resource "azurerm_resource_group" "example" {
  name     = "example-resources"
  location = "West Europe"
}

resource "azurerm_kubernetes_cluster" "example" {
  name                = "example-aks1"
  location            = azurerm_resource_group.example.location
  resource_group_name = azurerm_resource_group.example.name
  dns_prefix          = "exampleaks1"
  azure_policy_enabled              = true
  role_based_access_control_enabled = true
  kubernetes_version                = "xxx"

  lifecycle{} 
  service_principal{}
  
  storage_profile{
	file_driver_enabled = true 
	blob_driver_enabled = true 
	disk_driver_enabled = true
  }

  default_node_pool {
    name       = "default"
    node_count = 1
    vm_size    = "Standard_D2_v2"
  }

  identity {
    type = "SystemAssigned"
  }

  tags = {
    Environment = "Production"
  }
}
```

* `resource_group_name`: assigns a resource group where the Kubernetes Cluster should exist. 
* `oidc_issuer_enabled`: You can use OIDC to enable single sign-on (SSO) between OAuth-enabled applications on your Azure Kubernetes Service (AKS). 
* `workload_identity_enabled`: specify whether Azure AD workload Identity should be enabled for the cluster. 
* `role_based_access_control_enabled`: if Role Based Access Control for this Kubernetes Cluster should be enabled. Default = true. 
* `azure_policy_enabled` if the Azure Policy Add-On should be enabled. 
* `dns_prefix`:  Used to generate a FQDN when the cluster is created. 
* `kubernetes_version`: 
* `automatic_channel_upgrade`:  If set to other option than none, azure will auto-update the cluster. Default = none
* `private_cluster_enabled`:
* `node_resource_group`: 
* `sku_tier`:  ("Free" | "Standard"), Don't use "Free" in production
* 

#### Network Profile

If its not set, `kubenet` will be used as default. 

Its set as a block that can define: 

* `network_plugin`: plugin used for networking (azure, kubenet or none)
* `network_mode`: network mode to use with Azure CNI. Can be `bridge` or `transparent`. 
* `network_policy`: allows to control the <span style="color:grey;">pods' traffic control</span> (`calico` or `azure`). 
* `dns_service_ip`: IP address within the Kubernetes CIDR [[AKS - Virtual network]] that will be used for cluster service discovery (<span style="color:LightSeaGreen;">kube-dns</span>)
* `docker_bridge_cidr`: IP address in CIDR used as docker bridge IP address in nodes. 
* `outbound_type`: outbound routing method. Can be `loadBalancer`, `userDefinedRouting`, `managedNATGateway` and `userAssignedNATGateway`. Defaults to `loadBalancer`.
* `pod_cidr`: The CIDR to use for Pod IP Addresses. Only when network_plugin == kubenet. 
* `service_cidr`: The network range in CIDR format for Kubernetes service. 
#### Default node pool

In azure, nodes of the same configuration are grouped in <span style="color:MediumSlateBlue;">node pools</span>. 
This pools contains the existing VMs.

When created, the initial number of nodes and their size (SKU) need to be defined. 

In terraform, it needs to define: 

* `name`:  name for the kubernetes node pool
* `type`: Type of the node pool. (`AvailabilitySet` or `VirtualMachineScaleSets`(Default))
* `vm_size`: size of the virtual machine like `Standard_DS2_v2`. 
* `enable_auto_scaling`: if the Kubernetes Auto Scaler should be enabled for this node pool. 
	* `min_count`: minimum count of nodes
	* `max_count`: maximum count of nodes
	* `node_count`: initial number of nodes that should exist in this node pool. Must be between `min_count` and `max_count`.  
* `max_pods`: maximum number of pods that can run on each agent. 
* `orchestrator_version`: version of the kubernetes used for the agents. 
* `vnet_subnet_id`: the id of a subnet where the kubernetes node pool should exist. 
* `node_labels`: the labels to assign to each node that is created. Declare it as an array of key-value pairs. 

Example of a common `default_node_pool`: 
```json
default_node_pool {
    name                 = "generic"
    min_count            = 1
    max_count            = 50
    max_pods             = 70
    vm_size              = "Standard_DS2_v2"
    enable_auto_scaling  = true
    orchestrator_version = var.kubernetes_version
    
    upgrade_settings {
      max_surge = "10%"
    }

    node_labels = {
      app = "generic"
    }
    vnet_subnet_id = azurerm_subnet.aks_subnet.id
  }
```

The Cluster Node Pool can also be defined outside the Kubernetes Cluster, as another resource in Terraform and reference it using the element ID. 

Extra elements: 
* `node_taints`: a list of kubernetes taints which should be applied to nodes in the agent pool. e.g. \[key=value:NoSchedule\]. 

#### Upgrade settings

The `upgrade_settings` block must define the parameter for an scaling. 

* `drain_timeout_in_minutes`: time in minutes to wait on eviction and termination per node. If this time is exceeded, the upgrade fails
* `node_soak_duration_in_minutes`: The amount of time to wait after draining a node and moving into next one. Default = 0. 
* `max_surge`: the maximum number or percentage of nodes which will be added to the Node Pool Size during an upgrade. 



#### Storage profile

An `storage_profile` block is used to allow or forbid different persistent storage types.

A storage_profile block supports the following:

* `blob_driver_enabled` - (Optional) Is the Blob CSI driver enabled? Defaults to false.
* `disk_driver_enabled` - (Optional) Is the Disk CSI driver enabled? Defaults to true.
* `disk_driver_version` - (Optional) Disk CSI Driver version to be used. Possible values are v1 and v2. Defaults to v1.
* `file_driver_enabled` - (Optional) Is the File CSI driver enabled? Defaults to true.
* `snapshot_controller_enabled` - (Optional) Is the Snapshot Controller enabled? Defaults to true.