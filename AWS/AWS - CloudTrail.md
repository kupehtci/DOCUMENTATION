#AWS 

# AWS - CloudTrail

**AWS CloudTrail** its an fully managed service that records account-level activity and store it as logs. 

It records events (Who did what, when, from where and on which resource) for auditing, security and operational troubleshooting. 

# How its the data shown or delivered? 

The data captured by CloudTrail is delivered in different ways: 
* **Trails**: configure pipelines that deliver logs to: 
	* Amazon S3 [^1]
	* CloudWatch logs [ˆ2]
	* Event Bridge [^3]
* **Console event history**: you can view the last 90 days of events without using trails. 

Use trails for long-term (more than 90 days) retention. 

# Integrations

CloudTrail can be integrated with other services: 

* Configuring a **trail** to stream data into an S3[^1], you can query logs using **Amazon Athena**[^4] using SQL queries.
 

# Organization-wide

You can turn on **organization-wide** or **multi-region** trail to have a complete coverage of the whole organization events and stream that into a central S3 storage. 



## Use cases

CloudTrail is mostly used for: 

* Compliance and security
* Troubleshooting
* Analytics. 

[^1]: S3 or Simple Storage Service [[AWS - S3]]
[^2]: CloudWatch [[AWS - Cloudwatch]]
[^3]: Event Bridge [[AWS - EventBridge]]
[^4]: Amazon Athena allow to make SQL queries to an S3 or other resources through connectors. [[AWS - Athena]]