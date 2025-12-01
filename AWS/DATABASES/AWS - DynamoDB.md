#AWS 

# AWS DynamoDB

**AWS DynamoDB** is an AWS's fully managed, serverless and NoSQL database service. 

Offers single digit miliseconds latency at any scale with high availability, scalability and security.

Key characteristics: 

* **NoSQL database** -> stores data in key-value structures 
* **Managed service** -> No need to manage servers, replication, patching or scaling. 
* **Performance** -> Consistently fast.
* **Scalable** -> Scales automatically. 
* **Highly available** -> Data is replicated across multiple AZ in a region. 
* **Serverles** -> Doesnt need to manage a server.


## Global tables

Enables multi-region and multi-active data replication. 
This lets the application connected to the DynamoDB to be available worlwide.

## Recovery

### Point-in-Time Recovery (PITR)

DynamoDB's PITR automatically maintains a continuous backup of the table data **for the last 35 days**, allowing you to restore the table to any second within the last retention periods. 

## Caching
### Amazon DynamoDB Accelerator (DAX)

Amazon DynamoDB Accelerator is a fully managed, in-memory cache designed to speed-up read-heavy workloads for Amazon DynamoDB. 

With DAX, reads are served from in-memory DAX cluster (latency in **microseconds**). 

DAX is like Redis for DynamoDB. 

## Provision modes

DynamoDB offers two modes for handling read and write performance: 

* `Provisioned`: you specify the number of read (RCUs) and write capacity units (WCUs) the DynamoDB table needs and DynamoDB will allocate resources based on these things
	* Appropriate for fixed and predictable request rate. 
* `On-Demand`: DynamoDB scales to handle any traffic request without specifying performance metrics. 
	* Appropriate for unpredictable traffic. 
