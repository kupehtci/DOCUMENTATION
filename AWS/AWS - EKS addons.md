#AWS #EKS 

# EKS addons

In AWS EKS or Elastic Kubernetes Service, addons are packaged software components provided by Amazon that can be easily integrated with the EKS cluster. 

This enables to add essential components like networking, security, observability and more. 

By using EKS addons instead of Helm[^2] releases or similar, you ensure that the components are highly compatible with EKS versions. 

The EKS provider addons list are: 

| Description                                                                                                                                                                                                                                           | Name                                  | EKS name                          |
| ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------- | --------------------------------- |
| Provide native VPC networking for your cluster                                                                                                                                                                                                        | Amazon VPC CNI plugin for Kubernetes  | `vpc-cni`                         |
| A flexible, extensible DNS server that can serve as the Kubernetes cluster DNS                                                                                                                                                                        | CoreDNS                               | `coredns`                         |
| Maintain network rules on each Amazon EC2 node                                                                                                                                                                                                        | Kube-proxy                            | `kube-proxy`                      |
| Provide Amazon EBS storage for your cluster                                                                                                                                                                                                           | Amazon EBS CSI driver                 | `aws-ebs-csi-driver`              |
| Provide Amazon EFS storage for your cluster                                                                                                                                                                                                           | Amazon EFS CSI driver                 | `aws-efs-csi-driver`              |
| Provide Amazon S3 storage for your cluster                                                                                                                                                                                                            | Mountpoint for Amazon S3 CSI Driver   | `aws-mountpoint-s3-csi-driver`    |
| Enable the use of snapshot functionality in compatible CSI drivers, such as the Amazon EBS CSI driver                                                                                                                                                 | CSI snapshot controller               | `snapshot-controller`             |
| Secure, production-ready, AWS supported distribution of the OpenTelemetry project                                                                                                                                                                     | AWS Distro for OpenTelemetry          | `adot`                            |
| Security monitoring service that analyzes and processes foundational data sources including AWS CloudTrail management events and Amazon VPC flow logs. Amazon GuardDuty also processes features, such as Kubernetes audit logs and runtime monitoring | Amazon GuardDuty agent                | `aws-guardduty-agent`             |
| Monitoring and observability service provided by AWS. This add-on installs the CloudWatch Agent and enables both CloudWatch Application Signals and CloudWatch Container Insights with enhanced observability for Amazon EKS                          | Amazon CloudWatch Observability agent | `amazon-cloudwatch-observability` |
| Ability to manage credentials for your applications, similar to the way that EC2 instance profiles provide credentials to EC2 instances                                                                                                               | EKS Pod Identity Agent                | `eks-pod-identity-agent`          |

### How to get an addon and its version 

To list all the available addons for the EKS cluster, you can execute the following command: 
```zsh
aws eks describe-addon-versions | grep addonName
```

To list the available versions of an addon, the following command can be uses in the AWS CLI tool: 

```bash
 aws eks describe-addon-versions \
	 --kubernetes-version=1.26 \
	 --addon-name=<addon-name>\
	 --query='addons[].addonVersions[].addonVersion'
```

### CLI addon Install

Addons can be installed via the AWS CLI tool with `aws eks create-addon` command: 

```bash
aws eks create-addon \ 
	--cluster-name my-cluster \ 
	--addon-name vpc-cni \ 
	--addon-version v1.12.1-eksbuild.1
```

And update it with `aws eks update-addon` command: 

```bash
aws eks update-addon \
    --cluster-name my-cluster \
    --addon-name vpc-cni \
    --addon-version v1.12.2-eksbuild.1
```

To list all the installed addons, can be done with `aws eks list-addons` command: 

```bash
aws eks list-addons --cluster-name my-cluster
```
### Terraform addon install

Addons can also be installed to AWS via terraform to a terraform managed or imported EKS cluster: 

```hcl
resource "aws_eks_cluster" "my_cluster"{
  # Some configuration
}

resource "aws_eks_addon" "vpc_cni" {
  cluster_name = aws_eks_cluster.my_cluster.name
  addon_name   = "vpc-cni"
  addon_version = "v1.12.1-eksbuild.1"

  resolve_conflicts = "OVERWRITE"

  depends_on = [aws_eks_cluster.my_cluster]
}
```

with: 

* `resolve_conflicts` specify how to resolve conflicts in the addons install: `OVERWRITE`, `NONE` or `PRESERVE`. 
* `service_account_role_arn` the IAM role associated with the add-on

Also a more configurable way and more legible, will be in case of needing to add more than one or two addons, use an `for_each` in the resource and list the addons and its versions in the `terraform.tfvars`. 

Do this by following this basic structure: 

```hcl
# ------------------- xxxx.tf ---------------------------------------------
resource "aws_eks_addon" "addons" {
  for_each                = { for addon in var.eks_addons : addon.name => addon }
  cluster_name            = aws_eks_cluster.eks.name
  addon_name              = each.value.name
  addon_version           = each.value.version
  resolve_conflicts_on_update = "OVERWRITE"
}

# ------------------- variables.tf ----------------------------------------

variable "eks_addons" {
  type = list(object({
    name = string
    version = string
  }))

  default = [] 
  description = "Addons for installing in the EKS cluster"
}

# ------------------- Terraform.tfvars ------------------------------------

eks_addons = [
    {
      name    = "kube-proxy"
      version = "v1.30.3-eksbuild.2"
    },
    {
      name    = "vpc-cni"
      version = "v1.18.3-eksbuild.2"
    },
    {
      name    = "coredns"
      version = "v1.11.3-eksbuild.1"
    },
    {
      name    = "aws-ebs-csi-driver"
      version = "v1.34.0-eksbuild.1"
    },
    {
        name = "eks-pod-identity-agent"
        version = "v1.3.2-eksbuild.2"
    }
  ]
```



[^2] HELM is a software package tool for Kubernetes manifests. [[HELM]]