 
# AWS Account

An **AWS Account** is the fundamental container and security boundary for using AWS services. 

It represents an independent identity, billing entity and resource container within the AWS Environment. 

* **Identity**: an AWS Account is tied to an unique root user (email + password). This root identity owns the account and has full administrative access. 
* **Billing**: each account has its own billing and usage tracking. Even when its part of AWS Organizations (Consolidated billing), costs can be tracked per account. 
* **Security boundary**: resources within one account are isolated from those in another account by default. 

An AWS Account can only belong to one organization at a time

##### Why to split in some AWS accounts

Dividing the resources between different AWS accounts has some benefits: 

* **Many teams**: splitting the resources between teams or applications. * 
* **Billing**: Splitting the resources between different AWS accounts brings granular imputation of payments of the different resources.  

### Users

In order to create an AWS account we need to create a root user that holds the root administration of the AWS account and the payments. 

This **root user** should not be used to make day-to-day interactions of management of the AWS resources. 
Other users, management of resources and authorization within AWS its made through <span style="color:DodgerBlue;">IAM Users</span>.

By creating <span style="color:DodgerBlue;">IAM users</span>, you manage efficiently and provide granular access to the resources depending on the type of access that a user need to have.
Its important to maintain the <span style="color:#d291bc;">principle of least priviledge</span>. 
##### Principal 

A principal is an identity that can authorize within AWS and has some permissions over AWS resources.
This principal can be a person, application, federated user through another provider or an assumed role. 
An AWS Principal can also be an AWS Service like an Amazon EC2 that need to access and modify other resources or an Identity through an Identity Provider (IdP). 

##### Types of access to different Identities

Principals or Users can access through User Console or Programmatic Access (Through CLI or via SDK)

This **programmatic access** is the access made by code or by console through a client ID and a client secret.
In order to authenticate via CLI, there are four main elements that we need to configure in your IAM user in AWS CLI: 

* AWS Access Key ID
* AWS Secret Access Key
* Default region name
* Default output format (JSON, yaml, yaml-stream, text or table)

Users can have access to only the resources they need within certain AWS Accounts.

The permissions of the user are managed through groups of permissions and can be granted to certain groups, so all users or identities within that group will inherit that roles / permissions. 

Assumed roles are delegated permissions to a role that can be assumed from different users in order to have permissions over the AWS resources. 

The IAM User / AWS service or a Federated User can make a call to the IAM API, Assume a role, and this will assume that role with the given permissions. 


##### Types of identity-based functions

There are three main types of policies: 

* Service Access: granular access to certain services and under some actions. 
* Job Functions: group of actions over certain services and resources
* Custom Policies: 


##### Identity based policies format

Identity based poilcies are formatted in JSON as: 

```json
{
	"Version" : "2012-10-17", 
	"Statement" : [
	{
		"Effect" : "Allow", 
		"Action" : [
			"ec2:StartInstances", 
			"ec2:StopInstances"
		], 
		"Resource" : "arn:aws:ec2:*:*:instance/*", 
		"Condition" : {
			"StringEquals" : {
				# ...
			}
		}
	}
	
	]
}
```

And can contain the following parameters: 
* <span style="color:DodgerBlue;">Effect</span>: Allow or deny. 
* <span style="color:DodgerBlue;">Principal</span>: Indicated the account, user, role or federated user to which you want to allow or deny access on resource policies. 
* <span style="color:DodgerBlue;">Action</span>: List of actions that the policy allows or denies. 
* <span style="color:DodgerBlue;">Resource</span>: Specify the list of resources to which the actions apply. This resource is specified as ARN annotation.  
* <span style="color:DodgerBlue;">Condition</span>: Under which circumstances the policy grants permissions. 

The main parameters required are Effect (Allow or deny), Actions that can be done or denied and the resource that we want to give permissions to. 

**Deny is more restrictive than Allow** so if a user has some action denied and also allowed by a certain Job Function or custom role, the explicit Deny will be applied.  


##### Resource based policy

A resource based policy is an IAM policy applied to a certain resource to allow or restrain the access to a certain Identity / user or others. 

An example in JSON format can be: 

```json
{
	"Version" : "2012-10-17"
	"Statement" : 
	[
		"Sid" : 
	]
}
```


##### Permission boundaries

The permissions can be restrained to 