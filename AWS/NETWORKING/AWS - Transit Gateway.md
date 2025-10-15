#AWS 

# AWS - Transit Gateway

**AWS Transit Gateway** is a central hub that connects multiple VPCs, VPNs and Direct Connection together. 

Its like a **big router** that all the networks can plug into instead of creating complex mesh peering between resources. 

The key benefits of this resource are: 
* **Number of connections**: scales up to thousands of VPCs. 
* **Simplifies management**: as no VPC mesh peering is needed between each VPC. 
* **Cross-account**: supports cross-account and cross-region networking with DX gateways. 