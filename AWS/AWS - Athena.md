#AWS 

# AWS - Athena

**Amazon Athena** is a **serverless interactive query service** that allows you to analyze data directly in Amazon S3 using standard SQL queries. 

As its **serverless** you don't need to manage infrastructure, Athena will scale to execute the queries. 

Ideal for: 
* ad-hoc queries
* log analysis
* data exploration

On data: 
* Structured datasets
* Semi-structured datasets
* Unstructured datasets

Can also be integrated with other services like DynamoDB using **connectors**. 
**Connectors** are integrations of SQL queries into native operations, like DynamoDB queries. 

### Key features

* **Serverless**: no need to provision infrastructure.
* **Standard SQL Support**: Supports ANSI SQL 
* **Integration with S3**: integrates with S3 data without ETL transformation or moving anywhere else. 
* **Integration with Glue Data Catalog** to store data's schemas. 

## Amazon Athena Federated Query

Federated Query lets to run SQL in Athena that reads data form multiple sources through connectors and stream the results back into Athena so you can SELECT or JOIN as if were a regular SQL table. 
Federated imply that can query multiple and independent data sources (like S3 and Dynamo) at the same time without moving the data. 

