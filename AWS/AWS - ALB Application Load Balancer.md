#AWS 

# AWS Application Load Balancer (ALB)

ALB or Application Load Balancer is a Load Balancing service at L7[^3] that balances application traffic to kubernetes `ingress`[^1] resources. 

This helps to balance HTTP[^2] and HTTPS traffic between the different AWS resources within an VPC. 

It works by having a listener resource that listen the requests that income from the internet traffic at a certain port (80 for HTTP and 443 for HTTPS[^4]) that redirects the listened traffic to a certain target group where the resources that accept incoming traffic will recieve it balanced between the resources using ATW. 

ATW or Automatic Target Weights is a new weighted random load balancer algorithm that provides availability of an application that is distributed between various resources. 

ALB is **DNS-only** meaning that cannot attach an static IP and can only be references by DNS name. If an static IP is required use an AWS Network Load Balancer [[AWS - NLB Network Load Balancer]].  

### TLS offloading 

When an HTTPs listener is created, it encrypts the connection (SSL offload [^5]) the connection between the clients and the load balancer by initializing SSL or TLS sessions. 

---

# Target Selection Algorithm

Target Selection algorithms define which target receives the response within a group: 

* **Round Robin**: distributes new requests across healthy target at a "random". 
* **Least Outstanding responses**: prefer targets with fewest "in-flight" requests to reduce queuing on busy instances. 

---

# CloudWatch metrics to balance traffic

ALB's least outstanding responses target selection algorithm can take into account CloudWatch metrics to balance traffic. As arbitrary metrics cannot be used by there are some interesting key metrics to balance the traffic: 

* `RequestCount` or `RequestCountPerTarget`: total requests and average per healthy target. 
	* Recommended for detecting uneven load. 
* `ActiveConnectionCount` and `NewConnectionCount`: current and newly stablished connections. 
	* Useful for "least outstanding requests". 
* `TargetResponseTime`: time from target selection until the target responses. 
* `ELB-level Latency` alongside with `TargetResponseTime` helps to differenciate network latency versus target processing issues. 
* `HTTPCode_Target_4XX_Count` or `HTTPCode_Target_5XX_Count`: count of 4XX or 5XX errors indicating target issues: 
	* Helpful for routing to healthy targets. 
* `HealthyHostCount` or `UnHealthyHostCount`: Health status for routing eligibility. 
* `RejectedConnectionCount`: connections rejected due to max connections reached. This is a strong signal for scaling up. 

---

The AWS Application Load Balancer have different capabilities: 

##### Sticky sessions

Sticky sessions is a mechanism to route requests from the same client to the same target while during the sessions. 
This is done using duration-based cookies or application-based cookies. 

To manage an sticky session the key is to determine how long your load balancer is going to consistently route a user request to the same target.  

The sticky sessions properties are set per target group. 

##### Redirects

An AWS ALB can redirect an incoming requests from one URL to another URL. 
Also can redirect HTTP requests to HTTPS requests. 

##### Responses

ALB can control which clients are served by your applications and respond to HTTP requests with appropriate responses without forwarding the requests to the application. 

##### IP addresses as Targets

The load balancing can be done to an application hosted in a backend hosted on-premise or AWS by using it IP. 

Also Lambda functions can be used as targets. 

##### Content-based routing

If the application is composed of different services, the traffic between that services can be redirected by the HTTP content[^2]. This allow to route by: 

* Host field
* Path URL
* HTTP header
* HTTP method (GET, POST, PUT, HEAD, ...)
* Query string
* Source IP address

##### Container balancing support

In a kubernetes cluster[^6] or an EC2[^7] running various containers, you can balance the traffic across various ports within the same EC2 instance. 


##### Authentication

You can delegate the authentication functionality to your apps into ALB and it will authenticate users to access Cloud Applications. 
Its integrated with Amazon Cognito[^8] which allows end users to authenticate using social identity providers such as Google, Facebook, amazon and enterprise identity providers such as Microsoft AAD or other OpenID connection compatible provider. 

[^1]: Ingress kubernetes resource [[KUBERNETES - Ingress]]
[^2]: HTTP or Hyper Text Transfer protocol [[HTTP]]
[^3]: Layer 7 in OSI model [[OSI Layers]]
[^4]: Networking ports [[PORTS USED]]
[^5]: SSL offloading [[SSL - One line]]
[^6]: Elastic Kubernetes service is the AWS approach to a Kubernetes managed Cluster in the cloud [[AWS - EKS Elastic Kubernetes Service]]
[^7]: EC2 or Elastic Cloud Computing resource is a virtual machine that can be deployed and managed in the AWS cloud. [[AWS - EC2]]
[^8]: AWS Cognito [[AWS - Cognito]]