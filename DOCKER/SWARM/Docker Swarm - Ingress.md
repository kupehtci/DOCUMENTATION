#DOCKER 

# Docker Swarm - Ingress

Docker Swarm Ingress is an overlay network that enbles the external traffic to reach services that are running inside a Docker Swarm Cluster, regardless of which node the service is actually running on. 

To redirect to a healthy replica of the swarm service even if its in another working node, uses IPVS (IP Virtual Server) or on every node so it handles the load balancing and uses the **overlay network**[^1] to tunnel the traffic from the ingress node to the actual service. 



[^1]: Docker networking models [[DOCKER - Networking]]