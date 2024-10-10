#PHP #SQL 

# Start a mysqli connection

You can initialize the mysli connection by  creating a new <span style="color:#ababf5;">mysqli</span> object with the 

```PHP
public function Connect(){  
	$hostname = "localhost"
	$username = "root"; 
	$password = ""; 
	$database_name = "ECOMMERCE"; 

    try{  
        $db = new mysqli($hostname, $username, $password, $database_name);  
  
        if ($this->db->connect_errno != null) {  
            die("Connection error: " . $db->connect_error);  
	        $db = null; 
        }  
    }  
    catch(Exception $e){  
        echo "Error while SQL Connection $e";  
        return null; 
    }  

	return $db; 
}
```