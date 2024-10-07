#GCP 


# GCP IAM identity and Access Management

IAM allows to manage a granular access to the resources within your google cloud project.

<span style="color:DodgerBlue;">Principal</span> are the **who** of the IAM and it can be: 

* individual users
* groups
* domains
* the whole public

You can grant <span style="color:magenta;">roles</span> to these principals to give them permissions to perform actions over Google Resources. 

Permissions[^1] are the most basic Unit of the IAM, its an allowed action over a certain resource or type of resources. 

This <span style="color:magenta;">roles</span> are a set of one or more permissions over some resources and the set of all roles granted to a resource are called an <span style="color:LightSalmon;">IAM policy</span>. 

You have three types of roles: 

* **Basic Roles**: Owned, Editor and viewer that existed previously to IAM roles
* **Predefined Roles**: provide granular access to specific services and are managed by Google Cloud. 
* **Custom Roles**: Roles predefined by the user that grant a customized list of permissions. 

And each role have some <span style="color:DodgerBlue;">properties</span>: 

* **Title**: its an human readable name for the IAM role. 
* **Name**: An identifier of the role following a format: 

| Level              | Format                                      | Example             |
| ------------------ | ------------------------------------------- | ------------------- |
| Predefined roles   | `roles/<SERVICE>.<IDENTIFIER>`              | roles/storage.admin |
| Project roles      | `projects/<PROJECT-ID>/roles/<IDENTIFIER>`  |                     |
| Organization roles | `organizations/<ORG-ID>/roles/<IDENTIFIER>` |                     |
* **ID**: unique identifier of the role
* **Description**: an human-readable description of the role. 
* **Permissions**: the permissions included by the role, following this format: 

```bash
<SERVICE>.<RESOURCE>.<VERB>
```

### IAM Policies

IAM Policies in Google Cloud offer several types of policies to control the resources can principals access. 
Policies can be one of this types: 

* **Allow policies**: Grant principals access to resources
* **Deny policies**: Ensure that principals cannot use specific permissions
* **PAB policies**: Restricting the resources that a principal can access. 


### IAM Custom Roles in terraform

You can define custom IAM Roles in Google Cloud: 

```hcl
resource "google_project_iam_custom_role" "my-custom-role" {
  role_id     = "<role-id-name>"
  title       = "<legible-name>"
  description = "<description>"
  permissions = ["iam.roles.list", "iam.roles.create", "iam.roles.delete"] #Example
}
```

You only need to set the same properties as described before, and a lis of permissions that can use.

`project` can be set, but if not specified, it will take by default the specified project in the `google` provider. 

The id of the role will be defined as: `projects/<PROJECT-ID>/roles/<ROLE-ID>`. 


[^1]: Permissions are the basic actions that can be granted or denied to a role. By default, each action that is not specifically granted, is denied by default. 
