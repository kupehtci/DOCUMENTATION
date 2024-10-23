#AKS #AZURE 

# Create a volume in AKS with Azure File Share

A persistent volume is a piece of storage provisioned for the Kubernetes Pods to persist the files. 
This persistent volumes can be manually created or dynamically provisiones through an Storage Class[^1]. 

To use a Persistent Volume, a requester such as a Pod should request storage through a **Persistent Volume Claim** or PVC.[^2]

In Azure Cloud an easy way to provision Persistent Storage to a Pod or Kubernetes Cluster is using Azure Files but the previous way of using `azureFiles` when mounting the volume is deprecated. 

In this case, this documentation gathers the steps to create an <span style="color:DodgerBlue;">Azure File Share</span> and use it as a Persist Volume using Azure Files CSI to provide it. 

### How to create an Custom Storage Class

We will need an Storage Class for dynamically provide a PV for the Claims. By default azure provides it by its CSI storage Driver, but it can also be manually created with the following manifest: 

```yaml
kind: StorageClass  
apiVersion: storage.k8s.io/v1  
metadata:  
	name: <storage-class-name>  
provisioner: file.csi.azure.com
reclaimPolicy: Retain # Default option is Delete
allowVolumeExpansion: true # | false
mountOptions:  
	- dir_mode=0777  
	- file_mode=0777  
	- uid=0  
	- gid=0  
	- mfsymlinks  
	- cache=strict  
parameters:  
	skuName: Standard_LRS  
	shareName: pod-fileshare
	storageAccount: <storage-account-name>
	server: <storage-account-name>.file.core.windows.net
```

Take into account that using the default <span style="color:orange;">StorageClass</span> will create a new Storage Account in Azure and place the file share within it. 

We can also check that if the AKS cluster has already the storage class provided by searching it with Kubectl tool. 
```bash
❯ kubectl get sc
NAME                     PROVISIONER          RECLAIMPOLICY   VOLUMEBINDINGMODE    
azureblob-fuse-premium   blob.csi.azure.com   Delete          Immediate            
azureblob-nfs-premium    blob.csi.azure.com   Delete          Immediate            
azurefile                file.csi.azure.com   Delete          Immediate            
azurefile-csi            file.csi.azure.com   Delete          Immediate            
azurefile-csi-premium    file.csi.azure.com   Delete          Immediate            
azurefile-premium        file.csi.azure.com   Delete          Immediate            
default (default)        disk.csi.azure.com   Delete          WaitForFirstConsumer 
managed                  disk.csi.azure.com   Delete          WaitForFirstConsumer 
managed-csi              disk.csi.azure.com   Delete          WaitForFirstConsumer 
managed-csi-premium      disk.csi.azure.com   Delete          WaitForFirstConsumer 
managed-premium          disk.csi.azure.com   Delete          WaitForFirstConsumer 
```

With this storage class (The provided or the custom one) we can create a PersistentVolumeClaim that will be automatically provisioned with a PersistentVolume attached to it. 

```yaml
apiVersion: v1
kind: PersistentVolumeClaim
metadata:
  name: pvc-for-fileshare
spec:
  accessModes:
    - ReadWriteMany
  storageClassName: <storage-class-name>
  resources:
    requests:
      storage: 2Gi
```

This will automatically create an storage account within the AKS' resource group or use the one specified in the StorageClass, create a File Share with the same name and size as requested in the **PersistentVolumeClaim** and provide the PersistentVolume with the Storage Account credentials via a Kubernetes secret 

To use this volume and mount it in a Pod we need to define it in the pod / deployment as: 
```yaml
apiVersion: apps/v1 
kind: Deployment
metadata:
  name: <deployment-name>
spec:
  selector:
    matchLabels:
      app: <example>
  replicas: 1
  template:
    metadata:
      labels:
        app: <example>
    spec:
      containers:
      - name: ubuntu
        image: ubuntu
        volumeMounts:
        - mountPath: /app/folder  # <--- Indicate here the path
          name: volume            # <-- Indicate the volume defined before
      volumes:
      - name: volume              # <-- Define a Volume using a PVC
        persistentVolumeClaim:
          claimName: volume-claim
```

`spec.containers.volumeMounts` should define the mount path of a volume defined before. Then in `spec.volumes` the different volumes should be defined indicating in `spec.volumes[x].persistentVolumeClaim.claimName` the name of the PVC we have just created.  

[^1]: Kubernetes Storage Class  [[KUBERNETES - Storage Class]]
[^2]: Persistent Volume Claim is a Kubernetes storage resource used to request space from a defined Persistent Volume. [[KUBERNETES - Persistent Volumes]]