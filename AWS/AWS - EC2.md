#AWS 

# AWS EC2

The EC2 or Elastic Cloud Compute is a virtual server within the AWS cloud. 

Its highly scalable.  

There are various types of EC2 instances depending on computing, memory or storage need:

* **General purpose instance**: This instance balances between computing, memory and networking resources. 
* **Compute optimized instance**: This instances are the best for a high compute. 
Good for application servers, gaming servers and web applications. 

* **Memory optimized instance**: This type can deliver large dataset workloads faster for temporary storage area. 
It allows to load from storage, hold the data and processes before compute it. 
It enables to pre-load a computer program and give the CPU whole access to it.

* **Accelerated computing instances**: Use hardware accelerators to boost data processing. 
Its the best for graphics applications and streaming. 

* **Storage optimized instances**: This type is the best for large dataset within the instance. Optimized for large file systems, data warehouses and online transaction systems. 

* **Nitro-based instances**: virtualization with near to bare metal performance and strong isolation. 
	* Has bare metal functionalities like access to underlying hardware for special workloads or licensing needs. 
	* EBS Multi-attach is only available in this type of instances in io1 and io2 volume types

### EC2 scalability

This AWS resource is scalable, meaning that you only pay for the resources that you need and has flexibility to grow freely.

<span style="color:orange;">Auto-scaling</span> can be added as a buffer on top of the instances by setting a minimum and maximum capacity of instances that will be running. 
It handles automatic scaling groups to scale between this min and max

The <span style="color:orange;">auto scaling</span> enabled to process more requests that one only instance can handle by adding or removing EC2 instances automatically. 

- Dynamic scaling: responds to the variable demand
- Predictive scaling: schedules the scaling based on a predictive demand. 

Both scaling options can be combined to be able to respond faster to the changed in demand. 

## Types of EC2 in terms of costs

There are different types of EC2 machines in terms of costs and flexibility: 

* **On-Demand Instances**: Regular EC2 instances that you can launch and pay by second or hour. Recommended for short-term or when workload is unpredictable. 
	* Full flexibility as you can start and stop anytime. 
	* No upfront cost. 
	* Immediate capacity

* **Reserved instances (savings plan)**: You purchase an specific instance type for 1 - 3 years in exchange for an significan discount (Up to 70%) compared to on-Demand.  
	* For steady and predictable workloads (Applications always-on or backend services)
	* Used for baseline capacity (24/7)
	* Less flexibility as you cannot change machine and you also pay when its off. 

* **Spot instances**: unused AWS capacity offered with up to 90% discount but AWS can reclaim the capacity with a 2 minute notice. 
	* Use them with interruption-tolerant workloads
		* Normally for batch processing, CI/CD, data analytics, machine learning training and similar.
	* Its extremely cheap compared to On-Demand instances
	* The capacity and runtime is not guaranteed. 

* **Reserved instances and Savings Plan**: 
	* Agreement on 1 to 3 years of an EC2 usage in exchange of great discounts. 
	* Similar characteristics as On-Demand. 
	* Recommended for high utilization. 


Once a Savings plan has been purchased it will automatically apply across the entire AWS Organization if: 
* Accounts are int the same Organization including the account that bought the savings plan. 
* **Discount sharing is enabled**. 