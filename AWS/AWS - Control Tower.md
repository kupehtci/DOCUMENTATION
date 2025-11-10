#AWS

# AWS - Control Tower

**AWS Control Tower** is a fully managed governance service to operate easily AWS environment (Landing Zone) with multiple AWS Accounts.

It uses best-practice blueprints and centralized guardrails for security and compliance in all AWS Accounts. 

# Guardrails

Guardrails are packed governance rules that can be enabled per organizational units (OU) to prevent non-compliant configurations. 

They can be used to enforce: 
* Mandatory encryption
* Enforcing centralized logging
* Blocking certain services usage

## Data residency guardrails

Data Residency are an special type of Guardrails to ensure resources and data stay within an approved region/s to meet compliance. 

They prevent usage of non-approved regions to deploy resources and can block or prevent the creation of certain types of resources. 

Can be used to block VPC connection to internet or creation of Internet Gateway resources. 