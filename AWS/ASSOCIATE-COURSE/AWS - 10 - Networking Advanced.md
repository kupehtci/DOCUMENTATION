#AWS 


### VPC Endpoints

With VPC endpoints we can keep our connections to AWS services private. 
The traffic goes over the AWS backbone. 

We have two types:
* <span style="color:DodgerBlue;">Gateway endpoint</span>: is a gateway that can be routed traffic to with a route table and can redirect traffic to an Amazon S3 or an Amazon DynamoDB
* <span style="color:DodgerBlue;">Interface Endpoint</span> is an elastic network interface (ENI) with a private IP address and serves as an entry point for traffic to a supported service. AWS Private link powers up interface endpoints and avoid exposing this traffic to public internet. 


#### VPC Peering

VPC Peering is used to privately route traffic between VPCs. 

Is a one-to-one connection between two VPCs. You can only have one Peering between two VPCs and each VPCs can have multiple Peerings. 

But also has some limitations:

* There is a limit on the number of active and pending peerings per VPC
* Maximum transiction units (MTUs) across a VPC Peering connection is 1,500 bytes. 

The route tables of the VPC must be configured in the format that each route table of the VPC, points to the other VPC CIDR's block. 

> Note: Take into account that in a three VPCs connection that A is connected with B and B is connected with C, A has no communication with C unless they have a Peering between them. 

VPC Peering has some benefits: 

* Bypass the Internet Gateway or Virtual Private Gateway and connect two networks without any other virtual appliances. 
* Avoid bandwidth bottlenecks. All inter-region traffic is encrypted within AWS backbone and has no point of failure. 
* Use private IP addresses to direct traffic. 

The most common pattern is to keep an VPC with shared services that can be accessed from other specific purpose VPCs.  



#### Hybrid Networking

An hybrid network is a network composed of resources On-Premise and resources in the cloud. 

AWS offers some resources for connecting this different resources: 

#### AWS Site-to-site VPN

Offers a connection using two VPN tunnels. 
These tunners go between a virtual private gateway (Transit gateway) and a customer gateway on the on-premise site. 
* A *cirtual private gatway* is the VPN concentrator on the AWS side of the AWS Site-to-site VPN connection. 
* A *customer gateway* is the resource created in AWS that represent a customer gateway device in the on-premise network. This needs to be configured in the on-premise side. 
* This can have dynamic or static routing based on the features in the customer site.  

#### AWS Direct connect

Is a direct cable between a Customer Gateway Device in the On-Premise to a Virtual Private Gateway in the cloud.  

You need to fulfill a Authorization and Connection Facility Assigment (LOA-CFA) to begin this connection. 


A Direct Connection Location provides AWS in the region that is associated. To use one of this connections you need to met: 

* Your network is collocated with an existing Direct Connect Location. 
* You are working with a Direct Connect Partner
* You are working with an independent service provider to connect to Direct Connect. 

> Note: see pricing comparison between both


#### AWS Transit Gateway

AWS Transit Gateway act as a hub that controls how traffic is routed among all connected networks. 
This simplify management and reduce operational costs because **each network only needs to connect to Transit Gateway**. 

This can also be used to interconnect your VPC and on-premise networks and simplify the management. 

AWS Transit gateway reduces the number of route tables we need to manage a global network composed of various connections and VPCs. 

Transit Gateway operates at L3 where traffic are sent to the next hop attachment based on their destionation IP address.

**Attachment** is a connection of a connectivity resource to a transit gateway. You can attach the following resources: 

* VPC
* VPN Connection
* Direct Connect Gateway
* Transit Gateway Connect
* Transit Gateway Peering Connection
