#VELERO 

# VELERO Troubleshooting

If you get the logs InitContainer that are deployed when deploying velero app, you can get some warning or even errors if the pods are restarting itselfs because of some errors in the configuration: 


### Snapshot Azure error `ResourceNotFound`

```txt
# Log 
level=error msg="Cluster resource restore error: error executing PVAction for persistentvolumes/pvc-bdbaf91d-0223-42e0-ae9b-271ed33f3c90: rpc error: code = Unknown desc = compute.SnapshotsClient#Get: Failure responding to request: StatusCode=404 -- Original Error: autorest/azure: Service returned an error. Status=404 Code=\"ResourceNotFound\" Message=\"The Resource 'Microsoft.Compute/snapshots/pvc-XXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX' under resource group 'MC_....' was not found. For more details please go to https://aka.ms/ARMResourceNotFoundFix\"" logSource="pkg/controller/restore_controller.go:587" restore=velero/<backupname>-20240820135036
```

This error is caused because when making a backup, searches the persistent volume claims within the cluster, lists the persistent volumes and queue for making snapshots of them. 
In this case, the storage resource group defined in the configuration is set to the wrong resource group. 

Check that: 

```yaml
  set {
    name  = "configuration.volumeSnapshotLocation[0].config.resourceGroup"
    value = "${data.azurerm_resource_group.rg.name}" 
  }
```

```yaml
  set {
    name  = "credentials.secretContents.cloud"
    value = <<EOF
      AZURE_SUBSCRIPTION_ID=XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX
      AZURE_TENANT_ID=XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX
      AZURE_RESOURCE_GROUP=${data.azurerm_resource_group.mc_rg_aks.name}
      AZURE_CLIENT_ID=${azuread_service_principal.velero_sp.client_id}
AZURE_CLIENT_SECRET=${azuread_service_principal_password.velero_sp_pass.value} 
      AZURE_CLOUD_NAME=AzurePublicCloud
      EOF
  }
```

* The `volumeSnapshotLocation` resource group is set to the one that holds the entire AKS and other resources of the infrastructure that doesn't belong to the AKS. 
* Within `credentials.secretContents.cloud` the resource group specified is the `MC_` one that holds the AKS resources

