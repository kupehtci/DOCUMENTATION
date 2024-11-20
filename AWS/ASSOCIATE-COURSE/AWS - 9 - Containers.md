#AWS 

# AWS 9 Containers

Containers are meant to make applications independent from others and isolated. 
Changes in one application can not affect other containers and we can make sure that a container will run without problems or errors in all environments.


AWS has some legacy applications to handle containers for applications: 

---
#### Loose coupling

Loose coupling imply the use of managed solutions as intermediaries between different layers of the system. 
The different services of the application are not attached between them and we need to handle its communication and use together. 

These can be solved with load balancing and message queues. 

---

These Microservices architecture imply designing the infraestructure as small services. 

In the case of running Docker containers within an EC2 which its a virtual machine, imply having a docker running in top of an hypervisor. 

![[./IMAGES/EC2-docker.png|350]]

#### Running containers on AWS. 

Running containers in AWS involves selecting and configuring some components: 

* Registry: store the container images that holds everything to run the container. Includes application code, runtime, system tools, system libraries and settings. You push this images to the respository and can be pulled in order to run the container. 

AWS ECR or Elastic Container Registry is a docker images registry for holding all this images in AWS.

* Orchestration tool: A container orchestration tool is used to manage the containerized applications at scale. They help to manage the containers start-ups, shutdowns, monitor health, deployes and manages. 
	* EKS or Elastic Kubernetes Service is a managed service for running Kubernetes Orchestration software on AWS. Allow more configuration in environments with multiple containers. 
	* Amazon ECS is a managed orchestration  service that offer a managed model for deploying containers. ECS offers also additional integrations with other AWS services. 
* Container Hosting: we also need to define the compute resource that the orchestration tool will use to host and run the container's workload. 
	* Amazon EC2 to launch containers and we can scale the number of instances as the traffic varies. This method is cost-effective. 
	* AWS Fargate is a serverless hosting service that automatically allocates CPU and memory resources to support containers. 

#### Elastic Container Registry

Amazon Elastic Container Registry or ECR is a managed Docker Container registry. 

You can push container images to Amazon ECR and can pull those images to launch the containers. 
With ECR you can also manage versioning and image tags.


#### Elastic Kubernetes Service (EKS)

Kubernetes is an open-source to deploy a managed containerized applications at scale. 
Kubernetes manages clusters of Amazon EC2 compute instances and run containers in those instancess with processes for deployment, maintenance and scaling. 

EKS is a managed kubernetes service in AWS cloud that provide high availabililty and secvure clusters with automate tasks such as patching, node provisioning and updates. 

