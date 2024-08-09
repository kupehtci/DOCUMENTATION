#SQL #PostgreSQL 

### Joins in SQL Databases

Joins consist of joining different tables by a shared value column. 

An example of a `JOIN` can be: 

```SQL
SELECT * FROM Users INNER JOIN Passwords ON Users.id = Passwords.user_id; 
```

In this case, image a Users table and a passwords table that is "linked" to users table by having a `user_id` column that has the foreign key related to the user that belongs it. 

There are different types of join: 

➡️ INNER JOIN: Retrieve the registers that share the same value in both tables. 
  
➡️ LEFT JOIN: Retrieves all the values of the left tables and the ones that share the attribute with the other one. 
  
➡️ LEFT JOIN WITH NULL CHECK: filter only the registers of the Left table that not share values with Right table. 
  
➡️ RIGHT JOIN: Same as Left join but retrieves the Right table values. 
  
➡️ RIGHT JOIN WITH NULL CHECK: Filter the results from the right table that don't share any values with the left table
  
➡️ FULL JOIN: retrieves all the values and join if there is a coincidence between both tables. 
  
➡️ FULL JOIN WITH NULL CHECK: filter the values that don't have any coincidence in both tables. 
![[./IMAGES/join_types.gif]]