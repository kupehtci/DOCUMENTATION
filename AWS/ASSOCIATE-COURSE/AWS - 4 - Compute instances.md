
### AWS Compute instances

In AWS there are some different types of compute instances: 

* Amazon EC2
* Amazon Elastic Container Service (ECS)
* AWS Lambda
* AWS Fargate
* AWS Inferentia and trainium processors
* AWS Graviton processors

ECS allows to runs containers in order to improve: 

* Platform independence: resources deployed within the container are not attached to an OS so it can be launched everywhere. 
* Consistent runtime: it wont be installed more services or applications within the same container
* Higher resource use: optimize the resources used by the container
* Easier and faster deployments: containers are better for settling up a deployment. 
* Isolation: containers are isolated environments for the executed code. 

Also other resources are available to run containers such as ECS that runs distributed applications in a managed EC2 instances using docker or by using kubernetes for microservices containerized applications within EKS or Elastic Kubernetes Service. 

AWS Lambda is a serverless computing service to run code without needing to provision an EC2 instance. 
Also AWS Fargate gives a serverless computing service for running containers. 

Inferentia chips for EC2 are specialized processors for AI and years later Trainium processorswere released as a more optimized chip for deep learning. 

Graviton Processors for EC2 are built around ARM cores and are optimized for scale-out workloads to share workload across multiple smaller instances. 

### EC2 or Elastic Cloud Compute

EC2 is a virtual machine within the AWS cloud. Its like a traditional Virtualized On-Premise server and support servers, databases, storage and higher-level application components that can be installed like in a traditional server.  

#### AMI


AMIs can also be set to public, so can be freely use by the community or share with other AWS accounts. 

#### Instance types

The virtualized hardware of the EC2 machines is defined by the type of the machine and its size.

The type define the realation of hardware properties and the size define the amount of hardware following that relation. 

The types and size are defined by a set of characters: 

```txt
c6g.xlarge
```

General purpose has a ratio of 4 to 1 in relation of vCPU to vRAM

![[AWS-EC2-TYPES.png]]

### Elastic Network Interface

Elastic Network Interface > Elastic Network Adapter > Elastic Fabric Adapter

##### User data

When creating an EC2, we can define User Data, that is a little script that will be run when the EC2 is launched.

This can be used for example to install a little HTTP server, install SQL server or other procedures. 


### Spot machines

The spot machines use the same infrastructure and hardware as on demand and savings plan. 
You get the best value for the machines by setting the price that you want to pay for the machines and if they are "on discount" you provide more machines and if the price goes up, they are removed. 

This can be use to schedule workloads for when the machines for handling its workload are more cheap.

Also image rendering and use for  big data and analytics. 


### AWS Lambda


AWS lambda is a serverless event-driven 

All the resources that the AWS lambda needs, need to be in serverless AWS services, configurations, files, users, data, databases and others. 

It helps to runs an workload in response to an event. It most commonly used for isolated 