#AWS

# AWS - Redshift

**Amazon Redshift** is a fully managed data warehouse for analytics at a high scale. 
It uses a columnar storage and a massively parallel processing (MPP) to run fast SQL queries on large datasets. 

It can run in provisioned clusters or serverless mode with features like: 
* Data compresion
* Materialized views
* Result Catching
* Data Sharing
* Federated queries to RDS, Aurora or S3 data lakes. 


# Redshift Architecture

It uses **Redshift Architecture** where a **Leader** node parses and optimizes the queries and dispatch the work to compute nodes that process the columnar data in parallel. 

## Integrations

Redshift has integrations with: 
* Query data from S3[^1] lakehouse
* Federated queries to Aurora[^2] or RDS[^3].




[^1]: S3 or Simple Storage Solution its a general object storage fully managed solution by AWS [[AWS - S3]].
[^2]: Aurora DB [[AWS - Aurora]]
[^3]: AWS RDS or Relational Data Base