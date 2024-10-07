#AWS 

# AWS Boilerplate Overview

This infrastructure consist in several different components that work together to provide a basic template as a common infrastructure core for deploying an Elastic Kubernetes Service (EKS). 

#### AWS Infrastructure overview

The key features of the structure are: 

* A **main VPC** composed of **4 subnets** (2 private and 2 public). The traffic is routed using route tables from the private subnets to a **NAT Gateway** to the public ones and from the public ones to the Internet using an **Internet gateway**. 
* An **EKS with a Node Group** provisioned to run the Kubernetes workloads in worker nodes managed with autoscaling and protected by a custom security group. 
* Basic workload add-ons for the EKS
	* **AWS EBS CSI Driver**: provides CSI for managing EBS as EKS storage solution
	* **Core DNS** for service discovery within the cluster
	* **EKS Pod identity agent** to manage IAM roles provided to Kubernetes Service Accounts
	* **Kube proxy**: Allow network proxy operations within the cluster. 
	* **VPC CNI**: manage networking within the EKS using the VPC. 
* Custom **IAM Policies** for EKS, node group and ALB. 
* **S3 bucket** with configurable versioning. 
* ALB, EKS and VPC managed **security groups** with custom ingress and egress rules. 
* A managed **ECR** with custom policies to be able to pull images from the EKS. 
* A **cloudwatch log group** to collect metrics from EKS control plane


The **Application Load Balancer** is provided in the solution but not deployed by default. Its recommended to use AWS ALB controller inside the EKS and this will automatically deploy, manage and configure the ALB and its routes, rules and listeners. 


### In-Cluster Infrastructure overview 

Within the AKS cluster, the following tools and services are automatically deployed and fully configured using terraform:

* `ArgoCD`

Provides Continuous Delivery and GitOps tool for kubernetes or Helm applications inside the cluster. Monitors the linked Git repositories and automatically syncs them to inside the cluster. 
Provides consistency and optimize the delivery process. 

* `AWS ALB controller`

Exposes the application through the internet automatically by exposing the ingress resources following its annotations. 
If you expose a service it creates a Network Load Balancer that points to this service and if expose an ingress resource it creates an Application Load Balancer. 

Also configures the ELB listeners, deploy the correspondent target groups and traffic rules to route the traffic to the Pods following the correspondent annotations. 

* `Cert Manager`

Automates the management and renovation of certificates.  Allow to validate certificates using HTTPs and DNS method through various certificate authorities. 

* `Prometheus and grafana`

Provides metric collection, monitoring and dashboards within the kubernetes cluster. Allow to create custom dashboards for data analysis and  define rules for detecting errors or warnings. 

* `velero`

Tool that provide backup and restore, disaster recover and migration of the kubernetes resources. 
Ensures that you can recover from disaster by deploying a recent backup and persistent volumes. 

Its configured with AWS provider in order to authenticate and use S3 buckets and EBS EC2 storage to store the backups and snapshots. 



