#DATABASES 

## Concurrency control protocols

There are some protocols to prevent concurrency problems in a multiuser database: 

### <span style="color:DodgerBlue; background-color:SeaShell; border-radius:0.5rem;padding:0.3rem;">Database locking</span>

Only one transaction has access to a certain part of the database at a time. 

This locking can be done at different <span style="color:MediumSlateBlue;">levels of granularity</span>: 

* Database level: blocks the entire database
* Table level: blocks the table 
* Page level: when performing an <span style="color:orange;">UNION</span> when performing a select, this set of tables is readed in a "virtual" table named as <span style="color:orange;">page</span>. 
* Row level: blocks a single row in the database. 
* Field level: blocks a single field in the database. 
### <span style="color:DodgerBlue; background-color:SeaShell; border-radius:0.5rem;padding:0.3rem;">Time-Stamp Based protocol</span>

Each transaction is issued a timestamp when it enters the system. 

The protocol manages concurrent execution such that the time-stamps determine the serialization order. 


### <span style="color:LightSeaGreen;">ISOLATION LEVELS</span>

Isolation levels are designed to balance the need of concurrency and performance with the levels of consistency and accuracy. 

There are 5 levels of isolation: 

* `Read uncommitted`: transactions are not necessary to lock rows before reading or writing data. 
* `Read committed`: transactions needs for a row t be committed before reading it. Transactions locks the table rows. 
* `Repeatable read`: any reading transaction blocks any other writing transaction from accessing the same row. Each insert, update or delete. 
* `Serializable`: 
* Snapshot

Different isolation levels and the concurrency problems: 

| Isolation Level  | Dirty Read      | Nonpeatable Read | Phantom Read    | Serialization Anomaly |
| ---------------- | --------------- | ---------------- | --------------- | --------------------- |
| Read uncommitted | Allowed (No PG) | Possible         | Possible        | Possible              |
| Read commited    | Not Possible    | Possible         | Possible        | Possible              |
| Repeatable Read  | Not Possible    | Not Possible     | Allowed (No PG) | Possible              |
| Seriazable       | Not Possible    | Not Possible     | Not Possible    | Not Possible          |


### CODE

Transactions can be defined with a level of isolation using the following code in postgreSQL: 

```PostgreSQL
BEGIN TRANSACTION ISOLATIONN LEVEL <isolation_level_name>
```

#### Why not use serializable always? 

Why not use the maximum isolation level (Serializable) because a serialize schedule [[Concurrency Control Schedules]] will make a huge slow down in the queries because until a transaction is ended or a read, write sequence is finished, the other transactions cannot perform data operations. 




