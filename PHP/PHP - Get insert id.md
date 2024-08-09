#PHP #SQL 

## Get inserted id

Once you have made an insert, you can get the id of the new row inserted for being able to use it for adding child elements or manipulate the new row. 

#### USING `mysqli_statement`

```PHP
$user_id = 4; 

$stmt = $sql->db->prepare("INSERT INTO Orders(user_id) VALUES({$user_id}, 'Pending',{$ref})");  
$stmt->execute();  
$order_id = $stmt->insert_id;   
$result = $stmt->get_result();
```

Using `mysqli_statement::inserted_id` you can access id of the last `INSERT`->[[SQL - MAIN COMMANDS]]

If you use `INSERT` to insert more than 1 value: 
```SQL
INSERT INTO Users(username, email) VALUES
("Dani", "dani@gmail.com"), ("Marta", "marta@gmail.com"); 
```

The variable `insert_id` would return the first insertion ID. 


#### USING `query`

If you have used `$connection` `query` statement for making the query, without having the statement, you can still getting the last insertion id: 

```PHP
$sql_db_connection->prepare("INSERT INTO Products(name, quantity) VALUES({$product['product_name']}, {$product['qty']})");  
$inserted_id = $pdo->lastInsertId();
```

Using `$pdo->lastInsertId();` you can get the id.  
PDO connection is done by: 
```PHP
$pdo = new PDO("mysql:host=$host;dbname=$dbname;charset=utf8mb4", $username, $password);
```
