#GKE #GCP 

# GCP GKE Networking

This is a summary and explanation of the best networking configurations for a GKE deployment and some requirements that GKE needs to be provided in the network in order to have a correct behavior. 


Take into account that some network options cannot be changed once it has been deployed without recreating the cluster. 


When creating a new Project, the `default` network has auto mode VPC network that creates subnets and corresponding subnet routes with CIDR blocks `/20`. 

In a GKE cluster, each pod requires an unique IP address for every pod.  