#PHP 

Take into account that PHP is not a normal language. 
Is lightly typed and have some certain features not avaliable in other languages. 

Take into account that using <span style="color:orange;">for loops</span> to traverse an array is not as common due to the fact that PHP arrays are not indexed as common arrays, they are like <span style="color:#d291bc;">ordered maps</span>


### foreach 

One of the best ways to traverse around php associative arrays [[PHP - Arrays]] is using a foreach loop.  
The foreach loop syntax in PHP is: 

```PHP
foreach (array_variable as $value){
	//code
}
    
foreach (array_variable as $key => $value){
	//code
}
```
