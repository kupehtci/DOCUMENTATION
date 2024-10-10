#REDIS #DATABASES #INFORMATION_TECHNOLOGIES 

## REDIS Query optimization

Redis by itself doesn't have query optimization like in PostgreSQL[^1]

Redis stores its information within the Device RAM but can be saved as a file and restored when launching the database

Taking into account that REDIS is a key-value NoSQL database, the queries are not as complex as a relational database with foreign keys could be. 

There are some optimization tips: 

* Use appropriate data structures (hash, sets, single, etc)
* Minimize data transfer
* Use efficient commands
* Avoid expensive operations
* Optimize data serialization
* Use caching
* Optimize memory usage
* Use of hashes for memory optimization

### Query cache

There are two different types of cache usage in redis: 

* <span style="color:MediumSlateBlue;">Cache prefetching</span> is pre-store in cache common queries
* <span style="color:MediumSlateBlue;">Cache-aside</span> consist in dynamically fill the cache like a Cache miss or Cache hit, similar to Cache L1, L2 and L3 of dynamically memory read. 

It has a <span style="color:orange;">benchmark</span> to test performance over Redis operations

### Pipelining

Pipeline is a technique in Redis that allows the client to send multiple commands within a single request. 

This reduces the time of waiting the server to respond with each command individually in order to send the next one.


[^1]: PostgreSQL and other relational databases query optimization in SQL technologies [[Query Optimization]]