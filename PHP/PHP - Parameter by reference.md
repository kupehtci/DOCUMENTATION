#PHP 

## Variables in PHP

References in PHP are a means to access the same variable content by different names. They are not like C pointers; for instance, you cannot perform pointer arithmetic using them, they are not actual memory addresses, and so on. 

Instead, they are <span style="color:#ababf5;">symbol table aliases</span>. Note that in PHP, variable name and variable content are different, so the same content can have different names. 
The closest analogy is with Unix filenames and files - variable names are directory entries, while variable content is the file itself. References can be likened to hardlinking in Unix filesystem.

## Pass a parameter by reference

A parameter in PHP is passed by copy. This means that is the value gets modified within a function, the value outside the function. 
This happens because inside the function you are not using the variable itself, you are using a copy. 

To be able to modify a variable value within a function, you can pass the value as reference: 


```PHP
public function IncrementByStep(&$a, $step){
	$a += $step
}

$a = 10; 
IncrementByStep($a, 2); 
echo $a; //$a = 12
```