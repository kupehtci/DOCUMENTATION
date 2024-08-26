#AKS #VELERO 

### Velero Disaster Recovery

Velero [^1] is a disaster recovery and migration tool that creates under-demand or scheduled backups in order to restore it in another cluster to migrate the cluster[^2] or recover from a disaster. 

### Installation

In order to store Velero backups we need an storage location in order to store blob data. 
To do this en AKS, we can use an Azure Storage Account[^3]

To store this backupds we need to create this Azure storage account and a blob container within it. 


#### Grant permissions

_**Note**: This is only required for (1) by using a Velero-specific service principal with secret-based authentication, (2) by using a Velero-specific service principal with certificate-based authentication and (3) by using Azure AD Workload Identity._

1. Obtain your Azure Account Subscription ID:
    
    ```
    AZURE_SUBSCRIPTION_ID=`az account list --query '[?isDefault].id' -o tsv`
    ```
    
2. Specify the role There are two ways to specify the role: use the built-in role or create a custom one. You can use the Azure built-in role `Contributor`:
    
    ```
    AZURE_ROLE=Contributor
    ```

Here are the minimum required permissions needed by Velero to perform backups, restores, and deletions:

- Storage Account

> Back Compatability and Restic

- Microsoft.Storage/storageAccounts/read
- Microsoft.Storage/storageAccounts/listkeys/action
- Microsoft.Storage/storageAccounts/regeneratekey/action

> AAD Based Auth

- Microsoft.Storage/storageAccounts/read
- Microsoft.Storage/storageAccounts/blobServices/containers/delete
- Microsoft.Storage/storageAccounts/blobServices/containers/read
- Microsoft.Storage/storageAccounts/blobServices/containers/write
- Microsoft.Storage/storageAccounts/blobServices/generateUserDelegationKey/action

> Data Actions for AAD auth

- Microsoft.Storage/storageAccounts/blobServices/containers/blobs/delete
- Microsoft.Storage/storageAccounts/blobServices/containers/blobs/read
- Microsoft.Storage/storageAccounts/blobServices/containers/blobs/write
- Microsoft.Storage/storageAccounts/blobServices/containers/blobs/move/action
- Microsoft.Storage/storageAccounts/blobServices/containers/blobs/add/action
- Disk Management
- Microsoft.Compute/disks/read
- Microsoft.Compute/disks/write
- Microsoft.Compute/disks/endGetAccess/action
- Microsoft.Compute/disks/beginGetAccess/action
- Snapshot Management
- Microsoft.Compute/snapshots/read
- Microsoft.Compute/snapshots/write
- Microsoft.Compute/snapshots/delete
- Microsoft.Compute/disks/beginGetAccess/action
- Microsoft.Compute/disks/endGetAccess/action

Use the following commands to create a custom role which has the minimum required permissions:

```
AZURE_ROLE=Velero
az role definition create --role-definition '{
   "Name": "'$AZURE_ROLE'",
   "Description": "Velero related permissions to perform backups, restores and deletions",
   "Actions": [
	   "Microsoft.Compute/disks/read",
	   "Microsoft.Compute/disks/write",
	   "Microsoft.Compute/disks/endGetAccess/action",
	   "Microsoft.Compute/disks/beginGetAccess/action",
	   "Microsoft.Compute/snapshots/read",
	   "Microsoft.Compute/snapshots/write",
	   "Microsoft.Compute/snapshots/delete",
	   "Microsoft.Storage/storageAccounts/listkeys/action",
	   "Microsoft.Storage/storageAccounts/regeneratekey/action",
	   "Microsoft.Storage/storageAccounts/read",
	   "Microsoft.Storage/storageAccounts/blobServices/containers/delete",
	   "Microsoft.Storage/storageAccounts/blobServices/containers/read",
	   "Microsoft.Storage/storageAccounts/blobServices/containers/write",
	   "Microsoft.Storage/storageAccounts/blobServices/generateUserDelegationKey/action"
   ],
   "DataActions" :[
	 "Microsoft.Storage/storageAccounts/blobServices/containers/blobs/delete",
	 "Microsoft.Storage/storageAccounts/blobServices/containers/blobs/read",
	 "Microsoft.Storage/storageAccounts/blobServices/containers/blobs/write",
	 "Microsoft.Storage/storageAccounts/blobServices/containers/blobs/move/action",
	 "Microsoft.Storage/storageAccounts/blobServices/containers/blobs/add/action"
   ],
   "AssignableScopes": ["/subscriptions/'$AZURE_SUBSCRIPTION_ID'"]
   }'
```


[^1]: [[KUBERNETES - Velero]]
[^2]: Kubernetes cluster [[AKS - Kubernetes cluster]]
[^3]: Azure storage account[[AKS - Storage Account]]