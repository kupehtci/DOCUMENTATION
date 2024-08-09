#JS #PHP 

One thing is passing a variable and another one is passing an array, but isn't that worse. 
This can be done with JavaScript Object Notation(JSON).[[JSON - BASICS]]

**Method 1: Using json_encode() function:** The **json_encode()** function is used to return the JSON representation of a value or array. The function can take both single dimensional and multidimensional arrays.

**Steps:**

- Creating an array in PHP:
```PHP
<?php
    $sampleArray = array(
            0 => "Hello", 
            1 => "world", 
            2 => "from", 
            3 => "Aura"
        );
    ?>
```

- Using json_encode() function to retrieve the array elements

```PHP
var passedArray = <?php echo json_encode($sampleArray); ?>;
```
