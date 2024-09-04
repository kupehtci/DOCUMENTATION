#AWS 

# AWS ELB Target groups

AWS Load Balancer Target Groups are the main component to balance and direct the traffic to certain components or instances, discerning by IP addresses, lambda functions or containers. 

This target groups are associated with a Network, Application[^1] or Elastic Load Balancer in order to direct the incoming trafic to certain targets based on configured rules. 
### How it work

When a load balancer receives traffic, it forwards the request to one of the targets within a target group based on the load-balancing rules you’ve defined. A target group maintains a list of registered targets (e.g., EC2 instances, IP addresses, or Lambda functions) and routes traffic to these targets according to the load balancer's configuration.

Targets in a group can be located in different Availability Zones (AZs) for increased availability and fault tolerance. You can define multiple target groups, each with its own health check configuration, to ensure that traffic is only routed to healthy targets.

### Types of target groups

AWS provides three different target groups for redirecting the traffic to certain AWS resources. 

* Instance Target Groups
	- **Use Case:** Targets EC2 instances.
	- **Target Type:** EC2 instances registered with the target group by instance ID.
	- **Supported Load Balancers:** Application Load Balancer (ALB), Network Load Balancer (NLB), Gateway Load Balancer (GWLB).

* IP Target Groups
	- **Use Case:** Targets IP addresses within a VPC.
	- **Target Type:** IP addresses (IPv4/IPv6) that are reachable within the VPC.
	- **Supported Load Balancers:** ALB, NLB, GWLB.

* Lambda Target Groups
	- **Use Case:** Targets AWS Lambda functions.
	- **Target Type:** Lambda function ARN.
	- **Supported Load Balancers:** ALB.

### How to configure a target group

To create a target group, you can use the AWS Management Console, AWS CLI, or AWS SDKs. Below is a step-by-step guide using the AWS Management Console:

1. **Navigate to Target Groups:**
    - Open the EC2 Dashboard and select "Target Groups" from the "Load Balancing" section.

1. **Create Target Group:**
    - Click "Create target group."
    - Choose the type of target group (Instances, IP addresses, or Lambda functions).

1. **Define Target Group Settings:**
    - **Target group name:** Specify a name for your target group.
    - **Protocol:** Choose a protocol (HTTP, HTTPS, TCP, TLS, etc.).
    - **Port:** Specify the port on which the targets are listening.
    - **VPC:** Select the VPC where the targets reside.

1. **Health Check Configuration:**    
    - Configure health checks to monitor the health of the targets. You can specify the protocol, path, port, interval, timeout, and thresholds for healthy and unhealthy targets.

1. **Register Targets:**
    - Add targets to the group. Depending on the target type, you’ll either select instances, IP addresses, or Lambda functions.

1. **Save Target Group:**
    - After configuring the settings, click "Create" to finalize the target group.


Once your target group is created, you need attach it to a load balancer:

1. **Create or Modify Load Balancer:**
    
    - When creating a new load balancer (ALB, NLB, etc.), you’ll be prompted to select a target group.
    - For an existing load balancer, navigate to the "Listeners" section and modify or add rules that forward traffic to the desired target group.ç

1. **Listener Rules:**
    - Define listener rules that direct traffic to specific target groups based on conditions like path, host headers, or source IP.

1. **Traffic Distribution:**
    - The load balancer will distribute incoming traffic across the registered and healthy targets in the target group.

