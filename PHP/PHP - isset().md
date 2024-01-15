#PHP 

Function `isset()` is a built-in function in PHP that determines if a variable is set and not null. 
It returns `true` if the variable exists and has a value other than `null`, and `false` otherwise.

Can be used to check, for example the post array indexes: 

```PHP 
if(!isset($_GET['search'])){
header('Location: ./index.php');
exit; 
}
```