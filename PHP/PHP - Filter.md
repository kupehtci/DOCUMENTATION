#PHP 

You can filter and sanitize the variables for adding security over uploading them into a database SQL or similar: 

```PHP
filter_var(mixed $value, int $filter = FILTER_DEFAULT, array|int $options = 0)
```

Returns a `mixed` value. [[PHP - mixed]], and has the following parameters: 

`value`

Value to filter. Note that scalar values are converted to string internally before they are filtered.

`filter`

The ID of the filter to apply. The Types of filters manual page lists the available filters.

If omitted, **`FILTER_DEFAULT`** will be used, which is equivalent to [**`FILTER_UNSAFE_RAW`**](https://www.php.net/manual/en/filter.filters.sanitize.php). This will result in no filtering taking place by default.

`options`

Associative array of options or bitwise disjunction of flags. If filter accepts options, flags can be provided in "flags" field of array. For the "callback" filter, [callable](https://www.php.net/manual/en/language.types.callable.php) type should be passed. The callback must accept one argument, the value to be filtered, and return the value after filtering/sanitizing it.
#### SANITIZE AN EMAIL 


```PHP
$email = "example@gmail.com"; 
$email = filter_var($email, FILTER_SANITIZE_EMAIL);
```

