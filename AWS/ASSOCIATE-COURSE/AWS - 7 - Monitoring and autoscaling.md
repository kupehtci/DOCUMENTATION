#AWS 

# AWS 7 Monitoring and autoscaling

Both come together because monitoring the resource utilization is the principle that automatic will scale the resources to handle the increasing or decreasing workload of the resources. 

## Monitoring

The reasons for monitoring: 

* Operational Health: operational visibility
* Application performance: collect data of every layer of the performance stack
* Resource Utilization: improve the resource utilization, improving the user experience. 
* Security and auditing: automate the management evidence collection, security and integration

#### Amazon CloudWatch

Amazon CloudWatch is an AWS service that provides near-real-time stream of system events. This events describe changes of the AWS resources. 
This can be use to monitor CPU usage, disk operations of EC2 instances. 

You can use built-in metrics and custom metrics. 

This metrics can have one-second granularity and up to 15 months of metrics retention.  


Metrics can have **two different types**:

* <span style="color:LightSeaGreen;">Real time metric</span>: metric captured at real time. 
* <span style="color:LightSeaGreen;">Calculated</span>: the metric is derivated of a calculation using other metrics like SLA or others. 

A <span style="color:DodgerBlue;">CloudWatch metric</span> includes the following components: 

* A <span style="color:orange;">Namespace</span> that act as a container for CloudWatch metrics. AWS namespaces by default group the metrics by services in the following format *AWS/Service* as example *AWS/EC2*. 
* A <span style="color:orange;">Metric</span> represents a set of data points over the time published to CloudWatch.
* A <span style="color:orange;">dimension</span> is a name-value pair that identifies the metric. Each metric can have up to 10 dimensions. This dimensions are categories. 

There are different types of logs: 

* <span style="color:orange;">Amazon CloudWatch logs</span>: monitors, store and access the log files from Amazon EC2 instances, AWS CloudTrail, Amazon Route 53 and other resources. 
* <span style="color:orange;">AWS CloudTrail</span> provides a history of the account activity, actions taken by console, AWS SDK, CLI and AWS Services. This services provides continuously monitoring and security. 
* <span style="color:orange;">AWS Flow logs</span> captures information about the IP traffic that goes in/out the ENI (Elastic Network Interface). 
* <span style="color:orange;">Load Balancing</span> provides logs with captured information about the requests that are sent to the load balancer. You can use **custom logs** for your applications. 

The EC2 instances, publish logs in a log file and this to a **log stream**. This **log stream** is a sequence of log events that share the same source. 
Multiple **log streams** can be grouped in a single **log group**, that share the same retention, monitoring and access control. 
With a log group, you can use metric filters to search patters, terms, phrases or certain values in the log events. 

##### AWS CloudWatch Alarms

The alarms can be linked with Amazon Simple Notification System or SNS to push notifications or emails in case that an alarm turns on. 

Alarms can have 3 states: 

* OK: metric is within the defined threshold
* ALARM: metric is outside the threshold
* INSUFFICIENT_DATA: alarm has started but the metrics are not available

And to create an alarm you need to define the following parameters: 

* **Statistics**: data agregations over an specified time. 
* **Period** is the length of time to evaluate the metric
* **Evaluation Periods** is the number of most recent perios that need to evaluate to consider an alarm. 
* Datapoints to alarms is the number of data points within the evaluation perios that must be breaching to cause the alarm to reach ALARM state. 

#### AWS CloudTrail

AWS CloudTrail provides insight about who did what in the AWS Api. It provides a history of the account activity, actions taken by console, AWS SDK, CLI and AWS Services. This services provides continuously monitoring and security. 

The event's logs are pushed internally to an Amazon S3. 

This improves security analysis, tracking of resource changes and compliance auditing. 

CloudTrail is configured per region and if you use more than one regions, you can choose where the log files are created in each file. Because the logs are stored in an S3 bucket, this can be one per each region or a shared one for all regions. 

#### Alarm componets

The alarms are component 

#### Amazon EventBridge

Amazon CloudWatch events are now part of Amazon EventBridge. 
EventBridge is a service for managing automatizations that involve AWS resources. 

This enables data exchange between AWS and SaaS applications by using events. 

In EventBridge, event publishers are decoupled from event subscribers and cna be used to built event-driven applications. 

As an example, EC2 can report the CPUUtilization Metric data to CloudWatch, a custom alarm is configured as CPUAbove90Percent. 
EventBridge rules can be built to notify the support team in an ALARM state. It can send a notification via SNS and send a rick notification to a third party monitoring tool using the EventBridge events. 

#### VPC Flow Logs



### Load Balacing

#### Elastic Load Balacer (ELB)

An Elastic Load Balancer or ELB automatically distributes traffic across multiple targets. 
Provides high availability of the resources. 

It has various types: 

* <span style="color:orange;">ALB or Application Load Balancer</span> is a flexible application management load balancing that operated at application Layer 7. (HTTP and HTTPS). 
* <span style="color:orange;">NLB or Network Load Balancer</span> is an extreme performance and static IP load balancing that operates at transport Layer 4. (TCP or UDP). 
* <span style="color:orange;">GLW or Gateway Load Balancer</span> is a flexible application management advanced load balancing of traffic that operates at network layer 3 (IP). 

| Features                    | ALB | NLB | GLB |
| --------------------------- | --- | --- | --- |
| health checks               | YES | YES | YES |
| CloudWatch metrics          | YES | YES | YES |
| Logging                     | YES | YES | YES |
| SSL offloading              | YES | YES |     |
| Connection draining         | YES | YES | YES |
| Preserve source IP address  | YES | YES | YES |
| Static IP addresses         | --  | YES |     |
| Lambda functions as targets | YES |     |     |
| Redirects                   | YES |     |     |
| Fixed response actions      | YES |     |     |

The components for a Load Balancer are: 

* <span style="color:DodgerBlue;">Listener</span>: entry point of the load balancer, where it will be listening for requests at the IP of the load balancer. 
* <span style="color:DodgerBlue;">Target Group</span>. groups of instances or resources where it fill forward the requests using an specified protocol and port. 


#### AWS Auto scaling

AWS Autoscaling monitors an application and automatically adjust the resources and capacity to 
maintain performance at lowest possible cost. 

It can be used with EC2, Spot Fleet, Amazon DynamoDB, Amazon Aurora and many other services. 

Automatically redirects the traffic and balance it between the different autoescaled instances. 

##### AWS EC2 Autoscaling

With EC2 autoscaling, you can build scaling plans in order to automate how groups of different EC2 resources respond to changes in demand. 

This policies set up how EC2 Autoscaling can launch and terminate instances on demand as the demand increases or decreases. 

The traffic distribution between all the machines in the autoscaling group is handled with an ELB, allowing you to provision more ELBs of other types before it. 

It has three main components: 

* Launch templates: What resources do you need? 
* Amazon EC2 auto scaling group: Where and how many do you need?  
* Autoscaling policy: when and for how long do you need them.? 

The **group** is a collection of the machines that autoscale and are defined by a minimum and maximum number of instances and a desired state.

##### Launch Template

A Launch Template includes the parameters required to launch an EC2 in response to a scaling change in the EC2 autoscaling group. 

It define parameters such as AMI and instance type. 

Also Launch configuration you must specify information about other parameters such as key pair, security groups, block device mapping and others. This parameters can also be taken from an existing EC2 instance. 