#GCP 

# GCP Compute instances

Google Compute instances are Virtual machines hosted in Google Cloud infrastructure. 
This instances can be created manually or managed by a Group of Managed instances or MIG. 

This  images can run public images (Linux and Windows) that google provides, custom private images or even Docker containers by using the <span style="color:DodgerBlue;">Container-optimized OS public image</span>. 

The properties of a Compute Instance such as number of virtual CPUs and the amount of memory can be set using the **predefined machine types** or **creating a custom VM type**. 

### Managed Instances Group or MIG

A MIG is a group of virtual machine instances that can be treated and managed as a single entity. 

Its based on a <span style="color:DodgerBlue;">instance template</span> that defines the VM properties for all the VMs deployed and managed by the MIG.

