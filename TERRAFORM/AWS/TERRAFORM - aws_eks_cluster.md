
# TERRAFORM `aws_eks_cluster`

The `aws_eks_cluster` resource manages an AWS Elastic Kubernetes Service[^1] cluster for Kubernetes. 

It has to follow this basic structure:

```hcl
resource "aws_eks_cluster" "example" {
  name     = "example"
  role_arn = aws_iam_role.example.arn

  vpc_config {
    subnet_ids = [aws_subnet.example1.id, aws_subnet.example2.id]
  }

  # Ensure that IAM Role permissions are created before and deleted after EKS Cluster handling.
  # Otherwise, EKS will not be able to properly delete EKS managed EC2 infrastructure such as Security Groups.
  depends_on = [
    aws_iam_role_policy_attachment.example-AmazonEKSClusterPolicy,
    aws_iam_role_policy_attachment.example-AmazonEKSVPCResourceController,
  ]
}

output "endpoint" {
  value = aws_eks_cluster.example.endpoint
}

output "kubeconfig-certificate-authority-data" {
  value = aws_eks_cluster.example.certificate_authority[0].data
}
```


`aws_eks_cluster` requires at least this attributes: 

* `name` name for the cluster that need to meet the following regex `^[0-9A-Za-z][A-Za-z0-9\-_]*$`
* `role_arn` is the ARN of the IAM role that provides permissions to the Kubernetes control plane to make AWS operations through AWS API. 
* `vpc_config` configuration block for the VPC associated with the cluster: 



[^1]: Elastic Kubernetes Service or EKS from AWS [[AWS - EKS Elastic Kubernetes Service]]