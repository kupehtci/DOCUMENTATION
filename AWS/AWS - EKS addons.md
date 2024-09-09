#AWS #EKS 

# EKS addons

In AWS EKS or Elastic Kubernetes Service, addons are packaged software components provided by Amazon that can be easily integrated with the EKS cluster. 

This enables to add essential components like networking, security, observability and more. 

By using EKS addons instead of Helm[^2] releases or similar, you ensure that the components are highly compatible with EKS versions. 

Some <span style="color:DodgerBlue;">common EKS add-ons</span> are: 



### How to get an addon version 

To list the available versions of an addon, the following command can be uses in the AWS CLI tool: 

```bash
 aws eks describe-addon-versions \
	 --kubernetes-version=1.26 \
	 --addon-name=aws-ebs-csi-driver\
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
# xxxx.tf 
resource "aws_eks_addon" "addons" {
  for_each                = { for addon in var.eks_addons : addon.name => addon }
  cluster_name            = aws_eks_cluster.eks.name
  addon_name              = each.value.name
  addon_version           = each.value.version
  resolve_conflicts_on_update = "OVERWRITE"
}

# variables.tf 

variable "eks_addons" {
  type = list(object({
    name = string
    version = string
  }))

  default = [
    {
      name    = "kube-proxy"
      version = "v1.26.15-eksbuild.5"
    },
    {
      name    = "vpc-cni"
      version = "v1.18.3-eksbuild.2"
    },
    {
      name    = "coredns"
      version = "v1.9.3-eksbuild.17"
    },
    {
      name    = "aws-ebs-csi-driver"
      version = "v1.34.0-eksbuild.1"
    }
  ]

  description = "Addons for installing in the EKS cluster"
}

# Terraform.tfvars

eks_addons = [
    {
      name    = "kube-proxy"
      version = "v1.27.1-eksbuild.1"
    },
    {
      name    = "vpc-cni"
      version = "v1.18.3-eksbuild.2"
    },
    {
      name    = "coredns"
      version = "v1.11.1-eksbuild.11"
    },
    {
      name    = "aws-ebs-csi-driver"
      version = "v1.25.0-eksbuild.1"
    }
  ]
```



[^2] HELM is a software package tool for Kubernetes manifests. [[HELM]]