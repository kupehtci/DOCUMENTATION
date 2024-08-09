#JS 

When interacting with <span style="color:#ababf5;">Number</span> data type, its specially usefull being able to distinguish between a float or an integer or format both to give a certain characteristic. 

Here are the most common methods to deal with <span style="color:#ababf5;">Number</span>. 

## toFixed()

This function let you format a number using fixed point notation. 

`toFixed(digits)` digits let you specify the number of digits that appear after decimal point, being a value between 0 - 20. 

```JS
function financial(x) {
  return Number.parseFloat(x).toFixed(2);
}

console.log(financial(123.456));
// Expected output: "123.46"

console.log(financial(0.004));
// Expected output: "0.00"

console.log(financial('1.23e+5'));
// Expected output: "123000.00"

```

Exceptions thrown: 
+ **RangeError** if digits is not within 0 - 20. 
+ **TypeError** is this method is used on an object that is not a number. 

## isSafeInteger()

The method `Number.isSafeInteger()` let you check if a number if a safe integer. 
A safe integer is the one that meet the next characteristics: 
* Can be represented with an IEEE-754 number of double precision
* Its representation cannot be represented by the result of rounding another integer to adapt the IEEE-754 representation. 

See more about IEEE-754 single floating point: [[IEEE-754 Floating Point]]