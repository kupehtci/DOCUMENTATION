#AWS 

# AWS - Storage Gateway

**AWS Storage Gateway** is an AWS hybrid cloud storage service that acts as a bridge between on-premisses environments and AWS Cloud Storage. 

Storage Gateway is used for connecting local infrastructure to AWS Storage Services without modifying the actual applications or workflows. 

It supports connection to AWS Storage solutions using protocols like: 
* NFS
* SMB
* iSCSI 
* iSCSI-VTL

## Storage Gateway types

Storage Gateway offers four different types to support various use cases: 

* **Amazon S3 File Gateway**: store files as native S3 objects using NFS or SMB protocols
* **Amazon FSx File Gateway**: provides full access to managed windows file shares using FSx for Windows File Server[^1]. 
* **Volume Gateway**: offers block storage using iSCSI protocol: 
	* **Cached mode**: primary in S3 with local cache
	* **Stored mode**: entire data set on-premises with S3 backups as EBS snapshots. 
* **Tape Gateway**: Presents a virtual tape library or VTL for backup applications. Each virtual tape is stored in S3 Glacier or S3 Glacier Deep Archive. 

## Security

Data is encrypted in traffic between on-premise and AWS using HTTPS (SSL), KMS integration for rotation. 
Also allows WORM immutability capabilities in the storages. 



[^1]: FSx storage solution [[AWS - FSx]]