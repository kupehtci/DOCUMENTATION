#GCP

# GCP Routes

Google Cloud Routes define the paths that networking traffic must take from a Virtual Machine (VM) to other destinations. 

In a VPC network, this route consist in a <span style="color:DodgerBlue;">single destination prefix</span> in CIDR format and a single <span style="color:MediumSlateBlue;">next hop</span>. 

When a VPC network send a packet, Google Cloud delivers the package to the next hop if the destination address is within the route's destination address. 

By default there two default routes: 

* `0.0.0.0/0` to `default_internet_gateway`: routes all traffic taht don't match other route to the default internet gateway. 
* for each `subnet` to `vpc_network`: Forward the packages from the VMs and internal load balancers to the VPC they belong to. 