#DATABASES 

### Concurrency control protocols

There are some protocols to prevent concurrency problems in a multiuser database: 

**Database locking**

Only one transaction has access to a certain part of the database at a time. 

This locking can be done at different <span style="color:MediumSlateBlue;">levels of granularity</span>: 

* Database level: blocks the entire database
* Table level: blocks the table 
* Page level: when performing an <span style="color:orange;">UNION</span> when performing a select, this set of tables is readed in a "virtual" table named as <span style="color:orange;">page</span>. 
* Row level: blocks a single row in the database. 




