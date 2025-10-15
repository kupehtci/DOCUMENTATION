#AWS 

# AWS Subnets

An AWS subnet is a range of IPs logically separated in the VPC. 

The resources in different subnets are isolated from other subnets resources. 


### Private and public Subnets

The main difference between public and private subnets within AWS, its the 0.0.0.0/0 route in the route table. 

A private subnet set this route to a NAT gateway /instance, on the other hand, a public subnet set this 0.0.0.0/0 route to an internet gateway (IGW). 

### Terraform

A subnet resource in terraform format will have the following structure: 

