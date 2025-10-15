#AWS 

# AWS - SSM Parameter Store

**AWS SSM Parameter Store** is a managed and secure storage service for configuration data and secrets. 

Its normally used for storing values such as: 
* App Configuration (e.g. Environment names, database endpoints)
* Secrets (e.g. passwords or API Keys)
* Version numbers or any string / JSON / Text. 

Its a **centralized key-value store for application configuration and secrets**. 

It integrates with other AWS Services like EC2, Lambda, ECS and CloudFormation, making it easy to inject data into the workloads. 

There are different types of parameters: 
* `String`: plain text not encrypted. 
* `StringList`: Comma-separated list of strings. 
* `SecureString`: Encrypted using AWS KMS for storing sensitive data. 

This **key-value** parameters can be accessed directly from: 
* EC2 User Data scripts
* Lambda functions
* ECS task definitions
* CloudFormation templates
* CodeBuild / CodePipeline

It has some main key benefits: 

* **Fine-grain access***: integrated with AWS IAM so you can grant or restrict access to specific parameters
* **Versioning**: SSM Parameter Store keeps previous versions of parameters and can *rollback* to a previous version
* **Low/no cost**: storing standard parameters is *free* and only KMS API usage has a cost for encryption/decryption.
* **Logging**: integrated with CloudTrail so you can keep track of who accessed or modified a parameter. 

## Use Cases

* **App configuration management** for storing non-sensitive configurations like API URLS, environmental names so apps doesnt need to be re-deployed when values change. 
* **Secrets Storage**[^1]: Store sensitive data like passwords or API Keys using `SecureString` parameters and KMS. 
* **CI/CD and IaC**: Use parameters in CodePipeline, CodeBuild, CloudFormation to pass dynamic values. 
* **Runtime config**: configuration parameters for EC2, Lambda or ECS that can be fetch on startup so the AMIs and deployments are kept generic. 
* **Version control**: Easy version control and rollback


[^1]: [[AWS - Secret Encryption]]

