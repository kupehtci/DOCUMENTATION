#AWS 

# AWS NAT Gateway

A <span style="color:MediumSlateBlue;">NAT gateway</span> is a Network Address Translation (NAT) service. This can be used to let instances in a private subnet to connect to services outside the VPC[^1]. 

You can create a NAT gateway with two different connectivity types: 

* **public** by default, instances in private subnets can connect to internet through this public NAT gateway but cannot receive unsolicited connections from the internet. 
* **private** the private subnets instances will be able to connect to other VPCs through a transit gateway or a virtual private gateway. In this case you cannot create an EIP[^2] associated with the NAT gateway or route the traffic from the NAT gateway to the Internet gateway. 

If you select a **public** one, you must configure the `elastic IP allocation ID` or `allocation_id` in terraform and optionally the Private IP address associated to the NAT gateway. If no IPv4 address is associated for private usage, AWS will automatically associated one.

With this NAT gateway you avoid to assign a public IP to each one of the instances/resources within a private VPC.

### Considerations

You can use either a public or private NAT gateway to route traffic to transit gateways and virtual private gateways.

If you use a private NAT gateway to connect to a transit gateway or virtual private gateway, traffic to the destination will come from the private IP address of the private NAT gateway.

If you use a public NAT gateway to connect to a transit gateway or virtual private gateway, traffic to the destination will come from the private IP address of the public NAT gateway. The public NAT gateway will only use its EIP as the source IP address when used in conjunction with an internet gateway in the same VPC.

### Terraform

NAT Gateway can have a public EIP (Elastic IP) assigned if its intended to act as public. For that, `allocation_id`must settled to the allocation ID of the Elastic IP address for the NAT Gateway. And`connectivity_type` to `public`.

```hcl
resource "aws_nat_gateway" "example" {
  allocation_id = aws_eip.example.id
  subnet_id     = aws_subnet.example.id
  
  depends_on = [aws_internet_gateway.example]
}
```

For a <span style="color:DodgerBlue;">Private NAT</span>, set the `connectivity_type` to `private` and set the `subnet_id` to the current private subnet id. 

```hcl
resource "aws_nat_gateway" "example" {
  connectivity_type = "private"
  subnet_id         = aws_subnet.example.id
}
```

A NAT gateway requires a <span style="color:DodgerBlue;">route table</span> resource, that can be defined in terraform and associated to the NAT gateway using an `aws_route_table_association` resource that associates the route table with the gateway or the subnet.

```hcl
resource "aws_route_table" "eks_subnet_route_table" {
  vpc_id = aws_vpc.main
  
  # For routing private subnet traffic to NAT gateway
  route {
    cidr_block     = "0.0.0.0/0"
    nat_gateway_id = aws_nat_gateway.example.id
  }

  # Other parameters like tags Name
}

resource "aws_route_table_association" "eks_subnet_nat_gw_route_table" {
  gateway_id = aws_nat_gateway.eks_subnet_nat_gw.id
  route_table_id = aws_route_table.eks_subnet_route_table.id
	# Other parameters like tags sName
}
```

[^1]: VPC or Virtual Private Cloud [[AWS - VPC Virtual Private Cloud]]