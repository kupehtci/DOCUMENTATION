#REACT 

# React Lazy Loading

Lazy loading is a performance optimization technique where a component is only loaded when its actually needed instead loading all the resources at the initial page load. 

This reduces the initial loading time and speeds up the first render of the webpage. 

The **core idea** behind Lazy Loading in React is to split the code into chunks and deferring the download of non-critical chunks until a user navigates to that view or do an specific action. 

# Suspense

`<Suspense />` component allows to wait for an asynchronous component or to only render a component when its needed by displaying a lightweight component until the component is loaded. 

It allows to mark the component tree as its not loaded yet until the async resource is loaded. It will render the `fallback` specified until **everything** in the bundle is ready. 

The basic syntax of `<Suspense />` is: 

```tsx
import {lazy, Suspense} from 'react';

const products
```




Lazy Loading **is not limited to** `React.lazy()`, as `<Suspense />` can be used with **any component that 'suspends' so it returns a Promise** to indicate that has not loaded yet: 
* Regular slow components won't trigger a Suspense: 
	* Data fetching using `useEffect` hook doesn't activate suspense
	* Event handlers also doesn't trigger suspense. 
You need to manually throw a *Promise* in order to indicate that the data is not ready yet. 

```jsx
function fetchData() {
	let status = 'pending'; 
	let promise = null; 
	let data = null; 

  if (status === 'pending') {
    if (!promise) {
      promise = fetch('/api/products')
        .then(res => res.json())
        .then(obData => {
          status = 'success';
          data = obData;
        });
    }
    // This throw triggers the suspense. Cannot use await suggar syntax
    throw promise; 
  }
  return cache.data;
}
```


## React.lazy()

`React.lazy()` allows to load a React component on demand instead of just bundling the component directly into the initial javascript. 

This reduces the initial Javascript file and improve the load performance of larger apps. 

To make a component lazy loaded and only render it when its visualized it needs to be imported using `React.lazy(...)`, function so its bundled independently. 

`React.lazy` is a helper that will return a *dynamic import* into a React component that will be fetched when its first rendered. This component needs to be within a `<Suspense />` component that "suspends" the component until the network request of that dynamic component finishes. 

