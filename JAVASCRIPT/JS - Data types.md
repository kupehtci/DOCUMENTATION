#JS 

## JS Variable types

Javascript is a weak typed language, meaning that variables has no specified type when declaring them. 
Once the variable its declared, an internal type is asigned that can be: 

En Javascript disponemos de los siguientes **tipos de datos** principales:

|Tipo de dato|Descripción|Ejemplo básico|
|---|---|---|
|`Number`|Numerical value (integers, decimales, etc...)|`42`|
|`BigInt`|Big numerical value |`1234567890123456789n`|
|`String`| text value (char strings, characters, etc...)|`'MZ'`|
|`Boolean`|Boolean value (true or false)|`true`|
|`undefined`|Not defined value (variable without initialization)|`undefined`|
|`Function`|function saved in a variable |`function() {}`|
|`Symbol`|unique value as a key|`Symbol(1)`|
|`object` |Object, a more complex structure with properties|`{}`|


### How to know the type

To know the type of a variable we can use `typeof()` method. 

```js
console.log(typeof(text));       // "String"
console.log(typeof(number));     // "Number"
console.log(typeof(boolean));    // "Boolean"
console.log(typeof(notDefined)); // undefined
```

## typeof()

The return of `typeof()` could be: 

|Type|Result|
|---|---|
|[Undefined](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/undefined)|`"undefined"`|
|[Null](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Operators/null)|`"object"`([reason](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Operators/typeof#typeof_null))|
|[Boolean](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Boolean)|`"boolean"`|
|[Number](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Number)|`"number"`|
|[BigInt](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/BigInt)|`"bigint"`|
|[String](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/String)|`"string"`|
|[Symbol](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Symbol)|`"symbol"`|
|[Function](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Function) (implements [[Call]] in ECMA-262 terms; [classes](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Statements/class) are functions as well)|`"function"`|
|Any other object|`"object"`|

This method is used to check the data type of a variable and can also be used to check if the variable has been declared or initialized checking is its not `undefined`. 
