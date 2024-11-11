#AZURE #CLOUD 

### AZURE Application gateway


An Azure Application gateway is a web traffic (OSI Layer 7) load balancer that enables you to manage the traffic of the web applications. 

It can make routing decisions based on additional attributes of an HTTP request like URI path or different host headers. 

Example you can route traffic of `/login` to a certain server and if `/video/*` is received, route to other pool of servers. 

It has also other features: 

##### Secure Sockets layer (SSL/TLS) termination

It supports SSL and TLS termination at the gateway and after that the traffic flows to the backend servers unencrypted. 

Its helps to free the web servers from costly encryption and decryption but its not an acceptable option if you want to maintain a secure connection also in the backends or some applications require secure connections. 

For these applications, application gateway supports end to end SSL/TLS encryption from the gateway to the backend server. 

##### Autoscaling

Application gateway in version `Standard_v2` supports autoscaling, so it can scale up and scale down based on traffic demand. 

##### Zone redundant

It can cover some Availability Zones[^1] offering resilience and its not needed to be provision an Azure Application gateway in each zone 

##### Static VIP

It provide an static Virtual IP or VIP so it won't change even if the Application Gateway is restarted. 

##### Web application Firewall

Web application Firewall is a service that can be used in the Application Gateway that provide centralized protection of the web applications from common web exploits or vulnerabilities. 

This rules and protections can be customized through configuring some managed rules contained in the Azure Managed Default Rule Set or DRS. 
The set of configurable rules can be seen here [CRS and DRS rule groups and rules - Azure Web Application Firewall](https://learn.microsoft.com/en-us/azure/web-application-firewall/ag/application-gateway-crs-rulegroups-rules?tabs=drs21#drs934-21)



[^1]: Azure Availability Zones are different data centers provided by azure within a whole region 



