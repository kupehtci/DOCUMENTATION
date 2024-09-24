#AWS #EKS 

# AWS BOILERPLATE Configuration

This terraform deploy a managed EKS with all the necessary resources around it.

The goal of this project is to maintain an standardized structure for a quick, highly maintainable, easily configurable AWS infrastructure.

This documentation gathers a basic configuration keeping the structure of the boilerplate. In case of customizing it or adjusting more parameters, you can modify all the available components using the provided variables or modifying the project structure. 
### Prerequisites 

In order to be able to deploy the terraform and manage the connection to the AWS for terraform we need a valid user or role that can access the solution and has enough permissions to deploy and list resources. System admin is recommended in order to deploy all.

* `aws cli` installed in order to use terraform and authenticate before. 
* `kubectl` tool its recommended to check that you can connect to the EKS after it has been deployed and validate that all is correctly working. This can also be checked using AWS portal UI to see the different running Kubernetes resources. 

##### Provider configuration

To deploy Velero to the AWS cloud we are going to use velero helm release and deploy to the EKS cluster using terraform `helm` provider. 
Also because some resources of AWS need to be imported as data resources, we also need the `aws` provider for getting S3 bucket and declare other resources. 

For configuring `aws` provider, by default you can set some configuration in the `~/.aws/config` and use this configuration with SSO to login in AWS. 

```yaml
locals{
  aws_region                   = "eu-north-1"
  aws_shared_config_files      = ["~/.aws/config"]
  aws_shared_credentials_files = ["~ /.aws/credentials"]
  # aws_access_key = ""
  # aws_secret_key = ""
  aws_profile = "hiberus-devops"
}

provider "aws" {
  region = local.aws_region

  ## Uncomment this for login using user access and secret key 
  ## 
  # access_key = local.aws_access_key
  # secret_key = local.aws_secret_key

  ## Uncomment this for login using Profiles
  ## 
  shared_config_files      = local.aws_shared_config_files
  shared_credentials_files = local.aws_shared_credentials_files

  profile = local.aws_profile

  default_tags {
    tags = {
      Environment = local.environment
      Project     = local.project
    }
  }
}
```

You can authenticate AWS provider to the AWS cloud by two different forms: 

* Set `access_key` and `secret_key` to a user login access and secret. 
* Having a configuration and credentials files in `~/.aws/` settled with the login credentials to the AWS Cloud. For this, `shared_config_files` and `shared_credentials_files` need to be set to the path to each one of this files. Also `profile` need to be set to the name of the profile set within the configuration file. 

The `default_tags` variable is a list of tags that will be added to all the objects created with the AWS provider.  

For more information about authenticating to AWS provider: https://registry.terraform.io/providers/hashicorp/aws/latest/docs



##### Network configuration

The network is configure to provide 4 subnets, 2 privates and 2 public symmetrically distributed between two availability zones. 

The two private subnets route the 0.0.0.0/0 traffic to the NAT gateway placed in the public subnet. 
Also in the public subnets routes the 0.0.0.0/0 traffic to an Internet Gateway to the public internet. 

Take into account when deciding the CIDR blocks for the subnets and the VPC that EKS needs: 

* At least 16 IP addresses available
* To not reside in one of this availability zones: `us-east-1`,  `us-west-1` or `ca-central-1`. 
* Not use dual stack addresses for Kubernetes cluster private endpoint
* EKS its recommended to reside in the two private subnets
* Have at least 1 public subnet with internet access and private subnets pointing to it in order to have outbound connection from pods to the internet in order to pull images or other operations. 
* If the private subnets where the EKS is doesn't have a route table pointing to the NAT gateway, add VPC endpoint to AWS Private link to route the EKS traffic to the correspondent resources like S3, ELB, Cloud watch and similar. 

The subnets that are going to be controlled or related with the EKS need to have the following tag: 

* private subnets
```yaml
kubernetes.io/role/internal-elb:  1
```

* public subnets
```yaml
kubernetes.io/role/elb: 1
```

* To all subnets
```yaml
kubernetes.io/cluster/<my-cluster-name>: shared
```

  

The subnets are set to `"kubernetes.io/cluster/${var.eks_name}" = "owned"` or `shared` for being managed by the EKS. In the case that some AWS resources are going to be deployed within the same subnets but are not managed by EKS, set the value to `shared`.

In case of delete `kubernetes.io/role/internal-elb` (Private subnets) or `kubernetes.io/role/elb` (Public subnets), you will need to specify the subnets in the EKS ingress resources by adding to `metadata.annotations` the following annotation:  `alb.ingress.kubernetes.io/subnets`.

The tag `subnet_tier = "public"` or `subnet_tier = "private"` are used to retrieve a list of all the public or private subnets in other terraforms that import this resources as `data` terraform resources.

This data can be done following this format:

  

```hcl

data "aws_subnets" "private" {

  filter {

    name   = "vpc-id"

    values = [aws_vpc.id]

  }

  

  tags = {

    subnet_tier = "private"

  }

}

```


