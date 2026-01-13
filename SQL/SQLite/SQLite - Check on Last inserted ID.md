#SQLite

SQLite by default it doesn't return the ID of the last inserted item of a table that has an *autoincrement* column. 

An option to retrieve this last inserted ID or autoincremental value is to take a look at system table `sqlite_sequence`. 
This table is created automatically by the SQLite Database if you create any table with an autoincrement value. 

This table is for sqlite to keep track of the autoincrement field so that it won't repeat the primary key even after you delete some rows or after some insert failed 

So by using this table, you can get the newly inserted item's primary key by doing: 

```sqlite
select seq from sqlite_sequence where name="table_name"
```

Take into account that if an insertion fails, the autoincremental value retrieved is not going to be the one of the newly inserted item, so you will need to handle the error insertion before checking on the new ID. 

Another two ways to retrieve this ID: 

```sqlite
SELECT MAX(id) FROM yourTableName LIMIT 1;

SELECT rowid from your_table_name order by ROWID DESC limit 1; -- Less optimal
```



###### References

You can take a look at: [http://www.sqlite.org/autoinc.html](http://www.sqlite.org/autoinc.html)