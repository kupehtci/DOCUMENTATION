
You can create a Zabbix server capable of handling multiple hosts simultaneously with a high demand distributed environment but needs some robust or high scalable architecture. 

In terms of managing this high demand, Zabbix offers two different solutions: 

* An scalable Kubernetes cluster running in the cloud or on-premise. 
* A central robust Zabbix core server with a centralized Database with some servers acting as proxies. 

### Zabbix in a Kubernetes Cluster

Handling the main server workloads using a Kubernetes cluster within the cloud is a powerful solution for making a high distributed, scalable and resilient architecture.

It offers us: 

* **High scalability**: by setting up automatic scaling of the cluster, it can use as much services as needed when the requests and alerts increments and scale down when the demand goes down.
* **Fault tolerance**: Multiple replicas of the proxy servers can be deployed within the same cluster and Kubernetes will handle and keep a correct available status of all of them. 
* **Distributed**: the architecture can be then distributed within multiple regions that handle the data income to the cluster. 
* **Automated deploy**: deployments can be automated through the use of CD/CI pipelines to the main cluster using ArgoCD and other tools. If this deployments of new features or versions fails, kubernetes can *rollback* to the previous stable state. 
* **Multi-cloud**: Kubernetes clusters can be deployed in different cloud providers or on-premise data centers using a single Kubernetes control plane. 
* **Disaster recovery**: some kubernetes disaster recovery tools can be used to maintain an automated backup that can be used to recover the working state in case of failure. 
* **Hybrid** although you have the server centralized in a single kubernetes cluster you still be able to distribute the architecture by deploying external proxies in other VMs. 

And some cons: 

* **Specialized knowledge** the management of a kubernetes cluster require more trained staff than a traditional VM. 
* **Troubleshooting**: detection of errors and debugging can be a little more complex than in a traditional VM. 
* **Not suitable for small environments**: kubernetes is designed to handle high demands with auto scaling environments so it may not be suitable for small demand Zabbix usage. 
* **Extra cost** the cost of managing a kubernetes cluster is a little bit higher than the use of tradicional VMs because the need of running the control plane processes but can be less than the machines if we take into account the huge number of VMs that need to be provided to handle the Zabbix's services. 
* **Networking** the handle of networking surrounding resources to a centralized kubernetes cluster need to be fine tuned to avoid bottlenecks. 

### Zabbix in VMs

On the other hand, deploying the VM in a centralized Virtual machine can be a powerful solution if the incoming traffic is previously handled by other machines that run Zabbix proxy to handle the workloads and only use the server to store data. 

If offers some pros: 

* **Geolocations**: while main server remains in a centralized location, proxies can be geographically distributed to handle traffic from other zones and report it to the main server. 
* **Backups**: tasks for making custom backups of the database can be scheduled to recover from a failure of it but in case of the disaster, the machine should need to be redeployed with the previous snapshots and also deal with the huge size of this snapshots. 
* **More customization**: because you have access to the underlying host OS, you can handle configurations like the volumes in a more customized manner. 
* **Simplicity** Configuration of the VMs can be easier than in kubernetes cluster without the need of knowledge about containerization and kubernetes. 
* **Flexibility using proxies** because zabbix proxies can de distributed between multiple VMs geographically distributed, a good handle of the incoming data can be managed. 
* **Failure resilient**: Security or service failures can only impact a single resource, reducing the risk of cross-services failure if the failure only affects a single Proxy instead of the Main server or the Database. 

And some cons: 

* **Splited deployment**: while in kubernetes, the database backend, web server, processing server and main agent can be deployed through a single kubernetes deployment, in VMs all of this component need to be installed independently and configured to work together. 
* **Not easy autoscaling**: In case of an increasing demand of the centralized server, it can be a mess and need to manually provision new VMs for the server with the need to migrate all the server to the new one more capable of handling the demand. 
* **More resources handled**: Each VM have higher resource demand because each VM needs to handle a whole OS including its kernel, take more memory, CPU and storage resources. x
* **Less flexible while maintenance**: interventions to the VMs need to be made manually and the resource allocation in response to demand will need to be made manually by shutting down the machine, leading to downtime.  
* **Lack of automation**: the use of tools like Ansible or terraform can be used to provide the VMs but not to deploy the Zabbix server inside them.  
* **Isolation and security** because the proxies, main server and database need to be mounted in different isolated machines, the communication and data transfer between all of them need to be secured. 