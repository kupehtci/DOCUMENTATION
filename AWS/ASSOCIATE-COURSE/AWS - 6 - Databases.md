#AWS 

# AWS 6 Databases 

AWS provide different Databases as services:

* Amazon Relational Database Service (RDS)
* Amazon Aurora
* Amazon Redshift
* Amazon DocumentDB
* Amazon DynamoDB 
* Elastic Cache
* Amazon MemoryDB for redis
* Amazon Keyspaces (Apache cassandra)
* Amazon Timestream
* Amazon Neptune
* Amazon Quantum Ledger Database (Amazon QLDB)


Relational and no-relational Databases depends on the type of data that is going to be stored and the language used to realize CRUD operations over it. 


### Amazon RDS

It uses Amazon Aurora, PostgreSQL, MySQL, MariaDB, Oracle and SQL Server and estandarized the configuration, operations and usage independent of the SQL database used as backend. 

#### Amazon RDS Multi-AZ failover

An Amazon RDS can have an slave in multiple Availability Zones, and in case of the master fails, it recover the availability by exchanging with the other one present in the other availability zone. 

#### Amazon RDS read replicas

You can create read replicas of the database and AWS keeps them synced. 
They help to relieve pressure on the primary node and bring data closer to different AWS regions. 
### Amazon Aurora

Is a MySQL and PostgreSQL compatible relational database designed specially for the cloud. 
It offer a high performance, high available and durable database, also maintaining high security standard.
It decouples the compute workload layer from the storage layer. 

It maintain a high availability by maintaining 6 copies between different Availability Zones. 

It uses Aurora DB clusters. Each DB cluster consist in one or more DB instances and a cluster volume. 
The primary instances perform R/W operations while aurora replicas are read-only. 
An aurora cluster volume is a virtual database storage volume that spans multiple Availability Zones. 

**Aurora Serverless** is an scaling autoconfiguration for Aurora that automatically scales the capacity to handle requests. 

### Amazon DynamoDB

Amazon DynamoDB is a fully managed NoSQL key-value storage service.
The service automatically manages the distributed NoSQL database and offer autoscaling. 

It supports encryption and fine-grain access control. 

It supports structures of key-value pairs with a flexible schema. All data is mapped to a primary key and can be retrieved using that primary key. 
It partitions the data by key. 

This key-value pairs are stored in tables with a table name and a partition key: 

* **single primary key**: its a single primary key composed of one attribute
* **composite primary key**: a composite primary key is composed of a partition key and a sort key. In this case the partition key can be the same in different entries but sort cannot be equal. 

Its cost-effective, so you pay for the storage and the I/O operations that are done. 

It measures the capacity in Read capacity units (RCUs) and Write capacity Units (WCUs) and you can set the DynamoDB capacity in two ways: 

* On-demand: pay per request. its best for unknown workloads
* provisioned: set a maximum number of RCUs and WCUs and the excees are queued.

##### DynamoDB global tables

A **global table** is a collection of one or more DynamoDB tables owned by a single AWS account and the replica table of that collection will be distributed in different regions. 
DynamoDB manages the tasks to maintain the consistency between all the replicas. 


#### Database caching

Caching of some resources can be used to: 
* speed and expense
* helps with data and access pattern
* cache validity

With caching, an instance first try to read from a cache like Amazon Elastic Cache or DynamoDB Accelerator (DAX) in memory databases. If the data is not in the cache is retrieved from the source. 

It uses **lazy loading**, where is the request fails to the cache, it gets retrieved from the database and then  stored in the cache. 
Also other option is **write-through** where the when you write data in the database is also written in the cache. It must have more data space that may not be used.  

The cache is managed by evicting data when the cache memory is full or use TTL or Time to live of the data in the cache. 

##### Amazon ElastiCache

Amazon ElastiCache is a web service that eases setting up and manage an in-memory data store for a cache environement. 

It offers managed capabilities for two in-memory data stores: 

* MemCached: For data intensive applications. Service works as in-memory data store. It offers multi-threading. 
* Redis: is memory data storage for internet scale. Combines speed and scalability. 

|                                          | ElastiCache for MemCached | ElasticCache for Redis |
| ---------------------------------------- | ------------------------- | ---------------------- |
| Simple cache to offload database         | YES                       | YES                    |
| Scale horizontally for write and storage | YES                       | YES (Cluster mode)     |
| MultiAZ deployments                      | YES                       | YES                    |
| Multi-threaded performance               | YES                       |                        |
| Advanced data types                      |                           | YES                    |
| Sorting and ranking datasets             |                           | YES                    |
| Publish and subscribe capability         |                           | YES                    |
| Backup and restore                       |                           | YES                    |

##### Amazon DynamoDB Accelerator (DAX

 You can use DAX or DynamoDB accelerator for reducing the response time of the DynamoDB from miliseconds to microseconds. 
DAX is a caching service for DynamoDB for demanding applications. 

#### AWS Database migration system

AWS Database migration service or AWS DMS replicated data from a source to a target database in AWS cloud. 
By defining a source and a target connection you can predefine the ETL conversion to transform and migrate the data. 
Ir provides homogeneous migrations (Same database engine) and heterogeneous (different engines) migrations. 
For heterogeneous migrations, you can use AWS Schema conversion tool (AWS SCT), which will convert the source database schema to the majority database code objects. 
Also **Snowball Edge** can be used as a migration target for an environment with poor internet connectivity or if the database is so large. 