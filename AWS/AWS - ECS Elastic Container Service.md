#AWS 

# AWS ECS 

Amazon ECS or Elastic Container Service is an AWS Docker container service that handles management and provisioning of docker containers. 

Its a **fully managed service** so it comes with AWS configuration and integration with third-party tools like Amazon Elastic Container Registry and Docker. 

This helps to abstract the applications from the environment where they are running

The ECS service uses other instances like EC2[^2] and control them to launch containers within the machines associated to the ECS cluster. It uses this virtual machines in order to run and control the containers cluster.  

For registering a EC2 machine to an ECS cluster, it needs to have Amazon ECS container agent running within it. 
This can be done manually or using an AMI (Amazon Machine Image) such as Amazon ECS-optimized AMI which is an altered image to run ECS. 
### Differences with EC2

EC2[^2] and ECS are totally different. 

[^2]: Elastic Cloud Computing instances are cloud servers provided by Amazon Web Services [[AWS - EC2]]