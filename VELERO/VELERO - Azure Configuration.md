#VELERO #AKS 

### Velero Azure

Velero in order to run in Azure provider needs some permissions and resources around it to be able to make the on-demand / scheduled backups and volume snapshots. 

In the case of Azure, it uses a blob container inside an storage account in order to save all the backup related files and the state of the cluster when perform the backup.
It also realizes snapshots of the related managed disks that are used in the AKS[^1] by analyzing the persistent volumes and persistent volume claims within the kubernetes solution. 

This snapshots are placed in the resource group specified, so Velero need to have permissions in order to do the snapshots and a running and accessible storage account with a blob container. 

The following documentation gather all the steps and configurations relative to deploying Velero using terraform helm provider. 
### Velero Azure Configuration

When deploying Velero to a new Azure solution we need to configure certain parameters to have the BackupLocations and SnapshotLocations correctly settled and other initialize parameters correctly: 

We need to set the `subscription_id` and `tenant_id` for setting the volume snapshot locations and backup locations. This need to be set into providers if are not defined yet, in `velero.tf` locals or can be hard-coded within the deployment. 

In the case of not having the resource group resource, get it as data by filling its name. 

This properties need to be configured in the terraform file: 

* BackupStorageLocation Storage account must be the name of the storage account that velero will use to store the backups data. This value can be hard-coded or get it via data resource. 

```hcl
set {
	name  = "configuration.backupStorageLocation[0].config.storageAccount"
	value = data.azurerm_storage_account.storage-account.name
}
```

* Bucket references to the name of the container within the storage account specified in the previous parameter. This value can be hard-coded or get it via data resource. 

```hcl
set {
	name  = "configuration.backupStorageLocation[0].bucket"
	value = data.azurerm_storage_container.velero-container.name
}
```

* backupStorageLocation resource group parameter must be the resource group where the Storage account is placed. 

```hcl
set {
    name  = "configuration.backupStorageLocation[0].config.resourceGroup"
    value = data.azurerm_resource_group.rg.name
  }
```

* volumeSnapshotLocation resource group parameter mus tbe the resource group where velero will place the volume snapshots of the managed disks of the AKS. Can be the same resource group as the storage account. 

```hcl
set {
    name  = "configuration.volumeSnapshotLocation[0].config.resourceGroup"
    value = data.azurerm_resource_group.rg.name
  }
```

* The volume snapshot location requires the subscription ID specified in order to get the resource group defined previously. Assign the same subscription ID as the assigned in the providers via hard-coded, local variable or input variable. 

```hcl
set {
    name  = "configuration.volumeSnapshotLocation[0].config.subscriptionId"
    value = local.subscription_id
  }
```

* The credentials secretContent Cloud parameter can be inputed via file or hard-coded at it is in this terraform. All the configuration parameters depend on the provider, so various need to be set: 
	* AZURE_SUBSCRIPTION_ID: is the subscription ID, same as specifyed earlier. Set it with same value as the specified in the providers section
	* AZURE_TENANT_ID: tenant ID. Set it with same value as the specified in the providers section
	* AZURE_RESOURCE_GROUP: resource group of the AKS resources. Need to be the MC_*** generated one, no the one specified earlier. 
	* AZURE_CLIENT_ID: Service principal or Managed identity ID for velero to be able to authenticate and have permissions over the resources it needs. 
	* AZURE_CLIENT_SECRET: Service principal or managed identity for velero. 
	* AZURE_CLOUD_NAME: Cloud can be set to `AzurePublicCloud`, `AzureUSGovernmentCloud`, `AzureChinaCloud`. But in normal cases. need to be set to `AzurePublicCloud`. 
```hcl
set {
    name  = "credentials.secretContents.cloud"
    value = <<EOF
      AZURE_SUBSCRIPTION_ID=${local.subscription_id}
      AZURE_TENANT_ID=${local.tenant_id}
      AZURE_RESOURCE_GROUP=${data.azurerm_resource_group.mc_rg_aks.name}
      AZURE_CLIENT_ID=${azuread_service_principal.velero_sp.client_id}
      AZURE_CLIENT_SECRET=${azuread_service_principal_password.velero_sp_pass.value} 
      AZURE_CLOUD_NAME=AzurePublicCloud
      EOF
  }
```

