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


[^1]: SSM Parameter Store [[AWS - SSM Parameter Store]]