#AWS 

# AWS - Network ACL

**AWS Network ACL** or **NACL** its a network security statement associated with subnets that define the inbound and outbound traffic allowed in the subnet. 

NACLs by default deny all rules until they are enabled. 

In comparison with Security Groups that can be assigned to an ENI, NACL are attached to subnets and are **stateless**: 
* **Statefull**: In security Groups under a certain inbound is allowed, the outbound rule doesn't need to be allowed, as its open for the return of the request.
* **Stateless**: in NACLs, they don't store the inbound traffic for opening the returning port, do you need to explicitly allow the outbound port. 

