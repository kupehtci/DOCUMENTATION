#DATABASES 

### Transaction

A transaction is a logical unit of work that is performed as a single, indivisible operation. 
The set of operations are only correctly done if all of them take place correctly. 

This ensures the integrity of the database within a multiuser system, because transactions are done for each user and won't be harm during other user execution. 

Transactions need to meet ACID theorem; atomicity, consistency, isolation and durability[^1]. 

### Atomicity

The transactions set of queries needs to be done all completed or none of them. This will preserve its atomicity. 

This is done because each set of queries of a transaction do a part of a complex operation over the database.

```
For example, adding 100$ to a bank account. The operations are read, add 100 and write. If both of this operations are done without being isolated or one of them failed, we can lead into a consistency error. 
```
### Code

When doing `END`, has double action, Commit and End, so all commands done in the transaction are propagated into the database

In PostgreSQL: 

```PostgreSQL
BEGIN; c
INSERT INTO Professors(Name, snn) VALUES ("David", 13)
END; 
```

When a transaction leads into an error, cannot go back to the transaction declaration. Needs to go to a `ROLLBACK` to undo the possible errors propagated to the database caught by the transaction. 


[^1]: ACID theorem [[ACID]]