#VELERO #AKS 

### Velero AKS authentication

In order to allow velero to have permissions over the Azure Infrastructure in order to access the storage to make the backups and make changes over the Kubernetes cluster[^1]

There are different ways to authenticate and grant permissions to velero for this: 

* Velero specific Service Principal with secret based authentication
* Velero specific Service principal with certified based authentication 
* Azure AD workload identity
* Storage Account Access Key

In the case of using terraform, the best way is to create a <span style="color:orange;">Service Principal with Blob storage and Storage account key operator</span>[^2] permissions and grant the access to Velero by giving it <span style="color:DodgerBlue;">the Service Principal secret key access</span>. 

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

resource "azuread_application" "app" {
  display_name = "apps"
  owners       = [data.azurerm_client_config.current.object_id]
}

resource "azuread_service_principal" "velero_sp" {
  client_id = azuread_application.app.client_id
  owners    = [data.azurerm_client_config.current.object_id]
}

resource "azuread_service_principal_password" "velero_sp_pass" {
  service_principal_id = azuread_service_principal.velero_sp.object_id
}

resource "helm_release" "velero" {
  name = "velero"

  chart      = "velero"
  repository = "https://vmware-tanzu.github.io/helm-charts"
  version    = "7.0.0" # Check version to deploy 

  namespace        = "velero"
  create_namespace = true

# Set the credentials files
  set {
    name  = "credentials.secretContents.cloud"
    value = <<EOF
      AZURE_SUBSCRIPTION_ID=XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX
      AZURE_TENANT_ID=XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX
      AZURE_RESOURCE_GROUP=<resource-group>
      AZURE_CLIENT_ID=${azuread_service_principal.velero_sp.client_id}		      AZURE_CLIENT_SECRET=${azuread_service_principal_password.velero_sp_pass.value} 
      AZURE_CLOUD_NAME=AzurePublicCloud
      EOF
  }
  
# .... Other SET Values
}
```


[^1]: Kubernetes cluster [[AKS - Kubernetes cluster]]
[^2]: Azure Storage account [[AKS - Storage Account]] 