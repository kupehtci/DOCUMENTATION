#VELERO #KUBERNETES 

### VELERO - BackupStorageLocation

A BackupStorageLocation is the Kubernetes[^k] CRD resource used by velero in order to represent a location for storing backups. 

Velero must have at least one BackupStorageLocation. 

BackupStorageLocation manifests not need to be defined manually, they are deployed through Helm deployment when installing Velero charts. 

Velero uses this storage location also to store data about the snapshots related to each backup and how are they stored. When velero is re-deployed, it access the BackupStorageLocations and retrieve the different backups detailed there in order to restore all Cluster resources.   
#### EXAMPLE

As example, a BackupStorageLocation in AKS has the following manifest format: 

```yaml
apiVersion: velero.io/v1
kind: BackupStorageLocation
metadata:
  annotations:
    meta.helm.sh/release-name: velero
    meta.helm.sh/release-namespace: velero
  creationTimestamp: '20XX-XX-XXTHH:MM:SSZ'
  generation: 474
  labels:
    app.kubernetes.io/instance: velero
    app.kubernetes.io/managed-by: Helm
    app.kubernetes.io/name: velero
    helm.sh/chart: velero-7.0.0
  name: default
  namespace: velero
  resourceVersion: 'XXXX'
  uid: XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX
  selfLink: /apis/velero.io/v1/namespaces/velero/backupstoragelocations/default
status:
  lastSyncedTime: '20XX-XX-XXTHH:MM:SSZ'
  lastValidationTime: '20XX-XX-XXTHH:MM:SSZ'
  phase: Available
spec:
  accessMode: ReadWrite
  config:
    resourceGroup: <azure-rg>
    storageAccount: <azure-storage-account-name>
  default: true
  objectStorage:
    bucket: storage-account-container
  provider: azure
```

In this case, in azure provider, the backup location needs to be in a bucket within an storage account[^sa]

Also `.spec.credentials` is not defined in case that Velero credentials are defined externally like for example with a Service Principal [^sp]


### Providers

Depending on the provider of the infrastructure it will store the Backups in different resources: 

```txt
+-----------------------+--------------------------------------+
|       Provider        |           Objects location           |
+-----------------------+--------------------------------------+
| Amazon Web Service    | AWS S3                               |
| Google Cloud Platform | Google cloud storage                 |
| Microsoft Azure       | Azure Blob Storage (Storage Account) |
+-----------------------+--------------------------------------+

```


[^k]: Kubernetes [[AKS - Kubernetes cluster]]
[^sa]: Azure Storage account [[AKS - Storage Account]]
[^sp]: Service principal role,  access and permissions setting in azure [[AZURE - Service Principal]]