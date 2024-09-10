#AWS 

# AWS Basic EKS deployment

To make a basic deploy of an Elastic Kubernetes Service in AWS, you need to take firstly into consideration the basic networking requirements for the EKS to work. 

The EKS require at least two subnets and will place two Elastic Network Interfaces[^eni] within it. 

Also, EKS requires some compute resources[^cr] in order to run the Pod's containers of the kubernetes[^ku]: 

Once the provider has been set, you should start by creating the VPC[^vpc] for registering the resources within it. It act as a resource group and as a virtual network: 

```hcl
resource "aws_vpc" "main" {
  cidr_block = "10.0.0.0/16"

  tags = {
    Name = "vpc-main"
  }
}
```

Next, declare the 4 required subnets, two public and two private: 

```hcl
resource "aws_subnet" "private-us-east-1a" {
  vpc_id            = aws_vpc.main.id
  cidr_block        = "10.0.0.0/19"
  availability_zone = "us-east-1a"

  tags = {
    "Name"                                      = "private-us-east-1a"
    "kubernetes.io/role/internal-elb"           = "1"
    "kubernetes.io/cluster/${var.cluster_name}" = "owned"
  }
}

resource "aws_subnet" "private-us-east-1b" {
  vpc_id            = aws_vpc.main.id
  cidr_block        = "10.0.32.0/19"
  availability_zone = "us-east-1b"

  tags = {
    "Name"                                      = "private-us-east-1b"
    "kubernetes.io/role/internal-elb"           = "1"
    "kubernetes.io/cluster/${var.cluster_name}" = "owned"
  }
}

resource "aws_subnet" "public-us-east-1a" {
  vpc_id                  = aws_vpc.main.id
  cidr_block              = "10.0.64.0/19"
  availability_zone       = "us-east-1a"
  map_public_ip_on_launch = true

  tags = {
    "Name"                                      = "public-us-east-1a"
    "kubernetes.io/role/elb"                    = "1"
    "kubernetes.io/cluster/${var.cluster_name}" = "owned"
  }
}

resource "aws_subnet" "public-us-east-1b" {
  vpc_id                  = aws_vpc.main.id
  cidr_block              = "10.0.96.0/19"
  availability_zone       = "us-east-1b"
  map_public_ip_on_launch = true

  tags = {
    "Name"                                      = "public-us-east-1b"
    "kubernetes.io/role/elb"                    = "1"
    "kubernetes.io/cluster/${var.cluster_name}" = "owned"
  }
}
```

The public and private subnets must be divided between two availability zones[^az], one private and one public per each subnet. 

In order to interconnect and let access to the private subnet's resources to the public subnet resources, we need to implement a NAT gateway: 

```hcl
resource "aws_eip" "eip"{
  cidr_block = 
}
resource "aws_nat_gateway" "nat_gw"{
  allocation_id = aws_eip.eip.id
  domain = "vpc"

  tags = {
    Name = "nat-gw"
  }
  depends_on = [aws_eip.eip]
}
```

And similar, to server as proxy from the public subnet to the public internet, to let resources within the VPC[^vpc] have access to the public internet: 

```hcl
resource "aws_internet_gateway" "igw"{
  vpc_id = aws_vpc.main.id
  tags = {
    Name = "igw"
  }
}
```

Once we have this subnets and they are linked with this subnets, we need to define some a route table per each subnet to define the traffic flow. In this case, all the IPs `0.0.0.0/0`from the private subnets redirect to the NAT gateway and the public IPs from the public subnet to the internet gateway: 

```hcl
resource "aws_route_table" "private" {
  vpc_id = aws_vpc.main.id

  route {
    cidr_block     = "0.0.0.0/0"
    nat_gateway_id = aws_nat_gateway.nat.id
  }

  tags = {
    Name = "private"
  }
}

resource "aws_route_table" "public" {
  vpc_id = aws_vpc.main.id

  route {
    cidr_block = "0.0.0.0/0"
    gateway_id = aws_internet_gateway.igw.id
  }

  tags = {
    Name = "public"
  }
}

resource "aws_route_table_association" "private-us-east-1a" {
  subnet_id      = aws_subnet.private-us-east-1a.id
  route_table_id = aws_route_table.private.id
}

resource "aws_route_table_association" "private-us-east-1b" {
  subnet_id      = aws_subnet.private-us-east-1b.id
  route_table_id = aws_route_table.private.id
}

resource "aws_route_table_association" "public-us-east-1a" {
  subnet_id      = aws_subnet.public-us-east-1a.id
  route_table_id = aws_route_table.public.id
}

resource "aws_route_table_association" "public-us-east-1b" {
  subnet_id      = aws_subnet.public-us-east-1b.id
  route_table_id = aws_route_table.public.id
}
```

