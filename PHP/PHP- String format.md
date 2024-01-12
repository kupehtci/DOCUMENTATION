#PHP #STRING

Give a format to string or other primitives to have a certain look for PHP usage is a common usage to be show in HTML webpages. 

Here are some common methodologies to give some format to primitives to be show in the browser. 

#### EXPLODE USE

When you want to join strings with a separator cannot be done with a for because nade to take into account to not join the separator into the first one. 
This could be done this way: 

```PHP
public function CustomExplode(separator, stringArray){
	$result = ""; 
	for(int $i = 0; $i < count($stringArray); $i++){
		if($i == 1){
			$result .= $stringArray[$i]; 
			continue; 
		}
		$result .= $separator . $stringArray[$i]; 
	}
}
```

Instead, using `explode(separator, string_array);` let you concatenate all the strings with the separator between each one. 

```PHP
	$hello_world = array("Hello", "World"); 
	$string_contatenated = explode(", ", $hello_world); 

	echo $string_concatenated; // -> Hello, World 
```

#### TRIM

You can trim a string for deleting certain characters that appear at the begin or end of the string. 

```PHP
$string = "-HELLO-"; 
$string = trim($string, "-"): 
echo $string  // HELLO
```

#### DELETE SLASHES

You can delete slashes (\\ and /) by using `stripslashes($string)`function. 

```PHP
$data = "//\Hello"; 
$data = stripslashes($data);
echo $data;      // Hello
```

#### OTHER METHODS

A custom way to do a concatenation with certain elements between array items is: 

```PHP
	
```