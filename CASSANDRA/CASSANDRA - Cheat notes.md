#DATABASES #CASSANDRA

### CASANDRA NOTES

Create a <span style="color:MediumSlateBlue;">keyspace</span>: 

```cassandra
create keyspace <keyspace_name> with replication={'class':'<strategy_name>', 'replication_factor': <replication_number>}; 

// Example
create keyspace university_logs with replication={'class':'SimpleStrategy', 'replication_factor':3}; 
```

Replication define the number of nodes in the cluster  and replication factor is the strategy to place replicas in the ring. 


#### CHECK CREATED KEYSPACES

```cassandra
describe keyspaces;
```

#### USE CREATED KEYSPACE

```cassandra
use <keyspace_name>; 
```

#### CREATE TABLE

Similar to an SQL and need to define the primary key by specifying the "rows" of the table

```cassandra
> create table <table_name> (<data_row_name> <data_type>, ..., primary key(<data_row_name) ); 

// Example: 

> create table error_logs(location int, number_error int, type_error text, description text, time_error timestamp, primary key(location, type_error));
```

#### SELECT

We can select data from an existing table: 

```cassandra
> select * from <table_name>; 

// Example: 

> select * from error_logs; 


 location |   type_error  | description | number_error | time_error
----------+---------------+-------------+--------------+-------------------------
        1 |  acess_denied | ...         |            1 | 2024-03-24 10:00:00+0000

```

#### INSERT 

We can insert using a SQL-like syntax, data into a created table:

```cassandra


// Example: 

> insert into error_logs(location, number_error, type_error, time_error) VALUES(2, 1, 'access_denied', '2024-04-15 17:38:00'); 

> select * from error_logs; 

 location | type_error    | description | number_error | time_error
----------+---------------+-------------+--------------+--------------------------
        2 | access_denied |        null |            1 | 2024-04-15 15:38:00+0000
```

### CONDITIONAL SELECT

We can select data from a table and filter the select with a condition, similar to SQL. 

```select * from <table_name> where <condition> [allow filtering];```

```cassandra
> select * from error_logs where location=2;

 location | type_error    | description | number_error | time_error
----------+---------------+-------------+--------------+-------------------------
        2 | access_denied |        null |            1 | 2024-04-15 15:38:00+0000


> select * from error_logs where location=3; 

 location | type_error | description | number_error | time_error
----------+------------+-------------+--------------+------------

```

Concatenate conditions: 

```select * from <table_name> where <condition1> and <condition2> [allow filtering];```

```
> select * from error_logs where location=2 and type_error='access_denied';

location | type_error    | description | number_error | time_error
---------+---------------+-------------+--------------+-------------------------
       2 | access_denied |        null |            1 | 2024-04-15 15:38:00+0000

```

