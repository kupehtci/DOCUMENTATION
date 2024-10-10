#AZURE #AKS 

# AZURE BOILERPLATE - AKS

The Azure infrastructure is deployed using terraform `azurerm` and `azuread` providers. 
In order to deploy this infrastructure, some pre-requisites need to be meet: 

* Terraform cli installed
* Azure cli installed
* Azure account or managed identity with permissions to create all kind of resources and grant permissions to them. (Owner recommended)

### 1. Provider settings

This terraform solution uses two main providers: `azurerm` and `azuread`. 

Both, `azurerm` and `azuread` require the Azure CLI installed and permissions to modify resources and grant permissions. 

In order to configure the providers we have various forms: 

1. By using Azure login before using terraform, you only need to provide terraform the subscription ID and tenant ID in case that the account used to login has more than one tenant or one subscription. 

```hcl
provider "azurerm" {
  subscription_id = var.subscription_id
  tenant_id       = var.tenant_id

  storage_use_azuread = true 
  features {}
}

provider "azuread" {
  tenant_id = var.tenant_id
}
```

2. In case of using a Service Principal with the subscription scope, configure: 
```hcl
provider "azurerm" {
  features {}
  subscription_id = "subscription_id"
  client_id       = "client_id"
  client_secret   = "client_secret"
  tenant_id       = "tenant_id"
}

provider "azuread" {
  tenant_id       = "tenant_id"
  client_id       = "client_id"
  client_secret   = "client_secret"
}

```

3. In case of give credentials using a Managed Identity: 

```hcl
provider "azurerm" {
  features {}

  use_msi = true
  subscription_id = "subcription_id"
}
provider "azuread" {
  use_msi = true
}
```

### 2. AKS Settings

The AKS is configured by default to have a basic structure compatible to many cases of use. 
This are the different configurations that can be done: 

* `Autoscaling`
**Autoscaling** can be easily configured from `terraform.tfvars` by enabling it and set a maximum and minimum amount of nodes. 

```list
node_pool_enable_auto_scaling = true
node_pool_scaler_min_count = 1
node_pool_scaler_max_count = 2
node_pool_max_pods = 50
```

Always check the `aks_vm_size` and if it can handle the autoscaling settled parameters. 

* `Subnet`

The AKS is within its subnet where all the resources related to it belongs. In case of changing this to another subnet, some communication errors can occur. To change the subnet, configure the subnet id to other one created: 
```hcl
vnet_subnet_id = azurerm_subnet.assigned_subnet.id
```

*  `Microsoft defender`
To enable **microsoft defender** and push its logs into log analytics workspace, you can uncomment this block in the AKS: 

```hcl
microsoft_defender{
  log_analytics_workspace_id = azurerm_log_analytics_workspace.laworkspace.id
}
```

* `identity`

The managed identity is assigned by the System by default. In case of use Service Principal to give roles and permissions, you can uncomment the service principal block and let the identity to Manually assigned: 

```hcl
# identity{
# ... 
# }

service_principal {
    client_id = "client_id"
    client_secret = "client_secret"
}
```

Or in case that you want to manually assign a Managed Identity to the AKS cluster, you can uncomment this block and leave commented service_principal and the other identity block in order to use the managed identity declared in the same file: 

```hcl
resource "azurerm_user_assigned_identity" "aks_identity"{
  location            = var.location
  name                = "${var.environment}-aks-assigned-identity"
  resource_group_name = azurerm_resource_group.azure-boilerplate-aks.name
}

resource "azurerm_kubernetes_cluster" "aks"{
# ...
  identity {
    type         = "UserAssigned"
    identity_ids = [azurerm_user_assigned_identity.aks_identity.id]
  }
# ...
}
```

In case of use **User assigned identity**, the `principal_id` that ACR Custom role is pointing to must be changed to the `principal_id` of the `azurerm_user_assigned_identity`: 

By default, **metrics collection of the AKS** is enabled and pushed into the Main log analytics workspace. To disable this, comment this block: 

```hcl
oms_agent {
    log_analytics_workspace_id = azurerm_log_analytics_workspace.laworkspace[0].id
    msi_auth_for_monitoring_enabled = false
  }
```


### 3. Networking

#### 3.1. Virtual Network

The network configuration within this solution consist in a Virtual network with two different subnets and their associated Network Security groups. 

The association to the Network Security Groups is made to configure network rules to restrict / allow certain traffic to the different internal subnets.

It has 2 different default subnets within the main virtual network: 

* `aks_subnet`: the subnet for the AKS and the resources around it. In case of adding more resources to the infrastructure assign them this subnet or create a new one. 
* `atlantis_subnet`: the subnet for the Atlantis ACI and the resources that belong to it. 

#### 3.2. Network Security Rules

Each one of this subnets is associated with one Network Security Group that hold the different rules that control the inbound and outbound traffic. 

Only the default rules are created to allow HTTP and HTTPs traffic to the AKS subnet and allow connections to Atlantis subnet on HTTP (80) port and TCP 4141 used by Atlantis for webhooks listening.  

Follow this format to define more network rules and assign them to the belonging network security group of the appropriate subnet and resource group in case of have create more resource groups: 

```hcl
resource "azurerm_network_security_rule" "example" {
  name                        = "<name>"
  description                 = "<description>"
  priority                    = 100
  direction                   = "Inbound" | "Outbound"
  access                      = "Allow" | "Deny"
  protocol                    = "Tcp" | "Udp" | "Icmp" | "Esp" | "Ah" | "*"
  source_port_range           = "*"
  destination_port_range      = "*"
  source_address_prefix       = "*"
  destination_address_prefix  = "*"
  resource_group_name         = azurerm_resource_group.rg.name 
  network_security_group_name = azurerm_network_security_group.aks_nsg.name
}
```

