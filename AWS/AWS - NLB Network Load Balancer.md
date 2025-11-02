#AWS

# AWS - Network Load Balancer

**AWS Network Load Balancer** or **NLB** is an Elastic Load Balancer [^1] designed to offer high-performance and low-latency traffic at the transport layer (Layer 4 OSI Model)(TLS, TCP and UDP).

As an Layer 4 Load Balancer it can route raw TCP connections to targets depending on IP without inspecting the application data. 

A NLB can route traffic to: 
* EC2 instances
* IP Addresses
* Lambda functions using TCP-Lambda integration (This integration is limited)
And depending on TCP/UDP layer information: 
* Source IP, source Port
* Destination IP, destination port

It can perform **health checks** over resources so only healthy instances receive traffic. 

A Network Load Balancer cannot be integrated with a WAF (Web Application Firewall) or associated with security groups. 

### TLS Termination

Supports TLS Listeners but can offload TLS certificates if needed. 

### AWS Shield Advanced

NLB can be attached with AWS Shield Advanced to provide DDoS protection and prevent unauthorized access attempts. 


[^1]: Elastic Load Balancer or ELB [[AWS - ELB Elastic Load Balancing]]