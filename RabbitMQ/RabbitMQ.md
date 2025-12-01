#RabbitMQ

# RabbitMQ

**RabbitMQ** is an open-source message broker that enables a reliable communication between distributed applications and services. 

This message broker is in charge of the routing and queuing of the messages by implementing AMQP (Advanced Message Queuing Protocol)[^1].

Its core architecture its based in a pub/sub architecture with queuing: 
* **Producers** create messages and send them to an **exchange**. 
* **Exchanges** route messages to one or more queues. 
* **Queues** store the messages until they are consumed. 
* **Consumers** retrieve and process messages from queues at their own pace. 

RabbitMQ ensures that messages aren't lost through multiple mechanisms: 
* **Consumer Acknowledgements**: consumers must explicitly confirm that the message has been correctly processed so RabbitMQ can delete it from the queue. 
* **Publisher confirmations**: publishers receive explicit confirmations that RabbitMQ has received the message. 
* **Message persistence in durable queues**: messages marked as persistent are written into disk when written into durable queues. 
* **Clustering**: RabbitMQ replicates messages accross multiple nodes that compose a cluster: 
	* Available when Classic Mirrored Queues or Quorum queues are enabled. 

## Exchange types

RabbitMQ provides different exchanges for providing a flexible message routing: 
* **Direct exchanges**: route messages to queues where the routing key matches. 
* **Topic exchanges**: pattern matching ro route messages bassed on routing key patterns
* **Fanout exchanges**: broadcast messages to all bounded queues regardless of routing keys. 
* **Header exchanges**: route based on message header attributes. 




[^1]: AMQP (Advanced Message Queuing Protocol) [[AMQP - Advanced Message Queuing Protocol]]