#AWS 

# AWS - IAM Identity-based policies

An **identity-based policy** is a type of JSON policy in AWS that can be attached to an IAM Entity (Users, Roles or groups). 

These policies define what actions the identity can perform and on which resources.

Example: allowing a user to `s3:GetObject`on an specific bucket. 


### JSON Format

Like other AWS policies, the identity-based policy consists in a JSON document that is attached to an IAM identity. 

Every policy is a JSON with this key elements: 

```json
{
  "Version": "2012-10-17",
  "Statement": [
    {
      "Effect": "Allow",
      "Action": [
        "s3:GetObject",
        "s3:PutObject"
      ],
      "Resource": "arn:aws:s3:::my-bucket/*",
      "Condition": {
        "IpAddress": {
          "aws:SourceIp": "203.0.113.0/24"
        }
      }
    }
  ]
}
```

* **Version**: Current IAM policy language, currently `"2012-10-17"`
* **Statement**: list of individual rules.
* **Effect**: `Allow` or `Deny`
* **Action**: Specific API operations like `s3:PutObject`or `ec2:StartInstance`. 
* **Resource**: ARN of the resource or `"*"` to refer to all objects. 
* **Condition**: (Optional) refines access by defining a condition that must be met to apply the rule, like restring source IP, MFA, tags or similar. 


### Notes

* Take always into account the **least privilege principle**. 
* **Identity-based vs Resource-based principles**: take into account whether to define the access policy on the resource or to the identities that use it. 
	* Example: - Company wants to allow cross-account S3 access → Which one to use? Resource-based policy (bucket policy).
* **Deny overrides allow**: if a user has an inline-policy with `Allow` but an SCP denies, the user won't be able to access, 
* **Managed policies (AWS managed) vs inline**: managed policies are easier to maintain across multiple entities. 