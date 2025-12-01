#AWS 

# AWS - VPN

You can establish a **VPN** or **Virtual Private Network**[^1] in AWS to create a secure and encrypted connection between the on-premise infrastructure and the AWS Cloud environment. 

AWS provides two ways of configuring an VPN connection: 

* AWS Site-to-Site VPN
* AWS Client VPN 

## AWS Site-to-Site VPN

Site-to-Site VPN is a fully managed service that establish a secure connection between the on-premise party to the AWS environment using IPSec[^2]. 

It connects a tunnel between the on-premise and VPCs or AWS Transit Gateway[^3]. 
Each Site-to-Site VPN connects two tunnels for resilience. 

This service can be integrated with **CloudWatch** for monitoring. 

## AWS Client VPN

**AWS Client VPN** is a fully managed elastic remote access VPN solution for individual users to connect its devices to AWS resources and on-premises networks. 

This solution uses OpenVPN protocol to establish a secure connection through a VPN endpoint. 

As a managed resource, it scales up and down based on user demand with pay-as-you-go pricing. 

Users can be *authenticated* using:
* Active Directory
* SAML-based federated authentication (Through IDP)
* MFA or Multi-Factor Authentication

---

# AWS CloudHub

**AWS CloudHub** offers a centralized secure communication hub-and-spoke model to organize and communicate multiple Site-to-Site VPN connections. 

As a hub-and-spoke model, it enables the communication between each remote site and VPCs within AWS without a direct connection between each one of them. 


[^1]: VPN or Virtual Private Network [[VPN]]
[^2]: IPSec [[IPSec]]
[^3]: AWS Transit Gateway is a central hub that connects multiple VPCs, VPNs and Direct Connection together [[AWS - Transit Gateway]]
