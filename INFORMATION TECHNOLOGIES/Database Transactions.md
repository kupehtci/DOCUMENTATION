#DATABASES 



When doing `END`, has double action, Commit and End, so all commands done in the transaction are propagated into the database

In PostgreSQL: 

```PostgreSQL
BEGIN; 
INSERT INTO Professors(Name, snn) VALUES ("David", 13)
END; 
```

When a transaction leads into an error, cannot go back to the transaction declaration. Needs to go to a `ROLBACK` to undo the possible errors propagated to the database caught by the transaction. 