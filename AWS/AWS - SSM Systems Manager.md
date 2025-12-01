#AWS 

# AWS - SSM Systems Manager

**SSM Systems Manager** is a fully managed service for manage and automate operations for AWS resources like patching, configuration, monitoring and automation.

It can also be used for: 
* Execute commands in EC2 instances without SSH connections
* Automate pathcing of OS and applications
* Inventory about AWS managed resources
	* Collect metadata of Software, configuration and installed packages across managed instances
* SSM Parameter Store[^1] for storing secrets, data and parameters for applications

To use **Systems manager** the instance must be an **managed instance**: 
* In on-premise servers needs to have SSM agent installed and registered. 
* EC2 instances in order to be able to connect to Systems Manager you need to add `AmazonSSMManagedInstanceCore` policy to allow them to communicate to it.


SSM Systems Manager doesn't use IAM Users, they are controlled through instance's policies (Resource Policies).

## Systems Manager Patch Manager

Patch Manager allows to automate the process of patching managed instances at OS-Level. 
Supports OS-Level patching of this OS: 
* Amazon Linux
* Red Hat Enterprise Linux (RHEL)
* Ubuntu
* SUSE Linux
* Windows Server

You define a baseline: 
* Which patches are approved or rejected
* The classification (Security, critical or others)
* The auto-approval rules (Like automatically approve updates after 3 days). 

Also instances can be organized into patch groups like dev, test and prod using **tags**. 

---
## Systems Manager Automation Document

An **Automation Document** or **runbook** is a type of AWS Systems Manager document that define automated workflows to perform common maintenance or remediation tasks on AWS Resources. 

These documents are written in JSON or YAML format and include the steps and parameters that need to be executed in sequential order. 

The most common use cases for **runbooks** are: 
* **Automate maintenance tasks** like patching, creating AMIs or restarting instances
* **Deployment automation**: updating CloudFormation stacks and configuring resources. 
* **Remediation automation**: respond to events, compliance checks and backups
* **Complex orchestration**: removing instances from load balancers for patching like `AWSEC2-PatchLoadBalancerInstance` runbook. 

---
## Systems Manager Run Command

**Run Command** allows to execute commands in parallel across multiple EC2 instances instantly. 

---
## Systems Manager Session Manager

Secure and fully managed service to connect to an EC2 instance with an interactive CLI without using SSH keys, open ports or bastion hosts. 

Can be used in AWS CLI: `aws ssm start-session` or directly in AWS Management Console.  

SSM agent needs to be installed in the machine and the user needs to have `ssm:StartSession` permission. 


[^1]: SSM Parameter Store [[AWS - SSM Parameter Store]]