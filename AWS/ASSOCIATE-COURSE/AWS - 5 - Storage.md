#AWS

### AWS Storage


Storage volumes has some characteristics: 

Throughput optimized HDD > st1 and its a low cost HDD colume for frequently access and high intensive workloads. 
Size 125GB to 16TB

### Types of storage

There are three main cloud storages: 

* **Block storage**: Storage for all types of structured and unestructured storage. Offers solutions like Amazon Elastic Block Storage or EBS. 
* **File storage**: for shared files like a file system for many applications, Often supported with a Network Attached Storage (NAS) solution. Offers storage solutions like Amazon Elastic File System or EFS and Amazon FSx
* **Object storage**: like S3 for all types of files that provide scalability and flexibility. Ideal for Data Lakes, backups and storage, static websites, media storage and streaming. 


#### Amazon S3 or Simple Storage Service

The amazon S3 is the most common storage option for: 

* when a lot of users or applications must access the storage
* growing data sets
* Data that is written once and read many times 

S3 is the service and what the containers that you have to store data are known as bucket. It stores data as objects within this buckets.

An object includes a file and the metadata that describe the file.

The access to an S3 bucket and its objects can be controlled through policies.

You can access the different data within a bucket by using the bucket URL: 

```bash
https://<bucket-name>.s3.amazonaws.com/myfolder/dog.png
--------------------- ---------------- ----------------
      BUCKET URL       AMAZON DOMAIN    Obj path or key
```

##### S3 access control

By default all S3 resources are private. This imply that only the resource owner (AWS account that created it) can access the resources. 

Permissions can be granted with access policies. 

The bucket policies are based in JSON based policies and look like: 

```json
{
	"Version":"2012-10-17", 
	"Statement": [
		{
			"Effect":"Allow", 
			"Principal":"*", 
			"Action": [
				"s3:ListBucket",
				"s3:GetObject"
			], 
			"Resource": [
				"arn:aws:s3:::<bucket-name>", 
				"arn:aws:s3:::<bucket-name>/*"
			]
		}
	]
}
```

This policies can be used to add or deny permissions for certain objects in the buckets. 

By default, is recommended to keep the access configuration to "block all public access"

##### S3 Access Points

Amazon S3 Access Points simplify this data access at a scale to share small datasets within an Amazon S3. 
This access points are network endpoints that can be used to perform object operations like "s3:GetObject" or "s3:PutObject". Each endpoint will have different permissions and network controls and will be applied to each request made through the access point. 
This bucket policies can as an example restrict the data access to a private network or custom public access blocks. 
You can only use access points to perform operations on objects. You can't use access points to perform other Amazon S3 operations, such as modifying or deleting buckets. 

##### Encryption 

Chryptographic keys are used to encrypt data at rest. Amazon S3 offers three options of encryption: 

* Server-side encryption(SSE) with Amazon S3 managed keys (SSE-S3): each object is encrypted with an unique key. Also encrypts the key with a regularly rotation encryption. 
* Server-side encryption(SSE) with AWS keys stored in AWS Key management service (AWS KMS) (SSE-KMS) where KMS keys are stored in AWS KMS and each KMS key has separate permissions of use. Also provide audit usage logs. 
* Dual layer server-side encryption with AWS KMS Keys (DSSE-KMS) two layer of encryption
* Server-side encryption with customer-provided keys (SSE-C) where you manage the encryption keys and S3 encrypts the data as its being written. Also S3 manages the decryption of the data when is accessed. 

##### S3 storage classes

Depending on the access rate and in order to have a better cost of the S3 storage solution, it can be freeze. 

The basic types are: 

* **S3 Standard**: Active frequent access. Miliseconds to access. 
* **S3 Standard IA**: Infrequent access. Miliseconds to access. 
* **S3 One Zone IA**: Recreateable less accessed data. Miliseconds of access
* **S3 Glacier Instant Retrieval**: Archived data that need fast restore times. 
* **S3 Glacier Flexible Retrieval**: Unpredictable restore needs. Minutes to hours to retrieve. 
* **S3 Glacier Deep Archive**: the data is not likely to be restored. 12h or less to restore. 

IA doesn't means Artifical Intelligence, it means Infrequent Access. 
The S3 buckets considered as Glacier, it has cost per each retrieve of data. 

Also another class are **Intelligent Tiering**, that monitor the data access (this monitoring is Payed) and assigns the Tier of the S3 bucket as Standard and change to another tier in case that an object has not been accessed. 

##### Replication

Data in S3 can be replicated: 

* SRR: Same Region Replication. 
* CRR: Cross Region Replication. 

**Owner Override** is when changing the AWS Account of destination, it changes the owner of the data to the new AWS account. This option can be enable in replication. 

##### Amazon S3 versioning

The newly changed to an existing file creates a new version of it. 
This versioning helps to recover objects from accidental deletion or rewrite. 

