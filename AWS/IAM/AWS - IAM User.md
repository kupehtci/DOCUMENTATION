#AWS 

### AWS IAM Users

An IAM User is an entity that represents an human or a workload that uses this IAM user to interact with the AWS resources that it has access to. 

This helps to grant, manage and restrict user or other identities granular access and permissions to certain resources.

This IAM user consist in: 
* A friendly name that would be visible in AWS management console. 
* An Amazon Resource Name (ARN[^1]) that looks like: `arn:aws:iam:<account-ID>:user/<username>`. 
* An unique identifier of the user.

To allow IAM Users to create or modify the resources and perform certain tasks: 

* Choose or create IAM policies that define the permissions to access specific resources
* Attach the policies to the IAM user, groups or roles. 

Most users can have more multiple policies.

#### Multi-factor authentication 

You can add two-factor authentication to your account and to individual users for extra security. 
This required an special code via an email, sms or authentication app to be validated in order to login. 
