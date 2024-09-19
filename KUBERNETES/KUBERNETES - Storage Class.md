#KUBERNETES 

# KUBERNETES Storage Class

A StorageClass provides a way of administrators to describe the classes of storage that can be used by persistent volume claims to create persistent storage solutions. 

An storage Class is an object related with Kubernetes storage resources like Persistent volumes, persistent volume claims[^1], persistent volume[^1] objects and similar.

When a PersistentVolumeClaim has no default kubernetes storage class or even has no storageClass key settled, Kubernetes Control Plane assigns it. 
### Format

Each StorageClass contains the `provisioner`, `parameters` and `reclaimPolicy` which can be used when a <span style="color:orange;">PersistentVolume</span> needs to be provisioned by a <span style="color:DodgerBlue;">PersistentVolumeClaim</span>. 

An example of an storage class: 

```yaml
apiVersion: storage.k8s.io/v1
kind: StorageClass
metadata:
  name: low-latency
  annotations:
    storageclass.kubernetes.io/is-default-class: "false"
provisioner: csi-driver.example-vendor.example
reclaimPolicy: Retain # default value is Delete
allowVolumeExpansion: true
mountOptions:
  - discard # this might enable UNMAP / TRIM at the block storage layer
volumeBindingMode: WaitForFirstConsumer
parameters:
  guaranteedReadWriteLatency: "true" # provider-specific
```


### Default storage class

You can set an storage class as default by setting `storageclass.kubernetes.io/is-default-class` annotation to `true`. 



[^1]: Persistent Volume Claims kubernetes objects [[KUBERNETES - Persistent Volumes]]
