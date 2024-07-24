#KUBERNETES 

## <span style="color:DodgerBlue;">KUBERNETES</span> - ReplicaSets

A ReplicaSet is a workload API object that maintain a stable set of replica pods running at the time. 
Guarantees the availability of a specific number of **identical** pods.

This is an example of the ReplicaSet manifest: 

```yaml
apiVersion: apps/v1 
kind: ReplicaSet 
metadata: 
	name: example-replicaset 
	labels: 
		app: myapp 
spec: 
	replicas: 3 
	selector: 
		matchLabels: 
			app: myapp 
	template: 
		metadata: 
			labels: 
				app: myapp 
		spec: 
			containers: 
			- name: myapp-container 
			  image: myapp:1.0.0
```

With the following parameters: 

* 
### Management of the Pods

The pods managed by the ReplicaSet can be created by different ways:

* Created by template

The template defined in the ReplicaSet defines the Pods that are created and maintained by it: 

```json
apiVersion: apps/v1
kind: ReplicaSet
metadata:
  name: frontend
  labels:
    app: guestbook
    tier: frontend
spec:
  replicas: 3      # number of pods maintained
  selector:
    matchLabels:
      tier: frontend
  template:
	# Definition of the pod
    metadata:
      labels:
        tier: frontend
    spec:
      containers:
      - name: php-redis
        image: nginx
```

* Via acquisitions

The ReplicaSet is not limited to own the pod that creates by the template, it can also <span style="color:DodgerBlue;">acquire</span> other pods that references by the selector: 

The ReplicaSet references a label for the selector in order to acquire the Pods that match that label: 

```yaml
apiVersion: apps/v1
kind: ReplicaSet
metadata:
  name: frontend
  labels:
    tier: frontend
spec:
  replicas: 3
  selector:
    matchLabels:
      tier: frontend   #label for the selector
```

And the pod should contain the label specified in the <span style="color:DodgerBlue;">ReplicaSet</span>. 

```yaml
apiVersion: v1
kind: Pod
metadata:
  name: pod1
  labels:    # label for the selector
    tier: frontend  
spec:
  containers:
  - name: hello1
    image: gcr.io/google-samples/hello-app:2.0
```


### Delete a ReplicaSet

Take into account when deleting a ReplicaSet that its deletion can affect or not the Pods.

By using `kubectl delete`, you can delete the ReplicaSet and if don't want to delete also the Pods, set `--cascade=orphan` to avoid affecting its dependencies. 