### Add more backup storage locations

More Backup Storage locations can be added to Velero, but it will use the first one by default. 

In order to add more backup storage locations via terraform helm provider can be set in the configuration `values-velero.yaml` file as: 

```
backupStorageLocation:
  - name:  default
    provider: "azure"
    bucket: "velero-blob-container"           # Setted by Terraform         
    accessMode: ReadWrite
    config:
      # Configured to store backups in a blob container inside an Storage Account
      resourceGroup:  azure-boilerplate-aks   # Setted by Terraform 
      storageAccount: "boilerplatehiberussa"  # Setted by Terraform
       
	# Add another backup storage location with different name
  - name:  backup1
  provider: "azure"
  bucket: "velero-blob-container2"            
  accessMode: ReadWrite
  config:
    # Configured to store backups in a blob container inside an Storage Account
    resourceGroup:  azure-boilerplate-aks
    storageAccount: "boilerplatehiberussa"
```

And for setting the parameters of another backup storage locations from the terraform, its values can be accessed with the proper array index: 

Example, access the second backup storage location: 

```hcl
set {
	name  = "configuration.backupStorageLocation[0].config.storageAccount"
	value = "defaultstorageaccount"
}
set {
	name  = "configuration.backupStorageLocation[1].bucket"
	value = "velero-container-2"
}
```

This same procedure can be used to define more Volume snapshots locations. 

### Velero AKS authentication

In order to allow velero to have permissions over the Azure Infrastructure in order to access the storage to make the backups and make changes over the Kubernetes cluster[^1]

There are different ways to authenticate and grant permissions to velero for this: 

* Velero specific Service Principal with secret based authentication
* Velero specific Service principal with certified based authentication 
* Azure AD workload identity
* Storage Account Access Key

In the case of using terraform, the best way is to create a Service Principal with Blob storage and Storage account key operator[^2] permissions and grant the access to Velero by giving it <span style="color:DodgerBlue;">the Service Principal secret key access</span>. 

Also needs permissions for disk backups operator level and snapshot contributor in order to be able to create, modify and delete volume snapshots. 

The required permissions in Azure RBAC format are: 

Back Compatability and Restic
* Microsoft.Storage/storageAccounts/read
* Microsoft.Storage/storageAccounts/listkeys/action
* Microsoft.Storage/storageAccounts/regeneratekey/action
AAD Based Auth
* Microsoft.Storage/storageAccounts/read
* Microsoft.Storage/storageAccounts/blobServices/containers/delete
* Microsoft.Storage/storageAccounts/blobServices/containers/read
* Microsoft.Storage/storageAccounts/blobServices/containers/write
* Microsoft.Storage/storageAccounts/blobServices/generateUserDelegationKey/action
Data Actions for AAD auth
* Microsoft.Storage/storageAccounts/blobServices/containers/blobs/delete
* Microsoft.Storage/storageAccounts/blobServices/containers/blobs/read
* Microsoft.Storage/storageAccounts/blobServices/containers/blobs/write
* Microsoft.Storage/storageAccounts/blobServices/containers/blobs/move/action
* Microsoft.Storage/storageAccounts/blobServices/containers/blobs/add/action
Disk Management
* Microsoft.Compute/disks/read
* Microsoft.Compute/disks/write
* Microsoft.Compute/disks/endGetAccess/action
* Microsoft.Compute/disks/beginGetAccess/action
* Snapshot Management
* Microsoft.Compute/snapshots/read
* Microsoft.Compute/snapshots/write
* Microsoft.Compute/snapshots/delete
* Microsoft.Compute/disks/beginGetAccess/action
* Microsoft.Compute/disks/endGetAccess/action

In this case, for azure, all the permissions are granted through built-in roles added to the Service Principal that is next assigned to velero by specifying its id and secret in the `credentials.secretContents.cloud`. 

