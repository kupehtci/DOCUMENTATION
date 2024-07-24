#KUBERNETES 

# <span style="color:lime;">KUBERNETES</span> - StatefulSet


Is a <span style="color:DodgerBlue;">workload API object</span> that manage stateful applications. Manages the pods with an state. 


### Scale in runtime


A Kubernetes Statefulset can be scaled during runtime. 

Firstly find the StatefulSet that you want to scale: 

```bash
kubectl get statefulsets <sfs-name>
```

Then its replicas parameter can be changed with `kubectl scale` command: 

```bash
kubectl scale statefulsets <sfs-name> --replicas=<new-number-replicas>
```

