#GCP 

# GCP Regions and zones

Google Cloud is organized into regions and zones. All the deployed resources within GCP must be in an specific region and will have high availability in that Region. 


It follows this enclosure format, where a region is a section of a Multi region and a zone is a part within a region: 
```
Multi-region --> Region --> Zone
```

Example: 

```
Europe --> europe-west2 --> (europe-west2-a, europe-west2-b, europe-west2-c)
```

Unlike AWS, each edge zone or zone, its not always a physical data center, but act at is. 


A <span style="color:orange;">Region</span> is a geographical area where RTT[^1] from one VM to another is less than 1ms. 
A <span style="color:DodgerBlue;">Zone</span> is a deployment area within a region isolated from others.


### Resources restrictions

While some core resources in GCP are global, meaning that the same resource can be accessed from anywhere, some other resources are constrained to a certain to a region or zone.

Global resources: 
* Images
* Snapshots
* VPC network
* Firewalls associated
* Routes and gateways

Regional resources:
* Static external IP addresses: IP addresses by its nature, depend on a geographical region. 
* Subnets. Each subnet reside in a certain region. 

Zone resources:
* Compute Instances (VMs)
* Persistent disks

This means that you can attach a disk to instances of the same zone but no cross-zones. On the other hand, images and snapshots are global resources, so we can use the same image resource in different zones. 

![[./IMAGES/gcp_disks_images.png]]

### Why use zones and regions

When an application is build for high availability and fault tolerance, the best practice is to distribute the resources across multiple zones and regions. 


[^1]: RTT or Round Trip Time [[RTT Time]]