##### Security groups

  The configuration is based in three main security groups: 

* VPC security group that act as first layer of security
* EKS security group
* ALB security group 

The EKS security group has by default the following ingress ports: 

* 22 (TCP): Enable SSH connection
* 53 (UDP and TCP): allows DNS discovery
* 80 (TCP): HTTP Connections (Can be disabled if all traffic its going to be redirected to HTTPS or no insecure traffic is allowed in pass through ALB mode)
* 443 (TCP): HTTPS connections
* 8080(TCP): Connection for ArgoCD services. Can be closed if ArgoCD is not going to be deployed within the cluster. 
* 10250(TCP): In AWS this port is used within the Solution to do `kubectl port-foward` to a certain pod or service
* 9443 (TCP): Some APIs from AWS that pods can use to deploy and manage AWS resources, use this port to communicate. Disabling this port can cause errors on ingress creation with AWS load balancer controller. 


##### IAM Policies

Some built-in IAM Policies are assigned to some resources in order to grant permissions to manage or have access to other resources over the VPC. 

This is a list of the resources and the assigned IAM policies: 

* Elastic Kubernetes Service: 
	* `AmazonEKSClusterPolicy`
	* Custom: `eks_cluster_autoscaler`: grants permissions to be able to install karpenter or other auto scalers that work from inside the cluster. 
	* `AmazonEKSVPCResourceController`
	* `AmazonEKSWorkerNodePolicy`
	* Custom `aws_lb_controller_policy`: uncomment this IAM policy in case that AWS ALB controller is not going to be installed using this same projects applications to deploy this addon. A custom policy that grants an assumable policy for the controller to be able to deploy and list the Application Load Balancers.  
* EKS' node group: 
	* `AmazonEKSWorkerNodePolicy`
	* `AmazonEKS_CNI_Policy`
	* `AmazonEBSCSIDriverPolicy`
	* `AmazonEC2ContainerRegistryReadOnly`

Uncomment and use `iam_role_pods_identity` template in order to grant Assumable roles for pods to assume and have permissions over the EKS cluster. 


##### Elastic Kubernetes Service

The EKS is configured by default to be deployed at a specified Kubernetes version with public and private endpoints enabled. 

Also EKS is set in all Subnets while Node group of EC2 instances is kept within the private subnets. 

It uses a custom Security group with the necessary ports enabled for allowing the basic communication and usage of it. If the security group is wanted to be managed by the AWS EKS, delete `security_group_ids = [aws_security_group.eks_sg.id]` to let the EKS create and manage its own security group. 

You can restrict the CIDR blocks that are allowed to connect to the VPC EKS endpoint. You can set this groups using the variable `eks_public_access_cidrs = ["0.0.0.0/0"]`. 

By default, the EKS cluster is provided with some necessary addons with its specified version. This addons are settled in the `eks_addons` variable following this format: 

```yaml
# eks_addons = []  # Set this if no addons are installed
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
    name    = "eks-pod-identity-agent"
    version = "v1.3.2-eksbuild.2"
  }
]
```

In case of adding more, include the AWS registered name and its available version to deploy it. 

##### EKS Node Group

You can set the type of machines that EKS launches and get managed by the node group by setting in the `eks_instance_types = ["t3.large"]`. 

Take into account the limit of pods that each type of machine can handle because this could lead into a scheduler problem. 

The auto scaling configuration ( desired size, max and min size ) of the Node Group can be configured through the following variables: 

```
## Desired size of the Node pool for the autoscaling configuration
eks_scaling_config_desired_size = 1

## Max size of node pool for the autoscaling configuracion
eks_scaling_config_max_size = 5

## Min size of node pool for the autoscaling configuracion
eks_scaling_config_min_size = 0
```



##### Application Load Balancer

The application load balancer provided in this solution is not deployed because its managed and deployed by default with the AWS ALB controller installed in the EKS. 

This addon installed through helm manages and creates automatically

The necessary resources to expose ingress resources

Enable this resource by setting `var.deploy_alb = true' to create an ALB that can be used with other resources

##### Cloudwatch

The cloudwatch is pre-configured to capture the logs of the EKS. 

This is done by setting the log group to the EKS name. Its done through a variable to avoid the cyclic redundancy between this two resources. 

In order to adjust the type of logs that are captured from the EKS control plane, set: 

```yaml
enabled_cluster_log_types = ["api", "audit"]  
```

Possible log types are: 

* **api** Api server that exposes Kubernetes API. 
* **audit**: Record of individual users, administrators or components that affect the components of the cluster. 
* **authenticator**: control plane EKS component that kubernetes uses for RBAC authentication using IAM credentials. 
* **controllermanager**: control loops that are shipped with kubernetes
* **scheduler**: logs about scheduling pods to run in which nodes and when.

The retention days of the logs recollected by the cloudwatch is set by default to 7 days, but this can be modified with the following variable `eks_cloudwatch_retention_days = 7`
##### Certificates

Some certificates template is defined in the project but need to be configured depending on the project. 

This will depend if cert-manager is used to renew certificates or other methods. 