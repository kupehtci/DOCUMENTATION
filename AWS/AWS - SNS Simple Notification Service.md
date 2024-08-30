#AWS

## SNS Simple Notification Service


SNS is a cloud service for massive delivery of messages. 

Its a web service that automates the process of sending notifications to the subscribers attached to it. This can be application-to-person or application-to-application. 

Its cost efficient and provides a low-cost infrastructure. 

It send SMS or emails to an Amazon Simple Queue Service (SQS)[^sqs], AWS lambda functions or HTTP endpoints. 

For example, if a CPU usage gets higher than 80% triggers a AWS cloudwatch[^cw] alarm and activates the correspondent SNS to notify subscribers about the high CPU usage. 

### How it works

The <span style="color:DodgerBlue;">Publishers</span> communicate asynchronously by producing and sending an message to a topic, not to each receptor. 
In another part, the <span style="color:MediumSlateBlue;">subscribers</span> like servers, email addresses, SQS queues, Lambda functions[^lam] receive the notification of the topics that are subscribed to. 
### Use cases of SNS

* Decouples the microservices by letting them communicate asynchronously between them. 
* Send notifications to users or operators. 


[^sqs]: SQS or Simple Queue Service is a message queuing service [[AWS - SQS Simple Queue Service]]
[^cw]: AWS Cloudwatch monitoring resource [[AWS - Cloudwatch]]
[^lam]: AWS Lambda functions [[AWS - Lambda]]