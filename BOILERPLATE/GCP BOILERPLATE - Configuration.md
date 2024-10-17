#GCP #CLOUD
## GCP BOILERPLATE

This is a overview of the configuration about the Google Cloud Platform Boilerplate infrastructure for deploying a fully functional Google Kubernetes Engine. 

![[./IMAGES/gcp-boilerplate-v2.png]]
### Providers configuration

There is only one provider necessary for this project, `hashicorp/google`. In this case for authenticating to google via terraform, you only need to specify the Project ID of the project where the resources are going to be deployed and the region. 

Before doing terraform apply, in order to login to this project, you need to go `gcloud auth login` and login into google using the web browser. 

Firstly set the following properties about the project in order to configure terraform provider: 
```init
gcp_project_id = "boilerplate-gtq-250-46259"
gcp_region = "europe-southwest1"
project = "boilerplate"
environment = "pre"
```

Take into account that `project` is only for naming and prefixed of the different resources, not the project ID within GCP. 
### Network configuration

The network consist in a main VPC with one private subnet where all the resources reside and are externally communicated using **Cloud NAT** and **Cloud Router** associated with the main VPC.

The **Cloud NAT** its provided with an Static Premium public IP. 

This private subnet provision two different secondary IP ranges that define two different CIDR that are assigned to the GKE cluster to allocate IPs to the services and Pods. 

The names are also defined as parameters and dynamically provided to the GKE. 
```init
vpc_cluster_ip_range_name = "k8s-pod-range"
vpc_cluster_ip_range_cidr = "10.16.0.0/16"

vpc_services_ip_range_name = "k8s-service-range"
vpc_services_ip_range_cidr = "10.32.0.0/16"
```
Names are only used for assignation of the secondary IP purposes and are automatically assigned in the GKE as well as created in the Private Subnet.

This CIDR allocated for the GKE **must not overlap between them** and with the Private Subnet CIDR

Routing mode of the VPC is set to `REGIONAL` by default, but can also be set to `GLOBAL` to multi-regional infrastructures.

In order to communicate Private IP resources to the public Internet, a NAT and a router is configured to redirect the ingress / egress traffic to the private subnet of the cluster
The NAT is provided with a google compute address to have public access. The main network routes are created by default, but more routes can be created to the main VPC by adding more using the following template: 

```hcl
resource "google_compute_route" "default" {
  name        = "route-all-from-...-to-..."
  dest_range  = "XXX.XXX.XXX.XXX/XX"
  network     = google_compute_network.vpc.name
  next_hop_ip = "XXX.XXX.XXX.XXX"
  priority    = 100
}
```

### API Services

The different APIs that Google needs to communicate to deploy various of the resources, are enabled by `google_project_service` and its configured to create this type resource per each one of the different APIs listed in this variable 

```json
gcp_services = [
    "compute.googleapis.com",             
    "container.googleapis.com",           
    "artifactregistry.googleapis.com"     
  ]
```
This 3 APIs are the necessary configured for the resources in the boilerplate. In case of needing more enabled API services, add the `googleapis` link to the list to create the resource. 

You can list all the available services with the following command: 
```bash
gcloud services list --available
```

Or list the current enabled ones by using google web console or using `gcloud` console using the following command: 

```bash
gcloud services list --enabled --project <PROJECT>
```

In case some modifications on the API services enabled, results in terraform reporting a dependency error of some API services, enable `gcp_apis_disable_dependent_services` to force its deletion. Its recommended to keep this as false in **production environments**. 
### GCP Artifact Registry

Artifact registry is preconfigured to have an Image repository that is accesible from the GKE to pull and push images. 

Its preconfigured to hold DOCKER images by default with an unique name composed of `<project>-<environment>-cr`. This can be changed in the artifact registry `repository_id` variable if want a custom name. 

The deployment of the artifact registry can be disabled by setting `deploy_artifact_registry` to false or deleting the resource. 

By default is configure to hold DOCKER images without tag immutability, but can be changes with terraform variables to hold NPM, Python or other artifacts.

