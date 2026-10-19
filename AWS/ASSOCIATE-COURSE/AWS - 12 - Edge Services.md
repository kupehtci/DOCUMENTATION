#AWS 

# AWS 12 Edge Services

Edge services are taken into account when a low latency infrastructure is needed. 


The different distribution of places or locations are: 

AWS Regions > Edge Locations > AWS Local Zones > AWS Outposts > AWS Snow Family

* **AWS Edge locations**: are connected to AWS Regions through the AWS network backbone. You can use Amazon CLoudFront, AWS WAF and AWS Shield here. 
* **AWS Local zones**: Are extensions of the AWS cloud that are located closer to large populations where there isnt a close AWS AZ datacenter. 
* **AWS Outposts**: You can run AWS Services on your On Premises or at your own data center. 
* **AWS Snow Family**: Snow family of products that provide offline storage at the edge. They are used to deliver data back to AWS Regions. 

### Amazon Route 53

Amazon Route 53 is an AWS service that offers a DNS high available and scalable on the cloud. 
It provides Domain Name Registration and health checks. 

You can also purchase and manage domain names and automatically configure DNS Settings for this domains. 

Route53 can be used to route to AWS services like EC2, ELB or S3 buckets but can be also used to route users to outside of AWS. 

You can configure CloudWatch alamms to check the state of the endpoints and route to new healthy endpoints in case of failure (Failover). 
This dynamic routing, can also be used to route the connections to the lowest latency endpoints. 

A **hosted zone** is a container for this DNS records. Each record contains information about how to route traffic for an specific domain and subdomains. 

* Public hosted zones: contains records that specify how to route traffic on the internet: 
	* Internet Domain Name Server resolution
	* Delegation set: for authoritative servers that provided the domain name register or hold the parent domain. 
* Private hosted zones: contains records about how to route traffic in your Amazon Virtual Cloud (VPC). 
	* Domain Name Resolution inside a VPC
	* Can be associated with multiple VPCs and across accounts

When you create a record, you need to choose a routing policy, that determine how amazon Route 53 respond to the queries: 

* **Simple routing policy**: Use for a single resource that performs a given function for your domain. An example  is a web server that serves content for the example.com website. 
* **Failover routing policy**: Use when you want to configure active / passive failover.
* **Geolocation routing policy**: Use when you want to route traffic based on the location of your users. 
* **Geoproximity routing policy**: Use when you want to route traffic based on the location of your resources and, optionally, shift traffic from resources in one location to resources in another.
* **Latency routing policy**: Use when you have resources in multiple AWS Regions and you want to route traffic to the Region that provides the lowest latency with less round trip time.
* **Multivalue answer routing policy**: Use when you want Route 53 to respond to DNS queries with up to eight healthy records selected at random. 
* **Weighted routing policy**: Use to route traffic to multiple resources in proportions that you specify

It can also have **Multivalue answer routing**, where you can send up to 8 records of routing, and the user can select (If cannot receive the records, it will choose the first one). It also shuffles the records when are being sent. 


### Amazon CloudFront

Amazon CloudFront offers a Content Delivery Network (CDN) that use a global network of edge locations to deliver a cached copy of the web contents to your customers. 

Amazon CloudFront is a managed service. 

It uses the nearest edge locations to the customer and deliver the cached content. 
Use Regional caches when the content that is not accessed frequently enough to remain in an edge location.  

CloudFront supports real-time, bidirectional communication through WebSocket protocols used for chats, collaborations, gaming and trading. 

CloudFront distribute the content by routing each user request through the AWS backbone to the edge location that best serve your content. Typically this is a CloudFront edge server that delivers the content faster to the user. 

The steps of caching of CloudFront edge locations are: 

1. Request is routed to the optimal edge location
2. Non-cached content is retrieved from the origin
3. Origin content is transferred to the CloudFront Edge location.
4. Data is transferred to the user from the CloudFront. 

If content is already cached and its TTL has not expired, its not retrieved again and its delivered to the user. 

##### Configuring CloudFront

To configure the CloudFront, you must specify a source or origin server of the content fron which CloudFront takes the files. 
These content will be distributed from CloudFront. 
Then you define a **distribution** that tels CloudFront the properties such as log requests, TTL, paths patterns that will redirect to the CloudFront, 

Optimizations: 

* TCP Optimization: observer how fast a network is delivering the traffic and uses that data to improve performance. 
* TLS 1.3. support: Better performance for simmple handshake process with fewer round trips. 
* Dynamic content placement: serve dynamic content such as Web applications or APIs from ELB or Amazon EC2 instances. It improve the performance, availability and security. 

CloudFront origins access can be configured through OACs or Origin Access Control. 
### DDoS protection

A DDoS Attack is an attack where multiple "hacked" devices make requests to a network or web application in order to flood it. This attack can make that legit users are not able to use the service. 

DDoS can attack in various layers of the OSI model. The most common ones are L7, L6, L4 and L3. 


### AWS Shield

AWS Shield is a managed AWS DDoS protection service to protect the services in AWS. 
It protects from layer 3 and 4 frequent attacks by combining traffic signatures, anomaly requests and analysis of the incoming traffic. 
AWS Shield is protecting the services with no additional charge. 

### AWS Web Application Firewall (WAF)

AWS Web Application Firewall or WAF is a firewall to protect web applications or APIs from ilicit requests made from exploits or bots. 
You can define security rules to control how traffic is served and block common attacks patterns like SQLi and monitor the requests that passes through your AWS services. 

Its composed of: 

* WEB ACLs: Access Control List that defines the protection strategy through various rules. 
* Rules: define the patterns or properties that a web request can have or may not have and route or block the requests depending on that. 
* Rule groups: sets of rules that protect against similar attacks. 
* Rule statement: properties of the rule that need to match a web request. 
* IP set: set of IP addresses or ranges that can be used in a rule statement (AWS resources)

Also you can monitor the web requests, ACLs and rules that are matched and blocked or passed by using CloudWatch. These logs can be sent to Amazon S3, Amazon Kinesis Data Firehouse or CloudWatch Logs. 

### AWS Firewall manager

AWS firewall manager is intended for handling traffic to multiple AWS Accounts. 

It helps and simplifies the administration and maintenance of the AWS WAF and VPC security groups by setting them up only once. 
Then this service, will apply this protections and configurations across different accounts and resources. 

Use this service for large number of accounts, new applications that can be added easily and organization-wide visibility of all the threats. 

### AWS Outposts


AWS Outpost extend the AWS cloud to an on-premise data center by installing an Outposts rack. 
The different **outposts racks** are composed of various EC2 instances and EBS volumes. 

This hardware directly installed in you on-premise infrastructure lets you use AWS services within them in combination with the rest of the infrastructure. 

You will deploy the services by extending the VPC of the region with the outpost by using **Outpost subnets**. 

Each Outpost can support multiple VPCs with one or more Outpost subnets. 

The difference between **Outpost rack** and **Outpost server** is that Server is the whole rack while rack option is a single device placed in your own rack. 

It offer the following resources to be placed in the outpost hardware: 

* Compute and storage: EC2, EBS and S3
* Networking: Amazon VPC and Application Load Balancer
* Database: Amazon RDS and Amazon ElastiCache
* Containers: Amazon Elastic Container Service (ECS) and Amazon Elastic Kubernetes Service (EKS)