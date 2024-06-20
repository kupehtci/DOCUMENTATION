#JS #JQUERY #TESTING


Testings can be done by using `jquery's` qunit library: 

For defining an HTML that uses jQuery qunit testing framework: 

```html
<html>  
<head>  
   <script src="https://code.jquery.com/qunit/qunit-1.12.0.js"></script>  
   <script src="romans.js"></script>  
   <script src="tests.js"></script>  
   <link rel="stylesheet" type="text/css" href="https://code.jquery.com/qunit/qunit-1.12.0.css">  
</head>  
<body>  
  <div id="qunit"></div>  
  <div id="qunit-fixture"></div>  
</body>  
</html>
```

And the tests automation is done by including the `test()` functions in <span style="color :orange;">test.js</span>. 

Also uses assert.equal function that asserts the error results in case that expected result of the entered function and the current results doesn't match: 

```js
test("Basic testing", function(assert) {  
  assert.propEqual(convertIntegerToRoman("1"), {value: "I", message: '', result: true}, "TC-1");  
  assert.propEqual(convertIntegerToRoman("0"), {value: 0, message: 'Out of range (1-3999)', result: false}, "TC-2");  
  assert.propEqual(convertRomanToInteger("X"), {value:"10", message: '', result: false}, "TC-3")  
});

//or

test("Hello", function(assert){
	assert.equal(validTemplate("101000"), false, "Test-1-ONLY-NUM-1"); 
}); 
```