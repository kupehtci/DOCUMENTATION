#PHP 

### header()

```PHP
header(string $header, bool $replace = true, int $responde_code = 0)
```

Header function `header($header_string)` is used to send a HTTP header without format. 

The headers needs to be <span style="color:orange;">send before showing nothing from screen</span>. Its common to read code or include  / require files that include blank spaces before calling to `header()` and this could lead into error. 

#### PARAMETERS

* `$header` header in string
* `$replace` true by default. Indicated if the newly set header can replace a previous declared header

There are 2 special cases in the use of header: 

* Header that starts with "`HTTP/`" is used to discover the status code used to send. 
```PHP
<?php  
// Este ejemplo ilustra el caso especial "HTTP/"  
// Alternativas mejores en cases de uso típicos incluyen:  
// 1. header($_SERVER["SERVER_PROTOCOL"] . " 404 Not Found");  
// (para sobreescribir el mensaje de estado HTTP para los clientes que todavía usan HTTP/1.0)  
// 2. http_response_code(404); (para usar el mensaje defecto)  
header("HTTP/1.0 404 Not Found");  
?>
```

* `Location:` not only sends the header, also return the status 302 `REDIRECT` to the web browser instead the status send is not `201` or `3xx` has been send. 

```PHP
<?php  
header("Location: http://www.example.com/"); // Web browser redirection
  
// Make sure that following code is not executed before the Location Header
exit;  
?>
```

This location header can be used to <span style="color:orange;">redirect</span> to another url or relative path in the same web. 


### SPECIFIC HEADERS

Header to send GET and POST requests XmlHttpRequests: [[XMLHttpRequest]]
```PHP
header('Access-Control-Allow-Origin: *');
header('Content-Type: application/json');
header("Access-Control-Allow-Methods: GET");
header("Allow: GET, POST, OPTIONS, PUT, DELETE");
```

Download header

```PHP
<?php  
// show that a PDF is going to be shown
header('Content-Type: application/pdf');  
  
header('Content-Disposition: attachment; filename="downloaded.pdf"');  

// read the file from the path
readfile('original.pdf');  
?>
```


Force cache deactivation: 

```PHP
<?php
header("Cache-Control: no-cache, must-revalidate"); // HTTP/1.1
header("Expires: Sat, 26 Jul 1997 05:00:00 GMT"); // Fecha en el pasado
?>
```

