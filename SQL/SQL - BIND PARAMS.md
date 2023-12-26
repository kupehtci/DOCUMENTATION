## HOW TO BIND PARAMS IN PHP 
#PHP #SQL

How to bind params into an SQL query statement. This is done to prevent sql queries injection and ease the form of executing SQL queries into Database. 

database->prepare($sql_statement) -> $sql_statement needs to have the string with ? values that are going to be replaced with the desired ones. This returns a mysqli_statement. 
With ``` ->bind_param(string $dataTypes, $val1, $val2, ...)```, we specify the type of value to be replaced ( s: string, d: digit, i: integer, b: blob) Take on account that blob data type will be send in packages. 
and $valX are the values to replace the ? marks with.

```PHP

	$stmt = $this->db->prepare("SELECT * FROM Products WHERE Products.name=?");
	$stmt->bind_param("s","Wood Chair");
	$stmt->execute();
	$queryResult = $stmt->get_result(); 	

```

$queryResult store an __mysqli_result__ (associative array) with the results of that query

As an example of how to insert a user binding its parameters to avoid code injection: 

```PHP 
	
```