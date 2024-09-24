#NodeJS #JS 

# NodeJS Promises

An `promise` represents an function with an eventual completion or failure of an asynchronous operation. 

The promise is returned to the main execution of code and its not just completed, when it get resolved, it will execute other code. 

This function will `resolve()` or either `reject()` if there is success or not. 

You can then use: 

```js
promise.then(callback_function).catch(callback_function); 
```

Where `.then()` will be called if the promise invokes resolve and `catch()` in case that fails