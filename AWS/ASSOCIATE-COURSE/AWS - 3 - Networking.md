#AWS 

An networking environment is necessary in order to have communication between all resources within AWS Accounts. 


##### Virtual Private Cloud or VPC

The main element that groups all the networking resources within AWS is the VPC or Virtual Private Cloud. 

The VPC is constrained within an AWS region and spans all the availability zones of the region, so a VPC cannot be within two different regions. 

The communication is restricted to within the same VPC by default, so in order to have communication between two VPC an **VPC peering** must be configured

A subnet is a subnet within a VPC CIDR block and cannot overlap with another subnet. 
Each subnet resides only within one Availability Zone and each Availability Zone can have multiple subnets. 

There are 5 subnets reserved for AWS internal resources usage, so cannot be used.

##### Internet Gateway

An internet gateway  is an horizontal scaled, redundant and high available VPC component that **allows communication between instances in your VPC and the internet**. 

A subnet can be **public** or **private**, depending on the access that the networking resources has. This depends in the presence of a **Router (Internet Gateway)** within that Subnet. 

To define how the traffic is directed within a subnet, a **route table** needs to be defined and associated to a subnet in order to redirect traffic to an Internet Gateway or other resources. 

In a public subnet, the most common entry in the **Route table** is to redirect all the traffic (0.0.0.0/0) to the Internet Gateway and certain IPs to some resources that are within the public Subnet. 

AWS creates a default VPC with the CIDR block 172.31.0.0/16 in each region for the AWS account. If no VPC is specified when creating a resource, it will be created in this VPC that has public internet access. 


##### Elastic IP Addresses

Its an owned static IP address that can be associated with an instance or a network interface and reassociated to a new resource inmediately. 


##### Elastic Network Interface


##### NAT or Network Address Translation

NAT gateway is a resource that allow communication from a private subnet with resources within a public subnet.
It translates the private IP to a public IP in order to be able to communicate within the Internet. 

The NAT gateway is placed in the public subnet and is references from the route table of the private subnet. This allows that the resources in the private subnet has internet access but the inbound traffic won't reach that resource. 

The steps for the outbound connections from a private subnets are: 

* The route table for the private subnet sends all IPv4 internet traffic to the NAT gateway.
* The NAT gateway uses its Elastic IP address as the source IP address for traffic from the private subnet.
* The route table for the public subnet sends all internet traffic to the internet gateway. 

For high availability solutions for deploying a VPC across multiple Availability Zones, create an infraestructure with an Elastic Load Balancer for inbound traffic and set a NAT Gateway per each AZ in order to provide a secondary NAT in case of fail over. 
(Take into account the EIPs limitations (5 per region and AWS account))

##### Network Access control lists (ACLs)

A Network ACL is an optional layer of security for the VPC that act as a firewall for controlling the traffic in and out of some subnets.
Every VPC has an default ACL that allows all inbound and outbound IPv4 traffic but by default the custom ones block all traffic unless you define an allow rule for a type of traffic. x

##### Security Groups

A security group is a virtual firewall that controls inbound and outbound traffic to an ENI or Elastic Network Interface of a resource. 

It allows the traffic based on IP, protocol, port or IP address and is **stateful**. 
For all request or response that goes through the Network interface, the rules defined in the security group are evaluated.  

The main differences between this two "virtual firewall" are: 

| Network Access Control List (ACLs)                               | Security Group                               |
| ---------------------------------------------------------------- | -------------------------------------------- |
| Associated to a Subnet                                           | Associated with an Elastic Network Interface |
| Allow rules and deny rules                                       | Allow rules only (Other traffic is denied)   |
| All rules are processes in order                                 | Rules are evaluated before applying          |
| Stateless firewall                                               | Stateful firewall                            |
| Applied to an instance if its within the subnet that has the ACL | Applied to instance if associated with it    |

##### Security Group chaining

Chaining of security group consist in defining a set of layers with security groups that traffic is only enabled between one layer with the following one. 
Its made by only grating outbound connections from a layer to the next one that has inbound set to the same IPs and ports that the incoming traffic of the other layer.
This maintains a high security by denying direct access to elements in bottom layers.

The main security schema is the following: 

![[./IMAGES/AWS-security.png|600|center]]