### Remote docker repository

To create some **authentication** with a service account to access a remote container registry, you can enable `deploy_remote_docker_repository` and configure the URL, username and password to create and handle the upstream and pull connections. 

By default it grants certain permissions to the GKE, to access the secrets to get the credentials for accessing a remote repository. It uses Google **Secret Manager** so <span style="color:DodgerBlue;">secretmanager.googleapis.com</span> API must be enabled if the secrets are managed with it. 

Its recommended to not specify the **remote docker repository password** in the `terraform.tfvars` file, instead pass it to terraform by creating a environmental variable like `TF_VARS_remote_docker_repository_password` or input in the console while doing terraform apply. 

### Storage Cloud

One bucket is created if `deploy_storage_bucket` is set for having future storage in buckets from the boilerplate and / or velero deployment.

You can set the name of the bucket with `cloud_storage_bucket_name` and its location `cloud_storage_bucket_location`. 

By default is set to normal behavior of the storage as `STANDARD`. This can be set through `cloud_storage_bucket_class`. This can only be set to STANDARD, MULTI_REGIONAL, REGIONAL, NEARLINE, COLDLINE or ARCHIVE, normally settled depending on the access rate to the files in the bucket. 

`cloud_storage_bucket_force_destroy` this is set to true by default in order to be able to destroy and replace it when creating the resources with terraform but its recommended to set as false in production environments to prevent erase data hold in it. 

By default in order to reduce the cost of the storage, the versioning is disabled but can be enabled by setting `cloud_storage_bucket_versioning_enabled` flag 

### Workload identity

The resources predefined in `gke_workload_idenity.tf` file serve as a template for creating a workload identity and after a service account for enabling GKE authentication from pods during the workload. 

Take into account that a Kubernetes Service Account in order to use this Google Service Account must have same namespace and name as the one specified in the workload identity as: 

```bash
## Format 
serviceAccount:<gcp-project-id>.svc.id.goog[<k8s-namespace>/<ser-account-name>}]

## As an example for a workload identity that can be ussed by 'grafana-sa' 
## ServiceAccount in 'monitor' namespace: 
serviceAccount:hiberus-boilerplate.svc.id.goog[monitor/grafana-sa}]
```

### GKE Configuration

This section summarizes the configuration of the main Google Kubernetes Engine of the infrastructure. 
Also describe the different variables to adapt the networking functionalities of the GKE, the node pool provided or default one, logging and locations of the GKE. 

##### GKE Google Service Account

By default, it creates a `resource "google_service_account" "kubernetes"` google service account that its provided to the GKE node pool in order to be able to be used by the GKE resources. This Google Service account is attached to an IAM Member that has a custom role associated with it. 

