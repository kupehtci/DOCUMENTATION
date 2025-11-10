#AWS 
# ✅ **AWS Solutions Architect Associate Study Checklist**

## ☁️Core Compute

* [x] Amazon EC2
	* [ ] Instance types & families
	* [ ] Tenancy (Dedicated Host vs Instance)
	* [x] EC2 Launch Templates
	* [ ] Placement groups
	* [x] Auto Scaling
	* [ ] Auto Scaling Groups (ASG)
	* [ ] Step scaling policy
	* [ ] Target tracking policy
	* [ ] Scheduled scaling
	* [x] Spot instances
		* [x] Spot Fleet
* [x] AWS Lambda
* [ ] Event triggers & integrations
* [ ] Provisioned concurrency vs on-demand
* [ ] Lambda with VPC
* [ ] Containers
* [x] ECS (Fargate vs EC2)
* [x] EKS basics

## ☁️ Networking & Content Delivery
* [x] Amazon VPC
* [ ] Security Groups vs NACLs
* [ ] Subnets: Public vs Private
* [ ] NAT Gateway vs Instance
* [ ] VPC Peering vs Transit Gateway
* [ ] VPC Endpoints (Gateway vs Interface)
* [ ] Amazon Route 53
* [ ] Routing policies (Failover, Latency, Weighted, Geolocation)
* [ ] CloudFront with ALB as origin
* [ ] API Gateway (REST vs HTTP vs WebSocket)

## 📦 Storage
* [ ] EBS - Elastic Block Storage
* [ ] AWS Recycle Bin
* [ ] EFS
* [ ] EFS vs EBS difference
* [ ] EFS Performance modes
* [x] S3
	* [x] Storage Classes (IA, Glacier, Glacier Deep Archive)
	* [x] Object Lock / Versioning / MFA Delete
	* [x] Signed URLs & Signed Cookies
	* [x] S3 Lifecycle & Replication
		* [x] Intelligent tearing
	* [ ] S3 Requester Pays
* [ ] AWS Storage Gateway

## 🛢️ Databases
* [x] Amazon RDS
	* [x] Multi-AZ vs Read Replicas
	* [x] Backups & snapshots
* [ ] Amazon Aurora & Serverless
* [ ] DynamoDB
	* [ ] Partition keys, GSIs, LSIs
	* [ ] TTL, Streams
	* [x] DAX
* [ ] Amazon ElastiCache (Redis vs Memcached)

## 🔐 Security & Governance
* [ ] AWS Identity & Access Management (IAM)
	* [x] STS -> Federation
	* [x] Roles
	* [ ] Federation
	* [x] Users and Groups
	* [x] IAM Policies evaluation logic
* [ ] AWS KMS
* [ ] AWS Organizations
* [ ] AWS Control Tower
* [ ] AWS Shield
* [ ] WAF
* [ ] AWS Security Hub
* [ ] AWS Config
* [ ] Amazon GuardDuty
* [ ] Amazon Inspector
* [ ] IAM Access Analyzer
* [ ] AWS Secrets Manager vs SSM Parameter Store
	* [ ] MFA, SCPs, Boundary vs Policy

## 🔧 Management, Monitoring & Automation
* [ ] CloudWatch (Metrics, Logs, Alarms)
* [ ] CloudTrailSystems Manager (SSM)
	* [ ] Patch Manager, Session Manager, Parameter Store
* [ ] AWS Trusted Advisor
* [ ] AWS Well-Architected Framework (5 pillars)
* [ ] AWS CloudFormation basics

## 🔗 Application Integration
* [x] Amazon SQS (Standard vs FIFO)
* [x] Amazon SNS
* [ ] EventBridge
* [ ] AWS Step Functions
* [ ] Amazon Kinesis (Streams, Firehose, Analytics)

## 🤖 Analytics & ML
* [x] Amazon Athena
* [ ] Amazon Glue
* [ ] Amazon QuickSight
* [ ] AWS Comprehend
* [ ] Amazon Forecast (optional but useful)

## 🛠️ Migration & Hybrid

* [ ] AWS DMS (Database Migration Service)
* [ ] AWS Snow Family
* [ ] AWS Direct Connect vs VPN
* [ ] AWS Managed Services (AMS)

## 🏗️ Developer & CI/CD Basics
* [ ] CodeCommit
* [ ] CodeDeploy
* [ ] CodePipeline
* [ ] CodeBuild