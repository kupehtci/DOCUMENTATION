#SQL #PHP 

### Modifiers use

Modifiers are SQL statement add that <span style="color:#ababf5;">modify the query statement</span>. 
This modify the query result or the data rows affected by a statement. 
For example a <span style="color:orange;">SELECT</span> can be limited to get a limited number of data rows or the top or last ones. 


#### SELECT TOP 

Specifies the number of records to return. Useful in large databases where a raw select can affect the performance. 
```SQL 
SELECT TOP 3 * FROM Customers;
```

#### LIMIT 

Is the same as <span style="color:orange;">SELECT TOP</span> but for use in MySQL tables. 

```SQL 
SELECT * FROM Users LIMIT 3; 
```