Also S3 Object lock for data retention or protection can be use as Write Once Read Many (WORM) model, where you can prevent accidental overwrites or deletions of objects of an AWS S3. 

##### Amazon S3 Lifecycle policies

WIth Lifecycle policies, you can delete or move objects based on age. 
The lifecycle followed is "older than 30 days"  > S3  Standard IA > "older than 365" > S3 glacier deep archive. 

Its used for: 
* **Transition objects**: move objects between storage classes depending on age. 
* **Expire objects**: permanently delete objects after a defined period.
* **Abort incomplete mulipart uploads**: automatically clean up aborted uploads. 

Each lifecycle rule has 3 components: 
* **Filter** which objects it applies to (By prefix, object tags or whole bucket). 
* **Action**: transition, expiration or abort. 
* **Time condition** when to perform the action (Example, after 30 days since creation). 

##### Amazon S3 multipart upload


##### Amazon S3 Transfer Acceleration


##### Amazon S3 Event notifications


##### Amazon S3 Storage lens

<b>S3 Storage Lens</b> is a native feature that provides organization-wide visibility about S3 usage and activity


#### Amazon File Share

##### Amazon EFS

EFS or Elastic File Storage provides an Elastic FIle System for Linux based workloads within AWS services. 
Its a serverless service so you don't need to provision storage manually. 
Can be attached to EC2, Amazon ECS, AWS Fargate, EKS and more. 
It helps to handle storage of applications that runs on multiple instances and need to share the same file system. 
Amazon EBS provides block storage as an storage component of a self-managed file storage solution. 
Also offer the same performance and R/W capabilities of a network file system (NAS), more than an S3 bucket. 
Its three times more expensive than S3 storage and preserves the payment option of pay what you use. 

It has various availability options: 

* Standard storage class creates a file system replicated across all Availability Zones. 
* One zone storage class creates a file system data and metadata only redundant within a single Availability Zone. 

An VPC can use an Amazon EFS stardard storage class and each subnet has its own mount target. 

##### Amazon FSx

FSx allow to lunch, run and scale high performing file systems on AWS. 
It provides four file systems to choose from: 

* **Amazon FSx for Windows File Server**: provides Microsoft windows file server managed by a native Windows file system. For Windows server ofers administrative features like Microsoft AD. 
* **Amazon FSx for Lustre**: high performance cost-effective storage for Linux based AMIs
* **Amazon FSx for NetApp ONTAP**: fully managed shared storage with the management capabilities of ONTAP. 
* **Amazon FSx for OpenZFS**: fully managed shared file storage built over OpenZFS file system. 

#### Data migration tools

**AWS Snowball edge** is a type of snowball device with on-board storage and compute power that can process data locally, run workloads over it and transfer data to or from AWS cloud. 

Also, AWS offers other services to migrate databases: 
* AWS Storage Gateway: simplify on-premise adoption of AWS storage. This will connect the on-premise applications to AWS storage. It supports multiple file transfer protocol as Server Message Block (SMB), Network File System (NFS and Internet Small Computer Systems Interface(iSCSI). 
* **AWS Data sync**: is a data transfer service to move data between on-premise storage to amazon EFS, Amazon FSx and Amazon S3º
* **AWS Transfer Family**: permits the transfer of files in/out of Amazon S3 and EFS over the following protocols: 
	* Secure Shell FIle Transfer Protocol (SFTP)
	* File Transfer Protocol Secure (FTPS)
	* File Transfer Protocol (FTP)
	* Applciability Statement 2 (AS2)


##### Storage Gateway

AWS Storage Gateway connect to on-premisesoftware appliance with cloud based storage and provides integration with data security. 

You can use this service to store data in AWS cloud in an scalable and cost-effective way while maintaining data security. 

Also provide integrations with IAM, AWS KMS, AWS CloudTrail and Amazon CloudWatch.  

* **Amazon S3 File Gateway**: Native file system for amazon S3 for backups, archives. Present a file system to store files as objects in an Amazon S3 or NFS and SMB protocols. 
* **Amazon FSx**: provides for windows file server. 
* **Tape Gateway**: present a iSCSI based virtual tape library (VTL) of virtual tape drives and virtual media changes for on-premises backup applications. Stores this virtual tapes in Amazon S3 adn creates new ones automatically. 
* **Volume Gateway**: present Block storage of the applications using iSCI protocol. This allows to asynchronously backup data that is written into these volumes as point-in-time snaphots of this volumes. Then they are stored as Amazon EBS snapshots.  

The data that is moved to AWS using NFS, SMB or iSCSI can be stores within: 

| Storage type      | Storage Gateway used                 |
| ----------------- | ------------------------------------ |
| Amazon S3         | Amazon S3 File Gateway, Tape gateway |
| Amazon S3 Glacier | Amazon S3 File Gateway, Tape gateway |
| Amazon FSx        | Its own gateway                      |
| Amazon EBS        | Volume Gateway                       |

##### Data Sync

