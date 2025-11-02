#AWS

# AWS - IAM Policy Conditions

Policies can have conditions that needs to be met in order to apply a policy. 
You can restrict certain policies to for example, sourceIP value or others. 

For evaluating a condition you need to use an operator: 
- `StringEquals`
- `StringNotEquals`
- `StringLike`
- `StringNotLike`
- `Bool`
- `IpAddress`
- `NotIpAddress`
- `DateGreaterThan`
- `DateLessThan`
- Others

This is a list of conditions that can be defined in a policy: 

## General

* `aws:CurrentTime`: restrict access depending on the current time. Useful for blocking resources access outside work time.
* 




## <span style="color:DarkBlue;">S3-related conditions</span>

* `s3:prefix`: restrict the policy over items or resources with a certain prefix. Example only allow access to `s3://bucket/reports/*`.
* `s3:delimiter`: restrict listing operations to a certain folder.

## <span style="color:DarkBlue;">Networking-related conditions</span>

* `aws:SourceIp`: restrict access to incoming requests from a certain IP. Useful for limiting access to a resource to known resources with static or known IPs. 
* `aws:VpcSourceIp`: restrict access to certain VPCs.
* `aws:SourceVpce`: restrict access over certain VPC endpoints. You can use this condition to restrict S3 traffic to only from an VPC Endpoint. 
* `aws:UserAgent`: restrict access by a client.  


## <span style="color:DarkBlue;">Organization or Account-related conditions</span>

* `aws:PrincipalOrgID`: Restrict access to only accounts in the AWS Organization. 
* `aws:PrincipalOrgPaths`: Restrict access to certain OU (Organizational Units) in the AWS Organization. 
* `aws:PrincipalAccount`: Restrict access to a certain account. 

## <span style="color:DarkBlue;">Security-related conditions</span>

* `aws:MultiFactorAuthPresent`: Only allow a certain action if MFA is enabled. 
* `aws:TokenIssueTime`: restrict access to tokens only expedited after a certain time. Useful for restrict to newly generated tokens. 
* `aws:SecureTransport`: restrict access to only HTTP traffic. 

## <span style="color:DarkBlue;">API-related conditions</span>

* `aws:RequestSource`: restrict access to a certain resource from AWS. 