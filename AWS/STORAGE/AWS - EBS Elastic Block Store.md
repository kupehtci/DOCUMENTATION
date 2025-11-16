#AWS 

# AWS - Elastic Block Storage

**AWS Elastic Block Storage** or **EBS** is a block storage service for use in EC2 instances[^1]. 
EBS are also used in RDS databases. 

It provides a persistent, high-performance block storage that remains available even if the EC2 instance stops or terminate. 

EC2 instances[^1] by default has ephemeral storage, so EBS is used for giving persistency of the instance's files. 

If Amazon EC2 instance is deleted, the **EBS volume is deleted**. 

Key characteristics of this service are: 
* Attach or detach can be done to only one EC2 instance at a time (Excep for certain multi-attach volumes). For multi-access solutions is more recommendable to use FSx [^fsx] or EFS [^efs]


# EBS Types

This are the different types of EBS volumes: 

| Volume Type             | Category                 | Description                                                                                                    | IOPS (Performance)          | Best For                                           |
| ----------------------- | ------------------------ | -------------------------------------------------------------------------------------------------------------- | --------------------------- | -------------------------------------------------- |
| **gp2**                 | General Purpose SSD      | Older generation general-purpose SSD (scales IOPS with size: 3 IOPS per GB, up to 16,000 IOPS).                | Up to 16,000 IOPS           | Small–medium workloads, dev/test                   |
| **gp3**                 | General Purpose SSD      | Newer generation SSD (independent tuning of size, IOPS, and throughput). Default choice for new RDS instances. | Up to 16,000 IOPS (for RDS) | Most general workloads                             |
| **io1**                 | Provisioned IOPS SSD     | High-performance SSD with user-provisioned IOPS.                                                               | Up to 64,000 IOPS           | OLTP or latency-sensitive workloads                |
| **io2**                 | Provisioned IOPS SSD     | Next-gen of io1: higher durability (99.999%), more consistent performance, higher IOPS limit.                  | Up to 256,000 IOPS          | Mission-critical DBs (e.g., financial, production) |
| **magnetic (standard)** | HDD                      | Legacy spinning disks. Low cost, low performance.                                                              | ~100–200 IOPS               | Cold data, not recommended for production          |
| **st1**                 | Throughput-optimized HDD | High throughput (MB/s) optimized, not IOPS.                                                                    | Up to 500 IOPS              | Data warehouse or analytics workloads              |
| **sc1**                 | Cold HDD                 | Lowest-cost HDD. For infrequent access.                                                                        | ~80 IOPS                    | Archival or infrequently accessed data             |

# EBS Multi-attach

EBS Multi-attach allows to attach a single EBS (Provisiones IOPS io1 and io2) to multiple EC2 instances at the same time. 
EBS Multi-attach is only available in this type of instances in io1 and io2 volume types
The EC2 instances need to be in the same Availability Zone. 


## EBS Snapshots

EBS Snapshots are **incremental snapshots** automatically stored in an S3 for backup and recovery.

# Encryption
## Encryption at rest

You **cannot enable encryption on an existing unencrypted EBS volume**. So to enforce EBS encryption in all EBS volumes, enable EBS encryption by default option in the AWS region. 

## Encryption in transit

This type of encryption can be done using AWS KMS [^2]. 


## Deletion prevention

Its recommendable to use tag-based or name-based deletion prevention rules (retention rules) managed by AWS Recycle Bin [^3]. 



[^1] Amazon EC2 instances or Elastic Cloud Compute instances are virtual servers in the AWS cloud [[AWS - EC2]]. 
[^2]: AWS KMS or Key Management System[[AWS - KMS Key Management Service]]
[^3]: AWS Recycle Bin is a managed solution for having a bin in AWS that retain objects based on a retention rule to prevent automatic permanent deletion. 
[^fsx]: FSx [[AWS - FSx]]
[^efs]: Elastic File System [[EFS]]