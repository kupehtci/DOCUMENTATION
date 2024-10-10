#KUBERNETES 

### <span style="color:DodgerBlue;">Kubernetes</span> - Deployment Strategies

The following strategies are supported in the kubernetes deployment object[^1]

#### Rolling deployment

Is the default strategy in kubernetes
It maintains zero downtime by incrementally updating pods instances with new ones 

The old ReplicaSet is scaled down and the new one is scaled up, <span style="color:orange;">maintaining the pods stable</span>. 
Maintains a high availability of the service sacrificing resources. 

#### Recreate deployment

The recreate deployment involves shutting down the old version before deploying the new one. 
Is simpler and involves less resources, but the service is disrupted. 

#### Blue / Green deployment

In blue/green deployment, two versions coexist in separate environments (Known each one as blue and green). 
The traffic is routed to blue environment while the new version is deployed in the green and validated, and after that, the traffic is switched to the green one. 

For doing this, we can create two different services and use the selector in the service to switch the traffic between environments. 


#### Canary deployment

A canary deployment consist in delivering the new version of the application to a small subset of users before making it available to everyone. 

This can be useful to test the new release to a controlled group to test performance and reliability. 

Canary deployment can be achieved by modifying the traffic rules to balance traffic between old and new versions by setting weight values on pods. 

#### Shadow deployment

A shadow deployment is when the new version receives real-world traffic in parallel with the old version but not affecting the response to users. 

To implement this, the pods can be duplicated and traffic can be mirrored to these shadow pods. 

### Manifests

The deployment strategy is defined in the manifest in `spec.strategy` as: 

```yaml
apiVersion: apps/v1
kind: Deployment
metadata: 
	name: myapp
	namespace: default
spec: 
	strategy: 
		type: <type>
		rollingUpdate: 
			maxUnavailable: 1
			maxSurge: 1
	replicas: 4
	selector: 
		matchLabels: 
			app: myapp
	template: 
		#... 
```

[^1]: Kubernetes deployment object [[KUBERNETES - Deployment]]