#KUBERNETES 


### Command format

The most common command format for kubectl: 

```
kubectl action resource
```

### List resources

You can list the resources available in the Cluster: 

```
kubectl get <object-type>
```

Get deployments: 

```
kubectl get deployments
```
### Describe

You can view node or other objects status and other details by doing: 

```bash
kubectl describe node <insert-node-name-here>
```

### Apply a yaml file

A file defining a Kubernetes object can be applied: 

```bash
kubectl apply -f https://k8s.io/examples/pods/simple-pod.yaml
```


### Manually scale replicas

A deployment can be used to scale the pods to more replicas working. 

```bash
kubectl scale deployments/kubernetes-bootcamp --replicas=4
```

The load will be automatically load balances between the different replicas working. 
