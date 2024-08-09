
You can specify an array in your HTML this way:

```php
<form method="post" >
	<input type="hidden" name="id[]" value="1"/>
	<input type="hidden" name="id[]" value="2"/>
	<input type="hidden" name="id[]" value="3"/>
</form>
```

This will result in this $_GET array in PHP:

```php
array(
  'id' => array(
    0 => 1,
    1 => 2,
    2 => 3
  )
)
```

Of course, you can use any sort of HTML input, here. The important thing is that all inputs whose values you want in the 'id' array have the name `id[]`.