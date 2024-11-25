#AWS 

# AWS IAM Policies

AWS IAM policies are objects in AWS that can be associated with an identity or a resource to define their permissions. 

This policies are **evaluated** when an IAM principal makes a request over a resource. This policy can allow or deny that action. 

> Note!: Permissions has no method scope. This means that an IAM Identity with `GetUsers` permissions can list users in AWS CLI, Management console, AWS API or even SDK format. When you created an Identity you can choose if have CLI or programmatic access to AWS, but once that permission is granted you cannot define the scope of each of the permissions granted to that account. 

#### Policy types

There are some policies, defined in different order depending on how common are they: 

* <span style="color:DodgerBlue;">Identity-based policies</span>: this type of policies can be attached to IAM Identities (Users, groups and roles) that grant permissions to that identity. 
* <span style="color:DodgerBlue;">Resource-based policies</span>: attach inline policies to resources that grant permissions over that resource to the principals defined in the policy. 
* <span style="color:DodgerBlue;">Permission boundaries</span>: managed policy that define the maximum permissions that identity-based policies can grant to a user. 
* <span style="color:DodgerBlue;">Organization SCPs</span>: use Organization Service Control Policy (SCP) to define the maximum permissions for IAM users or IAM Roles within the organization or organizational unit (OUs). (Limit permissions, not grant)
* <span style="color:DodgerBlue;">Organization RCPs</span>: Organizations Resource Control policy to define the maximum permissions for resources within your accounts. (Limit permissions, not grant)
* <span style="color:DodgerBlue;">Access Control Lists (ACLs)</span>: Use ACLs to control which principals in other accounts can access the resources to which the ACL policy is attached to. 