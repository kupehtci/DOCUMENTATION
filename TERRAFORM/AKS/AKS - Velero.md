#AKS #VELERO 

### Velero Disaster Recovery

Velero [^1] is a disaster recovery and migration tool that creates under-demand or scheduled backups in order to restore it in another cluster to migrate the cluster[^2] or recover from a disaster. 


### Installation

In order to store Velero backups we need an storage location in order to store blob data. 
To do this en AKS, we can use an Azure Storage Account[^3]

To store this backupds we need to create this Azure storage account and a blob container within it. 





[^1]: [[KUBERNETES - Velero]]
[^2]: Kubernetes cluster [[AKS - Kubernetes cluster]]
[^3]: Azure storage account[[AKS - Storage Account]]