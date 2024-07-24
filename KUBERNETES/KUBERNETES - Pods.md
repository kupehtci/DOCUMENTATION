#KUBERNETES 

# <span style="color:lime;">KUBERNETES</span> - Pods 

A Kubernetes Pod is the smallest deployable unit that can be created and managed. 

A pod is a group of <span style="color:MediumSlateBlue;">one or more containers</span> with shared storage and network resources, and specification of how to run the containers. 

A pod that runs a single container is the most common usage in Kubernetes and the pod acts as a wrapper, so Kubernetes manages the Pod instead that managing the container directly. 

A pod can be defined in a <span style="color:MediumSlateBlue;">.yaml</span> file that define its variables: 

```yaml
apiVersion: v1
kind: Pod
metadata:
  name: nginx
spec:
  containers:
  - name: nginx
    image: nginx:1.14.2
    resources: 
	    limits: 
		    memory: 
		    cpu: 
	    requests: 
		    memory: 
		    cpu: 
    ports:
    - containerPort: 80
```


Usually pods are not manually created, they are created by workload resources such as: Deployment, Job and Statefulset. 


The container's updates depends on the `imagePullPolicy`: 

* `IfNotPresent`: the image is pulled only if not already present locally
* `Always`: every time the kubelet launches a container, it digest the image
