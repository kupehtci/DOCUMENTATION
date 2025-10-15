#AWS 

# AWS Kinesis

**AWS Kinesis** is a fully managed service for real-time streaming data that can collect, process and analyze streaming data at scale. 

Its normally used for: 
* log and event data collection (web clicks, app events and IoT sensors)
* Real time analytics dashboards
* Feed the data into data lakes or warehouses (Like S3 or Redshift)

---
### Components

It has different components: 

#### Kinesis Data Streams (KDS)

Is a streaming platform por real-time data ingestion. 
You manage shards ans scaling and consumers like EC2 or Lambda reads and process  the stream.

### Kinesis Data Firehose

Fully managed data delivery service that streams the incoming data into S3, Redshift, OpenSearch or Splunk. 
It handles batching, compression, encryption and scaling. 

Has the **least operational overhead** as there are no servers to manage. 

### Kinesis Data Analytics

Process streaming data using SQL or Apache Flink, enabling real-time analytics of the stream data before storage. 

---

## Kinesis Firehose or Kinesis Data Analytics

Use firehose for simple delivery of the data and data analytics for real-time queries. 

---

### Key features

* **Real time processing**: As data is processed as it arrives, not after storage
* **Scalable**: can handle gigabytes per second of data
* **Durable**: replicated streams across AZs
* **Integrated**: works with S3, Redshift, Lambda, Elastic Beanstalk, firehose and more
