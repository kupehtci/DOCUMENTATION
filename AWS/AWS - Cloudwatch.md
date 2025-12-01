#AWS #CLOUD

# AWS Cloudwatch

%%TODO%%


# Alarms

A CloudWatch alarm is a monitoring utility that monitor an specific metric and triggers actions when the metric crosses a defined threshold. 

Its used for automate responses to certain detected operational issues

An alarm can have three different states: 
* <span style="color:green;">OK</span>: metric is in a normal range
* <span style="color:Crimson;">ALARM</span>: metric has exceeded the threshold
* <span style="color:orange;">INSUFFICIENT_DATA</span>: doesn't have enough data to determine the state
## Actions

When an alarm transitions into an specific state it can trigger predefined actions like: 

* **EC2 actions**: 
	* Recover the instance
	* Stop the instance
	* Terminate the instance
	* Reboot the instance
* **SNS Notifications**: send messages to an SNS topic. It can be integrated with email, SMS or other subscribers. 
* **Auto scaling actions**: scale up or down an auto scaling group. 

To run other custom actions you can attach the actions to an SNS topic with an AWS Lambda [^1] subscriptor that will run custom code. 

# Cloudwatch dashboard

An Amazon Cloudwatch dashboard is a custom interactive display that allows to visualize metrics and logs from multiple AWS Services. 
## Sharing

You can share Dashboards directly without creating a proper IAM User, just by creating a **shareable URL**: 
* Makes the dashboard publicly available to anyone with the URL without AWS Login
* Viewers has **read-only access**.
* Usefull for sharing management reports or public status pages to people without IAM management permissions or AWS users. 
 

## Composite alarms

%%TODO%%

# CloudWatch Synthetics Canaries

**CloudWatch Synthetics Canaries** are configurable scripts that run on a schedule to proactively monitor an endpoint, API and web applications. 

This scritps simulate a real customer behaviour interacting with a web application or an API. 

This helps to check correct behavior of the WEB or API and measures load time and take screenshots of the UI. 
Also tracks in the case of APIs, http status codes, response times and error rates. 



[^1]: AWS Lambda [[AWS - Lambda]]