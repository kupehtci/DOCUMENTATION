#AWS 

# AWS - FSx


# FSx for ONTAP 

ONTAP is the proprietary storage OS of NetApp. Its the software that runs on NetApp storage appliances and gives the advanced data management capabilities. 
FSx for ONTAP is like having a NetApp storage appliance but hosted and managed by AWS. 

Natively **supports SMB and NFS** so windows, mac and linux EC2 instances can access the data. 

The key characteristics of this type of storage are: 

* **Multi-protocol access**: Supports both NFS, SMB and iSCSI at the same time over the same data. 
* **Tiered storage (Auto-tiering)**: hot data is stored in fast SSD-based primary storage while cold data is automatically and transparently moved to low-cost Amazon S3 storage. This reduces costs while keeping hot data with fast access. 
* **Fully managed and Highly available**: as AWS handles the infrastructure, patching and backups this service provides *Multi-AZ* and lower operational overhead. 
* **Enterprise grade features**: provide features like snapshots, cloning, data compression and deduplication, SnapMirror replication for disaster recovery. 
* **RBAC with Active Directory (AD)**: fully integrates with Microsoft Active Directory for SMB data transfer. 
* **Integrated with AWS ecosystem**: is fully integrates with other AWS services like CloudTrail, CloudWatch, IAM and AWS Backup. 


The use cases of this service are: 
* Shared file storage between different operating systems (Windows and linux)
* Migrating NetApp workloads to AWS
* BigData and machine learning workloads
* Persistent storage for containers (EKS / ECS) and EC2. 
* Cost-optimized storage using tiering between FSx and S3. 