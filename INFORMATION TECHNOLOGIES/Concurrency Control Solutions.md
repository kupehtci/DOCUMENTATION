#DATABASES 

## Concurrency control protocols

There are some protocols to prevent concurrency problems in a multiuser database: 

### <span style="color:#A8F9E3;">Database locking</span>

Only one transaction has access to a certain part of the database at a time. 

This locking can be done at different <span style="color:MediumSlateBlue;">levels of granularity</span>: 

* Database level: blocks the entire database
* Table level: blocks the table 
* Page level: when performing an <span style="color:orange;">UNION</span> when performing a select, this set of tables is readed in a "virtual" table named as <span style="color:orange;">page</span>. 
* Row level: blocks a single row in the database. 
* Field level: blocks a single field in the database. 
### <span style="color:#A8F9E3;">Time-Stamp Based protocol</span>

Each transaction is issued a timestamp when it enters the system. 

The protocol manages concurrent execution such that the time-stamps determine the serialization order. 



### CODE


```PostgreSQL
BEGIN TRANSACTION ISOLATIONN LEVEL <isolation_level_name>
```

Different isolation levels: 

| Isolation Level  | Dirty Read      | Nonpeatable Read | Phantom Read    | Serialization Anomaly |
| ---------------- | --------------- | ---------------- | --------------- | --------------------- |
| Read uncommitted | Allowed (No PG) | Possible         | Possible        | Possible              |
| Read commited    | Not Possible    | Possible         | Possible        | Possible              |
| Repeatable Read  | Not Possible    | Not Possible     | Allowed (No PG) | Possible              |
| Seriazable       | Not Possible    | Not Possible     | Not Possible    | Not Possible          |

Why not use the maximum isolation level (Serializable) because a serialize schedule [[Concurrency Control Schedules]] will make a huge slow down in the queries because until a transaction is ended or a read, write sequence is finished, the other transactions cannot perform data operations. 




