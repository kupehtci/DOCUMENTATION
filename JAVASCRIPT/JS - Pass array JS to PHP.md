#JS #PHP 

One way to pass an array form JS to PHP is using JSON format. 


```JS
let array = {"hello", "world"}; 
xhr.open("POST", "print.php", true);
xhr.send("array="+JSON.stringify(array)); 
```

```PHP
// print.php 
$array = json_decode($_POST['array']); 
```