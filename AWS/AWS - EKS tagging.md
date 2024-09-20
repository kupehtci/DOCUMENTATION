#AWS #EKS #CLOUD

# AWS EKS Tagging

When deploying an EKS with some resources around it, this resources need some specific tagging in order to be associated with the EKS and managed by it: 

1. VPC tagging requirement

When you create an Amazon EKS cluster earlier than version 1.15, Amazon EKS tags the VPC containing the subnets you specify in the following way so that Kubernetes can discover it:

```yaml
Key                                       Value

kubernetes.io/cluster/<cluster-name>      shared
```

Key: The value matches your Amazon EKS cluster's name.  
Value: The shared value allows more than one cluster to use this **VPC**.

2. Subnet tagging requirement

When you create your Amazon EKS cluster, Amazon EKS tags the subnets you specify in the following way so that Kubernetes can discover them:

> Note: All subnets (public and private) that your cluster uses for resources should have this tag.

```yaml
Key                                     Value
kubernetes.io/cluster/<cluster-name>    shared
```

Key: The value matches your Amazon EKS cluster.  
Value: The shared value allows more than one cluster to use this **subnet**.

3. Private subnet tagging requirement for internal load balancers

Private subnets must be tagged in the following way so that Kubernetes knows it can use the subnets for internal load balancers.

```yaml
Key                              Value

kubernetes.io/role/internal-elb  1
```

4. Public subnet tagging option for external load balancers

**You must tag the public subnets in your VPC so that Kubernetes knows to use only those subnets for external load balancers instead of choosing a public subnet in each Availability Zone** (in lexicographical order by subnet ID). If you use an Amazon EKS AWS CloudFormation template...

```yaml
Key                      Value

kubernetes.io/role/elb   1
```

### Tag an autoscaler group

If the autoscaler group is created through a Node Group[^1], it doesn't require tagging because its currently made by the Node Group deployment. 

The Cluster Autoscaler requires the following tags on your node group Auto Scaling groups so that they can be auto-discovered: 

```yaml
Key                                       Value

k8s.io/cluster-autoscaler/<cluster-name>  owned

k8s.io/cluster-autoscaler/enabled         true
```

### Tag a security group

If you have more than one security group associated to your nodes, then one of the security groups must have the following tag applied to it. If you have only one security group associated to your nodes, then the tag is optional.

```yaml
Key                                   Value

kubernetes.io/cluster/<cluster-name>  owned
```

[^1]: EC2 Node group [[AWS - EKS Compute instances]] [[AWS - EC2]] 