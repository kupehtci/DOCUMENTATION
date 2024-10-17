#KUBERNETES 

### Kubernetes Service component

A service can have various types depending on its purpose and behavior: 

##### ClusterIP

Exposes the Service within the Cluster IP internally so it cannot be used to access a micro-service from outside the cluster using this type of service unless you do poort-forwarding but its only recommended for testing and administration purposes. 

##### NodePort

Expose the application by its port settled in `nodePort`. 
You can only expose a **single** service per port and the port must be in the range of `30000` to `32767`. This is because the access to this service and the pod attached to it, will be done using the cluster node IP and the port. 
##### LoadBalancer

The most common way of exposing applications to the internet. This type of service is prepared for being managed and configured with a private Load Balancer that grant access to this Service of type `LoadBalancer`. 

The cloud manager controller must configure the private load balancer using the Service annotations like `service.beta.kubernetes.io/aws-load-balancer-type: alb` or similar depending on the Load Balancer controller used. 

It doesn't provide filtering or routing and you need to create a Load Balancer service for each application and kubernetes will create one Load Balancer per each one, so can become really expensive. 
Its more recommended to use Ingress[^1] (L7) for this purposes and use LoadBalancer if the ports to expose are not HTTP / HTTPS ports (80 or 443). 

Take into account that Load Balancer works in Layer 4 of the OSI layer[^2], so it handles TCP / UDP traffic. 

The format of a Kubernetes service component manifest declaration should look like this:


[^1]: Ingress kubernetes resource [[KUBERNETES - Ingress]]
[^2]: OSI layer [[OSI Layers]]


