#GCP  #CLOUD 
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
* **ID**: unique identifier of the role. 
* **Description**: an human-readable description of the role. 
* **Permissions**: the permissions included by the role, following this format: 

```bash
<SERVICE>.<RESOURCE>.<VERB>
```

As an example, `compute.disks.get` or `storage.objects.create`. 

### IAM Policies

IAM Policies in Google Cloud offer several types of policies to control the resources that certain principals can access. 

Policies can be one of this types: 
* **Allow policies**: Grant principals access to resources
* **Deny policies**: Ensure that principals cannot use specific permissions
* **PAB policies**: Restricting the resources that a principal can access. 

In order to grant a certain IAM member access to a certain role, you need to 

### IAM Custom Roles in terraform

You can define custom IAM Roles in Google Cloud: 

```hcl
resource "google_project_iam_custom_role" "my-custom-role" {
  role_id     = "<role-id-name>"
  title       = "<legible-name>"
  description = "<description>"
  permissions = ["iam.roles.list", "iam.roles.create", "iam.roles.delete"]
}
```

You only need to set the same properties as described before, and a lis of permissions that can use.

`project` can be set, but if not specified, it will take by default the specified project in the `google` provider. 

The id of the role will be defined as: `projects/<PROJECT-ID>/roles/<ROLE-ID>`. 

Then this role if want to grant access to it to a certain member, you need to define an IAM policy binding, you need to define either one of this resources: 

Three different resources help you manage your IAM policy for a service account. Each of these resources serves a different use case:

- <span style="color:DodgerBlue;">google_service_account_iam_policy</span>: Authoritative. Sets the IAM policy for the service account and replaces any existing policy already attached.
- <span style="color:DodgerBlue;">google_service_account_iam_binding</span>: Authoritative for a given role. Updates the IAM policy to grant a role to a list of members. Other roles within the IAM policy for the service account are preserved.
- <span style="color:DodgerBlue;">google_service_account_iam_member</span>: Non-authoritative. Updates the IAM policy to grant a role to a new member. Other members for the role for the service account are preserved

Examples: 



* google service account iam binding: 

```json
resource "google_service_account" "sa" {
  account_id   = "my-service-account"
  display_name = "A service account that only Jane can use"
}

resource "google_service_account_iam_binding" "admin-account-iam" {
  service_account_id = google_service_account.sa.name
  role               = "roles/iam.serviceAccountUser"

  members = [
    "user:jane@example.com",
  ]
}
```

The following arguments are supported:

* <span style="color:orange;">service_account_id</span> - (Required) The fully-qualified name of the service account to apply policy to.
* <span style="color:orange;">member/members</span> - (Required) Identities that will be granted the privilege in role. Each entry can have one of the following values:
	* **allUsers**: A special identifier that represents anyone who is on the internet; with or without a Google account.
	* **allAuthenticatedUsers**: A special identifier that represents anyone who is authenticated with a Google account or a service account.
	* **user:{emailid}**: An email address that represents a specific Google account. For example, alice@gmail.com or joe@example.com.
	* **serviceAccount:{emailid}**: An email address that represents a service account. For example, my-other-app@appspot.gserviceaccount.com.
	* **group:{emailid}**: An email address that represents a Google group. For example, admins@example.com.
	* **domain:{domain}**: A G Suite domain (primary, instead of alias) name that represents all the users of that domain. For example, google.com or example.com.

* <span style="color:orange;">role</span> - (Required) The role that should be applied. Only one <span>google_service_account_iam_binding</span> can be used per role. Note that custom roles must be of the format <span>[projects|organizations]{parent-name}/roles/{role-name}</span>. 

* <span style="color:orange;">policy_data</span> - (Required only by google_service_account_iam_policy) The policy data generated by a google_iam_policy data source.

* <span style="color:orange;">condition</span> - (Optional) An IAM Condition for a given binding. Structure is documented below.
[^1]: Permissions are the basic actions that can be granted or denied to a role. By default, each action that is not specifically granted, is denied by default. 
