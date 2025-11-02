#AWS 

# AWS S3 policies and permissions 

An S3 policy is a JSON format policy document that can be attached to an Amazon S3 bucket. 

The policy is composed of the following elements: 

* <span style="color:DodgerBlue;">resource</span>: the amazon S3 bucket, object, access point or job that the policy applies to. It must be defined using ARN[^arn] of the resource: 
	Example: `"Resource":"arn:aws:s3:::<bucket_name>`
* <span style="color:DodgerBlue;">Actions</span>: operations that can be done with the specified resource that can be allowed or denied.
* <span style="color:DodgerBlue;">Effect</span>: the effect that request an action on that resource will cause (`Allow` or `Deny`)
* <span style="color:DodgerBlue;">Principal</span>: account or user who is allowed access to the actions over the resources specified in the policy. 
* <span style="color:DodgerBlue;">Condition</span>: conditions for when a policy has effect. This can be used to only allow certain situations or behaviors over a resource. 

By **default**, only the owner account's IAM principals has access over the bucket so for granting access to other resources, services or identities on other accounts you need to attach certain policies to the S3 bucket. 

[Policies and permissions in Amazon S3 - Amazon Simple Storage Service](https://docs.aws.amazon.com/AmazonS3/latest/userguide/access-policy-language-overview.html)


### Identity-based policy

This is an example identity-based policy that by attaching it to an IAM Identity [[AWS - IAM User]], you can give it permissions over an S3 bucket: 

```json
{
  "Version": "2012-10-17",
  "Statement": [
    {
      "Effect": "Allow",
      "Action": "s3:ListAllMyBuckets",
      "Resource": "*"
    },
    {
      "Effect": "Allow",
      "Action": [
        "s3:ListBucket",
        "s3:GetBucketLocation"
       ],
      "Resource": "arn:aws:s3:::<bucket-name>"
    },
    {
      "Effect": "Allow",
      "Action": [
        "s3:GetObject",
        "s3:PutObject",
        "s3:DeleteObject"
      ],
      "Resource": "arn:aws:s3:::<bucket-name>/*"
    }
  ]
}
```

### Resource-based policy

This is a resource-based policy that can be attached to an S3 bucket to 
restrict permissions over it. 

```json
{
  "Version": "2012-10-17",
  "Statement": [
    {
      "Sid": "SingleObjectAccess",
      "Effect": "Allow",
      "Principal": {
        "AWS": "arn:aws:iam::111122223333:root"
      },
      "Action": "s3:GetObject",
      "Resource": "arn:aws:s3:::my-bucket/path/to/my-object.txt"
    }
  ]
}
```

You need to set `"Principal"` in order to define the IAM Principal that you are giving access to the S3 bucket. 

You can use the following common conditions to customize the access to the S3 resource. 
* `aws:SourceVpce`: restrict access over certain VPC endpoints. You can use this condition to restrict S3 traffic to only from an VPC Endpoint. 


[^arn]: ARN or Amazon Resource Name is a unique identifier that represents a certain resource within Amazon: [[AWS - ARNs]]

