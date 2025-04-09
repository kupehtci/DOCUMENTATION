
#AWS 

You can have access from identities in an A account access a B account resources. In order to do so, we will need to be able to assume a role that has that policy atached to it. 

You will need various policies:

1. A Identity based policy that allows permissions over the resource in <span style="color:orange;">destination account</span>. 
2. An assume role policy that grant permissions to the Identities in the <span style="color:DodgerBlue;">origin account</span>. 
3. (Optional) A resource-based policy that limits who has access to the resource in the <span style="color:orange;">destination account</span>

Once you have created an identity that has the proper permissions over that resource in the <span style="color:orange;">destination account</span>, you can create an IAM role with that policy. 

This role its going to be assumed by the IAM users or other Identities in the other account. We need to define an Assume Role Policy in the <span style="color:DodgerBlue;">origin account</span> 

An example of the resource based policy that set the access scope to the user is:
```json
{
  "Version": "2012-10-17",
  "Statement": [
    {
      "Sid": "CrossAccountAccess",
      "Effect": "Allow",
      "Principal": {
        "AWS": "arn:aws:iam::<account-id>user/<user-id>"
      },
      "Action": [
        "s3:GetObject",
        "s3:PutObject"
      ],
      "Resource": "arn:aws:s3:::example-bucket/*"
    }
  ]
}
```