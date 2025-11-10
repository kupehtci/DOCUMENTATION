#AWS 

# AWS - Security Token Service 

**AWS Security Token Service** or **STS** is a service that works with Cognito [^1] ,cross-account access and temporary credentials. 

Is a web service that let you request temporary security credentials with restricted privileges for AWS IAM Users or federated users. 

It issues short-term access keys composed of `Access key ID`, `Secret Access Key` and a `Session Token`. 

## STS + Cognito

An user logs in with an external identity provider like Cognito and STS exchanges the token for temporary AWS Credentials to access services like S3 or DynamoDB. 

## Cross-account Access

An user with an IAM user or role in Account A uses STS to assume a role in Account B. 

Its really useful in multi-account architectures. 

## Serverless and Mobile Apps

Mobile apps authenticate using Cognito[^1] and it uses STS to get temporary credentials for the App to access AWS Services directly like S3 storage. 



[^1]: AWS Cognito [[AWS - Cognito]]
