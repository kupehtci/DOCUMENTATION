#VELERO #KUBERNETES 

# VELERO Custom Resource Definitions

Velero deploys various CustomResourceDefiniton resources while being deployed. This are used to represent service monitors, applications  



This is a list of the basic CustomResourceDefiniton that Velero creates: 

```txt
backuprepositories.velero.io                
backups.velero.io
backupstoragelocations.velero.io
datadownloads.velero.io
datauploads.velero.io
deletebackuprequests.velero.io
downloadrequests.velero.io    
podvolumebackups.velero.io
podvolumerestores.velero.io
restores.velero.io
schedules.velero.io
serverstatusrequests.velero.io
volumesnapshotlocations.velero.io
```