#AWS 

# AWS - KMS or Key Management Service

**AWS KMS** or **Key Management Service** is a centralized encryption key management system. 
It lets you create, control and **manage cryptographic keys** used to encrypt data between AWS services and applications. 

They key characteristics of AWS KMS are: 
* **CMK** or **Customer Master Key**: master key created in KMS. Can be symmetric(AES-256) or asymmetric (RSA/ECC).
* **Key policies**: Indicates who can use or manage keys. (Access control mechanism)
* **IAM Integration**: Fine-grained permisions by allowing users or roles to use a key for encryption/decryption.
* **Automatic Key Rotation**: can automatically rotate CMKs yearly to improve security.
* **Audit** and **Logging**: Integrated with CloudTrail so can monitor who used a key and when. 
* **Envelope encryption**: KMS keys are used to encrypt data keys which encrypt the actual data sent. This improves security.
* **Cross-Region Replication**: Allows CMKs to be replicated across regions (For DR, backups or multi-region applications).
* **Integrated with many AWS Services**: Like S3, EBS, RDS, RedShift, Lambda, CloudTrail, Secrets Manager or SSM Parameter Store.

## Envelope Encryption

**Envelope encryption** implies that only the small data key is passed around, not the master key.

1. You create a **CMK** in KMS.    
2. Generate a **data key** from the CMK.
3. Use the **data key** to encrypt your data locally or in a service (like S3 or DynamoDB).
4. KMS stores the **CMK securely**, handles **key lifecycle**, and **decrypts data keys** when requested by authorized users/services.

### Usage cases

The most common usage cases of KMS Service are: 
* **Encrypt S3 buckets**: use KMS CMK for server side encryption.
* **Encrypt EBS Volumes**: Attach CMK to volumes for data-at-rest encryption.
* **Encrypt RDS / RedShift / DynamoDB data**: handle encryption keys automatically.
* **Secure Secrets Manager or Parameter Store Secrets**: encrypts the secrets at rest.
* **Digital Signatures and verification**: Asymmetric CMKs allow signing and verifying messages. 

### Integrations

The different services that KMS is integrated with: 

* CloudTrail: monitor events of key usage, useful for auditing all key usage for auditing requirements (PCI, HIPAA and others). 