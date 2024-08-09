#PostgreSQL 


Drop can be use to delete or 'drop' certain SQL elements: 

* database
* table

#### DELETE A DATABASE

You can also delete the entire database just by using `DROP` statement. 

#### DELETE A TABLE


You can delete a table by using `DROP` statement: 

```PostgreSQL
DROP TABLE [IF EXISTS] <table_name> [CASCADE | RESTRICT]
```

Example to drop the users table: 

```PostgreSQL
DROP TABLE IF EXISTS Users; 
```


* `RESTRICT`: is a guard, that blocks the drop if any objects in the database depend from this table
* `CASCADE`: 