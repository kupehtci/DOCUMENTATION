#AWS 


This is a list of common policies used in AWS as examples. 
Policies are JSON based files that define the permissions of various IAM resources or identities: 


### AWS S3 permissions 

This **identity-policy** grants permissions to list the available buckets, select the one that grant permissions to and be able to manage objects within it:   

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

In this policy, resources is as "\<bucket-container-name\>\/\*" so its related with object belonging under that resource. Meaning \* its for all resources that start with that ARN [^1]

If you want to restrict access to a single account over a single object within an S3 bucket, you can define a policy similar to this: 

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

> Note: this policy is an resource-based policy so must be attached to the bucket. 

[^1]: Amazon Resource Name or ARN is an unique object identifier within AWS [[AWS - ARNs]]. 

