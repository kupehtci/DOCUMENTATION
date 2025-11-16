 #AWS 

# AWS - Batch

**AWS Batch** is a fully managed service to easily run batch computing workloads on AWS by provisioning the optimal amount of computing resources based on volume and requirements of the jobs. 

**Batch workloads** are jobs or tasks that run asynchronously without user interaction like processing large amounts of logs files, simulations, video rendering or ETL tasks. 

The key features of **AWS Batch** are: 
* **Managed Compute**: AWS is in charge of provisioning EC2 or Spot instances based on job requirements.
	* has less limitations like 15 min execution limitation on Lambda executions
	* **Spot or On-demand instances**: support spot instances for costs savings or On-Demand for guaranteed resources. 
	* **Fargate**: allow to run Jobs in the serverles solution that brings AWS Fargate[^3]
* **Job queues**: jobs are submitted to queues that uses Batch to schedule jobs based on priority.
* **Jobs definitions**: you can define: 
	* Job container
	* CPU
	* Memory
	* IAM Role
	* Environmental variables
	* Dependencies
* **Integration with Docker**[^1]: AWS Batch runs jobs in **Docker containers**[^2].
	* Accept multiple programming languages and are independent of environment and has all dependencies needed to run.
* **Dependency**: supports to "link" jobs so one runs after another completes. 


[^1]: Docker containerization [[DOCKER]]
[^2]: Docker containers [[DOCKER - Containers]]
[^3]: AWS Fargate [[AWS - Fargate]]