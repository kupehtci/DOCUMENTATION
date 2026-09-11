#SQL 

# COUNT

You can get the count of an item that follow a certain `WHERE` condition or the complete table count of items. 

```SQL
SELECT COUNT(_column_name_) FROM _table_name_ WHERE _condition_;
```

Example: Count all rows in a table
```SQL
SELECT COUNT(*) FROM Products;
```

Count distinct values: 
```sql
SELECT COUNT(DISTINCT Category) FROM Products;
```

# AVG

Calculates the average value of a numeric column, ignoring NULLs.

```SQL
SELECT AVG(column_name) FROM table_name WHERE condition;
```

Example find the average price in a table: 
```SQL
SELECT AVG(Price) FROM Products;
```

# SUM

Returns the total sum of values for a numeric column.

```SQL
SELECT SUM(column_name) FROM table_name WHERE condition;
```


# GROUP BY and HAVING

Group results and apply aggregates to each group. Filter groups with HAVING.

```SQL
SELECT column_name, COUNT(*) FROM table_name GROUP BY column_name HAVING COUNT(*) > value;
```

Example: Find number of employees in each department with more than five people:

```SQL
SELECT Department, COUNT(*) FROM Employees GROUP BY Department HAVING COUNT(*) > 5;
```