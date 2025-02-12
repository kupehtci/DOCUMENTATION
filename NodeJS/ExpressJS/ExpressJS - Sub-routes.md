
By using ExpressJS router class, you can create modular and mountable route handlers. 
A Router is a complete middleware and routing system. 

Example: 
```ts
const express = require('express')
const router = express.Router()

// middleware that is specific to this router
const timeLog = (req, res, next) => {
  console.log('Time: ', Date.now())
  next()
}
router.use(timeLog)

// define the home page route
router.get('/', (req, res) => {
  res.send('Birds home page')
})
// define the about route
router.get('/about', (req, res) => {
  res.send('About birds')
})
```

If you concatenate Routers and the child routers needs to access the URI parameters of the parent router, you must set `{mergeParams : true}` in the RouterOptions in order to the child Router to receive the root params:

Example: 

```ts
const routerParent : Router = Router(); 
const routerChild : Router = Router(); 

routerParent.use("/game/:gid", exampleFunction()); 
routerParent.use("/game/:gid/genre", routerChild); 

routerChild.get("/:gid", (req, res) =>{
	console.log(req.params.gid);    // undefined
}); 

// By merging params: 

const router = express.Router({ mergeParams: true })

// You get the child router to inherit parameters like gid shown before
```