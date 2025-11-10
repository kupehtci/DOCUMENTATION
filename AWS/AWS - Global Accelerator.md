#AWS 

# AWS - Global Accelerator

**AWS Global Accelerator** is a networking service that improves the performance and high availability of a global application by using the AWS Global Network infrastructure to route traffic optimally to each application endpoint. 

Instead of sending user traffic over random and unpredictable public internet to the finally endpoint, it uses AWS private backbone network to the nearest healthy endpoint. 

## Anycast IP Addresses

Global Accelerator provides 2 status AnyCast IPs [^1] and users are automatically routed to the nearest AWS edge location. 

Can route to endpoints in multiple regions depending on location and has automatic failover between regions. 

[^1]: AnyCast IP Address [[AnyCast IP]]