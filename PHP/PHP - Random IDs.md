#PHP #SQL

## Generate random IDs

You can generate for example for inserting elements in a SQL or identifying different objects. 

There are some ways to generate "random" unique IDs: 

```PHP
$order_id = substr(crc32(uniqid()), 0, 11);
```


See the use of `substr()` in how to format a string: 
[[PHP - String format]]