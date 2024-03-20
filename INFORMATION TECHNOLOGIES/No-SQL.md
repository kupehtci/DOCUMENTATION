#DATABASES 

### NO-SQL DATABASES

Are databases that store data in a format other than relational tables. 

It allows to have different schema for same data instances, so have a <span style="color:orange;">flexible schema</span>. 
This allows the database to be easily adapted in order to waterfall project planifications. 

Also they provide more <span style="color:orange;">scalability</span> because are designed to scale horizontally using **distributed clusters**. 

Have <span style="color:orange;">high performance</span> compared to SQL databases because are optimized for data models or specific data access patterns. 

Can store multiple variable data types because of their <span style="color:orange;">high functionality</span> of having strong APIs for data manage and more data types. 

Also can be distributed between distributed structures of data replicated, allowing a <span style="color:orange;">high availiability</span>. 

### DRAWBACKS

* Eventual consistency

* Non-Compatibility with SQL
	no-SQL databases has their own characteristics and not are always compatible with relational databases. 

* Lack of standarization
	There are so many NO-SQLs technologies and each one has their own usage. 
	
* Multiplatform support
	Most of No-SQL databases are only prepared for Linux, not being multiplatform. 


### How they work

The No-SQL databases store multiple data models to access and administrate the data. 
Usually they are defined using JSON (Javascript Object Notation) [[JSON - BASICS]]. 

As in comparison with SQL databases: 

* A book is currently stored in a table with other values stored as this table attributes or other linked tables
* In No-SQL, this book data is stored as a document for each book record. 


### IMPORTANT TYPES

There are 4 forms of storing No-SQL data: 

* Document `MongoDB` 
	Data is stored as semi-structured documents, such as XML or JSON and can be queried as this
* Key-Value `Redis`
	The data is stored as tuples or Key and a value, optimized for simple and fast read operations
	 
* Wide-Column `Cassandra`
	Stored data as columns families and each one of them is considered as an entity. Optimized for large amount of data
* Graph `Neo4j`
	Stores data as nodes and edges and can handle easily complex relationships between data. 