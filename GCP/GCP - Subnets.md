#GCP 

# GCP Subnets

Subnets are a networking resource within GCP to distribute the virtual network. 


##### IPv4 subnet ranges

The IPv4 ranges that can be assigned to the subnets and its secondary IP ranges have some limitations: 

* Each primary or secondary IPv4[^1] ranges for a subnet must be unique CIDR blocks within the VPC. 
* The number of secondary IP addresses that can be defined are limited and can be seen in **Quotas and Limits** section within the project.
* When a subnet is created, the IPv4 range can be expanded **but no replaced with a new range or shrunk**. 
* The secondary IP ranges can only be replaced if no instances are using the range. 
* Longest subnet mask is `/29` allowing **at least IPv8 addresses**
* Shorter subnet mask is `/4` but its recommended at least ' /8' to avoid subnet overlapping. 
* Google Cloud creates corresponding [^2] subnet routes for the primary and secondary IP ranges. 

You can create **secondary IP Ranges** within the Subnets that can be assigned to other resources as **alias IP ranges** to create all the elements within that CIDR blocks. 

Take into account that, the secondary IP range must not overlap with the primary IP range or with other secondary IP ranges. 
However, the secondary IP range does not need to be within the primary IP range of the subnet. You can assign a completely different, non-overlapping CIDR block to the secondary IP range as long as it's **within the overall VPC's valid address space** and does not overlap with other IP ranges in the VPC.



[^1]: IPv4 Standard [[IPv4]]
