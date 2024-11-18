#AWS 

# AWS Architecting Fundamentals

##### Benefits of using AWS Cloud

AWS has more than 200 services and geolocally distributed data centers. 

Is a Pay as you Go service. 

Secure and robust. 

The most common benefits of migrating to the cloud are: 

* Optimize costs
* Minimize security vulnerabilities
* Accelerate time to market
* Increase innovation
* Scalability 
* Reduce management complexity

##### Infrastructure locations

Data Centers > Availability Zones > Regions

Complementary: AWS Local Zones > Edge Locations

* **Data Center**: All AWS services operate within AWS data centers. Each Data Centers hosts thousands of servers with proprietary network equipment. 
* **Availability Zone**: Data centers grouped within a region. They are isolated from other AZ. They are interconnected using high speed cables. 

![[./IMAGES/AWS-AZ.png]]

* **Regions**: Completely independent groups of Availability Zones. They are defined by geographical regions.

* **Local zones**: An extension of Data centers to give a low latency but with less AWS services. This helps for this use cases: 
	* Media and entertainment delivery
	* IOT
	* Live video streaming
	* Low latency services
* **Edge locations**: Runs in major cities around the world and support objects like S3 buckets for storage and, Amazon Route for DNS resolving and Amazon Cloudfront. Its a CDN or Content Delivery Network element for delivering content with low latency around the world.  

In order to choose a **Region** and an **Availability Zone**: 

* Government
* Availability
* Costs

### Architect responsibilities

The architect has some responsibilities: 

It needs to PLAN the migration to the cloud: 

* Set technical cloud strategy with business leads
* Analyse solutions for business needs. 

Also needs to research about the different services and resources to implement in the cloud, it need to research. 

And once it has been planed and research about details of how to create the desired infrastructure in the cloud, it must **implement** it. 

##### Good architecture pillars

* Security: maintain security at all layers and enforce the principle of least privileges [^lp]
* Cost Optimisation: Analyse, plan and optimise the costs of the infrastructure. 
* Reliability: recover from failure and test recovery procedures. Also scale to respond to more traffic and maintain a high availability. 
* Performance Efficiency: Reduce latency, improve the use with serverless infrastructure and incorporate monitoring for improving the resource utilisation.
* Operational excellence: Performs operations with code. Test responses to unexpected events. 
* Sustainability: understand the infrastructure impact and maximize utilization. 


[^lp]: Least privileges is a principle that establish that each access to a resource or service must have the least privileges and permissions over it in order to access it and preserve maximum security. [[Least Privilege Principle]]


##### Connecting to AWS service

In order to connect and manage AWS services you can interact with AWS using: 

* AWS launch portal (Management console)
* AWS Command Line interface
* IaC tools. 
