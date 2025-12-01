#AWS 

The Amazon EKS node `kubelet` daemon makes calls to AWS APIs on your behalf. Nodes receive permissions for these API calls through an IAM instance profile and associated policies. Before you can launch nodes and register them into a cluster, you must create an IAM role for those nodes to use when they are launched. This requirement applies to nodes launched with the Amazon EKS optimized AMI provided by Amazon, or with any other node AMIs that you intend to use. Additionally, this requirement applies to both managed node groups and self-managed nodes.

Before you create nodes, you must create an IAM role with the following permissions:

- Permissions for the `kubelet` to describe Amazon EC2 resources in the VPC, such as provided by the `[AmazonEKSWorkerNodePolicy](https://docs.aws.amazon.com/aws-managed-policy/latest/reference/AmazonEKSWorkerNodePolicy.html)` policy. This policy also provides the permissions for the Amazon EKS Pod Identity Agent.
    
- Permissions for the `kubelet` to use container images from Amazon Elastic Container Registry (Amazon ECR), such as provided by the `[AmazonEC2ContainerRegistryReadOnly](https://docs.aws.amazon.com/aws-managed-policy/latest/reference/AmazonEC2ContainerRegistryReadOnly.html)` policy. The permissions to use container images from Amazon Elastic Container Registry (Amazon ECR) are required because the built-in add-ons for networking run pods that use container images from Amazon ECR.
    
- (Optional) Permissions for the Amazon EKS Pod Identity Agent to use the `eks-auth:AssumeRoleForPodIdentity` action to retrieve credentials for pods. If you don't use the `AmazonEKSWorkerNodePolicy`, then you must provide this permission in addition to the EC2 permissions to use EKS Pod Identity.
    
- (Optional) If you don't use IRSA or EKS Pod Identity to give permissions to the VPC CNI pods, then you must provide permissions for the VPC CNI on the instance role. You can use either the `AmazonEKS_CNI_Policy` managed policy (if you created your cluster with the `IPv4` family).  Rather than attaching the policy to this role however, we recommend that you attach the policy to a separate role used specifically for the Amazon VPC CNI add-on.

In case of needing a more restrictive IAM role for Pod identity, you must need to define a custom IAM policy and attach to an IAM role. For doing the following chapter. 
### IAM Policy

In order to add IAM policies to ServiceAccounts[^sa], you need to attach `AmazonEKSWorkerNodePolicy` to the node IAM role of the EC2 nodes of the EKS or the node group. 

This grants permissions to Amazon EC2[^ec2] nodes to connect to Amazon EKS clusters. 
It grants the following permissions: 

* `ec2` Read instance volume and network information. 
* `eks` allows to describe the cluster
* `eks-auth:AssumeRoleForPodIdentity` allow retrieving credentials for EKS workload on the node. 

In order to grant Pod identity, we need to define an Assume policy in an IAM role for the Pods to assume. 
This policy must have this format: 

```json
{
    "Version": "2012-10-17",
    "Statement": [
        {
            "Effect": "Allow",
            "Action": [
                "eks-auth:AssumeRoleForPodIdentity"
            ],
            "Resource": "*"
        }
    ]
}
```

In terraform will look like: 

```hcl
resource "aws_iam_role" "iam_role_pods_identity" {
  name = "iam_role_${var.project}_${var.environment}_pods_identity"

  assume_role_policy = <<POLICY
  {
    "Version": "2012-10-17",
    "Statement": [
        {
            "Effect": "Allow",
            "Action": [
                "eks-auth:AssumeRoleForPodIdentity"
            ],
            "Resource": "*"
        }
    ]
}
  POLICY

  description = "IAM Role for the Pods ID Agent. THis allows PODS to assume roles identities to interact with the AWS resources"
}
```

[^sa]: Service Accounts kubernetes resource [[KUBERNETES - Service Accounts]]