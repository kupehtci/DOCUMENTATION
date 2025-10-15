#AWS 

# AWS EC2

The EC2 or Elastic Cloud Compute is a virtual server within the AWS cloud. 

Its highly scalable.  

There are various types of EC2 instances depending on computing, memory or storage need:

* `General purpose instance`: This instance balances between computing, memory and networking resources. 
* `Compute optimized instance`: This instances are the best for a high compute. 
Good for application servers, gaming servers and web applications. 

* `Memory optimized instance`: This type can deliver large dataset workloads faster for temporary storage area. 
It allows to load from storage, hold the data and processes before compute it. 

It enables to pre-load a computer program and give the CPU whole access to it.

* `Accelerated computing instances`: Use hardware accelerators to boost data processing. 
Its the best for graphics applications and streaming. 

* `Storage optimized instances`: This type is the best for large dataset within the instance. Optimized for large file systems, data warehouses and online transaction systems. 


### EC2 scalability

This AWS resource is scalable, meaning that you only pay for the resources that you need and has flexibility to grow freely.

<span style="color:orange;">Auto-scaling</span> can be added as a buffer on top of the instances by setting a minimum and maximum capacity of instances that will be running. 
It handles automatic scaling groups to scale between this min and max

The <span style="color:orange;">auto scaling</span> enabled to process more requests that one only instance can handle by adding or removing EC2 instances automatically. 

- Dynamic scaling: responds to the variable demand
- Predictive scaling: schedules the scaling based on a predictive demand. 

Both scaling options can be combined to be able to respond faster to the changed in demand. 

