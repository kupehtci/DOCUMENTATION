#AWS 

# AWS RDS

**Amazon RDS** or **Relational Database Service** is a fully managed service and AWS handles the OS, database software installation, patching, backups and maintenance


### AWS RDS Custom

An **RDS Custom** is a managed database service that requires custom database and OS configurations by the user. 

Its an hybrid, a mid-way between a fully managed RDS and a self hosted DB in an EC2. 


### RDS Storage

Amazon RDS stored the data on Amazon Elastic Block Store (EBS) [^1] volumes. You don't need to provision the EBS directly. 
When creating an RDS database, you need to choose the volume type when creating the DB instance. 

The choice of storage will affect: 
* IOPS (Input / Output operations per second)
* Throughput (MB/s)
* Latency
* Cost

The different EBS volume types that RDS supports are: 

| Volume Type             | Category                 | Description                                                                                                    | IOPS (Performance)          | Best For                                           |
| ----------------------- | ------------------------ | -------------------------------------------------------------------------------------------------------------- | --------------------------- | -------------------------------------------------- |
| **gp2**                 | General Purpose SSD      | Older generation general-purpose SSD (scales IOPS with size: 3 IOPS per GB, up to 16,000 IOPS).                | Up to 16,000 IOPS           | Small–medium workloads, dev/test                   |
| **gp3**                 | General Purpose SSD      | Newer generation SSD (independent tuning of size, IOPS, and throughput). Default choice for new RDS instances. | Up to 16,000 IOPS (for RDS) | Most general workloads                             |
| **io1**                 | Provisioned IOPS SSD     | High-performance SSD with user-provisioned IOPS.                                                               | Up to 64,000 IOPS           | OLTP or latency-sensitive workloads                |
| **io2**                 | Provisioned IOPS SSD     | Next-gen of io1: higher durability (99.999%), more consistent performance, higher IOPS limit.                  | Up to 256,000 IOPS          | Mission-critical DBs (e.g., financial, production) |
| **magnetic (standard)** | HDD                      | Legacy spinning disks. Low cost, low performance.                                                              | ~100–200 IOPS               | Cold data, not recommended for production          |
| **st1**                 | Throughput-optimized HDD | High throughput (MB/s) optimized, not IOPS.                                                                    | Up to 500 IOPS              | Data warehouse or analytics workloads              |
| **sc1**                 | Cold HDD                 | Lowest-cost HDD. For infrequent access.                                                                        | ~80 IOPS                    | Archival or infrequently accessed data             |

## RDS PRoxy

RDS Proxy is an highly available and fully managed proxy that keeps between the application and an RDS or Aurora DB[^2] to pool and share connections. 

It adds different features: 
* Failover behaviour between RDS instances
* Authentication
* TLS controls.

All the applications connect to that stable endpoint and it minimizes the connections to a more efficient set of DB Connections. 

Usefull to reduce spikes of traffic caused by frequent open/close connections from serverless services. 

## Recovery

### Point-in-Time Recovery (PITR)

RDS's PITR automatically maintains a continuous backup of the table data for the last 35 days, allowing you to restore the table to any second within the last retention periods. 


[^1]: EBS or Elastic Block Store [[AWS - EBS Elastic Block Store]]
[^2]: Aurora DB [[AWS - Aurora]]