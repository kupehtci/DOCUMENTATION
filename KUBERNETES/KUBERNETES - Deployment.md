#KUBERNETES 

## <span style="color:DodgerBlue;">KUBERNETES</span> - Deployment


Is a <span style="color:DodgerBlue;">workload API object</span> that manages updates for Pods [^1] and ReplicaSets[^2]. 

In a deployment you set a <span style="color:MediumSlateBlue;">desired state</span> and the deployment changes the state at a controlled rate in order to reach and maintain this state. 

This deployments can create ReplicaSets that control their pods. 

The most common uses for the deployment are: 

* A deployment that creates and maintain a ReplicaSet with pods.
* Update new state for the pods. By changing the `PodTemplateSpec` a new replica set is created and the old Pods are moved to the new one.
* Rollback. if the current state of the deployment is not stable, a rollback can be done. 
* Manual scale of the ReplicaSet. A deployment can be scaled though a command. 
* Check the status, pause and clean up. You can control all the replica set though the deployment. 

The Manifest format for declaring a Kubernetes deployment: 
```yaml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: nginx-deployment
  labels:
    app: nginx
spec:
  replicas: 3    # Set of replicas = number of pods 
  selector:
    matchLabels:
      app: nginx    # Selector for acquiring Pods 
      
  template:         # `.spec.template` is used to define pods specs
    metadata:
      labels:
        app: nginx
    spec:
      containers:
      - name: nginx
        image: nginx:1.14.2
        ports:
        - containerPort: 80
```

* `.spec.replicas` indicates the number of pods for the ReplicaSet[^2]
* `.spec.selector` indicates to the ReplicaSet[^2] which Pods to acquire. 
* `.template` : is the template for the pods that are created by the ReplicaSet[^2]
	* `.metadata.labels` : labels for the pods created
	* `.spec` indications for the pod' s specification. 
	* `.spec.containers` indicated the parameters for the containers hold within the Pod. More specification about how to define a pod in [[KUBERNETES - Pods]]. 

[^1]: Kubernetes Pods API objects [[KUBERNETES - Pods]]
[^2]:: Kubernetes ReplicaSets API object 