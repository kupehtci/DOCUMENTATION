#GCP 

# GCP - Network

The main element of a network within GCP and where all resources reside and have networking capabilities over it is the VPC[^1]. 

VPC have some properties: 

* VPC networks have no region or zone. 
* VPC networks with associated routes and firewall rules. 
* Each subnet[^3] defines a range of IPv4 addresses or CIDR block and auto-provision IPs to resources that belong to it within this CIDR block. 
* Instances must have an internal IPv4 to communicate with Google API services

### Other resources

VPC can be complemented with other resources following certain properties or requirements: 

* VPC networks can be connected to other VPC networks using <span style="color:DodgerBlue;">VPC Network Peering</span>. 
* VPC network can be connected in Hybrid environments with On-premise infrastructures by using <span style="color:HotPink;">Cloud VPN</span> or <span style="color:IndianRed;">Cloud Interconnect</span>. 
* A shared VPC can be used to keep a VPC in a host project and Authorized IAM principals[^2] from other project can create resources that can connect to this <span style="color:LightSkyBlue;">Shared VPC</span>. 


[^1]: VPC or Virtual Private Cloud [[GCP - VPC - Virtual Private Cloud]]
[^2]: IAM Identity Access Management [[GCP - IAM Identity and Access Management]]
[^3]: Network subnets [[GCP - Subnets]]