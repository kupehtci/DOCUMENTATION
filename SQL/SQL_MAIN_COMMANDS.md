#SQL #PHP 

### CREATE TABLE 

```SQL 
CREATE TABLE Users{
id NOT NULL AUTO_INCREMENT, 
name NOT NULL DEFAULT "default_name", 
username NOT NULL DEFAULT "default_username", 
created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP, 

}
``` 

Take into account the different **data-types** and their constraints. 
For `mariadb` data-types check the next notes: [[SQL_DATA_TYPES]]
### INSERTING ROWS

```SQL 
-- Insertion into a certain table and values
INSERT INTO Users(username, email password) VALUES("dlaplana", "dlaplana@gmail.com", 1234); 
```

## DELETING ROWS

```SQL 
DELETE FROM Users WHERE Users.id = 2; 
```

## DELETING WITH LIMITS 

By limiting the **delete** statement you just block the SQL to delete more than x columns when deleting from that table. 

```SQL 
DELETE FROM Users WHERE Users.name = "Daniel" LIMIT 1
```

## UPDATE VALUES

To update a single value or more of them from an SQL Table row, you can use the ```UPDATE```Command for changing this value. 

```SQL 
UPDATE Users SET Users.name = "Daniel" WHERE Users.id = 3 
```

## ORDER BY 

Add the `ORDER BY` keyword when you want to sort the result, and return the first 3 records of the sorted result.

SQL Results can be ordered by: 
* ```ASC``` - Ascending order
* ```DESC``` - Descending order

```SQL 
	SELECT * FROM Users ORDER BY Users.name; 
```

This statement will get all the users from the Users table and order then alphabetically by the name. 

This can be combined with ```LIMIT``` statement for getting a certain number of results and order them: 
```SQL 
	SELECT * FROM Customers ORDER BY CustomerName DESC LIMIT 3;
```

## WHERE  - AND 

The `WHERE` clause is used to filter records. It will only return the rows that actually match with the condition in the statement: 
```SQL 
	SELECT * FROM Users WHERE Users.name = "Daniel"; 
```
This statement will select `all` parameters from the Users rows that verify the condition that Users.name = "Daniel". In other words, that its name its Daniel. 

The `WHERE` clause can contain one or many `AND` operators.

The `AND` operator is used to filter records based on more than one condition, like if you want to return all customers from Spain that starts with the letter 'G':

```SQL
	SELECT * FROM Users WHERE Users.country = 'Spain' AND Users.name LIKE 'G%'
```

In this case, ```LIKE``` statement is used that compare values. 

## LIKE 

The `LIKE` command is used in a ```WHERE``` clause to search for a certain pattern in a value.

You can use two wildcards with `LIKE`: 

- % - Represents zero, one, or multiple characters
- _ - Represents a single character (MS Access uses a question mark (?) instead)

As the previous example, this can be use to search for a value that starts with a character or ends with one or a certain combination of characters. 

--- 
title: SQL MAIN COMMANDS
author: Daniel Laplana Gimeno 
date: 23-11-2023



