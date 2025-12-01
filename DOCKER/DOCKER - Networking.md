#DOCKER 

# DOCKER - Networking

Docker container's have different networking modes: 

* **Bridge**: creates a private internal network that isolates the containers in a single docker's host. 
	* Default networking mode for a container. 
* **Hosts**: uses the host's networking stack directly. 
	* It removes the network isolation, using directly the Host's IP address and network interface. 
	* The container loses the possibility of communicating with other containers using docker's internal DNS resolution. 
		* They need to communicate using host's IPs and Ports. 
* **None**: this mode disables networking entirely. 
* **Overlay**: mode for multi-host networking used normally in Docker Swarm[^1]. 
	* this mode allows communication between containers running in different docker daemon hosts, making it suitable for swarm or Kubernetes clusters.


## Docker internal DNS

Docker provides an embedded DNS server capability for bridge network, that allows containers to resolve names for other containers automatically.




[^1]: Docker Swarm [[Docker Swarm]]