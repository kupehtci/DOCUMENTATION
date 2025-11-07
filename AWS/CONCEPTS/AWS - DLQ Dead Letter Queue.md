#AWS 

# AWS - Dead Letter Queue or DLQ

An **AWS Dead Letter Queue** is an special queue used to hold messages that cannot be processed because of corruption, invalid format, missing fields, bussiness logic failures or others. 

Its not an AWS resource as is, its a type of usage of an SQS or Simple Queue Service [^sqs]

Instead of retrying a failed message forever or losing the message, configure SQS with a **redrive policy** to after a set of maximum attempts the message is sent to a DLQ. 


A SQS workflow that integrates an DLQ is: 

- A message is delivered to a consumer for example Lambda. 
- The consumer fails to process it
- The consumer does not delete the message
	- so it becomes visible again after the visibility timeout and lambda can fail. 
- After **maxReceiveCount** (e.g., 3 attempts), SQS moves the message to the **dead-letter queue or DLQ**.


[^sqs]: Simple Queue Service or SQS [[AWS - SQS Simple Queue Service]]

