#GCP #CLOUD 

# GKE Custom IAM Service Account


A GCP Service Account is a type of principal used for granting applications permissions over GCP resources. Acts similar to a Google Account.  

You can create a custom IAM Role using terraform. 

For this you need to declare a GCP Service Account and attach an IAM member with a custom role to it: 

```hcl
resource "google_service_account" "example" {
  account_id = "<name>"
}

resource "google_project_iam_member" "kubernetes_binding" {
  project = "<gcp-project-id>"
  member = "serviceAccount:${google_service_account.example.email}"
  
  role = google_project_iam_custom_role.custom_role.name
  
  depends_on = [ google_project_iam_custom_role.gke_custom_role ]
}

resource "google_project_iam_custom_role" "custom_role" {
  role_id = "custom-role"
  title = "custom-role"
  description = "<description>"
  permissions = ["iam.roles.list", "..."]
}
```