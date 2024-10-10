```CSS
.cm-s-obsidian code{
font-size: 1.2rem; 
}
```

### How to bind params using `mysqli_statement`
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

### How to bind params using `PDOStatement`

If you are using <span style="color:orange;">PDO connection</span>, you can use the `PDOStatement` generated to bind parameters.
The variable will be vinculated and then evaluated when called `PDOStatement::execute()`.
You can use ? and then substitute the ? with parameters by specifying the index of ? to exchange. 

```PHP
$gsent = $gbd->prepare('SELECT name, colour, calories  
FROM fruit  
WHERE calories < ? AND colour = ?');  
$gsent->bindParam(1, $calorías, PDO::PARAM_INT);  
$gsent->bindParam(2, $color, PDO::PARAM_STR, 12);
```

The best way to use PDOStatement is to instead of writing `?` , write keys in the structure of `:name` and exchange with the parameters: 

```PHP
$query = "INSERT INTO orders(user_id,username, is_sent) VALUES({$user_id}, :user, false)";  
$query->bindParam(':user', $username_g, PDO::PARAM_STR, count($username_g));
```


* `parameter`

El identificador del parámetro. Para sentencias preparadas que usen parámetros de sustición con nombre, esto será un nombre de parámetro con la forma :nombre. Para sentencias preparadas que usen parámetros de sustición de signos de interrogación, esto será la posición índice-1 del parámetro.

* `variable`

Nombre de la variable de PHP a vincular al parámetro de la sentencia SQL.

* `data_type`

El tipo de datos explícito para el parámetro, usando las [constantes **`PDO::PARAM_*`**](https://www.php.net/manual/es/pdo.constants.php). Para devolver un parámetro INOUT desde un procedimiento almacenado, se ha de usar el operador OR a nivel de bits para establecer los bits de PDO::PARAM_INPUT_OUTPUT para el parámetro `data_type`.

* `length`

La longitud del tipo de datos. Para indicar que el parámetro es un parámetro OUT de un procedimiento almacenado, se debe establecer explícitamente la longitud.

`driver_options`