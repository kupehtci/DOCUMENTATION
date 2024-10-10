#PHP 


### Postgres connection

Once you have configured the Postgres [[XAMPP Enable Postgress]], you can make queries from PHP to Postgres server via `pg_connect(string_parameters)`

This function expects a string with the parameters for the connection defined. 

```PHP
$db_handle = pg_connect("host=localhost port=5432 dbname=University user=postgres password=hello");

// Check connection information
if($db_handle){
	echo "<h3>Connection Information</h3>"; 
	echo "DATABASE NAME: " . pg_dbname($db_handle) . "<br>";
	echo "HOSTNAME: " . pg_host($db_handle) . "<br>"; 
	echo "PORT:  " . pg_port($db_handle) . "<br>"; 
}else{
	echo "error connection";
}
```