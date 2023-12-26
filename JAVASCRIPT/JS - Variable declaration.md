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
|`Object`|Object, a more complex structure with properties|`{}`|


### How to know the type

To know the type of a variable we can use `typeof()` method. 

```js
console.log(typeof(text));       // "String"
console.log(typeof(number));     // "Number"
console.log(typeof(boolean));    // "Boolean"
console.log(typeof(notDefined)); // undefined
```