#### 3.3. DNS Zone

By default is disabled, but the infrastructure has a DNS zone to hold DNS record of the resources that belong to that domain. 
In order to deploy this DNS zone, enable `has_resource_dns_zone` in the `terraform.tfvars` and include the records. 

For creating record in this DNS zone, follow this format: 

```hcl
resource "azurerm_dns_a_record" "example" {
  name                = "<record-name>"
  zone_name           = azurerm_dns_zone.dns_zone[0].name
  resource_group_name = azurerm_resource_group.rg.name
  ttl                 = 300
  records             = ["XXX.XXX.XXX.XXX"]

  count = var.has_resource_dns_zone == true ? 1 : 0
}
```

Take into account that this will register the DNS record within Azure DNS registry, but its recommended to register the non-authoritative Azure DNS registry as a CNAME in the Domain provider. 
To do this, configure the `soa_record` within the DNS Zone configuring `dns_zone_soa_record_email` and `dns_zone_soa_record_hostname`.


#### 3.4. Public IP

A public IP resource can be deployed into the network configuration. By default is disabled because NGINX load balancer controller deploys and manages its own public IP. 




### 4. Storage account

Storage account gives the infrastructure a managed storage resource for different data objects. 

The account is set by default to be optimized for holding a file share and a blob container with local replication. Its parameters can be changed in `terraform.tfvars`

If the storage account is set to private by setting: 
some network rules can be set within the resource group to restrict or allow the traffic from different IPs to the Storage account. To do this, uncomment the network rules and configure it: 

```hcl
resource "azurerm_storage_account_network_rules" "example" {
  storage_account_id = azurerm_storage_account.storage-account.id

  default_action             = "Allow" | "Deny"
  ip_rules                   = ["XXX.XXX.XXX.XXX"]
  virtual_network_subnet_ids = [azurerm_subnet.aks_subnet.id]
  bypass                     = ["AzureServices", "Metrics"] or ["None"]
}
```

For this rules, set the IPs that has access to it or set the access to a certain subnets. If `default_action` is set to "Deny", you can deny access to certain subnets. 

By default, two main containers are created within the storage account: 

* `velero blob container`

Velero needs a blob container in order to store the backups within an Azure Infrastructure. If velero is not going to be implemented, this blob container can be safely deleted. 

In case of using this Storage Account's container don't change its name or if changed, set the same name in the Velero deployment configuration. Velero uses its name to point to the correct storage account 

To create more containers within the Storage Account follow this template: 

```hcl
resource "azurerm_storage_container" "blob-container"{
  name                  = "<container-name>"
  storage_account_name  = azurerm_storage_account.storage-account.name
  container_access_type = "blob"

  depends_on = [azurerm_storage_account.storage-account]
}
```


* `atlantis file share`

Atlantis require a file share in order to use it to store `tfstate` files and other cache items of the project when doing the plans and terraform deploys. 
If Atlantis is not deployed by setting `deploy_atlantis = false`, this file share is also not deployed.  
### . Azure Key Vault

An azure Key vault and an access policy is created for storing, protect and manage secrets, keys and certificates. 

Take into account that `purge_protection_enabled` is enabled to once its deployed, it cannot be hard deleted, only scheduled for deletion in 90 days. 

The access is limited though an key vault access policy that contains the following modificable permissions: 

* certificate permissions
* key permissions
* secret permissions
* storage permissions

All of them can be modified by specifying a map in the `terraform.tfvars` file in order to restrict or allow the different access from the main resource group to this resource. 
By default is limited to \["Get", "List"\] or only \["Get"\]. 

### . Azure Container registry

This resource create a container registry that will be used by the Atlantis deployment, which depends on a custom image in order to run. 

This ACR allows you to store and manage Docker container images, and it is integrated with other Azure services, such as Azure Kubernetes Service (AKS).

In case that the Azure Container Registry is not needed in the project, the file or code can be easily commented / deleted and store the image in another docker image repository and configure it in the Atlantis Deployment. 

At `terraform apply` it will output the ACR login server, login username and password in order to be able to push / pull the images to the Container Registry. 

If username / password are not showed you can retrieve them with the following commands: 

```bash
# make sure the admin is correcly enabled
az acr show --name <acr-name> --query "adminUserEnabled"

# Retrieve the username
az acr credential show --name <acr-name> --query "username" --output tsv

# Retrieve first password for the admin user
az acr credential show --name <acr-name> --query "passwords[0].value" --output tsv
```

You can then use this credentials to login using docker and then push the correct images: 

```bash
docker login <acr-name>.azurecr.io -u <admin-username> -p <admin-password>
```

### . Configure Atlantis

The remote repository configuration will depend on the git repository provider used. In this case, if using Gitlab Enterprise as an standard, this are the steps to follow to configure the webhooks for atlantis: 

* Navigate to the project repository home page. 
- Click **Settings > Webhooks** in the sidebar
- set **URL** to `http://$ATLANTIS_URL:4141/events` (or `https://$ATLANTUS_URL/events` if using SSL) with `$ATLANTIS_URL`the url of the Atlantis ACI FQDN. 
- set the **Secret Token** of the Webhook Secret. 
- The following checkboxes must be marked: 
    - **Push events**
    - **Comments**
    - **Merge Request events**
- leave **Enable SSL verification** checked
- click **Add webhook**

Once you have correctly configure the Atlantis webhook, you can click test in order to check if a 200: OK is received. 
### Manage the AKS

In order to manage the AKS Cluster created in this infrastructure, you can retrieve the kubeconfig file in 2 different ways:

`az aks-getcredentials --resource-group <rg-name> --name <aks-name>`

