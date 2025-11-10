#APACHE 

# Apache Kafka

**Apache Kafka**

Apache Kafka[^1] its an open-source distributed streaming platform used to publish, store and process streams of records in real time at high-scale. 

Used to built **real-time data pipelines** to event-driven applications. 

It has different components: 
* Topics and partitions: data its organized into topic, split into partitions for paralelism and scalability. 
* Producers and consumers: producers write events to topis and consumers read them (Also consumer groups) and ensures that each partition is consumed by only one group member at a time. 
* Offset and durability: each record in a partition has a sequential offset that Kafka persist on disk and replicated accross nodes to tolerate failues. 

Applications can publish events to kafka and subscribe to topics to recieve new data that its published on them. 

Its commonly used in: 
* Real time analytics
* Event-driven microservices communication and decoupling.
* Data integration pipelines with Kakfa Connect. 
