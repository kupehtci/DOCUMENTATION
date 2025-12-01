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

## AWS Control Tower Account Factory

**Account Factory** is a component of AWS Control Tower that automates the creation and management of new AWS accounts in a *Multi-Account Landing Zone* or MALZ. 

It provides an standardized and configurable template for the accounts that define a baseline that complies with the organization's security and governance standards: 
* Networking
* Guardrails
* Region restrictions
* SSO

## SCP or Service Control Policies

**SCPs** or **Service Control Policies** are guardrails that **prevent actions**: 
* Block API Calls before even executed
* Cannot be overridden by AWS Account administrators (Only administered by the Control Tower Admin).
* Its the most powerful AWS permission mechanism. 

They apply to all accounts in the organization affecting all users, roles and resources. Event the account root user can be restricted by an SCP. 

Can be used for: 
* Deny creation of certain resources.
* Deny attachments of IGWs to VPCs (deny internet access)
* Deny specific actions like delete resources. 

An SCP looks like: 
```json
{
  "Version": "2012-10-17",
  "Statement": [
    {
      "Sid": "DenyAllRegionsExceptApNortheast3",
      "Effect": "Deny",
      "NotAction": [
        "iam:*",
        "sts:*",
        "organizations:*",
        "account:*",
        "cloudtrail:LookupEvents",
        "cloudtrail:GetTrailStatus",
        "support:*",
        "budgets:*"
      ],
      "Resource": "*",
      "Condition": {
        "StringNotEquals": {
          "aws:RequestedRegion": "ap-northeast-3"
        }
      }
    },
    {
      "Sid": "DenyInternetConnectivity",
      "Effect": "Deny",
      "Action": [
        "ec2:CreateInternetGateway",
        "ec2:AttachInternetGateway",
        "ec2:DeleteInternetGateway",
        "ec2:DetachInternetGateway",
        "ec2:CreateNatGateway",
        "ec2:CreateEgressOnlyInternetGateway",
        "ec2:AttachVpnGateway",
        "directconnect:*"
      ],
      "Resource": "*"
    },
    {
      "Sid": "DenyVPCPeeringOutsideRegion",
      "Effect": "Deny",
      "Action": [
        "ec2:CreateVpcPeeringConnection",
        "ec2:AcceptVpcPeeringConnection"
      ],
      "Resource": "*",
      "Condition": {
        "StringNotEquals": {
          "aws:RequestedRegion": "ap-northeast-3"
        }
      }
    }
  ]
}
```

SCPs can also be attached to AWS Accounts or to Organizational Units (OU), so for enforcing new policies you can: 
* Attach the new SCP to the appropriate AWS Account directly. 
* Create an OU, move the AWS Account to the OU and attach the SCP to the OU. 

### SCPs vs AWS Config

AWS Control Tower's SCPs prevent actions (Block) from happening. AWS Config otherwise, detects when something happens and notify when an resource configuration it's not-compliant. 