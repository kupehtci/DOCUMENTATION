#AWS 

# AWS S3 Simple Storage Service

AWS S3 or Simple Storage Service is a **general object storage** on the cloud. 

Its highly scalable, highly available, durable and easily integrated with other AWS resources. 

There are different ways to access a s3 bucket: 

* By URL: `https://s3.amazonaws.com/<BUCKET_NAME>/<OBJECT_NAME>` but by default, a s3 bucket is not public accesible. 
* Using python boro3 SDK or similar API to access the S3 bucket and store data within it in the application code. 

# S3 Storage classes

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

## Glacier retrievals

For archived data in S3 Glacier, where data that is not needed instantly is placed, you can choose different retrieval tiers for accessing the data: 

### Glacier Flexible

| Type of Retrieval | Expected time  | Cost         | Usage                           |
| ----------------- | -------------- | ------------ | ------------------------------- |
| Expedited         | 1 to 5 minutes | Highest cost | Urgent data                     |
| Standard          | 3 to 5 hours   | Moderate     | Normal restored from Glacier    |
| Bulk              | 5 to 12 hours  | Lowest       | Large datasets with low urgency |

### Glacier Deep Archive

It has the lowest cost storage but also is the slowest to retrieve from: 

| Type of Retrieval | Expected time  | Cost   | Usage               |
| ----------------- | -------------- | ------ | ------------------- |
| Standars          | 12 hours       | Low    | Long-term archival  |
| Bulk              | Up to 48 hours | Lowest | Very large archives |

### Glacier instant retrieval

It similar to Standard-IA but cheaper. 
Retrieve should last miliseconds. 

---
### Data Replication

Amazon S3 supports different types of replication for keeping objects in sync across buckets or regions. 

* **S3 Same-Region Replication**: replicates objects across buckets between the same AWS region. 
* **S3 Cross-Region replication**: replicates objects automatically from an S3 bucket in a region to another S3 bucket in other AWS region. 

For both types of replication, versioning is required to be enabled in both buckets. 

Support all storage classes including S3 standard, Standard-IA and Glacier ones, so you can replicate objects between same type or different storage classes like S3 Standard to S3 Intelligent-Tiering or S3 Standard-IA. 

If the **objects are KMS-encrypted** with a customer managed KMS key, the destination bucket must have permissions to decrypt and encrypt. 

S3 Data Replication applies to new object but can be enables to replicate also existing objects using **S3 Batch Replication**. 

---
## Multi-Region Access Points

**Multi-Region Access Points** or **MRAP** allows a single global endpoints for multiple S3 buckets and will automatically route requests to the nearest bucket. 

It offers automatic failover and enabling cross-region replication they will maintain the same data. 

---
# BucketVersioning

# Object-Lock

**Object Lock** its an immutability \[[[IMMUTABILITY]]\] feature that allows WORM (Write Once Read Many) feature so once the object is written it cannot be deleted or overwritten.
Its used for compliance, ransomware protection or preventing accidental deletions.

Requires bucket versioning to be enabled.

It has two different configurations: 
* **Retention period**: Locks an object until a certain date
* **Legal Hold**: indefinitely

## Legal Hold

A **Legal Hold** is an object lock feature that prevents the object from being deleted or overwritten. Unlike retention period, Legal Hold has no expiration date.

`s3:PutObjectLegalHold` its the permission needed to allow a principal to place or remove a Legal Hold over an specific version of an S3 object with **Object Lock** retention. 

It requires Bucket versioning and Object Lock to be enabled in the bucket.


# Governance vs Compliance mode

S3's Object Lock has two different types of modes to prevent accidental deletion of S3's objects: 
* **Governance mode**: Protect objects from accidental deletion
	* Can be bypassed with `s3:BypassGovernanceRetention` permission. 
	* Useful for internal policies but cannot guarantee an regulatory compliance.
* **Compliance mode**: enforce some regulatory retention (immutable): 
	* Cannot be bypassed. 
	* Designed for legal or regulatory compliance. 




---

# S3 Encryption

S3 offers different types of encryption: 

## S3 Encryption with SSE-S3 

**SSE-S3** or **Server Side Encryption** (SSE) offers encryption of the S3 data at rest, meaning that data is encrypted when stored in the S3 bucket and decrypted when the data is accessed. 

This type of encryption is fully managed by AWS so you don't manage any keys of the objects. 

It is enabled by selecting "Default Encryption" at the S3 bucket level.

> Take into account that S3 rotates the key automatically without notifying and key usage and rotation doesn't have integration with CloudTrail. 

## S3 Encryption with SSE-KMS

AWS KMS [^1]

---
## S3 Headers

You can add headers to S3 objects such as `Cache-Control` or `Expires` as they are reachable through an URI[^1].

The available headers [^2] are: 

* `Cache-Control`
* `Content-Type`
* `Content-Encoding`
* `Expires`
* `Content-Disposition`
* `x-amz-meta-*`: Custom metadata

This cache related headers are used by CloudFront[^3]

You can set the headers in the AWS Management console in Properties > Metadata or using AWS CLI: 

```bash
aws s3 cp index.html s3://<bucket-endpoint>/<object> \
  --cache-control "max-age=86400" \
  --content-type "text/html"
```

Or using terraform for controlling the S3's object: 
```yaml
resource "aws_s3_object" "example" {
  bucket        = "my-bucket"
  key           = "index.html"
  source        = "index.html"
  content_type  = "text/html"
  cache_control = "max-age=86400"
}
```

[^1]: URI or Uniform Resources Identifier [[CS - URI]]
[^2]: HTTP and HTTPs Available headers [[HTTP - Header attributes]]
[^3]: CloudFront is a content delivery network service in AWS used for caching content near to the end client [[AWS - CloudFront]]


## Requester pays

By default, the bucket owner pays for all the Amazon S3 storage, data transfer and replication costs but you can configure a general purpose S3 bucket as *Requester Pays* bucket. 
With *Requester Pays* buckets, the requester pays for the costs of the request and data download instead of the owner and the owner pays for the storage of the data. 

> If Requester Pays is enabled on a general purpose bucket, anonymous data retrieval is disabled and each requester needs to be identified with an IAM Identity. 
> When the requester assumes an AWS Identity and Access Management (IAM) role before making their request, the account to which the role belongs is charged for the request



---

[^1]: If objects have not been accessed in 30 days, are classified as Infrequent access.  
[^2]: IA stands for Infrequent Access 
