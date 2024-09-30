#GCP #DATABASES 

# GCP AlloyDB

AlloyDB is a **PostgreSQL**[^1] relational database fully managed by Google Cloud[^2]. 

It provides a highly availability, performance and scalable relational database technology that also combines Machine Learning-driven optimizations. 

The key features of the AlloyDB are: 

* Fully compatible with PostgreSQL: You can use all PostgreSQL features and libraries to manipulate it. 
* Highly availability: has automatic failover, backups and disaster recovery for ensuring that remain available in case of fails. 
* Scalability: It supports horizontal and vertical autoscaling. 
* Integrated with Google Cloud
* Fully managed: means that Google take care of patch, backups, replication, scaling and other operations. 


Take into account that for using AlloyDB you must enable its **API**. (`https://alloydb.googleapis.com`)


### Cluster

AlloyDB resources are created under a cluster, meaning that can be scaled the number of nodes of DB within the cluster.  

This can be configured to multi-node cluster or single-node cluster. 




[^1]: PostgreSQL [[PostgreSQL]]
[^2]: Google Cloud Platform [[GCP - Google Cloud Platform]]