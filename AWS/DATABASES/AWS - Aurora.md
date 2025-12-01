#AWS 

# AWS - Aurora

**AWS Aurora** is a fully managed relational database service (RDS) frm AWS that is compatible with MySQL and PostgreSQL. 

It brings performance and high-availability with simplicity and cost-effectiveness. 

The main characteristics of Amazon Aurora are: 

* **High performance**: up to 5 times faster than standard MySQL and 3 times faster than standard PostgreSQL. 
* **Fully managed**: AWS handles the backups, patching, compute performance and monitoring.
* **Highly available**: Data is replicated across multiple AZs for fault tolerance.
* **Auto scaling**: Aurora can automatically increase storage up to 128 TB per instance. 
* **Aurora serverless**: allows on-demand automatic scaling of compute capacity. Its recommended for variable workloads.
* **Global database**: you can replicate the database across multiple AWS regions.

The architecture of aurora differs from common databases as it **separates compute and storage**: 
* Storage is distributed across 3 Availability Zones with 6 copies of your data ( 2 copies per AZ).
* Compute layer (DB Instances) can scale up and down independently of the storage.


You have two different type of Amazon Aurora deployments: 

* **Provisioned**: choose the instance size.
* **Aurora Serverless v2**: auto scale compute capacity depending on the demand.

---
## Aurora Serverless v2 configuration types

Aurora Serverless v2 offer two storage configurations: 

* **Aurora standard**: 
	* Lower storage cost: recommended for high volume of data
	* Separate I/O charges
* **Aurora I/O-Optimized**: 
	* Higher storage costs than standard
	* No I/O charges: Best for high traffic. 

---

## Activity Streams

Amazon Aurora **Activity Streams** is a feature that provides near-real time monitoring of database activity that capture each database event (SELECT, INSERT, CONNECT and other SQL commands) and push them to **Amazon Kinesis Data Stream**

---

## Zero Downtime Restart 

**Zero Downtime Restart** or **ZDP** is an Aurora feature that preserve client connections during database restarts. 

This helps to prevent downtime under patching or minor version upgrades. 


[^1]: Amazon Kinesis Data Stream [[AWS - Kinesis]]

