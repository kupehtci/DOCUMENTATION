#AWS

# AWS 11 Serverless

In Serverless services, AWS handles the underlying infrastructure and management tasks.  

It includes the following advantages: 

* No infraestructure to provision or manage
* No servers to provision or manage
* Scales automatically by unit of consumption
* Pay for value billing model
* Built-in availability
* No need to architect for availability

The most common AWS Serverless resources are: 

* AWS Lambda
* AWS Fargate
* API Gateway
* Amazon S3
* Amazon DynamoDB
* Amazon Aurora serverless
* Amazon Cognito
* Amazon Simple Notification Service (SNS)
* Amazon Simple Queue Service (SQS)
* AWS Step functions
* Amazon Kinesis 
* Amazon Athena

#### API Gateway 

API Gateway is an AWS Service that let you create, publish and maintain, monitor and secure APIs. 

This can be used to connect the applications to AWS services and other public or private websites. It provides RESTful and HTTP APIs for mobile and web applications to access AWS Services and other resources hosted outside AWS

It handles tasks like traffic management, authorization, access control, monitoring and API version management. 

#### Amazon Simple Queue Service (SQS)

SQS allows to create a message queue for realizable service-to-service communication. 

It can process up to billions of messages per day. 

Developers can share SQS queues anonymously or with an account and they can be encrypted. 

It helps to: 

* **Loose coupling**: SQS can decouple processing steps from compute steps and post-processing steps. This uses synchronous processing. 
* **Failure tolerance**: in the event of application exception or transaction failure the order processing can be retried. 
* **Absorbs spikes**: An amazon SQS queue makes the system more resilient and act as a buffer to absorb spikes in the traffic. 

Use cases:

* **Work Queues**: decouple components that might not process the same work at the same time. 
* **Buffering and batch Operations**: add scalability and reliability to the architecture. 
* **Request offloading**: move slow operations off of interactive request paths by queuing the request. 
* **Autoscaling instances**: Use SQS queues to determine the load of an application. Also you can scale an autoscaling EC2 group based on the traffic of the SQS. 

Amazon SQS offers two types of Queues: 

* Standard Queues: at-least-once message delivery and best-effort ordering. Messages are generally delivered in the same order as sent. Can handle nearly unlimited number of API calls. 
* FIFO Queues: enhance messaging when the order of operations and events are critical. It has a limited number of API calls per second. 

Don't use SQS if the mesages are large and you need to only retrieve specific messages. 

#### Amazon SNS

###### Differences between SNS and SQS

| Features            | Amazon SNS | Amazon SQS    |
| ------------------- | ---------- | ------------- |
| Message persistence | NO         | YES           |
|                     |            | poll (Active) |
|                     |            |               |
|                     |            |               |
|                     |            |               |
