#KUBERNETES 

## Resource types in kubernetes

CPU and memory are each one a different resource type that can be granted to each component running within the cluster. 

* CPU is compute processing and is measured in <span style="color:DodgerBlue;">Kubernetes CPUs</span> 
* Memory is specified in units of bytes. 


Resources can be managed through: 

- `spec.containers[].resources.limits.cpu`
- `spec.containers[].resources.limits.memory`
- `spec.containers[].resources.limits.hugepages-<size>`
- `spec.containers[].resources.requests.cpu`
- `spec.containers[].resources.requests.memory`
- `spec.containers[].resources.requests.hugepages-<size>`

This specify the resource limits and requests for the Kubernetes Containers. 

### Memory Units

The memory can be assigned using 


Example of resource management: 

```json
---
apiVersion: v1
kind: Pod
metadata:
  name: frontend
spec:
  containers:
  - name: app
    image: images.my-company.example/app:v4
    resources:
      requests:
        memory: "64Mi"
        cpu: "250m"
      limits:
        memory: "128Mi"
        cpu: "500m"
  - name: log-aggregator
    image: images.my-company.example/log-aggregator:v6
    resources:
      requests:
        memory: "64Mi"
        cpu: "250m"
      limits:
        memory: "128Mi"
        cpu: "500m"
```