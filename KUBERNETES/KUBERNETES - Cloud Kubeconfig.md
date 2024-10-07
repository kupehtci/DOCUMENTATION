#TERRAFORM #AWS #EKS #GKE #AZURE #AKS #KUBERNETES 

For providers that manage resources within the Kubernetes Cluster, the kube config file is needed. 

This `kubeconfig` file contains the necessary credentials and API server address for connecting and manage the Kubernetes cluster. 

In <span style="color:MediumSlateBlue;">Amazon Web Service EKS (Elastic Kubernetes Service)</span>, you can retrieve the kubeconfig file with this command: 
```bash
aws eks --region <region> update-kubeconfig --name <cluster_name>
```

For <span style="color:#ffec8b;">Google GKE (Google Kubernetes Engine)</span>, use the following command: 
```bash
gcloud container clusters get-credentials <cluster_name> --region <region>
```

In order to authenticate over GCloud you will need `gke-gcloud-auth-plugin` to be able to use as client.go. For installing it you can do one of the following commands: 

```bash
#Using apt
sudo apt-get install google-cloud-cli-gke-gcloud-auth-plugin

#Or using GCloud CLI 
gcloud components install gke-gcloud-auth-plugin
```
  
For <span style="color:DodgerBlue;">Azure AKS (Azure Kubernetes Service)</span>, use the following command: 
```bash
az aks get-credentials --resource-group <resource_group> --name <cluster_name>
```

In the case that you are using `minikube` or `kind`: 
```bash
minikube kubeconfig
# or 
king get kubeconfig
```

To set the kube config for the provider, you need to specify the path of the file: 

```hcl
provider "kubernetes"{
	config_path = "~/.kube/config"
}
```