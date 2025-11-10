#AWS 

# AWS Fargate

**AWS Fargate** is a serverless solution for running containerized applications. 

By using Fargate you get a total abstraction of the environment, Fargate manages the infrastructure for you, it doesn't need to provision servers or infrastructure management.   

It works with: 
* Amazon ECS[^1] for running single container workloads
* Amazon EKS[^2] for running multi-container workloads

A **Fargate Task** its a basic unit of work, a simple definition of: 
* Container image
* CPU and Memory requirements
* Networking settings
* IAM Roles
* Environmental variables or volumes
It will automatically provision the compute layer and run the task. 

## Launch types

There are two different launch types, similar to EC2 types: 
* **Fargate On-Demand**: default fargate solution where you pay per vCPU and GiB RAM per hour. 
* **Fargate Spot**: Similar to EC2 Spot Instances [^3] where it uses the spare fargate capacity of the AWS datacenters to run tasks at a much lower price.
	* Tasks can be interrupted by AWS with only a 2 minute warning. 
	* Best for batch jobs and background processing and not for web servers or production APIs. 


## Use cases

Take into account that Fargate is a costly service, so use when you need: 
* Avoid EC2 fleets for ECS or EKS clusters
* Workloads that can scale up or down frequently
* Better isolation per pod



[^1]: ECS or Elastic Container Service [[AWS - ECS Elastic Container Service]]
[^2]: EKS or Elastic Kubernetes Service [[AWS - EKS Elastic Kubernetes Service]]
[^3]: Amazon EC2 Spot Instances [[AWS - EC2]]
