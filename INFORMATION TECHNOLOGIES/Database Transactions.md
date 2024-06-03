#DATABASES 

### Transaction

A transaction is a logical unit of work that is performed as a single, indivisible operation. 
The set of operations are only correctly done if all of them take place correctly. 

This ensures the integrity of the database within a multiuser system, because transactions are done for each user and won't be harm during other user execution. 

### Code

When doing `END`, has double action, Commit and End, so all commands done in the transaction are propagated into the database

In PostgreSQL: 

```PostgreSQL
BEGIN; 
INSERT INTO Professors(Name, snn) VALUES ("David", 13)
END; 
```

When a transaction leads into an error, cannot go back to the transaction declaration. Needs to go to a `ROLBACK` to undo the possible errors propagated to the database caught by the transaction. 