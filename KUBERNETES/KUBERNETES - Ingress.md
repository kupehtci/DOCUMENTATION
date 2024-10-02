#KUBERNETES 

### Ingress object

Is an API object that manages external access to services within the cluster. 
Exposes HTTP and HTTPS routes from outside the cluster to services within the cluster. 


![[ingress.svg]]

As a difference with load balancer Kubernetes' service type, it provides <span style="color:DodgerBlue;">filtering and domain / subdomain routing</span>, allowing to route traffic to different backends depending on the domain or path specified. 

An ingress controller also creates a LoadBalancer Service to create a single load balancer entry point to all the services and route the traffic depending on the routes. 
### Take into account

* Initialize an Ingress controller in order to make the ingress resource to work. Also supports AWS, GCE and nginx ingress controllers. 
* 