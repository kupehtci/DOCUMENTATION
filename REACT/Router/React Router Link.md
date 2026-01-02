#REACT #REACT_ROUTER

# React Router Link

The `<Link />` is a react component from `react-router-dom` ([[React Router]]) used to change the URL without reloading the full page. It returns an `<a>` () element that will redirect to the `to` property defined. 

Example of its usage: 

```ts
import { Router, Routes, Route, Link } from 'react-router-dom'
import Home from './views/Home'
import About from './views/About'

function App() {
return (
	<Router>
		<nav>
			<Link to='/'>Home</Link>
			<Link to='/about'>About</Link>
		</nav>
		
		<Routes>
			<Route path='/' element={<Home />} />
			<Route path='/about' element={<About />} />
		</Routes>
	</Router>
); 
}
```

Properties
* `to` the path to where the link should navigate to. 
* `replace` (Optional) replaces the current history instead of pushing a new one. The current page is entirely replaced. 
* `state` (Optional) passes optional data to the destination route without exposing it in the URL. The data passed can be accessed using the `useLocation` hook in the target component

```ts
// Sending component
<Link to="/user" state={{ from: '/home' }}>
  Next Step
</Link>

// Receiving component
import { useLocation } from 'react-router-dom';

function Profile() {
  const location = useLocation();
  const { from } = location.state;
  
  <Link to={from}>Return</Link>
}
```

* `relative` indicates how relative paths are resolved. It accepts: 
	* `'route'`: (default) indicates that the relative path is resolved to the route hierarchy defined within the `<BrowserRouter>` element. 
	* `'path'`: resolves the relative routes relative to the URL path segment. 

```typescript
<Link to='..' relative='path'>Parent path</Link>
<Link to='..' relative='route'>Parent route</Link>
```

* `reloadDocument` forces a full page reload instead of a client-side navigation. It bypass the React Router SPA default behaviour. 