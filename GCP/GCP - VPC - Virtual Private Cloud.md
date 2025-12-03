#GCP 

# GCP Virtual Private Cloud

Virtual Private Cloud provides a network functionality, similar to a physical network but virtualized in the Google Cloud. 

Provides connectivity and network capabilities for the Compute Engine Virtual Machine instances[^1] (also GKE clusters) and serverless workloads and other services running in VMs


Also this virtualized network, has high availability due to all Edge locations of Google and the internal physical network. 

The VPC provides the following configurations for IP addresses and VMs network interfaces: 

* <span style="color:DodgerBlue;">IP Addresses</span>: each Compute Engine VM instance, forwarding rules, GKE containers and other resources rely on IP addresses[^2] to communicate. 
* <span style="color:DodgerBlue;">Alias IP Ranges</span> When having multiple services running in a VM instance, you can give each service a different internal IP address using Alias IP ranges. The VPC will forward the packets to the correspondent VM. 
* <span style="color:DodgerBlue;">Multiple Network Interfaces</span>: A VM instance can have multiple network interfaces with each interface residing in a VPC network and acting this VM as a gateway that secures the traffic between VPCs. 


* `Firewall`

Each VPC provides a network virtual firewall that can be configured with some rules to control the packages that can travel to which destinations. 

The default VPC has additional firewall rules including a `default-allow-internal` rule that allow all communication between instances in the same network. 


* `Routes`

Routes[^3] tell VM instances and the VPC network how to send traffic from an instance to a destination, routing certain IP or CIDR blocks to a certain resource.

* `Forwarding rules`

Forwarding rules direct traffic to a google cloud resource inside an VPC based on the IP address, protocol or port. 
Some of this rules forwatd traffic from outside the GCloud and others direct traffic from inside the network. 

* `subnets`

While VPC resource is global, we can set regional subnets in order to deploy resources within it. This subnets hold different resources with predefined routes, internal communication and external communication using router services. 
### Terraform

This resource can be created and managed using terraform GCP provider resource: 

```hcl
resource "google_compute_network" "vpc_network" {
  name = "vpc-network"
  auto_create_subnetworks                   = false
  network_firewall_policy_enforcement_order = "BEFORE_CLASSIC_FIREWALL"
}
```

* `name` is required for the VPC and must meet this regex: `[a-z]([-a-z0-9]*[a-z0-9])?` with first character a lowercase and the following characters a dash, lowercase or digit except last character that cannot be a dash. 
* `description` is a description of the resource. Only allow to create this parameter the first time where is created. 

---
## CIDR

When an VPC is created you need to define a CIDR block for the resources deployed within it. 

Take into account the CIDR block assigned when stablishing an VPC peering, as IPs must not overlap between them. 

The maximum allowed CIDR block is /28, so /32 common ones are not allowed, so use normally /24. 



[^1]: Compute Engine Virtual Machines are VMs within the Google Cloud [[GCP - CEVM Computer Engine Virtual Machine]]
[^2]: IP addresses [[IPv4]]
[^3]: Routes within GCP [[GCP - Routes]]
