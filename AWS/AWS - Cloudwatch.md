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


[^1]: AWS Lambda [[AWS - Lambda]]