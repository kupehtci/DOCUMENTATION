
#### VERBOSE WAY 

You can insert an arrray as a get in PHP. 

The url needs to be like 

>`shop.php?cat[]=1&cat[]=2&cat[]=3` 

Then `$_GET['cat']` will be an array of those values. It's not as pretty, but it works out of the box.

#### FANCY WAY

A fancy way can be to insert like a string with each value separated with comas 

Url example: 

> `shop.php?cat=1,2,3`

And then with the resultant value of `$_GET['cat']` would be "1,2,3" as a string. 
Then with the resultant string you can explode it to separe into an array by slicing when detect a coma. 
```php
$values = explode(",", $_GET["id"]);
print count($values) . " values passed.";
```

