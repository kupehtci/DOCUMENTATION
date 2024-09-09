#TERRAFORM #AWS #EEKS #GKE #AZURE #AKS #KUBERNETES 

For providers that manage resources within the Kubernetes Cluster, the kube config file is needed. 

This `kubeconfig` file contains the necessary credentials and API server address for connecting and manage the Kubernetes cluster. 

In Amazon Web Service EKS (Elastic Kubernetes Service), you can retrieve the kubeconfig file with this command: 
```bash
aws eks --region <region> update-kubeconfig --name <cluster_name>
```

For <span style="color:#ffec8b;">Google GKE (Google Kubernetes Engine)</span>, use the following command: 
```bash
gcloud container clusters get-credentials <cluster_name> --region <region>
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