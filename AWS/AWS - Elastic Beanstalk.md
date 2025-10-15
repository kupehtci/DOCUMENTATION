#AWS 

# AWS Elastic Beanstalk 

Elastic Beanstalk is a provisioning service that help with infrastructure management service by deploying and scaling web applications and service. 

Automatically handles and manages AWS services setup, configuration, scaling and provisioning. 

Its a **PaaS** that allows to deploy and run applications without managing the infrastructure, as it automatically handles: 
* Provisioning of resources (EC2, load balancers and more).
* Scaling based on traffic (Autoscaling)
* Monitoring via CloudWatch [[AWS - Cloudwatch]].
* Updates and patches the platforms. 

### Architecture of each environment

When you create a BeanStalk environment, AWS provides a default architecture: 
1. Web Server Deployment: (HTTP/HTTPs applications): 
	1. EC2 instances
	2. Autoscaling group for the EC2
	3. Elastic Load Balancer (ALB or Classic LB) to distribute traffic
	4. Security groups to handle the network.
	5. VPC with public subets
2. Worker environment (background jobs): 
	1. EC2 instances for running the workers
	2. SQS queue for job processing
	3. Autoscaling based on the queue's size. 
3. Optional database: 
	1. Provision an RDS database. 

Within the default HA architecture you can define: 
* EC2 types of instances and AZs
* Load Balancer properties
* Autoscaling properties and scaling policies
* Health monitoring
* VPCs, subnets.
* Deployment strategies.

### Use cases

The most common use cases for Elastic Beanstalk are: 

* Deploying web applications quickly, example launching a new e-commerce site with minimal infrastructure.
* Manage high availability application or applications with variable traffic. 
* Blue/green deployments for **feature testing** as it allows to test new features safely in a separate environment and do URL Swapping to move users to the new environment instantly. 
* Worker environments
* Rapid prototyping. 
* Microservices deployment, deploying multiple services as separate Beanstalk environments. 

## Deployment strategies

Its ofter used when developers needs to test new features constantly, as it allow to create various environments and switch traffic between them using deployment strategies. 

| Deployment Type                   | Description                                                                                  | Pros                                                          | Cons                                                                        |
| --------------------------------- | -------------------------------------------------------------------------------------------- | ------------------------------------------------------------- | --------------------------------------------------------------------------- |
| **All at once**                   | Deploys the new version to **all instances simultaneously**.                                 | Fastest deployment.                                           | Causes **downtime**, not recommended for production.                        |
| **Rolling**                       | Deploys the new version **in batches** across existing instances.                            | Reduces downtime compared to all-at-once.                     | Partial downtime possible; may leave some users on old version temporarily. |
| **Rolling with additional batch** | Adds **extra instances** for deployment, deploys in batches, then removes extra instances.   | **Minimizes downtime**; safer than simple rolling.            | Slightly higher cost during deployment due to extra instances.              |
| **Immutable**                     | Launches a **separate set of instances** with the new version, then swaps them in.           | Zero downtime; safe rollback.                                 | Higher cost because new instances are provisioned temporarily.              |
| **Blue/Green (URL swapping)**     | Deploys new version to a **separate environment**, then swaps **CNAME/URL** to make it live. | Zero downtime; easy rollback; ideal for testing new features. | Slightly more setup effort; temporary duplication of environments.          |


### URL Swapping

**URL Swapping** is a technique used for blue/green deployments in Elastic Beanstalk to switch traffic between two environments.

It allows to redirect users to the new environments instantly without downtime