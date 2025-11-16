#AWS

# AWS - Directory Service

**AWS Directory Service** is a service that enables to connect AWS resources with Microsoft Active Directory (AD). 

The Microsoft Active Directory (AD) can be in the cloud oron-premise. 

It has different options: 
* **AWS Managed Microsoft AD**: a fully managed AD in AWS compatible with windows workloads. 
* **AD Connector**: connect to on-premises AD allowing AWS services to authenticate AD users without storing the AD data in AWS: 
* **Simple AD**: lightweight directory for linux/windows workloads. 

Can be used as an **identity source** for AWS IAM Identity Center. 

It offers: 
* **SSO Single Sign-on** for AWS Accounts and applications using AD users. 
* **Join EC2 instances or FSx file systems** using AD users. 
* **Hybrid environments** where AD users need to access cloud resources. 