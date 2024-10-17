
The kubernetes cluster consist of a set of worker machines, nodes that run containerized applications.

Each cluster has at least one working node, a set of working machines where the control plane schedules its workload. 


#### Control panel components 

The control panel components make global decisions about the cluster. 
Detect and response to cluster events. 

Control plane components can run in the same machine as other one in the cluster but for simplicity, all components are on the same machine and don't run other containers in the same machine. 

Some important control panel components are: 

* kube-apiserver
Component that exposes the Kubernetes api. Listens to API queries from kubectl [^1] and acts as a gatekeeper to redirect incoming requests to certain components. All traffic passed through it. 

* etcd
Consistent and highly-available key value store used for Kubernetes backing store for all the cluster data. 

* kube-scheduler
Component that watches newly created Pods (Containers) with no running node assigned and selects a node for them. 

* kube-controller-manager
Runs controller processes. Each controller is a separate process but for simplicity, they are all compiled into a single binary and run in a single process. 

* cloud-controller-manager
Embeds cloud-specific control logic. Separates the component that interact with the cloud provider API from the ones that interact with your cluster. 


#### Node components

This components runs on every node, maintain the running pods and provide kubernetes runtime environment. 

* kubelet
Runs on each node and makes sure that containers are running in a pod. 

* kube-proxy
network proxy that runs on each node in the cluster. It forwards and redirects traffic from the services[^2] to the pods[^3]. 

* container-runtime
Manages the execution of containers and lifecycle within the environment. 


### Addons

Addons are components that uses Kubernetes resources to implement cluster features. 

* DNS 
Only addon that is strictly required. 
Is a DNS server that serves DNS records for Kubernetes services. 

* WEB UI (Dashboard)
Is a general purpose, web-based UI for kubernetes clusters. 

* Container resource monitoring
* Cluster-level logging
* Network plugins


[^1]: Kubectl is the command line tool designed to interact with Kubernetes API. [[KUBECTL]]
[^2]: Services are a Kubernetes component in charge of managing incoming traffic. [[KUBERNETES - Services]]
[^3]: Pods are the most basic unit of Kubernetes and its in charge of running a Docker Container/s and maintain it. [[KUBERNETES - Pods]]
