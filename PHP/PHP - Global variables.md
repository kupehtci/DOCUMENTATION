#PHP 

The scope of the variables within a PHP script can be: 

* <span style="color:DodgerBlue;">local</span>: restricted to the block that belongs. A block can be a for loop, a function or similar
* <span style="color:IndianRed;">global</span>: visible within all the PHP script. 


The <span style="color:IndianRed;">global</span> variables in order to be used within a function, a `global` modifier needs to be declared first

```php
<?php  
$a = 1; /* global scope */  
  
function test()  
{  
	echo $a; /* reference to a local variable, not the global one */  
}  
  
test();  
?>
```

In order to use the global `$a` needs to be declared: 


```php
<?php  
$a = 1; /* Global scope */
  
function test()  
{  
	global $a; 
	echo $a;  
}  
  
test();  
?>
```


More than one variable can be defined as global reference within the same line: 

```php
<?php
$a = 2; 
$b = 3; 

function add(){
	global $a, $b; 
	return ($a + $b)
}

echo add(); 
?>
```

##### $GLOBALS

`$GLOBALS` is an ass