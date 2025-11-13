#AWS

# AWS - Gateway Load Balancer

**Gateway Load Balancer** or **GLB** is a Layer 3 (OSI Model [[OSI Layers]]) that lets you to insert network virtual appliances (Third party integrations) such as firewalls, packet inspection. 
Instead of inserting the resource between the traffic and a NLB, placing this resource makes it transparent. 

Preserves **flow stickiness** so statefull appliances see the both directions of a communication. 

It has the following characteristics: 
* health checks: remove unhealthy nodes or appliances.
* Geneve encapsulation (port 6081) [^1] to pass the traffic to the applicances while preserving the original packet. 
* Autoscaling


You can insert with this type of LB a third-party security appliance like Palo Alto, Fortinet for inspection across VPCs. 


[^1]: Geneve Encapsulation [[Geneve Encapsulation]]

