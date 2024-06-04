#CONCEPTS #DATABASES #INFORMATION_TECHNOLOGIES 

# SHARDING

<span style="color:IndianRed;">Sharding</span> is the method of dividing a database into multiple <span style="color:DodgerBlue">fragments or shards</span>. 

Each of this <span style="color:DodgerBlue">shards</span> contains a part of the database and are allocated within different servers. 

Its also known as <span style="color:Salmon;">horizontal partitioning</span> because is the same as partitioning the data by rows in a table. 

Its not the same as <span style="color:Salmon">Replication</span>, because each shard its a slice of the whole database and don't share data with other shards. 

# Replication

<span style="color:IndianRed">Replication</span> is the method of keeping an updated copy of the data within different servers. 

In order to keep a <span style="color:LightBlue;">consistency between databases</span>, the replication needs to be carefully designed in order to keep the different databases synchronized. 

Can have various systems: 

* <span style="color:DodgerBlue;">Master-slave replication</span>: a master that allows read-write with a replicated slave that is read-only. 
* <span style="color:DodgerBlue;">Master-master replication</span>: two masters allows read-write and synchronize the data between them. 

Also the volume of data replicated can differ: 

* <span style="color:SkyBlue;">Full replication</span>: the row or the table is stored at all sites
* <span style="color:SkyBlue;">Fully redundant</span>: the whole database is stored at all sites. 

<span style="color:green;">ADVANTAGES</span>

* Availability: data is available in several servers.
* Parallelism: queries can be processed by various nodes at the same time. 
* Reduce data transfer: data is available locally at each site. 

<span style="color:red;">DISADVANTAGES</span>

* Increase cost of updates
* Increase complexity of concurrency control


## COMPARISON

PURPOSE

Sharding focuses in horizontal partitioning for improve scalability. 
Replication focus in creating redundant copies to improve fault tolerance and availability. 

QUERY HANDLING 

Sharding needs an special query distribution, routing the query to the appropriate server that holds the requested data. 
Partition doesn't need special queries handling. 

FAULT TOLERANCE

Partition provides fault tolerance when server fails or gets corrupted while sharding may have a single point of failure when one of the shards distributed fail. 

