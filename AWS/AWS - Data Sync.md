
# AWS - Data sync

**AWS DataSync** is a managed data transfer service that helps you automatically and securely move large amounts of data between:
- **On-premises storage** (NFS, SMB file servers, object storage, Hadoop, etc.)    
- **AWS storage services** (Amazon S3, Amazon EFS, Amazon FSx, Amazon FSx for Windows File Server, Amazon FSx for Lustre, and even between AWS regions/accounts).

Its parallelized transfer, faster than `rsync`and its secured by TLS encryption in-flight. 



You need to install an **agent on the on-premise** in order to transfer the data to the cloud. In case you want to move data AWS-to-AWS data sync can move data directly between AWS storage services without using an agent