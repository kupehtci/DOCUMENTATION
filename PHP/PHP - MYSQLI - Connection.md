#PHP #SQL 

# Start a mysqli connection

You can initialize the mysli connection by  creating a new <span style="color:#ababf5;">mysqli</span> object with the 

```PHP
public function Connect(){  

	$database_name = "ECOMMERCE"; 

    try{  
        $db = new mysqli("localhost", "root", "", $database_name);  
  
        if ($this->db->connect_errno != null) {  
            die("Connection error: " . $db->connect_error);  
        }  
    }  
    catch(Exception $e){  
        echo "Error while SQL Connection $e";  
        return null; 
    }  
  
    //Open a session  
    $session_success = session_start();  
    if(!$session_success){  
        echo "<script>alert('Error starting session')</script>";  
    }  
	return $db; 
}
```