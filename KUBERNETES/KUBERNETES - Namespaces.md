#KUBERNETES 

# KUBERNETES - Namespaces

namespaces is a mechanism to organize resources depending on the application or other reason. 

A namespace isolates the resources between namespaces so can share same names, give granular access to different administrators and efficiently manage the resources. 

By default, kubernetes have 4 built-in namespaces that are created by default when the cluster is created:

* `kube-system` for system processes like master and kubectl[^1] processes are deployed in this namespace
* `kube-public` contains public accesible data like `ConfigMaps`[^2] for the cluster and so
* `kube-node-lease` its the heart of the different nodes and each one of them has its associated lease object that determines it availability. 
* `default` its the default namespace for the created resources if no namespace is defined. 

Avoid using `kube-` prefix for the creation of new namespaces, because its reserved for Kubernetes usage. 

### Namespaces in DNS

Namespaces also isolates the resources in terms of DNS and the services are exposed as it: 

This is the structure used for defining the DNS hostnames for the different services and the resources attached to them. 
```
<service-name>.<namespace>.svc.cluster.local
```

### Usages

To get a list of the current existing namespaces they can be retrieved as other resources in the cluster but without indicating the namespace that it belongs to: 
```bash
kubectl get namespaces
```

And describe it: 
```bash
kubectl describe namespace <namespace-name>
```

You can filter and get the resources belonging to a certain namespace: 
```bash
kubectl get pods --namespace=<namespace-name>
# or 
kubectl get svc -n <namespace-name>
```

Also add a label to an existing namespace: 
```bash
kubectl label namespaces <namespace-name> <label>=<value>
```

### Manifest

The format of the manifest of a namespace is very simple: 

```yaml
apiVersion: v1  
kind: Namespace  
metadata:  
  name: <namespace-name>  
  labels:          
    <key1>: <value1>  
    <key2>: <value2>
```

Example: 
```yaml
apiVersion: v1  
kind: Namespace  
metadata:  
  name: nginx
  labels:  
    environment : pre
    proyect : example
    
```

### Create a resource in a namespace

You can define the namespace for a new resource in its `metadata.namespace` : 
```yaml
apiVersion: apps/v1
kind: Deployent

metadata: 
	name: nginx
	namespace: nginx    # <--- Specify the namespace
spec: 
	selector: 
		matchLabels: 
			appp: nginx
	template: 
		#...
```
Or by indicating it when applying its manifest with kubectl: 

```bash
kubectl apply -f example_config.yaml --namespace=<namespace-name>
```

### Kubectl

Also Kubectl[^1] can be used to create a namespace with a simple command: 

```bash
kubectl create namespace <namespace-name>
```

[^1]: Kubectl is the Command Line Tool for managing and operate a Kubernetes cluster through its API [[KUBECTL]]
[^2]: ConfigMaps are a type of resource within Kubernetes used to set configurations [[KUBERNETES - ConfigMap]]