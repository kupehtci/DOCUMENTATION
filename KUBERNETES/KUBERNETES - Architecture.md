#KUBERNETES



![[kubernetes-cluster-architecture.svg]]


### Nodes

The containers are placed into pods and run on Nodes. 
Components within a node are <span style="color:orange;">kubelet</span>, a <span style="color:orange;">container runtime</span> and a <span style="color:orange;">kube-proxy</span>. 

The node can be registered into the API server in two ways: 

* kubelet self registers to the control plane \[--register-node is set to true\] 
* user adds a node object manually

The Node is uniquely identified by its `metadata.name` that its a valid DNS subdomain name. 


### Pods

A Pod is a group of one or more containers with shared storage and network resources. 

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
    ports:
    - containerPort: 80
```

Usually pods are not manually created, they are created by workload resources such as: 
* Deployment
* Job
* Statefulset: a workload API object that manage stateful applications. Manages the pods with an state. 
