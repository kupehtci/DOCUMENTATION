
# AWS Organizations

When having multiple accounts in AWS, maintaining a hierarchy under a certain Organizational Unit (OU) can be useful to manage all of them and grant permissions over certain branchs of the hierarchical organization. 

AWS Organizations helps with all of this management by creating this hierarchical structure for this accounts, enforce policies between all of them, consolidate billing and simplify resource and permission management: 


* **Centralized account management**

Create and manage multiple AWS accounts from a central management account. 
You can also add existing AWS account to the organization. 
This helps to manage the different accounts that can be created for different Applications or for different clients. 

* **Consolidated billing**

All the bills combined from all the AWS account can be combined under a single invoice but splitted by accounts to know granular view of the payments. 
Also you can share reserved instances and volume discounts by adding all the services in the cross account organization. 

* **Service Control Policies**

You can define and enforce policies across different AWS accounts to restrict or allow certain AWS actions without the need to define permissions in each one of them. 

* **Organizational Units (OUs)**

Group accounts into different OUs to apply policies at different levels. 

* **AWS Control tower**

Control tower can be used to streamline the account creations  (AWS Organizations for governance)

* **Cross-Accounts access**

Simplify the resource sharing and collaboration between different accounts, reducing the need for complex IAM configurations. 