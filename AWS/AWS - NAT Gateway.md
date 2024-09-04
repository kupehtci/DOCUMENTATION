#AWS 

# AWS NAT Gateway



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

  # Other parameters like tags Name
}

resource "aws_route_table_association" "eks_subnet_nat_gw_route_table" {
  gateway_id = aws_nat_gateway.eks_subnet_nat_gw.id
  route_table_id = aws_route_table.eks_subnet_route_table.id
	# Other parameters like tags sName
}
```

