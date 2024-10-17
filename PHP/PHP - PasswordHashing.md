# PASSWORD HASHING
#PHP 
## MD5 and SHA

Are MD5 and SHA hashes secure? no
Back in the day, passwords were stored using an MD5 or SHA1 hash.
Like this:

```php
    $password = 'my secret password';
    $hash = md5($password);
```

This technique is not safe enough.
For two reasons:
*   MD5 and SHA algorithms are too weak for today’s computational power.
*   Simple, not-salted hashes are vulnerable to “rainbow tables” and dictionary attacks.

## password_hash()

The password_hash() function creates a secure hash of your password.
This is how to use it:

```php
  $password = "my secret password";
  $hash = password_hash($password);
```

*    It uses a strong hashing algorithm.
*    It adds a random salt to prevent rainbow tables and dictionary attacks.

>  this password needs to be saved directly into server

## HOW TO STORE PASSWORDS IN SERVER

Here is a short example using PDO to manage the SQL.

```php
  /* Include the database connection script. */
  include 'pdo.php';
  $username = 'John';
  $password = 'my secret password';

  $hash = password_hash($password, PASSWORD_DEFAULT);

  $stmt = $this->database->prepare("INSERT INTO accounts (account_name, account_passwd) VALUES (?, ?)");
  $stmt->bind_params("ss", $name, $hash);

  try
  {
    $stmt->execute($values);
    $query_result = $stmt->get_result();
  }
  catch (PDOException $e)
  {
    echo 'Query error.';
    die();
  }
```

## VERIFY PASSWORDS

Passwords hashed using ```password_hash()``` are salted, this means that also contains a string known as "salt", a random string that protects against rainbow tables and dictionary attacks. 

THis results in having two similars passwords are hashed and the hashees are not equal. 

```php
  $pass1 = password_hash("hola1234",PASSWORD_DEFAULT); 
  $pass2 = password_hash("hola1234", PASSWORD_DEFAULT); 
  $equal = ($pass1 === $pass2); 
  echo "Equal: $equal"; 
  var_dump($equal); 
```
Those comparison will return a false as a result of having same password but different salt in each of them. 

Just to compare two hashed passwords and ensure if they are equal, use ```password_verify($password1, $password2);```

```php
  $password_login = "1234"; 
  $password_database = "$2y$10dc/dORDPnoy9kvP9ws98D8u5GxAMihh6PVzvMsjo/fqLovmD//5PUa"; 

  $password_login_hashed = password_hash($password_login, PASSWORD_DEFAULT); 
  if(password_verify($password_login_hashed, $password_database)){

    echo "Login correctly"; 
  }
  else{
    echo "Incorrect password"; 
  }
```


More information in [ALEXWEBDEVELOP](https://alexwebdevelop.com/php-password-hashing/)