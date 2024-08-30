#AZURE #AKS 

# AZURE BOILERPLATE

This infrastructure consist in several different components that work together to provide a basic template for almost all use cases of Azure Kubernetes Infrastructures. 

#### Azure Infrastructure overview

The key features of the structure are: 

* An Azure Kubernetes Service resource. 
* A vNet with two separated subnets for Atlantis and AKS respectively. 
* Inbound and outbound rules to allow / restrict traffic to atlantis and aks subnets. 
* Storage account with a blob container for backups and file shares for atlantis and other resources. 
* Key vault for managing secrets, encryption keys and certificates. 
* Atlantis running in an Azure Container Instance isolated and scalable environment. 
* Azure Monitor to collect and analyze infrastructure relative data by using Log Analytics workspace that query metrics from the entire environment. 

### In-Cluster Infrastructure overview 

Within the AKS cluster, the following tools and services are automatically deployed and fully configured using terraform:

* `ArgoCD`

Provides Continuous Delivery and GitOps tool for kubernetes or Helm applications inside the cluster. Monitors the linked Git repositories and automatically syncs them to inside the cluster. 
Provides consistency and optimize the delivery process. 

* `Nginx`

Manages internal and external access to services within the Kubernetes Cluster. 
Acts as load balancer and reverse proxy routing the incoming traffic to the internal resources. Simplify the traffic by having a single entry point to the cluster. 

* `Cert Manager`

Automates the management and renovation of certificates.   

* `Prometheus and grafana`

Provides metric collection, monitoring and dashboards within the kubernetes cluster. Allow to create custom dashboards for data analysis and  define rules for detecting errors or warnings. 

* `velero`

Tool that provide backup and restore, disaster recover and migration of the kubernetes resources. 
Ensures that you can recover from disaster by deploying a recent backup and persistent volumes. 



