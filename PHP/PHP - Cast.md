#PHP 

### How to cast in PHP

In PHP you can cast like in C or C\#,  just by using explicit cast conversor between "()". 

Example: 

```PHP
$num = "3.14";
$int = (int)$num;
$float = (float)$num;
```



Also can be caster using other methods. 

* Performing math operations: 
```php
$num = "10" + 1;
$num = floor("10.1");
```

* Using `intval()` or `floatval()`: 

```PHP
$num = intval("10");
$num = floatval("10.1");
```

* Using `settype()`: 
```PHP
$foo = "5bar"; // string
$bar = true;   // boolean

settype($foo, "integer"); // $foo is now 5   (integer)
settype($bar, "string");  // $bar is now "1" (string)
```