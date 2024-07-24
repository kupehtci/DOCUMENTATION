#KUBERNETES 


A Kubernetes manifest is a file in YAML or JSON format to describe the desired state of kubernetes API objects within the cluster. 

It defines how the component behaves within the cluster. 

The three most important components within the manifest file are: 

* `metadata` : includes essential information like name or namespace of the object. 
* `spec`: object specification. Declares the desired state of the object, like properties and behavior. 
* `status`: not currently declared within the manifest, but is a component that Kubernetes runtime creates in order to reflect and keep track of the current state of the cluster components.

The manifest has the following format, in this example a `Pod` declaration: 

```yaml
apiVersion: v1
kind: Pod
metadata:
  name: my-pod
  labels:
    app: my-app
spec:
  containers:
  - name: my-container
    image: nginx
    ports:
      - containerPort: 80
```

### Selectors

By giving labels to some components, we can use them as selectors. 
This is a effective way to organize groups and resources. 

Selectors are key-value pairs attached to objects like tags.

Selectors are used to filter, identify and attach some components to others based on their labels. 

For example, we can route a Load Balancing service to a certain Pod, by giving it the labels that are specified in the pod: 

```yaml
kind: Service
metadata:
  name: my-service
spec:
  type: LoadBalancer
  ports:
    - port: 80
  selector:
	#this selects for the load balancing, the components with app: my-app tag
    app: my-app   
```

* If you want to select by the <span style="color:LightSeaGreen;">name of an component</span>, you can access that variable as a tag with key `app.kubernetes.io/name`. 

```yaml
apiVersion: v1
kind: Service
metadata:
  name: my-service
spec:
  selector:
    app.kubernetes.io/name: MyApp
  ports:
    - protocol: TCP
      port: 80
      targetPort: 9376
```



### Multiple components declaration

Normally, the components are declared one peer each file, but also can be declared multiple components within the same file. 

To do so, you must use YAML `---` sequence to split each object. 

If separed by this way, `apiVersion: XX` must be declared again per each object.  

Example: 

```yaml
apiVersion: v1
kind: Pod
metadata: 
	name: my-pod-1
spec: 
	# ...
---
apiVersion: v1
kind: Service
metadata: 
	name: my-service-1
spec: 
	type: # declare type
	ports: 
		port: 80
```