This custom role is provided with the main permissions that a GKE service account and resource from inside the cluster can get over the resources. For more information about the different permissions that can be specified within a custom role take a look to (Custom role permissions)[https://cloud.google.com/iam/docs/custom-roles-permissions-support]. 

The custom GKE role permissions are declared in the following variable:  
```hcl
gke_service_account_custom_role_permissions = [
    ## Basic cluster and node pool management
    "container.clusters.create",
    "container.clusters.delete",
    "container.clusters.get",
    "container.clusters.list",
    "container.clusters.update",
    "container.clusters.getCredentials",

    # Security and network policies
    "container.networkPolicies.create", 
    "container.networkPolicies.delete",   	
    "container.networkPolicies.get", 
    "container.networkPolicies.list", 
    "container.networkPolicies.update", 

    # Allow to get and use Workload Identities
    "iam.serviceAccounts.actAs",
    "iam.serviceAccounts.get",

    ## Artifact registry and monitoring
    "artifactregistry.repositories.get",
    "artifactregistry.repositories.list",
    "artifactregistry.repositories.downloadArtifacts",
    "monitoring.timeSeries.list",
    "logging.logEntries.list",
  ]
```
#### GKE Node pool configuration 

The `gke_use_custom_node_pool = true` flag sets by default the cluster to not use its default node pool by setting `remove_default_node_pool` to true and the initial nodes deployed in google to 1 instead of 2. In case that its set to `false`, google will auto provide a managed node pool and you can set the number of nodes manually.

You can set the maximum number of pods per each node with the <span style="color:DodgerBlue;">gke_max_pods_per_node</span> variable. When reaches the maximum number of pods, the new scheduled pods will be scheduled for the new node of the autoscaling. 

Autoscaling of the node pool can be managed controlling the desired number of nodes and the maximum and minimum by setting

```yaml
## Enable autoscaling of the GKE cluster
gke_enabled_autoscaling = true

## Number of nodes for the Node Pool of the GKE
gke_desired_node_count = 1

## Minimum number of pods for the autoscaling  
gke_min_node_count = 0

## Maximum number of pods for the autoscaling
gke_max_node_count = 2
```

If min and max node count are set but `gke_enabled_autoscaling` flag is not set to true, this will set min and max to the desired node count. 

The machine type to use for each node of the node pool, can be set with <span style="color:DodgerBlue;">gke_node_pool_machine_type</span> variable. Use the standard machine names definition from google [Machine types](https://cloud.google.com/compute/docs/machine-resource). 
By default its set to a <span style="color:orange;">e2-standard-2</span> with 2 vCPUs, 8 GB of memory and 4 Gbps max egress bandwidth. For more small purposes, can be set to `e2-micro`, `e2-small` or `e2-medium` for low resources need environments. (Shared Core VMs). 

When using the GKE for **production environments** and not for testing purpose, its recommended to set `gke_delete_protection` to true to protect GKE from being deleted by terraform. Also for some changes in the cluster, if needs to be recreated, this flag must set to false to be able to delete and create again.
#### GKE Networking

By default the most recommended mode for GKE networking method is <span style="color:DodgerBlue;">VPC native</span> to let IP aliasing and automatically managed route tables. Its recommended to leave GKE to VPC_NATIVE by the flag `gke_networking_mode = "VPC_NATIVE"`. In case of setting it to <span style="color:LightBlue;">ROUTES</span> , change the networking resources properties of this infrastructure. 

The different allocated secondary IP ranges, provided to GKE to **allocate pods and services IPs** within its CIDR block its set with `vpc_cluster_ip_range_name` for the pods and `vpc_services_ip_range_name` for the services. This sets automatically the names of the two allocations that are configured in the main private subnet. 
For defining its correspondent CIDR blocks, set `vpc_cluster_ip_range_cidr` and `vpc_services_ip_range_cidr`. 

Take into account that this secondary IP ranges **must no overlap with the Private Subnet CIDR block**.  

#### GKE Location

The location of the cluster can be set with `gke_cluster_location`. Its recommended to keep in the same zone as the Project's one settled with `gcp_region` variable. 
The location of the nodes managed from the GKE's node pool, can be set with the property `gke_node_locations`. Take into account that need to be in zones within the same region that is defined for the GKE cluster.

#### GKE logging resources

In order to retrieve logs and metrics from components inside the GKE, you can specify the list of resources that reports to the monitor. 

By setting `gke_monitored_resources` you define the type of resources from the  GKE that are going to be reported to the logging service. 

```
gke_monitored_resources = ["SYSTEM_COMPONENTS", "APISERVER", "SCHEDULER", "CONTROLLER_MANAGER", "STORAGE", "HPA", "POD", "DAEMONSET", "DEPLOYMENT", "STATEFULSET", "KUBELET", "CADVISOR"]
```

Also `"https://www.googleapis.com/auth/monitoring"` need to be keep as `oauth_scope` and the API for the monitoring service as GKE's cluster `monitoring_service = "monitoring.googleapis.com/kubernetes"` for reporting the logs to the correct API within Google. 

> NOTE: in order to report metrics to Google you need to have GMP (Google Managed Prometheus) enabled, otherwise terraform will report an error. If GMP is disabled, keep `gke_monitored_resources = []` to don't report any metric or log