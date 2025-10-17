#AWS

# AWS - EC2 Spot Fleet

**EC2 Spot Fleet** is a set of EC2 spot instances [^1][^2] or On-Demand instances that AWS launches to meet a pre-defined target capacity. 

It automates the process of requesting, maintaining and scaling a group of Spot Instances. 

You can handle multiple instance types and AZs using the Fleet API to find best price and availability. 

In short terms, is a Spot instance manager for scalable and cost-efficient computing. 


### How it works? 

You define a target capacity like 100 vCPUs and give AWS a launch configuration like allowed types, AZs, price preferences and weighting. 

AWS will launch a combination of Spot instances (Optionally also On-Demand) instances to meet the required target. 
If any Spot instance is interrupted or terminated, Spot Fleet will automatically replace it. 

### Use cases

The workloads need to be able to handle interruptions. 
Its recommendable for a workload that required a lot of capacity. 

improves availability and lower costs. 

Similar use cases to Spot Instances: 
* Batch jobs that require a high capacity
* Data analysis with reduced costs
* CI/CD builds. 
* Video rendering
* Web crawling
* ML learning and training. 

But its more recomendable for large workloads than single Spot instances. 

[^1]: [[AWS - EC2]] EC2 types of machines
[^2]: [[AWS - 4 - Compute instances]] Computing instances