Once we have the networking environment prepared for the EKS[^eks] we can declare it. For the EKS we need an IAM role that let the resource to access, modify and create other resources when executing. This is an Assumable rol for the `principal.service` : eks.amazon.com. 

```hcl
resource "aws_iam_role" "eks-cluster" {
  name = "eks-cluster-${var.cluster_name}"

  assume_role_policy = <<POLICY
{
  "Version": "2012-10-17",
  "Statement": [
    {
      "Effect": "Allow",
      "Principal": {
        "Service": "eks.amazonaws.com"
      },
      "Action": "sts:AssumeRole"
    }
  ]
}
POLICY
}

resource "aws_iam_role_policy_attachment" "amazon-eks-cluster-policy" {
  policy_arn = "arn:aws:iam::aws:policy/AmazonEKSClusterPolicy"
  role       = aws_iam_role.eks-cluster.name
}
```

And the EKS itself: 

```hcl

resource "aws_eks_cluster" "cluster" {
  name     = aws_eks_cluster.name
  version  = "1.XX"                          # Kubernetes version
  role_arn = aws_iam_role.eks-cluster.arn    # assign the role

  # Configure the EKS to place within the present subnets
  vpc_config {
    subnet_ids = [
      aws_subnet.private-us-east-1a.id,
      aws_subnet.private-us-east-1b.id,
      aws_subnet.public-us-east-1a.id,
      aws_subnet.public-us-east-1b.id
    ]
  }

  depends_on = [aws_iam_role_policy_attachment.amazon-eks-cluster-policy]
}
```

Once we have the EKS defined, we need the instances[^cr] for running it. In this case, we set a Node group for having EC2 instances with autoscaling: 

```hcl
resource "aws_iam_role" "nodes" {
  name = "eks-node-group-nodes"

  assume_role_policy = jsonencode({
    Statement = [{
      Action = "sts:AssumeRole"
      Effect = "Allow"
      Principal = {
        Service = "ec2.amazonaws.com"
      }
    }]
    Version = "2012-10-17"
  })
}

resource "aws_iam_role_policy_attachment" "amazon-eks-worker-node-policy" {
  policy_arn = "arn:aws:iam::aws:policy/AmazonEKSWorkerNodePolicy"
  role       = aws_iam_role.nodes.name
}

resource "aws_iam_role_policy_attachment" "amazon-eks-cni-policy" {
  policy_arn = "arn:aws:iam::aws:policy/AmazonEKS_CNI_Policy"
  role       = aws_iam_role.nodes.name
}

resource "aws_iam_role_policy_attachment" "amazon-ec2-container-registry-read-only" {
  policy_arn = "arn:aws:iam::aws:policy/AmazonEC2ContainerRegistryReadOnly"
  role       = aws_iam_role.nodes.name
}

resource "aws_eks_node_group" "private-nodes" {
  cluster_name    = aws_eks_cluster.cluster.name
  version         = var.cluster_version # or aws_eks_cluster.example.version
  node_group_name = "private-nodes"
  node_role_arn   = aws_iam_role.nodes.arn

  subnet_ids = [
    aws_subnet.private-us-east-1a.id,
    aws_subnet.private-us-east-1b.id
  ]

  capacity_type  = "ON_DEMAND"
  instance_types = ["t3.small"]

  scaling_config {
    desired_size = 1
    max_size     = 5
    min_size     = 0
  }

  update_config {
    max_unavailable = 1
  }

  labels = {
    role = "general"
  }

  depends_on = [
    aws_iam_role_policy_attachment.amazon-eks-worker-node-policy,
    aws_iam_role_policy_attachment.amazon-eks-cni-policy,
    aws_iam_role_policy_attachment.amazon-ec2-container-registry-read-only,
  ]

  # Allow external changes without Terraform plan difference
  lifecycle {
    ignore_changes = [scaling_config[0].desired_size]
  }
}
```

[^vpc]: Virtual Private Cloud AWS resource [[AWS - VPC Virtual Private Cloud]]
[^eni]: Elastic Network Interface [[AWS - ENI Elastic Network Interfaces]]
[^ku]: Kubernetes [[KUBERNETES - Basics]]
[^eks]: Elastic Kubernetes Service [[AWS - EKS Elastic Kubernetes Service]]
[^cr]: Compute resources for EKS [[AWS - EKS Compute instances]]
[^az]: Availability regions, Regions and Edge locations [[AWS - Regions]] [[AWS - Edge Location]]