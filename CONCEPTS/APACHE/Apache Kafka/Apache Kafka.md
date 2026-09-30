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

## Architecture

* **Brokers**: the servers that make up a Kafka cluster, each one storing a subset of the partitions.
* **Replication**: each partition is replicated across multiple brokers (a leader plus followers), so if a broker fails another replica can take over without losing data.
* **Cluster coordination**: traditionally handled by an external [[Apache ZooKeeper]] cluster (electing partition leaders, tracking broker membership). Newer Kafka versions use **KRaft**, a built-in consensus protocol, removing the ZooKeeper dependency.

## Ecosystem tools

* **Kafka Connect**: a framework for moving data in and out of Kafka using pre-built connectors (databases, S3, Elasticsearch...) without writing custom producer/consumer code.
* **Kafka Streams**: a Java library for building stream-processing applications directly on top of Kafka, as an alternative to running a separate engine like [[Apache Flink]] or [[Apache Spark]].

## Related

* [[AWS - Amazon MSK Managed Streaming for Apache Kafka]] — AWS's managed Kafka service.
* [[AWS - SQS Simple Queue Service]] — a simpler managed [[Queue]], useful to contrast with Kafka's log-based, replayable model.
* [[Apache Flink]] — a common stream-processing engine consuming from and producing to Kafka topics.
