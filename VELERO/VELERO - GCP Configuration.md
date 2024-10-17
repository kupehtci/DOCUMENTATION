#GCP #CLOUD #VELERO 

# VELERO GCP Configuration 

Velero in order to run in Google Cloud provider needs some permissions and resources around it to be able to make the on-demand / scheduled backups and volume snapshots. 

In the case of GCP, it uses a bucket inside Google Storage in order to save all the backup related files and the state of the cluster when perform the backup.
It also realizes snapshots of the related disks that are used in the GKE[^1] by analyzing the persistent volumes and persistent volume claims within the kubernetes solution. 

This snapshots are placed in the resource group specified, so Velero need to have permissions in order to do the snapshots and a running and accessible bucket. 

The following documentation gather all the steps and configurations relative to deploying Velero using terraform helm provider. 

In order to simplify the definition and documentation about the resources created, we are going to distinguish between Kubernetes Service Account, for now on KSA and Google Cloud Service Account that its a identity of the Google IAM, for now on GSA. 

### Prerequisites 

In order to deploy Velero and configure it for running in a GKE we need: 

* An active GKE cluster with a workload pool assigned to `<project-id>.svc.id.goog` where the service account and workload identity may reside. 
* An active Google Account with owner or collaborator roles or at least `roles/container.admin` and `roles/iam.serviceAccountAdmin` roles attached to the account to the desired project. 
* An active Cloud Storage Bucket or roles to create it for Velero. 
### Google IAM Permissions

Velero in order to access the Cloud storage and to create snapshots from the volumes, it need to have the right permissions granted through an IAM member accessed by a Kubernetes Service Account attached to it. 

This default configuration grants Workload Identity permissions to the Kubernetes Service Account represented as: 

```yaml
"serviceAccount:<gcp-project-id>.svc.id.goog[<velero-namespace>/<ksa-name>]"
# By default: 
"serviceAccount:<gcp-project-id>.svc.id.goog[velero/velero]"
```

And to this KSA, the workload Identity User role is added to it in order to be able to identify as a GSA from the workload identity federation pool. 

The KSA must have the GSA that is going to use, specified as a `annotation`. 
```
iam.gke.io/gcp-service-account : "<gsa-name>@<project-id>.iam.gserviceaccount.com
```

To authenticate as a workload identity and use the associated GSA to authenticate and manage Google Resources. 

Then, a custom role with the previously defined roles is attached to the GSA: 

```hcl
resource "google_project_iam_custom_role" "velero_custom_iam_role" {
  permissions = [
    "compute.disks.get",
    "compute.disks.create",
    "compute.disks.createSnapshot",
    "compute.projects.get", 
    "compute.snapshots.get",
    "compute.snapshots.create",
    "compute.snapshots.useReadOnly",
    "compute.snapshots.delete",
    "compute.zones.get", 
    "storage.objects.create", 
    "storage.objects.delete", 
    "storage.objects.get", 
    "storage.objects.list", 
    "iam.serviceAccounts.signBlob", 
    "iam.serviceAccounts.getAccessToken"
  ]
  role_id = "velero${local.gke_cluster_name_cleaned}"
  title   = "velero-${local.gke_cluster_name}"
}
```

### Validation

Once it has been deployed we need to make sure that the Kubernetes Service Account has been created successfully with the correct annotation. The Service Account needs to looks similar to this: 

```yaml
apiVersion: v1
kind: ServiceAccount
metadata:
  annotations:
    iam.gke.io/gcp-service-account: <gsa-name>@<project-id>.iam.gserviceaccount.com
    meta.helm.sh/release-name: velero
    meta.helm.sh/release-namespace: velero
  creationTimestamp: "XXXXX-XX-XXXXX:XX:XXX"
  labels:
    app.kubernetes.io/instance: velero
    app.kubernetes.io/managed-by: Helm
    app.kubernetes.io/name: velero
    helm.sh/chart: velero-7.2.1
  name: velero
  namespace: velero
  resourceVersion: "XXXXXXXX"
  uid: XXXXXXXX-XXXXX-XXXX-XXXXX-XXXXXXXXXXXXXX
```

By default, Velero should deploy two pod node agents and one `velero-XXXXXXXXXXX-XXXXXX` pod, one service, a daemonset, one deployment and a replicaset. 

To check the creation logs you should check the ones belonging to the `velero` pod with: 
```bash
kubectl logs pods/velero-XXXXXXXXXXX-XXXXXX -n <velero-namespace>
```

And you should see all the initializations without an error and at least see that the Backup Storage location being correctly validated with a log entry like this: 

```bash
level=info msg="Validating BackupStorageLocation" 
level=info msg="BackupStorageLocations is valid, marking as available" backup-storage-location=velero/default controller=backup-storage-location logSource="..."
```

