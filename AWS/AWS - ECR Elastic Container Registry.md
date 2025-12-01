#AWS #DOCKER #EKS 

# AWS Elastic Container Registry

AWS ECR or Elastic Container Registry is an AWS managed Docker Container Registry. 

It provides a secure, scalable and reliable Container registry where you can push, pull and manage docker images and Open Container Initiative (OCI) images. 

It have the following key features: 

* Registry where one or more repositories can be created to store Docker images
* Authentication using an AWS user in order to push and pull images
* Manage the control access with repository policies. 

It also offer reviewed cache and validation of images, tagging control of the same, scan-on-push options and cross-account replication of the repositories. 


### Create an ECR repository using AWS CLI

You can create an ECR repository using AWS CLI: 

```bash 
# Format
aws ecr create-repository --repository-name <your-repo-name> --region <your-region>

#Example
aws ecr create-repository --repository-name aws-ecr-kubenginx --region us-east-1
```

### Create an ECR repository using terraform

You can create an ECR repository using terraform: 

```bash
## AWS Elastic Container Registry
resource "aws_ecr_repository" "ecr" {
  name = "${var.project}-${var.environment}-ecr-repo"

  image_tag_mutability = var.ecr_tag_mutability

  image_scanning_configuration {
    scan_on_push = true
  }

  tags = {
    Name = "${var.project}-${var.environment}-ecr-repo"
  }
}
```


## Scan on push

You can enable to scan the images that are pushed with "scan on push" functionality, 
This feature, searches for common CVEs [^1]


[^1]: CVEs or Common Vulnerabilities and Exposures [[CVEs Common Vulnerabilities and Exposures]]