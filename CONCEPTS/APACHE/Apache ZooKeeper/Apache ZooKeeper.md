#APACHE 

# Apache ZooKeeper

**Apache ZooKeeper** is an open-source **distributed coordination service**. It doesn't store application data itself — instead, it provides the primitives distributed systems need to stay coordinated: configuration management, naming, distributed locks, and leader election.

Historically, ZooKeeper was the coordination backbone for much of the Hadoop ecosystem, including older versions of [[Apache Kafka]] and [[Apache Hadoop]] (HDFS High Availability, YARN).

## What it provides

* **A shared hierarchical namespace**: similar to a filesystem, made of nodes called **znodes**, each able to store a small amount of data.
* **Leader election**: helps a cluster of nodes agree on which one is the "leader" at any given time (e.g. which Kafka broker is the controller).
* **Configuration management**: a central place to store and watch for changes in shared configuration.
* **Distributed locks**: coordinate access to a shared resource across multiple machines.
* **Group membership / service discovery**: track which nodes in a cluster are currently alive.

## How it works

A ZooKeeper deployment runs as a cluster of servers called an **ensemble**, using a consensus protocol (**ZAB**, ZooKeeper Atomic Broadcast) to keep all servers' state consistent. As long as a **majority** (quorum) of the ensemble is up, the service keeps working — this is why ZooKeeper ensembles are deployed with an odd number of nodes (3, 5...).

Clients can **watch** a znode: instead of polling, they get notified the moment its data changes, which is what makes ZooKeeper efficient for things like leader election and configuration propagation.

## Kafka and ZooKeeper

Kafka historically relied on ZooKeeper to store cluster metadata, elect the **controller** broker, and track partition leaders. Newer Kafka versions replace this with **KRaft**, a consensus protocol built directly into Kafka, removing the operational overhead of running a separate ZooKeeper ensemble. See [[Apache Kafka]].

## Use cases

* Coordinating leader election and metadata in distributed systems (historically Kafka, HBase).
* Centralized, watchable configuration shared across a cluster.
* Distributed locking to prevent conflicting operations across nodes.

## Related

* [[Apache Kafka]] — its original primary consumer for cluster coordination.
* [[Apache Hadoop]] — uses ZooKeeper for HDFS/YARN high-availability coordination.
