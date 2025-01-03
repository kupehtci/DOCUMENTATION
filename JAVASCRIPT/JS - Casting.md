
Even if JavaScript is a loosely typed language, you might have the need to convert a value from a type to another.

In JavaScript we have those primitive types:

- `Number`
- `String`
- `Boolean`
- [`Symbol`](https://flaviocopes.com/javascript-symbols/)
Take a deeper look into <span style="color:orange;">Javascript data types</script> [[JS - Data types]]

Here are the techniques to convert between different data types: 

### Casting to <span style="color:#ababf5;">string</span>

By using the String global function, or number type `toString()` method: 

```JAVASCRIPT
String(10) //"10"
(10).toString() //"10"
String(true) //"true"
true.toString() //"true"
String(false) //"false"
false.toString() //"false"
```

### Casting to <span style="color:#ababf5;">Number</span>

You can cast to number by using the `Number()` global function, sort of constructor. Pass it as a string. 

```CSHARP 
Number("1");   // 1 
Number(" 0 "); // 0
```

As we can see in the last example, the numbers in strings are trimmed after casting to other data types. 

An empty string is considered as 0: 
```CSHARP 
Number("") //0 
```

If you pass a value that cannot be converted to a <span style="color:#ababf5;">number</span> it will return a <span style="color:red">NaN</span>.

```JS
	Number("awesome"); //NaN
```


### `parseInt()` and `parseFloat()`

When you need to distinguish between a float and an integer except from a number, can be done with: 
* `parseInt(string, base)` string top be converted and a base for the number
* `parseFloat(string)` parse to float the string given. 

```js
const quantity = "12.99";

console.log(parseInt(quantity, 10)); //12
console.log(parseFloat(quantity)); //12.99
```




This are the basics of converting to numbers, but I give a lot more details in [how to convert a string to a number in JavaScript](https://flaviocopes.com/how-to-convert-string-to-number-javascript/). There are other ways to generate numbers from string including `parseInt()`, `parseFloat()`, `Math.floor()`, the unary `+` operator.