```hcl
# Create Storage account or get its data
data "azurerm_storage_account" "storage-account" {
  name                = "boilerplatehiberussa"
  resource_group_name = "azure-boilerplate-aks"
}
# Create Storage account Container or get its data
data "azurerm_storage_container" "velero-container" {
  name                 = "velero-blob-container"
  storage_account_name = data.azurerm_storage_account.storage-account.name
}
# Get client config 
data "azurerm_client_config" "current" {
}

# Grant roles to the SP 
# Roles to have access to Storage Account and its blob container
resource "azurerm_role_assignment" "velero_storage_blob_contributor" {
  role_definition_name = "Storage Blob Data Contributor"
  principal_id         = azuread_service_principal.velero_sp.object_id
  scope                = data.azurerm_storage_account.storage-account.id
}

resource "azurerm_role_assignment" "velero_storage_account_key_operator" {
  principal_id         = azuread_service_principal.velero_sp.id
  role_definition_name = "Storage Account Key Operator Service Role"
  scope                = data.azurerm_storage_account.storage-account.id
}

# Role to let velero have access to empty started disks and download / upload data
resource "azurerm_role_assignment" "velero_disk_contributor_mc" {
  principal_id         = azuread_service_principal.velero_sp.object_id
  role_definition_name = "Data Operator for Managed Disks"
  scope                = data.azurerm_resource_group.mc_rg_aks.id
}
resource "azurerm_role_assignment" "velero_disk_contributor" {
  principal_id         = azuread_service_principal.velero_sp.object_id
  role_definition_name = "Data Operator for Managed Disks"
  scope                = data.azurerm_resource_group.rg.id
}

# Role to let velero have access to backups listing
resource "azurerm_role_assignment" "velero_disk_backup_reader_mc" {
  principal_id         = azuread_service_principal.velero_sp.object_id
  role_definition_name = "Disk Backup Reader"
  scope                = data.azurerm_resource_group.mc_rg_aks.id
}
resource "azurerm_role_assignment" "velero_disk_backup_reader" {
  principal_id         = azuread_service_principal.velero_sp.object_id
  role_definition_name = "Disk Backup Reader"
  scope                = data.azurerm_resource_group.rg.id
}

#Role to let velero perform disk restoring operations from snapshots
resource "azurerm_role_assignment" "velero_disk_backup_operator_mc" {
  principal_id         = azuread_service_principal.velero_sp.object_id
  role_definition_name = "Disk Restore Operator"
  scope                = data.azurerm_resource_group.mc_rg_aks.id
}
resource "azurerm_role_assignment" "velero_disk_backup_operator" {
  principal_id         = azuread_service_principal.velero_sp.object_id
  role_definition_name = "Disk Restore Operator"
  scope                = data.azurerm_resource_group.rg.id
}

#Role to let velero perform disk snapshot write operations
resource "azurerm_role_assignment" "velero_disk_snapshot_contributor_mc" {
  principal_id         = azuread_service_principal.velero_sp.object_id
  role_definition_name = "Disk Snapshot Contributor"
  scope                = data.azurerm_resource_group.mc_rg_aks.id
}
resource "azurerm_role_assignment" "velero_disk_snapshot_contributor" {
  principal_id         = azuread_service_principal.velero_sp.object_id
  role_definition_name = "Disk Snapshot Contributor"
  scope                = data.azurerm_resource_group.rg.id
}

# Service principal to assign to velero
resource "azuread_service_principal" "velero_sp" {
  client_id = azuread_application.app.client_id
  owners    = [data.azurerm_client_config.current.object_id]
}

resource "azuread_service_principal_password" "velero_sp_pass" {
  service_principal_id = azuread_service_principal.velero_sp.object_id
}

```

### Define schedules

Velero backups can be made on-demand or scheduled at certain time spans. 
This schedules can be set using velero cli, once it has been installed or let it pre-configured in the deploy. 

To define schedules, set them following this format in the `values-velero.yaml` file:

```hcl
schedules:
  <name-of-backup>:
    disabled: false
    labels:
      myenv: foo
    annotations:
      myenv: foo
    schedule: "0 0 * * *"
    useOwnerReferencesInBackup: false
    paused: false
    template:
      ttl: "240h"
      storageLocation: <name-of-backup-storage-location
      includedNamespaces:
      - <mongodb-namespace-example>
```


[^1]: Kubernetes cluster [[AKS - Kubernetes cluster]]
[^2]: Azure Storage account [[AKS - Storage Account]] 