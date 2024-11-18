#AWS #CLOUD 

# AWS IAM Roles

AWS IAM Roles are RBAC resources for letting granular access to AWS Resources. 

This IAM Roles grants temporal AWS credentials and can be used by multiple users and employees that share the same role.


##### Assume roles

This roles can be assumed by an IAM user that has Assume Roles permissions over that role in order to get temporal permissions over some resources. 

Although some users can use the same IAM Role to perform some actions, this events can be tracked by users in order to **audit** this actions. 

A role can be assumed by a trusted identity (IAM user, AWS service or a federated user). 

