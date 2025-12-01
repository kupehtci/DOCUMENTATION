#AWS 

# Amazon Neptune

**Amazon Neptune** is a fully managed Graph database service designed for highly connected data sets and complex relationships between data entities. 

It supports property graph and RDF (Resource Description Framework) models. 


Similar to Neo4J[^1] graph database, that can be also queries using Cypher GQL (Graph Query Language)

# Neptune Streams

**Neptune Streams** is an Amazon Neptune feature that provides real-time change-log of all modifications made to the graph data (registers all inserts, updates and deletes). 

The stream of data can be consumed by external applications or AWS resources like: 
* **AWS Lambda**[^2]: to process or execute custom code under events. 
* **Amazon Kinesis Data Streams**: ingests Neptune changelogs into streaming analytics pipelines [[AWS - Kinesis]]
* **Amazon S3**[^3]: to store the change events
* **AWS Glue**: for ETL operations and streaming the change-log into a data lake. 
* **Amazon Elasticsearch / Opensearch**: for indexing and offer a high optimized search service over historical changes made in the database. 
* **Amazon SNS / SQS**: for notification to multiple resources or queuing patterns 


[^1]: Neo4j its a graph like  NoSQL database [[NEO4J - Basics]]. 
[^2]: AWS Lambda [[AWS - Lambda]]
[^3]: Amazon S3