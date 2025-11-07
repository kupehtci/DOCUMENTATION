#AWS 

# AWS - Trusted Advisor

**AWS Trusted Advisor** is a monitoring and recommendation service that helps you to optimize your AWS environment: 

* Cost Optimization: 
	* **RDS Reserved Instance Optimization** detects when RDS instances runs for so long and recommend to buy Reserved Instances to reduce costs
	* **EC2 Reserved Instance Optimization** – Identifies long-running EC2 On-Demand instances that could benefit from RIs or Savings Plans.
	* **Underutilized EC2 Instances** – Finds EC2 instances with consistently low CPU/network usage.
	* **Idle or unused Load Balancers** – Detects ELBs with noconnections.
	* **Unassociated Elastic IPs**: Flags unused EIPs that incur cost.
	* Low Utilization Amazon Redshift Clusters
* Performance: 
	* **High utilization Amazon EC2 instances** alerts when CPU, memory or network usage its to high. 
	* **High utilization in RDS instances**.
	* **CloudFront Content Delivery optimizations**: give recommendations for compression and caching improvements. 
* Security: 
	* **Identities MFA on root account**. 
	* **IAM Usage** so avoid using root account. 
	* **Security Groups allowing 0.0.0.0/0** detect unrestricted access to ports. 
	* **S3 bucket permissions**: detect public available or overly permissive buckets. 
* Fault Tolerance: 
	* **RDS Backups enabled**: ensures backup retention is properly configured. 
	* **ELB configuration**: ensures that ELBs are configured for a proper usage of AZs. 
	* **EBS snapshot age**: detect missing or outdated EBS snapshots. 
	* **Auto Scaling Group Health Checks** configuration issues.
	* Redundant Route 53 Name Servers. 
* Service limits: 
	* **EC2 instance limits** per region
	* **EBS volume limits**
	* **VPC limits**
	* **IAM Role / Policy limits**
	* **Elastic IP limits**
	* **RDS instance limits**

## Use Cases

Trusted Advisor checks the AWS environment and identifies: 

- Unused or underutilized resources
- Security misconfigurations
- Exposed S3 buckets
- Over-permissive IAM roles
- Idle or underused RDS or EC2 instances
- Opportunities to buy Reserved Instances or Savings Plans
- Approaching service limits


