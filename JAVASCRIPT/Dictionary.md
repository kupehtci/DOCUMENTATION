#JS 

# Javascript - Dictionary

There is no dictionary class in Javascript, but you can still create a dictionary class with Key-Value pairs and populating it. 

By creating an `Object` entity, you can initialize it with key-value pairs: 

```js
var dictionary = new Object() 

// Or

var dictionary = {}; 

dictionary = {
	firstValue : "FirstValue",
	secondValue : "SecondValue", 
	thirdValue : "ThirdValue"
}

// Also can be populated using object's indexer property
dictionary["firstValue"] = "FirstValue"

// By property
dictionary.FirstValue = "FirstValue"
```

### Iterate

You can iterate through a dictionary key-value pairs properties: 

```js
for(var key in dictionary){
	var value = dictionary[key]
}
```