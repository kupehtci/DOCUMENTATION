#AWS 

# AWS IAM Policies

AWS IAM policies are objects in AWS that can be associated with an identity or a resource to define their permissions. 

This policies are **evaluated** when an IAM principal makes a request over a resource. This policy can allow or deny that action. 

> Note!: Permissions has no method scope. This means that an IAM Identity with `GetUsers` permissions can list users in AWS CLI, Management console, AWS API or even SDK format. When you created an Identity you can choose if have CLI or programmatic access to AWS, but once that permission is granted you cannot define the scope of each of the permissions granted to that account. 

## Policy types

There are some policies, defined in different order depending on how common are they: 

* <span style="color:DodgerBlue;">Identity-based policies</span>: this type of policies can be attached to IAM Identities (Users, groups and roles)[^1] that grant permissions to that identity over certain resources. 
* <span style="color:DodgerBlue;">Resource-based policies</span>: attach inline policies to resources that grant permissions over that resource to the principals defined in the policy. 
* <span style="color:DodgerBlue;">Permission boundaries</span>: managed policy that define the maximum permissions that identity-based policies can grant to a user. 
* <span style="color:DodgerBlue;">Organization SCPs</span>: use Organization Service Control Policy (SCP) to define the maximum permissions for IAM users or IAM Roles within the organization or organizational unit (OUs). (Limit permissions, not grant)
* <span style="color:DodgerBlue;">Organization RCPs</span>: Organizations Resource Control policy to define the maximum permissions for resources within your accounts. (Limit permissions, not grant)
* <span style="color:DodgerBlue;">Access Control Lists (ACLs)</span>: Use ACLs to control which principals in other accounts can access the resources to which the ACL policy is attached to. 

Also policies depending on how they are used, they can be categorized as: 

* <span style="color:DodgerBlue;">Managed Policies</span>: Standalone Identity based policies that can be attached to multiple resources. They can be **AWS managed policies** or **Customer managed policies**. 
* <span style="color:DodgerBlue;">Inline Policies</span>: Policies that can be added directly to a single user, group or role and has a one-to-one relationship between the policy and the identity. 

## Priority

AWS evaluates the permissions of an IAM principal accessing or interacting with a resource in an strict order: 

- **Explicit Deny** always overrides everything and has the highest priority.
- **Explicit Allow** is considered only if there is no Deny.
- If neither policy allows access, it’s implicitly denied.

## JSON Format policies

An AWS IAM Policy is represented in JSON format, consisting in different parameters that set the permissions in a key-value pair format. 
It has some common parts in all types of policies and other parameters vary depending on the type of JSON policy: 

* **Version**: sets the policy language version
* **Statement**: Its the core of the policy and within it the policy is defined. 

And in case of Identity-based policies, within a statement: 
* **Effect**: allow or deny the specified actions. 
* **Action**: list of actions that the policy allows or deny. 
* **Resource**: Resource or resources in ARN format that this policy grants permissions over. It allow or deny the specified actions over that resources. 

Also optionally: 
* **Sid**:  unique identifier of the statement
* **NotAction**: actions that are excluded from the allowed or denied actions. 
* **NotResource**: resources that are excluded from the statement. 
* **Condition**: conditions under which the statement is effective[^2]. Its composed as: 

```json
"Condition" : {
	"IpAddress": {
		"aws:SourceIp" : "XXX.XXX.XXX.XXX/mm"
	}
}
```

In a resource-based policy You also need to define: 
* **Principal**: Identify the resources that has access over that resource. 


### SPECIAL USES
##### Cross-account policies 

To grant permissions to an entity over an AWS Account to access another resource within another different AWS Account you need to define two different policies: 
* A identity-based policy to grant permissions to that identity over the resource in the other Account
* A resource-based policy in the resource to able to be accessed by the other identity. 


[^1]: IAM Identity are users [[AWS - IAM User]] , groups and roles [[AWS - IAM Roles]]. 
[^2]: IAM Policy's conditions [[AWS - IAM Policy conditions]]. 