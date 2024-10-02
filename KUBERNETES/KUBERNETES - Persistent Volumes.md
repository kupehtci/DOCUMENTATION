#KUBERNETES 


A **Persistent Volume (PV)** is a piece of storage in a Kubernetes cluster that is provisioned by an administrator or dynamically by a `StorageClass`[^stoclass] that define how its used the storage depending of the environment. 
It is a resource that provides storage for applications running within the Kubernetes cluster. 

Persistent Volumes are used to abstract from the  storage implementation (Cloud, local or on-premise) and provide a consistent storage interface to pods. 

Unlike ephemeral storage (such as emptyDir volumes) that is tied to the lifecycle of a pod, Persistent Volumes exist independently of the lifecycle of a pod. This allows data to persist even after the pod that uses it has been deleted.


The manifest of a PersistentVolume has the following format: 

```yaml
apiVersion: v1
kind: PersistentVolume
metadata:
  name: pv-example
spec:
  capacity:
    storage: 10Gi
  accessModes:
    - ReadWriteOnce
  persistentVolumeReclaimPolicy: Retain
  storageClassName: manual
  hostPath:
    path: "/mnt/data"
```

And a `PersistentVolumeClaim` to be able to use the previously defined `PersistentVolume`: 

```yaml
apiVersion: v1
kind: PersistentVolumeClaim
metadata:
  name: pvc-example
spec:
  accessModes:
    - ReadWriteOnce
  resources:
    requests:
      storage: 10Gi
  storageClassName: manual
```
Remember that persistent volume claim can be: 

* ReadWriteOnce
* ReadOnly
* ReadWriteMany
* ReadWriteOncePod

[^stoclass]: Kubernetes Storage class resource [[KUBERNETES - Storage Class]] 