#AWS 
# AWS EKS Security Group

When you create a cluster, by default EKS creates a security group that's named `eks-cluster-sg-<cluster-name>-<generated-id>`. This security group has the following default rules:

| Rule type | Protocol | Ports | Source | Destination                         |
| --------- | -------- | ----- | ------ | ----------------------------------- |
| Inbound   | All      | All   | Self   |                                     |
| Outbound  | All      | All   |        | 0.0.0.0/0 (`IPv4`) or ::/0 (`IPv6`) |

And add some tags to the security group: 

* `kubernetes.io/cluster/<cluster-name>` = "owned"
* `aws:eks:<cluster-name>` = `<cluster-name>`
* `Name` = `eks-cluster-sg-<cluster-name>-<generated-id>`. 

In case of create a **custom security group** for the EKS remember to add this Tags and keep some rules in the custom one. 

|Rule type|Protocol|Port|Destination|
|---|---|---|---|
|Outbound|TCP|443|Cluster security group|
|Outbound|TCP|10250|Cluster security group|
|Outbound (DNS)|TCP and UDP|53|Cluster security group|

Take into account adding rules for the following possible traffic: 

- Any protocol and ports that you expect your nodes to use for inter-node communication.
- Outbound internet access so that nodes can access the Amazon EKS APIs for cluster introspection and node registration at launch time. If your nodes don't have internet access, review [Deploy private clusters with limited internet access](https://docs.aws.amazon.com/eks/latest/userguide/private-clusters.html) 
- Node access to pull container images from Amazon ECR or other container registries APIs that they need to pull images from, such as DockerHub.
- Access to  Amazon S3 [^s3].
- Separate rules are required for `IPv4` and `IPv6` addresses.

### Resources associated

This security group is associated with the two or four Network Interfaces[^2] that are created for the EKS and network interfaces of the nodes that are controlled by the managed node group allocated for the EKS. 


### Describe cluster security group with AWS CLI

You can determine the ID of the cluster security group by making the following command: 

```bash
aws eks describe-cluster --name <cluster-name> --query cluster.resourcesVpcConfig.clusterSecurityGroupId
```


[^2]: Elastic Network Interfaces [[AWS - ENI Elastic Network Interfaces]]
[^s3]: Amazon Simple Storage Service or S3 [[AWS - S3]]