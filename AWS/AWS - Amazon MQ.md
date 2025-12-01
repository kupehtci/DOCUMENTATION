#AWS 

# Amazon MQ

**Amazon MQ** is a fully managed message broker in AWS that uses Apache ActiveMQ or RabbitMQ[^1]. 

It handles for you the costs and maintenance of handling a message brocket, deploying a production-ready message broker in minutes without worrying in the underlying infrastructure. 

The most common use cases for Amazon MQ as wells as for RabbitMQ are: 
* **Decoupling services**: decouples asynchronous communication between services_ 
	* **Microservices communication**
* **Task distribution** distributes tasks between various nodes. 
* **Background job**: jobs can be send to Amazon MQ and nodes to process them. (Similar to Amazon SQS[^2] behavior in parallel with SNS[^2])
* **Remote Procedure Calls or RPC**
* **Complex message routing**
* **Reliable delivery**: ensuring that message exchange between two parties is reliable. 


[^1]: RabbitMQ is an open source application that acts as an message broker with a pub/sub pattern with queues for delivery and exchange of messages [[RabbitMQ]]
[^1]: SQS or Simple Queue Service [[AWS - SQS Simple Queue Service]]
[^2]: SNS or Simple Notification Service [[AWS - SNS Simple Notification Service]]
