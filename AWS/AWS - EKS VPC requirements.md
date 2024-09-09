#AWS 

# EKS VPC configuration and requirements

When creating an EKS cluster in AWS[^1], it requires a VPC[^2] and at least two subnets[^3] that are in different availability zones. 

This is a list of requirements that need to be meet by the VPC and its subnets in order to deploy an EKS cluster within it and everything works properly: 

* VPC needs to have at least two different subnets in different availability zones. The EKS will create 2 to 4 Elastic Network Interfaces[^5]

* VPC must have an enough number of IPs for the Cluster to provision the cluster, its nodes and the kubernetes resources within it. 
	If the infrastructure has not enough IPs defined in the VPC CIDR blocks, you can add more blocks to it. 

* VPC must have DNS hostname and DNS resolution support in order to let nodes register to the cluster. 

* VPC may require <span style="color:DodgerBlue;">VPC endpoints</span>[^4] using AWS Private Link. 

For more specifications about the VPC configuration for an EKS, take a look into AWS official documentation: [View Amazon EKS networking requirements for VPC and subnets - Amazon EKS](https://docs.aws.amazon.com/eks/latest/userguide/network_reqs.html)

### EKS Networking infrastructure

Taking into account that the EKS needs two subnets and place two Elastic Network Interfaces, one per each subnet, the most recommended infrastructure is to set two private subnets and two public IPs. 

This ensure the aws resources in the private subnets to be accessed from the internet, securing them 
In order to route the traffic from the private subnets to the public subnets, a route to a NAT gateway[^6] must be created. 

[^1]: Amazon Web Services [[AWS - Basics]]
[^2]:Virtual Private cloud is a resource within AWS that let group the resources and manage them in terms of networking.  [[AWS - VPC Virtual Private Cloud]]
[^3]: Subnets are networking separations that can be done within an VPC in AWS and in other networking environments. [[AWS - Subnets]]
[^4]: VPC endpoints [[AWS - VPC Endpoint]]
[^5]: Elastic Network Interfaces [[AWS - ENI Elastic Network Interfaces]] 
[^6]: NAT or Network Address translation gateways [[NAT]] [[AWS - Gateways]]