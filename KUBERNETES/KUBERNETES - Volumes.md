#KUBERNETES 

## KUBERNETES Volumes

Volumes are on-disk files that are ephemeral. This means that on a pod restart or crash, all this data is lost. 
Also another problem is that when multiple container within a pod need to share files. 

All this problems are solved by using kubernetes <span style="color:DodgerBlue;">volumes</span> abstraction. 

Kubernetes' pods support many types of volumes mounted simultaneously: 

#### ConfigMap

A ConfigMap provides a format to define configuration data for the pods. 
The data stored within a ConfigMap can be referenced by "mounting" a volume of type `ConfigMap` and used by containerized apps running within a pod. 


#### emptyDir

For a Pods that defines a `emptyDir` volume mount, this volume is created when the pods runs. 
Its initially empty and all containers within the pod can read and write and read the same files in the emptyDir volume. 
This volume can be mounted in the same path or different paths in each container. 

Example of how to mount the emptyDir for each container: 

```yaml
apiVersion: v1
kind: Pod
metadata:
  name: test-pd
spec:
  containers:
  - image: registry.k8s.io/test-webserver
    name: test-container
	volumeMounts:           # mount the defined volume 
    - mountPath: /cache
      name: cache-volume
  volumes:
  - name: cache-volume
    emptyDir:
      sizeLimit: 500Mi
```
