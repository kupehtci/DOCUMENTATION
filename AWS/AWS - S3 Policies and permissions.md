#AWS 

# AWS S3 policies and permissions 

An S3 policy is a JSON format policy document that can be attached to a resource like an Amazon S3 bucket. 

This policies specific certain actions on a certain resource and define the conditions where it apply. 


The policy is composed of the following elements: 

* <span style="color:DodgerBlue;">resource</span>: the amazon S3 bucket, object, access point or job that the policy applies to. It must be defined using ARN[^arn] of the resource: 

Example: `"Resource":"arn:aws:s3:::<bucket_name>`

* <span style="color:DodgerBlue;">Actions</span>: operations that can be done with the specified resource that can be allowed or denied.
* <span style="color:DodgerBlue;">Effect</span>: the effect that request an action on that resource will cause (`Allow` or `Deny`)
* <span style="color:DodgerBlue;">Principal</span>: account or user who is allowed access to the actions over the resources specified in the policy. 
* <span style="color:DodgerBlue;">Condition</span>: conditions for when a policy has effect. This can be used to only allow certain situations or behaviors over a resource. 

[Policies and permissions in Amazon S3 - Amazon Simple Storage Service](https://docs.aws.amazon.com/AmazonS3/latest/userguide/access-policy-language-overview.html)


[^arn]: ARN or Amazon Resource Name is a unique identifier that represents a certain resource within Amazon: [[AWS - ARNs]]

