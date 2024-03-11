## SERIAL in PostgreSQL
#PostgreSQL

SERIAL is a pseudo-type in PostgreSQL. 
It works as an stored sequence in postgreSQL that auto increments by storing the next value to be assigned and when new instance is added, uses he new value stored in the sequence. 

In this case, by using serial assigns a `int` value with auto increment property. 

This means that each time a new instance is inserted, it gets assigned a new value following a sequence or incremented from the previous one used. 

```PostgreSQL
CREATE TABLE IF NOT EXISTS Users
(
	id serial,     -- Serial declaration of id primary key 
	name varchar(32) not null default "", 
	email varchar(32) not null default "", 
	PRIMARY KEY(id)
); 
```




