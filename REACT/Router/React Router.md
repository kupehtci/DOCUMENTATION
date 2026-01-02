#REACT

# React Router

**React Router** is a react ecosystem's library that allows dynamic routing of componentes based on URL changes in the React App. 

Unlike multi-page normal websites, the router provides view updates without reloading the webpage. 

It provides: 
* You define the navigation using `<Routes>` and `<Route>` API. 
* Powerful navigation hooks like `useNavigate`, `useLocation` and `useParams`. 
* Support for code splitting and lazy loading. 

Eliminates the need to reload the page

## How to set up React Router

First, install the react router dom, the package to enabling new routing features: 
```bash
npm install react-router-dom
```

Now, in order to manage the routing, wrap the application within the `<BrowserRouter />` component just like: 

```ts
import { BrowserRouter } from ‘react-router-dom’;

function App() {
  return (
    <BrowserRouter>
      {/* Routes will go here */}
    </BrowserRouter>
  );
}
```

This configuration will handle the necessary context for managing and handling all the URL changes and update the views dynamically on navigation events. 

### Define routes

Once you have `BrowserRouter` settled up properly, you can create basic routes using `Routes` and `Route` components to map certain paths to certain components: 

```ts
import { Routes, Route } from ‘react-router-dom’;
import Home from ‘./Home’;

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path=”/” element={<Home />} />
      </Routes>
    </BrowserRouter>
  );
}
```

All the routes will have the format: 
```ts
<Route path"/path/to/" element={ <Component />} />
```

Meaning that going to the URL `/path/to` will render `<Component />` component. 

You can also do relative routing meaning that child items have a route path relative to the parent's path: 
```ts
// In this case, <Company /> component is under /about/company
<BrowserRouter>
	<Routes>
		<Route path="about" element={<About />}>
			<Route path="company" element={<Company />} />
		</Route>
	</Routes>
</BrowserRouter>
```

### Nested routes

Nested Routes allow to build complex routing where the parent and the child items coexist. 

For implementing nested routes, use the `Outlet` component as a placeholder for where the child routes will be. This will allow to render child components within the parent component. 

In parent component: 
```ts
import { Outlet } from 'react-router-dom'

function Parent() {
	return (
		<div>
			<h2>Parent</h2>
			<Outlet />
		</div>
	)
}
```

And in the routes: 
```ts
<Routes>
  <Route path=”parent” element={<Parent />}>
    <Route path=”settings” element={<Settings />} />
  </Route>
</Routes>
```

This nested routes are **essential** for maintaining layout over the application. 

## Navigate to other React routes

You should use the `Link` ([[React Router Link]]) component from `react-router-dom` and set the `to` property accordingly to the wanted route you want to navigate to: 

# Hooks

**Hooks** are functions that can be called inside a react function to read the router state like the current URL or params.

React Router offer a set of hooks for interacting with the router: 
* `useNavigate()` returns a function that can be called to navigate to another path or go back. 
* `useLocation()` gives the location object with the current pathname,s earch and hash to react to certain URL changes. 
* `useParams()` matches the URL against a pattern and return mach data. 


## `useParams()`

`useParams()`  its used to read dynamic path parameters placed in the URL like `:id` or `:user` from the current URL from inside a component. 

When you define a route with a placeholder like `/users/:userId` and call a component, this component can call `useParams()` to retrieve that `:userId` from the URL. 

```typescript
import {useParams} from 'react-router-dom'

function mComponent() {
	const { userId } = useParams(); //useParams is equal to { userId=... }
	
}

<BrowserRouter>
	<Route path='/users/:userId' element={<mComponent />}>
</BrowserRouter>
```

## `useNavigate()`

The `useNavigate()` hook provides a method to do programmatic redirection to a path in the application. 

```
import {useNavigate} from 'react-router-dom'