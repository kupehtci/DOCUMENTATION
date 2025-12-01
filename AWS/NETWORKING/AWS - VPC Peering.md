#AWS 

# AWS - VPC Peering

**VPC Peering** its a networking connection between two VPCs that enables the traffic to be routed between them using IPv4 or IPv6 addresses. 
The resources in both VPCs can communicate as if they were in the same VPC. 

# How it works? 

VPC Peering creates a one-to-one connection between the VPCs without virtual / logical resources. 
It ensures that the traffic between both VPCs doesn't go through the public internet

VPC Peering is **not transitive**, so the communication can go between resources going through only a single Peering: 

> Example: If VPC A is peered with VPC B and VPC B with VPC C, resources cannot communicate between VPC A and VPC C without an explicit VPC Peering between A and C. 

VPC Peering do not use Gateways or single point of failure elements, it routes traffic directly between VPC without single resources. 


## Costs

The VPC Peering costs depends on the AWS Region and AZ of both VPCs:

| Traffic                    | Cost               | Notes                                                           |     |
| :------------------------- | ------------------ | --------------------------------------------------------------- | --- |
| Between same AZ            | Free               | In the same AZ or datacenter the peering has no associated cost |     |
| Same region, different AZs | 0.01$ / GB         | The traffic between two different data centers (AZs)            |     |
| Different AWS Regions      | 0.02$ - 0.17$ / GB | Depending the source and destination AWS Region                 |     |
AWS Cost Explorer has a dedicated billing, known as `{REGION-NAME}-VpcPeering-In/Out-Bytes` for searching this usage type. 