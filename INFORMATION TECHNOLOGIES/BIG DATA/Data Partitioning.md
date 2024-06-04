#BIGDATA 

### Data partitioning

Partitioning is dividing the stored database objects (tables, indexes, views) in order to separate parts. 

This is made in order to: 

* <span style="color:DodgerBlue;">Improve performance</span>: operations take over smaller volumes of data
* <span style="color:DodgerBlue;">Improve scalability</span>: when database reaches its limit, data can be splitted into different shards. 
* <span style="color:DodgerBlue;">Improve security</span>: sensitive and non sensitive data can be separated 
* <span style="color:DodgerBlue;">Improve availability</span>: available in different servers the other partitions

### Types of partitioning

There are various types of data partitioning: 

* Vertical partitioning: division into independent parts. From a table, create a relation independent table. 
* Horizontal partitioning: separate rows of the database. 

![[a0018b6a-0e64-4dc6-a389-0cd77a5fa7b8_1999x1837.jpg]]

Relational databases only supports vertical partitioning and No-SQL technologies normally support both. 
