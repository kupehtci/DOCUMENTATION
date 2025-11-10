#NETWORKING 

# AnyCast IP

AnyCast IP is a single IP Address that is geographically distributed from multiple endpoints so packets from a client are routed to the nearest available endpoint according to path length and latency. 

It offers a single, stable and static IP address that routes users to the closest healthy endpoint. (One IP and Many locations).

Its used for global entry points for services like CDNs [[CDN - Content Delivery Network]], DNS Resolvers [[DNS - Domain Name System]] or AWS Global Accelerator for example in the cloud [[AWS - Global Accelerator]].

### Comparison with Unicast

Unicast maps one single IP to a single location and doesn't route to different locations. 