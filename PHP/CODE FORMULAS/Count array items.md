#PHP 

Here is a way to recursively count the number of items in a multidimensional array in PHP: 

```php
<!DOCTYPE html>
<html>
<head>
<title>Multidimensional array count</title>
</head>
<body>
<?php
/**
 * Perfoms a deep count of the elements in an multidimensional array
 */
function deepCount($array) {
	$count = 0;

	foreach ($array as $item) {
		$count++; 

		if (is_array($item)) {
			$count += deepCount($item);
		}
	}

	return $count;
}
            
// Example usage:
	$array =    [1,
				[2, 3, [4, 5]],
				[6, [7, [8]]],
				9];

$totalCount = deepCount($array);
echo "Total count of elements (including nested elements) is: " . $totalCount;
?>
</body>
</html>
```