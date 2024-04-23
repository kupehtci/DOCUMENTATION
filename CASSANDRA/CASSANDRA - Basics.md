#DATABASES #CASSANDRA 

Installable in any platform but with no official support for windows builds. 

Has not a graphical interface, so require using the command line

Cassandra provided Cassandra Query Language (CQL), that is similar to SQL. 

Is linearly scalable, can scale by only adding more nodes to the cluster. 


### CASSANDRA NODES


When creating a keyspace with a replication factor, we define the number of nodes and the strategy to split the data between the different nodes. 

If we choose `SimpleStrategy` would link the different nodes in a circular way. 





As you can see from the previous questions, Cassandra is not designed to execute read queries efficiently (without ALLOW FILTERING). In fact, Cassandra's strong point is writing, and Cassandra should be used when the insertion rate is much higher than the reading rate.
