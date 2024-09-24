#AWS 

# AWS ECR IAM Policies

In case that an EKS[^1], ECS[^2] or Fargate[^3] requires to access an ECR[^4] in order to pull o even push images to the container registry, we need to grant it with a certain IAM policy to give the correct permissions. 


AWS provide some built-in IAM Policies for managing ECR[^1] access: 

##### AmazonEC2ContainerRegistryReadOnly

This policy provides read only access to an EC2 Container Registry. 

```json
{
  "Version" : "2012-10-17",
  "Statement" : [
    {
      "Effect" : "Allow",
      "Action" : [
        "ecr:GetAuthorizationToken",
        "ecr:BatchCheckLayerAvailability",
        "ecr:GetDownloadUrlForLayer",
        "ecr:GetRepositoryPolicy",
        "ecr:DescribeRepositories",
        "ecr:ListImages",
        "ecr:DescribeImages",
        "ecr:BatchGetImage",
        "ecr:GetLifecyclePolicy",
        "ecr:GetLifecyclePolicyPreview",
        "ecr:ListTagsForResource",
        "ecr:DescribeImageScanFindings"
      ],
      "Resource" : "*"
    }
  ]
}
```

* arn: `arn:aws:iam::aws:policy/AmazonEC2ContainerRegistryReadOnly`


[^1]: Elastic Kubernetes Service [[AWS - EKS Elastic Kubernetes Service]]
[^2]: Elastic Container Service [[AWS - ECS Elastic Container Service]]
[^3]: AWS Fargate [[AWS - Fargate]]
[^4]: ECR or Elastic Container Registry [[AWS - ECR Elastic Container Registry]]