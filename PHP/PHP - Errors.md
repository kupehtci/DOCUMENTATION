
## Cannot access offset of type string on string in

This error is received when trying an invalid access an index of a non array value: 

```PHP 
$arr = "Hello world!"; 
$arr['id'] = "hello";    // This willl cause the error
```