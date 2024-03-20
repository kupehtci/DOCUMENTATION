#DATABASES 

# TERMINOLOGIES

## Partitions or Shard

A vertical partition in SQL is divide data into two different tables separated

An horizontal partition is a <span style="color:orange;">shard</span> in No-SQL when you divide some data records into different databases

## SCALABILITY 

* **Vertical scaling** is increasing the properties of the same server or database
* **Horizontal scaling** is increasing the number of databases

## CAP THEOREM

CAP stand for Consistency, Availiability and partition tolerance (Shard tolerance)

This theorem says that a database can only guarantee two of this aspects. 

* Consistency: All clients see the same data at the same time
* Availability: System continues to operate even in in the presence of node failures
* Partition-Tolerance: The system continues to operate despite of network failures