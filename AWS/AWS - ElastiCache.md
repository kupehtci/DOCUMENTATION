#AWS 

# AWS - ElastiCache

**AWS ElastiCache** is a fully managed in-memory caching service that lets you deploy and operate Redis or Memcached clusters in AWS. 

The main purpose of this type of cache is to improve application performance by reducing load on database / APIs, delivering microsecond to milisecond latency. 

There are two different cache engines: 

* **Redis**: rich features like persistence, replication, clustering, pub/sub and streams. 
* **Memcached**: simple, lightweight and multi-threaded cache. 

The main key features of having an ElastiCache are: 
* **Offload frequently accessed data** from slower storage solutions like RDS, DynamoDB or S3. 
* **Lower Latency** and reduce DB query costs.
* Scaled horizontally with **cluster mode**. 
* Built-in **high-availability** (multi-AZ failover in Redis). 
* Integrated with monitoring using **CloudWatch** [^1]. 

### Caching strategies

When using cache like ElastiCache there are some common patterns of handling the cache: 

##### Cache-Aside or Lazy Loading

Application firstly checks the cache, if data is cached return it, otherwise is a cache miss and fetch it from the database, write into cache and return it. 

##### Write-Through

Every write to the DB is also written into the cache at the same time, so cache is always up-to-date with the DB.

It has higher latency for writes (As need to write in two different places). 
Cache may contain unused data. 

##### Write-Around

Writes go only to the DB and cache is populated on demand (like cache-aside). 
Avoids filling the Cache with rarely used data but the first read is always slower (cache miss). 

##### Refresh / TTL (time-to-live)

Cached items expire after a set TTL (Time-to-live). 
Ensures that data is not stored for too long. 

Gives a balance between performance and freshness and return a cache miss over expired items retrieval. 

The con is that might evict data that still useful because it has expired, causing more cache misses. 

### Notes about caching

If the data requests are predictable and has high-read workloads -> use cache-aside
If must keep cache updated immediately and has consistency between DB and Cache -> use write-through
If cache space is expensive and data is rarely used -> use write-around. 

**ElastiCache for Redis** supports persistence, clustering, replication, pub/sub so often is more useful when real-time analytics or session management is needed. 

**ElastiCache for Memcached** is more simple and stateless so its bettwer for simple caching without persistence. 



[^1]: AWS CloudWatch is a service for monitoring the cloud: [[AWS - Cloudwatch]]