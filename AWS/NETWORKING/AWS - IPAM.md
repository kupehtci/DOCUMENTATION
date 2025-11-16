#AWS 

# AWS IPAM 

AWS IPAM or IP Address Manager is a VPC[^1] feature that helps to plan, track, manage and provision IP addresses for the AWS workloads. 

It simplifies the IP address management in complex setups that imply cross-regions and cross-accounts setups. 

* Avoid IP conflicts by defining CIDR block to specific regions derived from a parent CIDR block. 
* Centralized IP address management reduces the risk of conflicts

### Terraform 

To deploy a ipam and its adjacent IP address pool, follow this basic structure

```hcl
resource "aws_vpc_ipam" "vpc_ipam" {
  description = "IPAM of the main VPC"
  operating_regions {
    region_name = var.aws_region
  }

  tier = var.vpc_ipam_tier
  tags = {
    Name = "${var.environment}-vpc-ipam"
  }
}

resource "aws_vpc_ipam_pool" "vpc_ipam_pool" {
  address_family = "ipv4"
  ipam_scope_id  = aws_vpc_ipam.vpc_ipam.private_default_scope_id
  locale         = var.aws_region

  tags = {
    Name = "${var.environment}-vpc-ipam-pool"
  }
}

resource "aws_vpc_ipam_pool_cidr" "vpc_ipam_pool_cidr" {
  ipam_pool_id = aws_vpc_ipam_pool.vpc_ipam_pool.id
  cidr         = var.vpc_cidr
}
```


[^1]: VPC or Virtual Private Cloud is a resource group for deploying resources within it in AWS [[AWS - VPC Virtual Private Cloud]]