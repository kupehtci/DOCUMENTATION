#AWS 

# AWS S3 Simple Storage Service

AWS S3 or Simple Storage Service is a **general object storage** on the cloud. 

Its highly scalable, highly available, durable and easily integrated with other AWS resources. 


There are different ways to access a s3 bucket: 

* By URL: `https://s3.amazonaws.com/<BUCKET_NAME>/<OBJECT_NAME>` but by default, a s3 bucket is not public accesible. 
* Using python boro3 SDK or similar API to access the S3 bucket and store data within it in the application code. 

### S3 Storage classes

For covering different purposes, it has various types of S3 buckets objects in order to optimize the storage for different types of data: 

For frequently accessed objects: 
* <span style="color:orange;">S3 Standard</span> is the default storage class. 
* <span style="color:orange;">S3 Express One Zone</span> is a highly performance, single zone S3 storage class for latency sensitive applications. 
* <span style="color:orange;">Reduced Redundancy</span> Reduced Redundancy Storage or RRS is meant for noncritical reproducible data that its stored with less redundancy than standard one. 

For data that has changing or unknown patterns: 

* <span style="color:orange;">S3 Intelligent-Tiering</span> is a S3 storage class that optimizes the storage to the most cost effective access tier. Its recommended for monthly object monitoring or automation where less accessed objects are moved to lower-cost access tiers. 
	This tier classify the items in 3 access tiers, **Frequent Access**, **Infrequent Access** [^1] and **Archive instant access**. The objects not accessed can be moved to **Archive Access** or **Deep Archive Access**. 

For **infrequent data access**, this data storage classes are recommended and its charged a retrieval fee for this objects so are more recommendable and cost-effective for infrequent data. Its recommended for backups, older data but with milliseconds access. 

* <span style="color:orange;">S3 Standard-IA</span>[^2]: stored data redundant between separated availability zones, same as Standard storage class. 
* <span style="color:orange;">S3 One Zone IA</span> stores data in only one availability Zone. making it less expensive than S3 Standard-IA, but makes it not resilient to loss of a availability zone. 

For a barely or rarely access to objects, the <span style="color:MediumSlateBlue">Glacier</span> object storage class is the most recommended, because its low-cost, long-term storage and data archiving: 

* <span style="color:orange;">S3 Glacier Instant Retrieval</span>: for rarely accessed data but offers miliseconds retrieval. It has real time access. 
* <span style="color:orange;">S3 Glacier flexible Retrieval</span> for having portions of the data than can be retrieved in minutes. Has not real-time access. 
* <span style="color:orange;">S3 Glacier Deep Archive</span> all data is in "cold" access and has no real-time access. 

As a summary and quick look: 

| **Category**                    | **Storage Class**             | **Description**                                                                                                         |
| ------------------------------- | ----------------------------- | ----------------------------------------------------------------------------------------------------------------------- |
| **Frequently Accessed Objects** | S3 Standard                   | Default storage class.                                                                                                  |
|                                 | S3 Express One Zone           | High-performance, single-zone storage for latency-sensitive applications.                                               |
|                                 | Reduced Redundancy            | Non-critical, reproducible data stored with less redundancy than standard storage.                                      |
| **Changing/Unknown Access**     | S3 Intelligent-Tiering        | Optimizes storage to cost-effective access tiers. Ideal for automatic transitions for less frequently accessed objects. |
| **Patterns**                    |                               | - Frequent Access: Frequently accessed data.                                                                            |
|                                 |                               | - Infrequent Access: Less frequently accessed data.                                                                     |
|                                 |                               | - Archive Instant Access: Archived data with instant access.                                                            |
|                                 |                               | - Archive Access/Deep Archive Access: Archived data with longer retrieval times.                                        |
| **Infrequent Access**           | S3 Standard-IA                | Data stored redundantly across multiple availability zones.                                                             |
|                                 | S3 One Zone IA                | Data stored in a single availability zone, less expensive but less resilient than S3 Standard-IA.                       |
| **Rarely Accessed Objects**     | S3 Glacier Instant Retrieval  | Low-cost storage with milliseconds retrieval for rarely accessed data.                                                  |
|                                 | S3 Glacier Flexible Retrieval | Portions of data can be retrieved in minutes, not real-time access.                                                     |
|                                 | S3 Glacier Deep Archive       | Lowest-cost storage for long-term archiving, with no real-time access.                                                  |


[^1]: If objects have not been accessed in 30 days, are classified as Infrequent access.  
[^2]: IA stands for Infrequent Access 

### Manage access

When owning multiple S3 buckets accessed by applications running in different VPCs. 

Also in certain cases, you want to define 


