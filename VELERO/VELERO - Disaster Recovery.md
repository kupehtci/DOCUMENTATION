#VELERO 

### Prerequisites

Before starting the recovery or restore some resources from the backup, you need some requisites: 

* An existing or new running Kubernetes cluster
* Velero configured to use the needed provider (Azure, AWS, GCP)
* Configured the specific storage properties depending of provider (Azure Blob Container, )
*  `velero` cli installed in the Command line of preference
* `kubectl` cli installed in the command line of preference

### Velero recover from a disaster

If the infrastructure is managed by terraform, re-deploy the aks using terraform or restart the cluster. 

Once its initialized, only restore velero manually, by terraform or just by installing it in the cluster and other desired resources that are wanted to be restored with the backup. Remember that `velero` namespace must be exclusively keep for velero resources in order to perform the backups correctly. 

Take into account that Velero is configured correctly depending on the provider and the BackupStorageLocations and VolumeSnaphotLocations properties are correctly set to the locations that currently hold the backup. 

Once velero pod, service and node agents are running, we are able to list the backups available

```bash
velero backup get 
```

![[./IMAGES/velero-backup-get.png]]

We need to select the one most recent or the one desired. 
If we want to check the contents that have been backed up and the different snapshots related with the backup, we can make a describe of the element we want to check: 

```bash
velero backup describe <backup-name>
```

![[./IMAGES/velero-backup-describe.png|400]]

In the describe we can see the number of resources that have been backup, when did the backup were made and the PVC associated with this backup. 

When restoring this backup take into account that the PVC that will be restored, will be rename has `restored-` and the PersistentVolume associated with the new resource restored will be linked with this new disk. 


To create the restore, create it indicating the included or excluded namespaces to be restored. If both are not specified, all namespaces resources keep in the backup will be restored. Take into account that `velero` resources won't be backed up and also restored, they remain untouched. 

```bash
velero restore create   --from-backup <backup-name> | --from-schedule <schedule>
						--include-namespaces <namespace>,<namespace>
						--exclude-namespaces <namespace>,<namespace>
```

You can also select the items that want to be restored by defining `--selector <label>` or `--include-resources <resources>` / `--exclude-resources <resources>`. 

For not restoring the volume snapshots you can set the `--use-volume-snapshots` to false

As Examples: 

* To restore all namespaces: `velero restore create --from-backup bk1`
* To restore a namespace: `velero restore create --from-backup bk1 --include-namespaces hello-world`
* Don't restore VolumeSnapshots `velero restore --from-backup bk1 --use-volume-snaposhots false` 
* Restore from an specific schedule, the backup most recent: `velero restore create --from-schedule sch1`

Once the `restore` have been initialized, we can se it's status with the `describe`  command referencing to the restore name indicated when created: 

![[./IMAGES/velero-restore-create.png]]

When the backup pass from `InProgress` to `Completed`, the backup and snapshots will be completely restored. 

Velero is configured to be non-destructive, so when doing the restore, the backup resources are compared with the existing ones, and if some resources are currently present in the cluster, they won't be restored. 

Some warning may appear in the warnings.namespaces.\<namespace-name\> like the one in the image, indicating that some items have not been restored if they are currently present in the cluster.  

### Notes

##### Labeling

All the restored items in the cluster are labeled with: 
```
velero.io/backup-name=<backup-name>
velero.io/restore-name=<restore-name>
```
This is made to check if the existing elements have just been restored recently from the same backup or need to be restored again 

##### PVC naming

The restored PVC and its disk will be relabeled. If want to change its name or make the PVC point another PV or Disk, you can define a ConfigMap [Velero Docs - Restore Reference](https://velero.io/docs/main/restore-reference/#restore-existing-resource-policy) or change the PVC parameters. 

##### Order

Velero follows a defined order of resources when restoring them. It depends on the kind of objects within the backup. The order is the following

- Custom Resource Definitions
- Namespaces
- StorageClasses
- VolumeSnapshotClass
- VolumeSnapshotContents
- VolumeSnapshots
- PersistentVolumes
- PersistentVolumeClaims
- Secrets
- ConfigMaps
- ServiceAccounts
- LimitRanges
- Pods
- ReplicaSets
- Clusters
- ClusterResourceSets

### Azure disks

In the case of Azure disks that were created in order to hold the storage for kubernetes PersistentVolumes, they will be restored as `restore-<uid>` and they are automatically linked by velero 
