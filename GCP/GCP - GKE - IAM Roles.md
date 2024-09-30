#GKE #GCP 

# GCP GKE IAM Roles

This is a list of predefined roles that can grant access to specific resources around the Google Kubernetes Engine[^1]. 

* `roles/container.admin` provides full access
* `roles/container.clusterAdmin` Access to the management of the cluster
* `roles/container.clusterViewer` access to get and list the GKE clusters
* `roles/container.defaultNodeServiceAccount` privileged role to use as default service account 
* `roles/container.developer`: Provides access to Kubernetes API objects inside the clusters
* `roles/container.hostServiceAgentUser`: allows Kubernetes Engine Service account to configure network resources and inspect firewall
* `roles/container.viewer`: provides read-only access to Kubernetes resources. 




[^1]: GKE or Google Kubernetes Engine is a fully managed kubernetes cluster provisiones by Google Cloud. [[GCP - GKE - Google Kubernetes Engine]]