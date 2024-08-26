#VELERO #KUBERNETES 

# VELERO 

Velero is an open-source tool used for backup, recovery and migration of Kubernetes Cluster[^kc] and persistent volumes. 

It protects the kubernetes workloads by allowing to backup the cluster resources and persistent volumes [^pv]. 

Velero can be deployed in cloud environment or on-premise. 

### Backups and snapshots

Velero backups the entire state of Kubernetes cluster, including namespaces declarations, configurations (ConfigMaps and Secrets) and other kubernetes resources. 

Persistent Volumes are also backed up as snapshots, maintaining this actual data of the application. 

### Disaster Recovery

In case of failure, The kubernetes cluster and the persistent data can be restored from the velero backups. 
This recovery can be done from scheduled backups or on-demand backups. 

### Migration

Velero can be used to migrate resources from one Kubernetes cluster to another. This can be useful to change between clusters, migrating between production environments or even migrate between providers. 

Migrate within the same provider can be easily done just by sharing or copying the backups generated previously by Velero, following a similar process as when doing a disaster recovery. 

Migrating the cluster between providers its a little more difficult because Velero use different backup locations and snapshot utilities in each provider. 

[^kc]: Kubernetes cluster [[KUBERNETES - Basics]]
[^pv]: Persistent volumes are kubernetes resources for granting persistent storage [[KUBERNETES - Persistent Volumes]]