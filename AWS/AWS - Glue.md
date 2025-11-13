#AWS

# AWS - Glue

**AWS Glue** is a fully managed, serverless data integration service that makes it easy to discover, prepare, and combine data for analytics, machine learning, and application development.

It helps organizations move data between **different sources and targets** without 
managing servers or infrastructure.

### Components

**AWS Glue** has the following main components: 

* **Data Catalog**: central metadata repository that stores table definitions, schemas and location of the data. 
* **ETL** for extract from sources, transform ir and load into targets
	* Supports python (PySpark) scripts for defining the ETL pipelines
* **Crawlers**: automatically scan the data stores from S3, RDS, Redshift to detect schema changes and populate the **data catalog**. 
* **Jobs**: ETL jobs that process and move the data than can be run: 
	* on-demand
	* on a schedule
	* in response to events (Via EventBridge). 

### Connections to data storages

- **AWS**: S3, RDS, Redshift, DynamoDB, JDBC databases, FSx for Lustre    
- **On-premises**: via JDBC or connectors
- **Other sources**: SaaS via connectors (e.g., Salesforce, Snowflake)


# Glue DataBrew

**AWS Glue DataBrew** is a fully managed data preparation service that can clean, normalize and transform data without writing custom code. 

# Glue Scala and Glue PySpark

Both are programming options for coding an AWS Glue ETL job that runs in an Apache Spark environment. 

Glue Scala uses Scala libraries (Dynamic Frame and Relationalize as an example) while PySpark uses this library with Python's extensions like DynamicFrame or transforms for schema handling and ETL patterns. 

Both ETL jobs are charged by DPU-hour, costing aroing 0.44 USD per hour of execution. (1 DPU its 4vCPUs and 16GB RAM): 
* Normally higher cost than a Lambda job execution. 