#PostgreSQL 


### PostgreSQL Isolation level

The isolation level in PostgreSQL when starting a transaction [[Database Transactions]]  can be defined by specifying it at the start of the transaction. 

The different isolation levels [[Concurrency Control Solutions]] are used in order to prevent different concurrency problems that can happen when the database is being used simultaneously by various users. 

The syntax to begin a transaction with a isolation level is: 

```PostgreSQL
BEGIN TRANSACTION ISOLATION LEVEL <isolation_level_name>;
```

There are 3 different isolation levels in PostgreSQL: 

* `READ COMMITTED`
	A statement can only see rows committed before it began. This is the default.

* `REPEATABLE READ`
	All statements of the current transaction can only see rows committed before the first query or data-modification statement was executed in this transaction.

* `SERIALIZABLE`
	All statements of the current transaction can only see rows committed before the first query or data-modification statement was executed in this transaction. If a pattern of reads and writes among concurrent serializable transactions would create a situation which could not have occurred for any serial (one-at-a-time) execution of those transactions, one of them will be rolled back with a `serialization_failure` error.



