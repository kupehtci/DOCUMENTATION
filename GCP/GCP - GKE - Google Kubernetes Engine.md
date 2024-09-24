#GKE 

# GKE Google Kubernetes Engine

Google Kubernetes Engine offers a cloud kubernetes managed cluster while providing integration of this service with other Google Cloud services like monitorization, storage, DNS, networking, role access and more. 

It provides the orchestration of a Kubernetes solution to run managed and auto controlled containerized applications. 

It includes the Kubernetes control plane components like `kube-apiserver`, `etcd`, `kube-scheduler`, and `kube-controller-manager`.

### Compute instances

In order to run the workloads of the  kubernetes cluster, it uses Node Pools composed of virtual machines where the Kubernetes control plane will  schedule the work and Container computation needs to it. 

The main virtual services where the Nodes resides are <span style="color:DodgerBlue;">Compute Engine Virtual Machines</span>[^1]

This nodes have some specific features: 

* Auto-repair: monitorize health checks of the nodes and change them if needed. 
* Auto-update: keep the nodes updates with the newer version of Kubernetes and GKE
* Auto-scaling: re dimension the cluster if the compute needs are needed. 
* Auto-provision: create Node Groups that automatically adjusts to the workloads
### Create a GKE using gcloud cli

You can create a GKE using gcloud CLI command line tool. To do so, use this command: 

```bash
gcloud container clusters create my-cluster --zone us-central1-a --num-nodes 3
```

You need to define at least the <span style="color:orange;">zone</span> where the cluster is going to be deployed and the <span style="color:MediumSlateBlue;">number of nodes</span> where the workload can be executed. 


[^1]: Compute Engine Virtual Machine [[./GCP - CEVM Computer Engine Virtual Machine]]

