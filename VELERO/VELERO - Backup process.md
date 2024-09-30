#VELERO #AKS #EKS 

Once you have the Kubernetes cluster running with the velero instances running and Velero CLI installed in the device, you can make the backup using velero. 

By default in AKS[^1], for the backup storage location is configured a blob container inside an Azure Storage Account[^2]


The backup and restore process is independent of the platform (AKS, EKS, etc ), Because each BackupStorageLocation[^3] has the properties and credentials of the backup place and how to save it. 

In case of using AKS (Azure Kubernetes Service)[^1]
### Backup process

To create a backup on demand, use `velero backup create` command. 

```bash
velero backup create <backup-name> --include-namespaces <namespace> 
```

`--include-namespaces <namespace>` The namespace to include in the backup(optional). If not specified, the backup will be made with all namespaces

`--include-resources <resources>` the resources to include in the backup (optional). If not specified, all resources are included in the backup

You can **list all the backups** available by using `velero backup get`

### Restore process

To restore an existing backup, use the `velero restore create` command: 
```bash
velero restore create --from-backup <backup-name> --include-namespaces <namespaces>
```

* Specify the backup name in the `--from-backup` flag
* `--include-namespaces <namespace>` The namespace to restore from the backup(optional). If not specified, all namespaces resources will be restored. 

Also, the restores can be listed to see all the restores that have been made: 
```bash
velero restore get
```

### Create backup schedules

The backups can be made automatically by setting an schedule: 
```bash
velero schedule create <schedule-name> --schedule="@every 24h" --include-namespaces <namespace>
```
### Troubleshooting

If  you encounter any issues when backing up or restoring, you can check the logs for more insights: 

```bash 
velero logs
```


[^1]: Azure Kubernetes Service [[AKS - Kubernetes cluster]]
[^2]: Azure Storage account [[AKS - Storage Account]]
[^3]: BackupStoreLocation of velero [[]]