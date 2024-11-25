
### Disaster planning

Disaster planning consist in making a plan of action for cases of a partial or complete failure of the infrastructure. Testing resources and planning are vital components of a successful DR plan. 

* Testing: test the DR plan to validate the implementation
* Resources: run the recovery path in production to validate ti and verify that the resources are sufficient for operation through the event. 
* Planning: tha recovery that works is the path that is test frequently. 
### Failovers and regions

AWS maintain a strict isolation policy between regions. Events in a region won't impact any other regions. 
In case of AWS direcct connect, it will be diferent the access between Regions. 

* RPO Recovery Point Objective is the acceptable amount of data loss measured in time. It condition the automatized backup time.
* RTO recovery Time Objective is the time that takes after distruption to restore the business process at a service level

During a disaster, you need to provision new resources o fail over to existing pre-configure resources. These involve code and content but also other pieces or configurations such as DNS entries, Network Firewall rules, virtual Instances or machines. 

A good approach to a disaster recovery plan can be **duplicate data in storage**. 
Duplicate instances like SnowFamily, S3 standard and glacier, EBS and snapshots can be use in case of failure.
Also the use of AWS DataSync to sync the files from on-premises or in cloud file systems to an Amazon EFS over the internet or through an AWS Direct Connect connection. 

Also **configuring AMIs** for recovery of EC2 machines. 

Failover in the network can be handled different: 

* Route 53 include global load balancing capabilities, being able through health check to route the traffic to other instances. 
* ELB distributes the traffic between multiple EC2 instances
* You can extend the VPC to extend the network topology of the cloud to recover from a disaster. 
* Maintain a dedicated network connection from on-premise to AWS with AWS Direct Connect. 

Also a good practice to recover easily from a disaster would be, having the infrastructure scripted, so be able to restore easily by creating a new one. 


### AWS Backup

AWS Backup is a fully managed backup service that helps you centralize and automate the backup of data across AWS services and AWS accounts (Through AWS Organizations). 

It works with various resources like databases (DynamoDB, Aurora and RDS), EC2 and Storage (EFS, EBS, FSx and AWS storage gateway). 

It has some features: 

* Simplicity: the backup is simplifies without needeing backup scripts, it can backup resources that has a certain tag and the configuration of the backups is centralized in the AWS Backup service. 
* Compliance: you can enforce backup policies, encrypt the backups and protect them from manual deletion. Also consolidate logs of backups activity. 
* Control costs: reduce risks of downtime. It has no added cost for orchestration. 

##### How AWS Backup works

When creating an **AWS backup plan** you specify the following: 
* Schedule: frequency of the backups and window of time
* lifecycle: when the backup is moved to cold storage
* Vault: it keeps backups in AWS Backup Vault, with a certain plan. 
* Tags for backup: the tag that will be assigned to tags when is created by this plan. 

You assign the resources that will be backed up with it or tags that resources that match will be backed up. 


### Recovery Strategies

There are 4 DR scenarios: 
* Backup and restore
* Pilot light
* Warm standby
* Multi-site active/active

##### Backup and restore

Data is backed up as tape in an Amazon S3 and can be transferred to production in case of failure. 
Create new EC2 instances using the same previous AMI and restore the backup. 

##### Pilot light

You replicate the data from one environment to another and provision a copy of the core workload infrastructure. 
replciate the production web server, app server and database in a recovery environment. Then you switch up to the new infrastructure. 

##### Warm Standby

Involves creating an scaled down fully functional copy of the production environment in another recovery. 
By identifying the most critical systems, you can fully duplicate these systems and keep them always on. 

It decreases the time of recovery but you don't have to wait for resources in the recovery environment to start up. 

##### Multisite active/active

The solution runs in two environments and Route53 can route traffic between both.
If one of them fails, the traffic is currently being routed to the other environment. 

## Comparison

A comparison between them in terms of RPO-RTO are: 

```txt
Backup and restore   >    Pilot light   >  Warm Standby    > Multisite act/act
RTO-RPO: Hours     -  RTO-RPO: 10s mins -  RPO-RTO: mins   -  RPO-RTO: real time
```

