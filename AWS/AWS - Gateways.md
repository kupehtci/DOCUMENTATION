#AWS 

# AWS - Gateways

There are different gateways to access VPC resources in AWS: 

### Internet Gateway

The AWS internet gateway is a proxy or a door between the VPC[^1] and the internet. 

Without it, the resources within the VPC cannot be access from the internet. 

### Virtual Private gateway

Its used to access private resources within the VPC. 

Compared to the internet gateway, this only allows traffic from a certain endpoint and has extra layers of protection. 

Maintains the internet traffic encrypted between the endpoint and the Virtual Private Gateway's VPC's endpoint. 

The connection to the VPG is a Virtual Private Network or VPN[^2]

### AWS Direct Connect

Makes a direct dedicated private connection between the data center and a VPC.

The link between the two its not shared with others. 

[^1]: VPC o Virtual Private Cloud [[AWS - VPC Virtual Private Cloud]]
[^2]: VPN or Virtual Private Network  [[VPN]]