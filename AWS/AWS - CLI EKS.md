#AWS 

# EKS CLI 

This is a summary of interesting commands to interact with AWS Elastic Kubernetes Service[^eks] resources using AWS CLI. 

To list clusters:  

```bash
aws eks list-clusters
```

To describe a cluster: 

```
aws eks describe-cluster --name <cluster_name>
```

To create a cluster using the CLI: 

```bash
aws eks create-cluster \
  --name <cluster_name> \
  --role-arn <role_arn> \
  --resources-vpc-config subnetIds=<subnet_ids>,securityGroupIds=<security_group_ids>
```

To delete a created cluster by specifying the cluster-name. To do this will be interesting to list to list the available clusters before deleting: 

```bash
aws eks delete-cluster --name <cluster_name>
```

You can also describe the node group associated with the EKS: 

```bash
aws eks describe-nodegroup \
  --cluster-name <cluster_name> \
  --nodegroup-name <nodegroup_name>
```

And delete an associated node group: 

```bash
aws eks delete-nodegroup \
  --cluster-name <cluster_name> \
  --nodegroup-name <nodegroup_name>
```

#### Fargate management

In case of deploying it over an AWS fargate, you need to manage it in a different way using CLI than with Node Group: 

To create a fargate profile: 

```bash
aws eks create-fargate-profile \
  --cluster-name <cluster_name> \
  --fargate-profile-name <fargate_profile_name> \
  --pod-execution-role-arn <role_arn> \
  --subnets <subnet_ids>
```

To delete an associated fargate profile: 

```bash
aws eks delete-fargate-profile \
  --cluster-name <cluster_name> \
  --fargate-profile-name <fargate_profile_name>
```

To list the fargate profile: 

```bash
aws eks list-fargate-profiles --cluster-name <cluster_name>
```

#### Networking resources 

To manage the networking resources surrounding the EKS: 

```bash
aws ec2 describe-vpcs --vpc-ids <vpc_id>
```

To check the security groups associated

```bash
aws ec2 describe-security-groups --group-ids <security_group_id>
```

To check an IAM role associated with the EKS

```bash
aws iam get-role --role-name <role_name>
```

And attach the IAM policies to the IAM Role[^iam]

```bash
aws iam attach-role-policy --role-name <role_name> --policy-arn <policy_arn>
```
#### Monitorization

To check if the loggin is enabled and which type of logging is configured, you can do `--query 'cluster.logging'` to retrieve the Cloudwatch[^1] configuration: 

```bash
aws eks describe-cluster --name <cluster_name> --query 'cluster.logging'

# You will recieve a response like this
{
    "clusterLogging": [
        {
            "types": [
                "api",
                "audit",
{
    "clusterLogging": [
        {
            "types": [
                "api",
                "audit",
                "authenticator",
                "controllerManager",
                "scheduler"
            ],
            "enabled": false
        }
    ]
}
```

[^eks]: Elastic Kubernetes Service or EKS AWS resource [[AWS - EKS Elastic Kubernetes Service]]
[^1]: AWS Cloudwatch service [[AWS - Cloudwatch]]
[^iam]: IAM Policies and roles is the resource to manage the access control in AWS [[AWS - IAM]]