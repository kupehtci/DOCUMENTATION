#AWS 


## AWS Simple Queue Service

Simple Queue Service, also called SQS, is a message queuing service from AWS[^aws] that exchanges and stores messaged between components within the infrastructure.

A service add messages in the queue an users or service can pick up this messages form the queue. Once they are processes, they gets deleted. 


### Types of queues

SQS has two different types of queue types: 
* **Standard**: Default queue tipe that process at least one delivery and its unordered. Its recommendable for high-throughput systems.
* **FIFO**: process exactly-once and its ordered. Recommended for event logs or payment processing. 

## How SQS Works

An SQS works as follows: 

1. A producer sends a message to the SQS queue.
2. Message is stored redundantly across multiples AZs
3. Consumer polls the queue and process a message
4. Message needs to be deteled after a successful processing

The **Visibility Timeout** its the time after a message has been polled until it becomes visible again if the consumer haven't delete it. 

## Integrations

SQS integrates with many AWS services as origin or target of the messages: 

* **AWS Lambda**: can poll SQS messages via **event source mapping** and processes messages without servers. 
* **Amazon SNS**: SQS can subscribe to SNS topics to deliver the same message to multiple queues allowing parallel processing. 
* **Event Bridge**: 
	* SQS can be a target of EventBridge so it sends events to a Queue. 
	* Can be integrated with SQS for scheduled events so a message is received by EventBridge.
* **Amazon S3**: Can send object-created events to SQS. 
* **EC2**: A custom application can recieve SQS messages through an SDK. 
* **AutoScaling group**: An autoscaling group can access two different metrics to scale up or down depending on them: 
	* `ApproximateNumberOfMessages` (queue depth)
	* `ApproximateAgeOfOldestMessage` (message wait time)

## Redrive policy

A Redrive policy is a type of policy configurable in an SQS that redirects a message after a `MaxReceiveCount` number of attempts to deliver the message to a target. 

If the target doesn't not delete the message once its completed or becomes visible more than that number because of the target fails to complete it, it will redirect the message to another service. 

The target of a **redrive policy** its normally a DLQ or Dead Letter Queue [^dlq]. 

## Use cases

In distributed systems, components that should not depend on each other execution so its very useful for: 
* Service coupling (One service is waiting on another) so by implementing SQS you can decouple their execution.
* Failure propagation (If one systems fails, as its coupled with another, the whole system fails). 
* Scaling issues during traffic spikes.

So the most common use cases are: 
* Decoupling microservices
* Buffering requests so can work under traffic spikes
* Serverless workflows using SQS + Lambda [^lambda]

## SSE-SQS

**Server Side Encryption for Simple Queue Service** or **SSE-SQS** encrypts SQS mesages at rest using AWS-Managed encryption keys[^2]. 

[^aws]: Amazon Web Services [[AWS - Basics]]
[^2]: KMS or Key Management System managed by AWS [[AWS - KMS Key Management Service]]
[^lambda]: AWS Lambda [[AWS - Lambda]]
[^dlq]: Dead Letter Queue [[AWS - DLQ Dead Letter Queue]]
