#DATABASES 

### NO-SQL DATABASES

Are databases that store data in a format other than relational tables. 

It allows to have different schema for same data instances, so have a <span style="color:orange;">flexible schema</span>. 
This allows the database to be easily adapted in order to waterfall project planifications. 

Also they provide more <span style="color:orange;">scalability</span> because are designed to scale horizontally using **distributed clusters**. 

Have <span style="color:IndianRed;">high performance</span> compared to SQL databases because are optimized for data models or specific data access patterns. 

Can store multiple variable data types because of their <span style="color:DodgerBlue;">high functionality</span> of having strong APIs for data manage and more data types. 

Also can be distributed between distributed structures of data replicated, allowing a <span style="color:MediumSlateBlue;">high availiability</span>. 

### 📈 PROS

* <span style="color:Salmon;">Flexibility</span>
	Easily to adapt to a project more than Entity-Relationship models

* <span style="color:Salmon;">Horizontal Scalability</span>
	Scale in number of servers, not in server consumption

* <span style="color:Salmon;">Performance</span>:
	Supports <span style="color:IndianRed;">query optimization</span> for large amounts of data. 

* <span style="color:Salmon;">High availability</span>: 
	Support distributed structures with data replicated. This replication minimizes latency. 

### 📉 DRAWBACKS

* <span style="color:Salmon;">Non-Compatibility with SQL</span>: 
	No-SQL databases has their own characteristics and not are always compatible with relational databases. 

* <span style="color:Salmon;">Lack of estandarization</span>
	There are so many NO-SQLs technologies and each one has their own usage. 
	
* <span style="color:Salmon;">Multiplatform support</span>
	Most of No-SQL databases are only prepared for Linux, not being multiplatform. 

* <span style="color:Salmon;">Eventual consistency</span>
	No all NoSQL consider atomicity and integrity of the data. 

* <span style="color:Salmon;">Access control</span>
	Different views [^views] or different access capabilities can not easily or even restricted in different no-SQL technologies. 
 
### IMPORTANT TYPES

There are 4 forms of storing No-SQL data: 

* Document `MongoDB`
	Data is stored as semi-structured documents, such as XML or JSON and can be queried as this
	
* Key-Value `Redis` and `DynamoDB`
	The data is stored as <span style="color:IndianRed;">tuples</span> or Key and a value, optimized for sim. le and fast read operations

* Wide-Column `Cassandra` and `HBase`
	Stored data as columns families and each one of them is considered as an entity. Optimized for large amount of data. 
	
* Graph `Neo4j` and `Memgraph`
	Stores data as nodes and edges and can handle easily complex relationships between data. 

![[types_nosql.png]]

##### TECHNOLOGIES COMPARISON

| Feature                 | MongoDB                                 | Redis                                      | Cassandra                                                   | Neo4j                                   |
| ----------------------- | --------------------------------------- | ------------------------------------------ | ----------------------------------------------------------- | --------------------------------------- |
| **Type**                | Document                                | Key-value                                  | Wide-column                                                 | Graph                                   |
| **Orientation**         | Flexibility                             | Performance and fast                       | Distributed data per nodes. High availability               | Relationships between data              |
| **Platform**            | Any                                     | Any (No windows builds)                    | Any (No windows builds)                                     | Any                                     |
| **GUI**                 | Yes                                     | No                                         | No                                                          | Yes                                     |
| **Data Model**          | JSON-like documents                     | Key-value pairs                            | Column families                                             | Labeled property graph                  |
| **Query Language**      | MongoDB Query Language (MQL)            | Redis commands and data types              | CQL (Cassandra Query Language)                              | Cypher Query Language                   |
| **Consistency**         | Strong                                  | Strong                                     | Eventual consistency                                        | Strong, ACID transactions               |
| **CAP**                 | CP                                      | CP                                         | AP                                                          | CA                                      |
| **Partition Tolerance** | Shard                                   | Shard                                      | Shard                                                       | No                                      |
| **Availability**        | Eventual                                | Eventual                                   | Always                                                      | Always                                  |
| **Scalability**         | Horizontally scalable                   | Horizontally scalable                      | Horizontally scalable                                       | Vertical scalable                       |
| **ACID**                | Yes                                     | No                                         | No                                                          | Yes                                     |
| **FK**                  | Reference                               | No                                         | No                                                          | Relations                               |
| **Transactions**        | Yes                                     | Serial                                     | No                                                          | Yes                                     |
| **Query Optimization**  | Yes                                     | No, only pipelining                        |                                                             |                                         |
| **Durability**          | Configurable                            | Non-persistent                             | Configurable                                                | Configurable                            |
| **Use Cases**           | Content Management, Real-time Analytics | Caching, Pub/Sub messaging, Session store, | Time Series Data (Health tracker), IoT, Distributed systems | Social networks, Recommendation engines |


---

[^views]:  [[Views]]