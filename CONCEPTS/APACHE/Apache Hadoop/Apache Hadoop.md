#APACHE 

# Apache Hadoop

**Apache Hadoop** is an open-source framework for **distributed storage and processing** of very large datasets across clusters of commodity hardware. It was the foundation the modern big-data ecosystem was built on — [[Apache Hive]], [[Apache Spark]] and HBase all originated as ways to make Hadoop easier or faster to use.

Hadoop is made of three main components:

## HDFS (Hadoop Distributed File System)

The storage layer. Files are split into large **blocks** (traditionally 128 MB) and distributed across the machines (**DataNodes**) in the cluster, with each block **replicated** (commonly 3 times) to tolerate hardware failures. A **NameNode** keeps track of where each block lives, without storing the actual data itself.

This design lets Hadoop store petabytes of data cheaply by scaling out with more commodity machines, instead of scaling up with more expensive single servers.

## YARN (Yet Another Resource Negotiator)

The cluster **resource manager**. YARN allocates CPU and memory across the cluster to whichever processing framework is running — MapReduce, [[Apache Spark]], Flink, Tez — so multiple applications can share the same physical cluster.

## MapReduce

The original distributed processing model, splitting a job into two phases:

* **Map**: process each input record independently and emit key-value pairs.
* **Reduce**: group the emitted pairs by key and aggregate them.

```
Input → Map(record) → (key, value) → Shuffle & Sort by key → Reduce(key, values) → Output
```

MapReduce writes intermediate results to disk between the map and reduce phases, which makes it reliable but slow for iterative workloads — the main reason [[Apache Spark]] (in-memory processing) largely replaced it as the default execution engine.

## Use cases

* Cheap, durable, distributed storage for a data lake (HDFS), even when processing is done by other tools reading from it.
* Batch processing of very large datasets that don't fit on a single machine.
* Running a shared cluster (via YARN) for multiple processing frameworks.

In cloud environments, HDFS's role is now commonly replaced by object storage like Amazon S3, with tools like [[Apache Spark]] or [[Apache Hive]] reading directly from it instead of from a self-managed Hadoop cluster.

## Related

* [[Apache Hive]] — a SQL data warehouse layer built on top of Hadoop.
* [[Apache Spark]] — a faster, in-memory alternative to MapReduce that can still run on YARN and read from HDFS.
* [[AWS - S3 Select]] — a cloud object-storage equivalent that can replace HDFS as the storage layer.
