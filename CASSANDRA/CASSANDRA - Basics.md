#DATABASES #CASSANDRA 

Installable in any platform but with no official support for windows builds. 

Has not a graphical interface, so require using the command line

Cassandra provided Cassandra Query Language (CQL), that is similar to SQL. 

Is linearly scalable, can scale by only adding more nodes to the cluster. 


### CASSANDRA NODES


When creating a keyspace with a replication factor, we define the number of nodes and the strategy to split the data between the different nodes. 

If we choose `SimpleStrategy` would link the different nodes in a circular way. 





As you can see from the previous questions, Cassandra is not designed to execute read queries efficiently (without ALLOW FILTERING). In fact, Cassandra's strong point is writing, and Cassandra should be used when the insertion rate is much higher than the reading rate.


### TABLES

There are two types of columns: 

* <span style="color:DodgerBlue;">Partition key columns</span>: first part of a primary key and they spread data around a cluster. Depending on this value, will be placed in a different cluster. 
* <span style="color:DeepSkyBlue;">Clustering columns</span>: rest of the keys that conform the primary key. Used to cluster the data in a partition and allow a very efficient retrieval of the rows. 

```txt 
Example: 

If we save a University degrees in a database with the following attributes: 
UniState, Degree and name we can conform the primary key with PK(UniState, Degree). UniState will be used to distribute the data along the different state clusters and degree as clustering column to help data retreival. 

|------------------|----------|--------|------------------|
| PRIMARY KEY      | UniState | Degree | Name             |
| ---------------- | -------- | ------ | ---------------- |
| ZGZ, 001         | ZGZ      | 001    | Computer Science |
|------------------|----------|--------|------------------|
```

Take into account that, when <span style="color:Salmon;">filtering</span> with a WHERE clause, we can only restrict following the PK order. We cannot restrict Degree without restricting UniState. 
