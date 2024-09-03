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

