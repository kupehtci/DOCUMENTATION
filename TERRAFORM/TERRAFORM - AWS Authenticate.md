#TERRAFORM 

To use the IAM credentials to authenticate in the terraform AWS provider, we need to set two environment variables: 

* `AWS_ACCESS_KEY_ID`
* `AWS_SECRET_ACCESS_KEY`

As follows: 

```terraform
export AWS_ACCESS_KEY_ID=
export AWS_SECRET_ACCESS_KEY=
```

## Create AWS Secret Access Key

1. Sign in into the AWS management console. 
2. Search for the IAM role / user desired or Create a new one.
	* Existing or new user must have administrator access IAM Role or enough permissions for creating / deleting the resources that are defined in the terraform files. 
3. In Persons: 
	1. Search the IAM User
	2. Go to security Credentials
	3. Go to Access Keys and click on create new access key: 
		1. Use cases of the new access key: **Command Line Interface (CLI)**.
		2. Label: enter a label for establishing a name for the access key. 
		3. Then it will prompt the User key. Store it as you will no longer be able to read it. 

The Access key ID, its the "username" associated with the access key, not the label, but the username that appears on top: 

![[aws_access_key_id.png]]