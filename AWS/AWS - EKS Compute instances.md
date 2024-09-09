#AWS 

### EKS Compute instances

Amazon Elastic Kubernetes service or EKS is a managed AWS service to deploy a kubernetes service without manually deploying a Kubernetes control plane. 

This kubernetes cluster[^1] needs a virtual compute resource(s) where to execute its workloads. This resources are responsible of running the containers running in the pods[^2] and can be deployed in various forms: 

1. **EC2 Instances (Node Groups)**
2. **AWS Fargate**
3. **Self-managed Nodes (Custom EC2 Instances)**

### 1. EC2 Instances (Node Groups)

Amazon EKS allows you to run your workloads on a group of EC2 instances, known as **node groups**. These instances are provisioned as part of the Kubernetes cluster and can be scaled up or down based on your workload requirements.

- **Control**: Full control over the underlying EC2 instances, including instance types, networking, and scaling.
- **Cost**: You pay for the EC2 instances and any associated resources (e.g., EBS volumes, networking).
- **Scaling**: Manual or automatic scaling can be configured using EC2 Auto Scaling Groups.
- **Use Case**: Suitable for workloads that require custom configurations, higher performance, or access to specialized instance types.

### 2. AWS Fargate

**AWS Fargate** is a serverless compute engine that allows you to run containers without managing the underlying infrastructure. When you deploy workloads on Fargate in EKS, AWS automatically provisions and scales the necessary compute resources.

- **Control**: Limited control over the infrastructure; AWS manages the compute resources.
- **Cost**: Pay only for the vCPU and memory resources used by your running containers.
- **Scaling**: Automatic scaling is handled by AWS, with no need to manage instance scaling or capacity planning.
- **Use Case**: Ideal for workloads that require simplicity, where you don't want to manage infrastructure, and for applications with unpredictable scaling requirements.

### 3. Self-Managed Nodes (Custom EC2 Instances)

In this setup, you manage your own EC2 instances that are registered as nodes in the EKS cluster. This method provides the most control over your infrastructure.

- **Control**: Full control over EC2 instances, including the AMI, network settings, and scaling.
- **Cost**: You pay for EC2 instances, similar to node groups.
- **Scaling**: Manual scaling; you must manage the scaling of instances yourself.
- **Use Case**: Suitable for specific use cases that require custom networking, storage, or other configurations not supported by managed node groups.

## Differences Between EKS on EC2, Fargate, and Node Groups

| Feature                     | **EC2 (Node Groups)**                                      | **AWS Fargate**                                         | **Self-Managed Nodes (Custom EC2 Instances)**               |
|------------------------------|-----------------------------------------------------------|---------------------------------------------------------|----------------------------------------------------------------|
| **Infrastructure Control**   | Full control over instance types and configurations       | Minimal control, managed by AWS                         | Full control over EC2 instances, AMI, and scaling              |
| **Cost Model**               | Pay for EC2 instances and associated resources            | Pay for vCPU and memory usage only                      | Pay for EC2 instances and associated resources                  |
| **Scaling**                  | Manual or Auto Scaling Groups                             | Automatic, managed by AWS                               | Manual scaling, managed by the user                             |
| **Customizability**          | High, can use custom AMIs, networking, and instance types | Low, no control over underlying infrastructure          | High, full control over instance configurations                 |
| **Use Case**                 | Performance-intensive workloads, custom configurations    | Simplicity, serverless applications, unpredictable loads | Custom networking, storage, or specialized configurations |

## Conclusion

Amazon EKS provides flexibility in how you manage compute resources, allowing you to choose between fully managed serverless options like Fargate, managed EC2 instances with node groups, or self-managed EC2 instances. The choice of compute resource depends on your specific workload requirements, cost considerations, and the level of control you need over your infrastructure.


[^1]: Kubernetes cluster running in elastic service[[AWS - EKS Elastic Kubernetes Service]]
[^2]: Kubernetes pods are the minimal resource. Its in charge of run and maintain one or more containers [[KUBERNETES - Pods]]