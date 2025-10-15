#AWS 

# AWS - Snowball edge

**AWS Snowball Edge** is a physical, ruggedized device designed for offline data transfer and edge computing.
It helps customers move large amounts of data into and out of AWS **without using the internet**, and it can also run **compute workloads locally** if needed.

Its normally used when a company needs to move data to the cloud and have insufficient bandwidth for transferring it using DataSync. 

If you need to copy tens or hundreds of terabytes from local to AWS without using bandwidth, copy the data to snowball edge device, ship it to AWS and it will automatically copy the data to an S3. 

### Types of devices

Has two types of devices:
* Storage optimized: more storage and lower compute resources. Good for bulk data transfer. 
* Compute optimized: moderate storage and more computer power for running applications at the edge. 

### When its used

The AWS Snowball edge is normally used for: 

* **Large-scale migrations** from on-premises NAS to S3.
* **Disaster recovery**: copy backup data to snowball and ship to AWS. 
* **Edge processing** to collect and/or process data on remote locations and run the compute before sending results or interact with other AWS resources. 
* **Bandwidth-limited environments**