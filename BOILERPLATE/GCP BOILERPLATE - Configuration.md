#GCP #CLOUD
## GCP BOILERPLATE

### Providers configuration

There is only one provider necessary for this project, `hashicorp/google`. In this case for authenticating to google via terraform, you only need to specify the Project ID of the project where the resources are going to be deployed and the region. 

Before doing terraform apply, in order to login to this project, you need to go `gcloud auth login` and login into google using the web browser. 

### Network configuration

The network consist in a main VPC with one private subnet. 

This private subnet provision two different secondary IP ranges that define two different CIDR that are assigned to the GKE cluster to allocate IPs to the services and Pods. 
The names are also defined as parameters and dinamically provided to the GKE. 

Routing mode of the VPC is set to `REGIONAL` by default. 

In order to communicate Private IP resources to the public Internet, a NAT and a router is configured to redirect the ingress / egress traffic to the private subnet of the cluster
The NAT is provided with a google compute address to have public access.

### API Services

The different APIs that Google needs to communicate to deploy various of the resources, are enabled by `google_project_service` and its configured to create this resource per each one of the different APIs listed in this variable 

```json
gcp_services = [
    "compute.googleapis.com",             
    "container.googleapis.com",           
    "artifactregistry.googleapis.com"     
  ]
```
This 3 APIs are the neccesary configured for the resources in the boilerplate. In case of needing more enabled API services, add the `googleapis` link to the list to create the resource. 

### Artifact Registry

Artifact registry is preconfigured to have an Image repository that is accesible from the GKE to pull and push images. 

Its preconfigured to hold DOCKER images by default with an unique name composed of `<project>-<environment>-cr`. This can be changed in the artifact registry `repository_id` variable if want a custom name. 

The deployment of the artifact registry can be disabled by setting `deploy_artifact_registry` to false or deleting the resource. 
### Storage Cloud

One bucket is created if `deploy_storage_bucket` is set for having future storage in buckets from the boilerplate and / or velero deployment.

You can set the name of the bucket with `cloud_storage_bucket_name` and its location `cloud_storage_bucket_location`. 

By default is set to normal behaviour of the storage as STANDARD. This can be set through `cloud_storage_bucket_class`. This can only be set to STANDARD, MULTI_REGIONAL, REGIONAL, NEARLINE, COLDLINE or ARCHIVE, normally settled depending on the access rate to the files in the bucket. 

`cloud_storage_bucket_force_destroy` this is set to true by defualt in order to be able to destroy and replace it when creating the resources with terraform but its recommended to set as false in production environments to prevent erase data hold in it. 

By default in order to reduce the cost of the storage, the versioning is disabled but can be enabled by setting `cloud_storage_bucket_versioning_enabled` flag 

### Workload identity

The resources predefined in `gke_workload_idenity.tf` file serve as a template for creating a workload identity and after a service account for enabling GKE authentication from pods during the worlkload. 

### GKE Configuration

This section summarizes the configuration of the main Google Kubernetes Engine of the infrastructure. 
Also describe the different variables to adapt the networking functionalities of the GKE, the node pool provided or default one, logging and locations of the GKE

By default, it creates a `resource "google_service_account" "kubernetes"` google service account that its provided to the GKE node pool in order to be able to be used by the GKE resources. THis Google Service account is attached to an IAM Member that has a custom role associated with it. 
This custom role is provided with the main permissions that a GKE service account and resource from inside the cluster can get over the resources. For more information about the different permissions that can be specified within a custom role take a look to (Custom role permissions)[https://cloud.google.com/iam/docs/custom-roles-permissions-support]. 


#### GKE Node pool configuration 

The `gke_use_custom_node_pool = true` flag sets by default the cluster to not use its default node pool by setting `remove_default_node_pool` to true and the initial nodes deployed in google to 1 instead of 2. In case that its set to `false`, google will auto provide a managed node pool and you can set the number of nodes manually.

You can set the maximum number of pods per each node with the `gke_max_pods_per_node` variable. When reaches the maximum number of pods, the new scheduled pods will be scheduled for the new node of the autoscaling. 

Autoscaling of the node pool can be managed controlling the desired number of nodes and the maximum and minimum by setting

```yaml
## Number of nodes for the Node Pool of the GKE
gke_desired_node_count = 1

## Minimum number of pods for the autoscaling  
gke_min_node_count = 0

## Maximum number of pods for the autoscaling
gke_max_node_count = 2
```

The machine type to use for each node of the node pool, can be set with `gke_node_pool_machine_type` variable. Use the standard machine names definition from google [Machine types](https://cloud.google.com/compute/docs/machine-resource). By default its set to a `e2-standard-2` with 2 vCPUs, 8 GB of memory and 4 Gbps max egress bandwidth. For more small purposes, can be set to `e2-micro`, `e2-small` or `e2-medium` for low resources need environments. (Shared Core VMs)


#### GKE Networking

By default the most recommended mode for GKE networking method is VPC native to let IP aliasing and automatically managed route tables. Its recommended to leave GKE to VPC_NATIVE by the flag `gke_networking_mode = "VPC_NATIVE"`. In case of setting it to ROUTES, change the networking resources properties of this infrastructure. 

The different allocated secondary IP ranges, provided to GKE to **allocate pods and services IPs** within its CIDR block its set with `vpc_cluster_ip_range_name` for the pods and `vpc_services_ip_range_name` for the services. This sets automatically the names of the two allocations that are configured in the main private subnet. 
For defining its correspondent CIDR blocks, set `vpc_cluster_ip_range_cidr` and `vpc_services_ip_range_cidr`. 

Take into account that this seconday IP ranges **must no overlap with the Private Subnet CIDR block**.  


#### GKE Location

The location of the cluster can be set with `gke_cluster_location`. Its recommended to keep in the same zone as the Project's one settled with `gcp_region` variable. 
The location of the nodes managed from the GKE's node pool, can be set with the property `gke_node_locations`. Take into account that need to be in zones within the same region that is defined for the GKE.

When using the GKE for **production environments** and not for testing purpose, its recommended to set `gke_delete_protection` to true to protect GKE from being deleted by terraform. Also for some changes in the cluster, if needs to be recreated, this flag must set to false to be able to delete and create again.

#### GKE logging resources

By setting `gke_monitored_resources` you define the type of resources from the  GKE that are going to be reported to the logging service. 

```
gke_monitored_resources = ["SYSTEM_COMPONENTS", "APISERVER", "SCHEDULER", "CONTROLLER_MANAGER", "STORAGE", "HPA", "POD", "DAEMONSET", "DEPLOYMENT", "STATEFULSET", "KUBELET", "CADVISOR"]
```

Also `"https://www.googleapis.com/auth/monitoring"` need to be keep as `oauth_scope` and the API for the monitoring service as GKE's cluster `monitoring_service = "monitoring.googleapis.com/kubernetes"` for reporting the logs to the correct API within Google