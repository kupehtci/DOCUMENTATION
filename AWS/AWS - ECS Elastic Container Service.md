#AWS 

# AWS ECS 

Amazon ECS or Elastic Container Service is an AWS Docker container service that handles management and provisioning of docker containers. 

Its a **fully managed service** so it comes with AWS configuration and integration with third-party tools like Amazon Elastic Container Registry and Docker. 

This helps to abstract the applications from the environment where they are running

The ECS service uses other instances like EC2[^2] and control them to launch containers within the machines associated to the ECS cluster. It uses this virtual machines in order to run and control the containers cluster.  

For registering a EC2 machine to an ECS cluster, it needs to have Amazon ECS container agent running within it. 
This can be done manually or using an AMI (Amazon Machine Image) such as Amazon ECS-optimized AMI which is an altered image to run ECS. 

### Launch types

ECS needs a compute resource to run its workload, so the launch types defines where and how the AWS ECS's tasks (Containers) run. 

It can be one of the following: 

| Launch type  | what it is                                                                                                       | Who manages the compute                                                                  | Use Case                                                                 |
| :----------- | ---------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------- | ------------------------------------------------------------------------ |
| Fargate      | Serverless container where you specify he CPU/Memory and networking                                              | AWS fully managed                                                                        | Minimize operational overhead, webapps, APIs and microservices           |
| EC2          | Containers run on EC2                                                                                            | Manually managed EC2 instances                                                           | Custom OS settings or special instance types like for GPU or high memory |
| ECS Anywhere | Run ECS tasks on on-premise servers or Virtual Machines. Servers need to be registered as ECS Anywhere Instances | You manage the on-premise servers and ECS manages the task scheduling and orchestration. | Hybrid cloud or edge computing.                                          |

In the EC2 launch type, you must manage the EC2 instances manually (patching, scaling, AMIs and more), so has a higher operational overhead. 

### Differences with EC2

EC2[^2] and ECS are totally different. 

[^2]: Elastic Cloud Computing instances are cloud servers provided by Amazon Web Services [[AWS - EC2]]