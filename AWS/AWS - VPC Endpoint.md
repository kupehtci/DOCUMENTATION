#AWS 

# AWS VPC Endpoint

An AWS VPC endpoint is a point of connection to other services powered by AWS Private link[^1] 

There are two types of endpoints: 

* **Interface endpoints**: that enable connectivity to services over AWS PrivateLink such as AWS managed services, services powered by AWS customers or partners. 

This interface endpoint is a set of elastic network interfaces with a private address that acts as entry point for traffic that is directed to a certain service within the VPC. 

* **gateway endpoints**[^ge]: targets specific IP routes in a Amazon VPC route table as a prefix list.

This type of endpoints are used for redirect traffic to an Amazon DynamoDB[^db] or Amazon S3[^2]. 



[^1]: AWS Private link is a service to link VPCs between then and access resources between this clouds. [[AWS - Private Link]]. 
[^db]: Amazon DynamoDB is a NoSQL database [[AWS - DynamoDB]]
[^2]: Amazon S3 or Simple Storage Service [[AWS - S3]]
[^ge] Gateway endpoints [[AWS - Gateway endpoint]]