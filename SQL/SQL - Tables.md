#SQL 


## TABLES

In <span style="color:orange;">SQL</span> tables are the basic structure for data storing. 



### CREATE A TABLE IN MySQL

This is the statement for creating a table in MySQL. 
The structure consist in `CREATE TABLE <NAME> {}` with each of the instance parameters of the table. 
Each of the parameters need to be separated like an enum declaration with comas. 

```SQL 
CREATE TABLE Users{
id NOT NULL AUTO_INCREMENT, 
name NOT NULL DEFAULT "default_name", 
username NOT NULL DEFAULT "default_username", 
created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP, 
}
``` 

Take into account the different **data-types** and their constraints. 
For `mariadb` data-types check the next notes: [[SQL - Data types]]