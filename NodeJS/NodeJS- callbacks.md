#NodeJS 

# NodeJS Callbacks

A <span style="color:DodgerBlue;">callback</span> is an special function passed as an argument to another function. 

They are called when the function that contains the callback as function completes it execution. 

Callbacks are used to make asynchronous calls, because NodeJS doesn't wait for the callback function to be completed. 


### How to define a callback

To define a callback, can be done with a lambda function (or arrow function `() => {}`) or with the keyword `function` but without a name. 

```js
function getData(callback){
	//simulate asynchronous operation 
	setTimeout(() => {
		callback("data fetched"); 
	}, 1000)
}
```

