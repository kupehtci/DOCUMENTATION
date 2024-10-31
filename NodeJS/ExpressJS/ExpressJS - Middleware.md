#NodeJS 

### Middleware in ExpressJS

Middleware consist in functions that can be use to access the request and response objects that are sended and recieved through the express endpoints

This can be useful for modifying its values, executing code depending on the parameters received in the request or even calling other functions with `next()`

Also provides modularity when executing code. 

As an example, with this basic functionality of receiving some users (username and password) as a JSON in the HTTP request in the body, we should see that the `req.body` is undefined: 

```js
const express = require('express');
const app = express(); 

app.post('/users', async (req : any, res : any) => {
    res.json({requestBody: req.body})
});
```

But if we include the middleware function with the `app.use()` function, we "enable" the functionality of retrieving the JSONs from the request body: 

```js
const express = require('express');
const app = express(); 

app.use(express.json())

app.post('/users', async (req : any, res : any) => {
    res.json({requestBody: req.body})
});
```

We use `app.use` to "force" ExpressJS to execute that callback before the correctly assigned callbacks to the correspondent endpoint, and we can pass a custom middleware to that function that will take this format: 

```js
function CustomMiddleware (req : any, res : any, next : Function) {  
    // Some functionaluity  
    next() // call the next middleware function in case that doesnt end the circle  
}

app.use(CustomMiddleware)
```

This has been an example for parsing JSON body but we have other built-in middleware functions like: 

* `express.static('public')` for serving static content like web pages. 
* `cookie-parser` for retrieving cookies from the request (Third party middleware)
* `body-parser` to parse and retrieve non-json body from the http request. 

If a middleware function that is passed to express, has no end, so needs to call the next function, it should end with `next()` function. 

This will invoke the following middleware function to make a chain. 


###### Sources

All of this research has been gathered from different sources: 

* Official express JS documentation > https://expressjs.com/en/guide/using-middleware.html#middleware.application
* Explanatory youtube videos > https://www.youtube.com/watch?v=TrEwaT4I2yU&t=73s
* Not official documentation https://radixweb.com/blog/expressjs-middleware