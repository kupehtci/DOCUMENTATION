#AWS 

# Security Groups

A **Security Group** is a virtual firewall that controls inbound and outbound traffic to an ENI or Elastic Network Interface of a resource. 

It allows the traffic based on IP, protocol, port or IP address and is **stateful**. 
For all request or response that goes through the Network interface, the rules defined in the security group are evaluated.  

## Security group vs Network Access Control List (NACLs)

NACLs or Network Access Control Lists [^1] are also an AWS resource that can be used to control the traffic in the cloud. 

The main differences between this two "virtual firewall" are: 

| Network Access Control List (NACLs)                              | Security Group                               |
| ---------------------------------------------------------------- | -------------------------------------------- |
| Associated to a Subnet                                           | Associated with an Elastic Network Interface |
| Allow rules and deny rules                                       | Allow rules only (Other traffic is denied)   |
| All rules are processes in order                                 | Rules are evaluated before applying          |
| Stateless firewall                                               | Stateful firewall                            |
| Applied to an instance if its within the subnet that has the ACL | Applied to instance if associated with it    |

[^1]: Network Access Control Lists or NACLs [[AWS - Network ACL]]