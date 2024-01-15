#PHP 

You can filter and sanitize the variables for adding security over uploading them into a database SQL or similar: 


##### SANITIZE AN EMAIL 

```PHP
$email = "example@gmail.com"; 
$email = filter_var($email, FILTER_SANITIZE_EMAIL);
```

