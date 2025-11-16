#AWS 

# AWS - AutoScaling Groups

**AutoScaling groups** 


# Scaling Options

* **Maintain**: keeps the group at its desired capacity, replacing unhealthy instances automatically
	* Doesn't require metrics. 
* **Manual**: You adjust the desired, min and max via console or CLI. 
* **Scheduled scaling**: Changes min, max and desired at specific times via like a cron. 
	* Great for predictable patterns like weekdays. 
* **Predictive scaling**: uses historical patterns for forecasting and pre-provision capacity before the demand arrives. 
* **Dynamic scaling**: Reacts to live metrics to scale up and down automatically: 
	* **Target Tracking capacity**: keeps a metric near a target like AverageCPU or RequestCountPerTarget at a certain value and scales up or down to keep that metric. 
	* **Step Scaling**: Uses CloudWatch alarms with step adjustments and different breach sizes trigger different scale actions like: +1 instance if 60% $\ge$ CPU, +2 instances if CPU $\ge$ 75%
	* **Simple scaling**: one alarm triggers a fixed scale action and applies a threshold until re-evaluate again. 

