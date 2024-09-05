#AWS #EKS 

# EKS Taints

In AWS EKS or Elastic Kubernetes Service[^1] , you can create additional node pools (referred to as "Node Groups" in AWS terminology) to segregate workloads, allocate different resources, or isolate different applications. This allows you to tailor the node configurations (e.g., instance types, auto-scaling settings) based on the specific needs of each application. Here's how you can create another node pool (Node Group) in EKS using Terraform.

### Steps to Create Another Node Pool for Different Applications in AWS EKS

#### 1. **Define the New Node Group in Terraform**

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
#### 2. **Customize the Node Group Configuration**

- **Instance Types:** You can choose the appropriate instance type based on your application requirements. For example, use `t3.large` for compute-intensive applications or `r5.large` for memory-intensive workloads.
- **Scaling:** Adjust the `desired_capacity`, `min_size`, and `max_size` based on the expected load.
- **Labels:** Adding labels allows you to schedule specific workloads to this node group. For example, you can use the label `app=my-application` to identify the node pool for a specific application.
- **Taints:** Use taints to ensure that only specific pods are scheduled on this node pool. In the above example, the taint `dedicated=my-application` with `NO_SCHEDULE` ensures that only pods tolerating this taint are scheduled on these nodes.

#### 3. **Deploy the Node Group**

After defining the new node group in your Terraform configuration, run the following commands to deploy the new node pool:

sh

Copy code

`terraform init terraform apply`

Terraform will create the additional node group in your EKS cluster.

#### 4. **Schedule Applications to the New Node Group**

Once the node pool is created, you can configure your Kubernetes workloads to run on this node pool. There are two primary ways to do this:

- **Node Selector:** Use `nodeSelector` in your pod specification to ensure that pods are scheduled on the correct nodes.

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

- **Tolerations:** If you’ve added taints to the node group, you'll need to add tolerations to your pod specification.

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

#### 5. **Manage and Scale the Node Group**

After deployment, you can manage and scale your node groups independently, based on application demands. AWS EKS supports auto-scaling based on metrics like CPU, memory, or custom metrics. You can also manually scale the node group using Terraform by adjusting the `desired_capacity`, `min_size`, and `max_size` values.

### Conclusion

By creating multiple node pools (node groups) in AWS EKS, you can optimize resource allocation and isolate workloads across different applications. This setup allows you to tailor the infrastructure to meet specific requirements and ensure better performance and scalability for each application running in your Kubernetes cluster.


[^1]: Elastic Kubernetes Service [[AWS - EKS Elastic Kubernetes Service]]