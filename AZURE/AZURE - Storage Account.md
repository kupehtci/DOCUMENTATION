#TERRAFORM #AZURE #AKS 

# AZURE Storage Account

An Azure Storage Account is a container for holding persistent storage within the Azure cloud. 

Its highly scalable, allowing to increment the storage without a limit size and high availability for various types of structured and unstructured data. 

An storage account can store the following components: 

* **Blob storage**: offers storage for unstructured data (Blobs) like documents, images, backups, etc. And it can be stored in three tiers Hot, Cool and archive depending on access frequency. 
* **File storage**: fully managed file share service using SMB (Server Message Block) protocol. Used for sharing files between multiple VMs or on-premise. 
* **Queue Storage**: allows to stack in a queue messages between different components of an application. 
* **Table storage**: Provides a NoSQL[^nsql] key-value store for structured data. 
* **Disk storage**: Used for storing virtual hard disks (VHDs) for Azure Virtual Machines. 

You can have different tiers for the storage depending on the access rate that you are going to deal with it: 

* **HOT**: for highly frequent access is optimized for high availability and quick access to it
* **COOL**: Optimized for frequent access
* **ARCHIVE**:  Optimized for rarely accessed archives

#### Storage Account types

You have different Azure Storage Account types depending on the usage that you are going to do to it: 

* **General Purpose v2 or GPv2** supports all Azure Storage components and recommended for optimization, flexibility and cost efficient.
* **General Purpose v1 or GPv1** supports basic blob, file and table services but its less efficient than GPv2. 
* **Blob Storage Account**: optimized for storing large amounts of structured data. (Only allows blob storage components)


#### Storage account name

The storage account name has some limitations. 

- Storage account names must be between 3 and 24 characters in length and may contain numbers and lowercase letters only.
- Your storage account name must be unique within Azure. No two storage accounts can have the same name. This is like this because must be accesible from the internet like an endpoint \[https:\/\/\<storage-account\>.web.core.windows.net\]. 

So its common use to apply the name as a local variable[^2]

### Terraform definition

We must use the storage account in order to store the <span style="color:MediumSlateBlue;">tfstate</span> for multiple users working environment

It can be accessed like an endpoint: 

```
https://*mystorageaccount*.blob.core.windows.net/*mycontainer*/*myblob*
```

##### Other clouds resources

The Azure storage account has similarities with other cloud's resources: 

In AWS: 

* **AWS S3**[^5] or Simple Storage Service offers blob storage for unstructured data
* **EFS** or Elastic File System: 

[^2]: Terraform local variables [[TERRAFORM - Locals]]
[^3]: Replace function in terraform configuration language [[TERRAFORM - replace function]]
[^4]: Lower function in terraform configuration language [[TERRAFORM - lower function]]
[^nsql]: NoSQL Database [[No-SQL]] and in comparison to SQL databases [[SQL vs No-SQL]]
[^5]: AWS S3 or Simple Storage Service [[AWS - S3]]
