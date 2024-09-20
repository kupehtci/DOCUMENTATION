#AWS #EKS 

# EKS Taints

In AWS EKS or Elastic Kubernetes Service[^1] , you can create additional node groups to split workloads, allocate different resources, or isolate different applications. 

This is a basic documentation about how to split this allocations using EKS taints 

### Steps to Create Another Node Pool for Different Applications in AWS EKS

### 1. Define the New Node Group in Terraform

You can add another `aws_eks_node_group` resource in your Terraform to create a new node pool for specific resources within the Kubernetes cluster

For example, suppose you want to create a node group for an application that requires more compute power. You can define a new node group with larger instance types:

```yaml
resource "aws_eks_node_group" "additional_node_group" {
  cluster_name    = aws_eks_cluster.my_cluster.name
  node_role_arn   = aws_iam_role.eks_node_group_role.arn
  subnet_ids      = var.subnet_ids
  instance_types  = ["t3.large"] # Larger instance types for more compute power

  scaling_config {
    desired_size = 3
    max_size     = 5
    min_size     = 1
  }

  labels = {
    app = "my-application"
  }

  taints = [{
    key    = "dedicated"
    value  = "my-application"
    effect = "NO_SCHEDULE"
  }]
}
```

### 2. Customize node group

For the new group you can choose the appropriate instance type based on your application requirements. For example, use `t3.large` for computing applications or `r5.large` for memory demanding workloads.

You can also adjust the `desired_capacity`, `min_size`, and `max_size` based on the expected load.
 
 Its mandatory to add labels to the new node group in order to schedule specific workloads to this node group. In this example,  `app=my-application` its used to identify the node pool for directing workloads. 
 
 Define this labels in the taints to make sure that only specific pods are scheduled on this node pool. In the example, the taint `dedicated=my-application` with `NO_SCHEDULE` ensures that only pods tolerating this taint are scheduled on these nodes.


### 3. Schedule Applications to the New Node Group

Once the node pool is created, you can configure your Kubernetes workloads to run on this node pool. For this use this ways: 

- **Node Selector:** 

```yaml
apiVersion: v1
kind: Pod
metadata:
  name: my-app
spec:
  containers:
    - name: my-app
      image: my-app-image
  nodeSelector:
    app: my-application
```

- **Tolerations:** 

```yaml
apiVersion: v1
kind: Pod
metadata:
  name: my-app
spec:
  containers:
    - name: my-app
      image: my-app-image
  tolerations:
    - key: "dedicated"
      operator: "Equal"
      value: "my-application"
      effect: "NoSchedule"
```

This ensures that your application pods are only scheduled on the nodes in the correct node pool.

[^1]: Elastic Kubernetes Service [[AWS - EKS Elastic Kubernetes Service]]