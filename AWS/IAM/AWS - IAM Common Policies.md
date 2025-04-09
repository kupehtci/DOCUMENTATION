#AWS 


This is a list of common policies used in AWS as examples. 
Policies are JSON based files that define the permissions of various IAM resources or identities: 


##### AWS S3 permissions 

This policy grants permissions to list the available buckets, select the one that grant permissions to and be able to manage objects within it:   

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
      "Resource": "arn:aws:s3:::<bucket-container-name>"
    },
    {
      "Effect": "Allow",
      "Action": [
        "s3:GetObject",
        "s3:PutObject",
        "s3:DeleteObject"
      ],
      "Resource": "arn:aws:s3:::<bucket-container-name>/*"
    }
  ]
}
```

You can use