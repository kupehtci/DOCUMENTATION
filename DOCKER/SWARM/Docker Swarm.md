#DOCKER 

# Docker Swarm

Docker Swarm is a clustering and orchestration tool made by Docker to manage a group of Docker nodes that act as a unified cluster for running the containers workload. 

It provides a unified way to deploy, scale and manage containerized applications between multiple hosts with native high availability and load balancing. 

It also offers service discovery using the built-in DNS with the overlay networking mode[^1]. 


# Nodes

In a Docker Swarm cluster, there are different types of nodes in charge of different tasks: 

* **Manager Nodes**: maintain the state and handle the orchestration. 
* **Worker Nodes**: execute the tasks received from the manager and ensure the containers are running correctly. 

## Manager Nodes

Manager Nodes in order to have high availability must maintain a **quorum**, so the minimal number of healthy manager nodes that need to remain met $3(N/2+1)$ nodes

 For an example in a N=5 cluster, the majority is 3. Losing the 3rd node means the remaining 2 cannot form a majority, and the cluster enters read-only mode, blocking all configuration changes.


[^1]: Docker overlay network mode [[DOCKER - Networking]]