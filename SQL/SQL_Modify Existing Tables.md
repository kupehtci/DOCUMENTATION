#### MODIFY TABLES

Once the table has been created, each column can be modified, dropped or add new ones. 

As an example we have create a users table

```SQL 
CREATE TABLE Users(
	 id INT NOT NULL AUTO_INCREMENT PRIMARY KEY, 
	 name VARCHAR(32) NOT NULL, 
	 email VARCHAR(64) NOT NULL
)
```

If we want to add a new column we can `ALTER` the table. 

```SQL
ALTER TABLE Users
	ADD password VARCHAR(32) NOT NULL DEFAULT ""; 
```

Also `ALTER` can be used for drop a column. Take into consideration if this key / column has a foreign key associated in another table or in its table.

```SQL
ALTER TABLE Users
	DROP password; 
```