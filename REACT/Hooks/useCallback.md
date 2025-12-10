#REACT 

# useCallback

The `useCallback` hook allows to memoize[^1] a function so React uses the same function instance between renders unless the dependencies passed to the callback changes. 

The basic syntax of `useCallback` is: 
```tsx
import { useCallback } from 'react'
const memoizedFn = useCallback(
	(parameters) => {
	
	},
	[dep1, dep2, ...]
)
```

Having as parameters: 
* The callback function to memoize. 
* An array of dependencies that on change will force callback function to be recreated. 

React compiler automatically memoizes the values and functions to reduce the need for manual `useCallback` but you can still use this function to force memoization automatically. 

Example: 
```tsx
import { useCallback } from 'react'

function MyComponent() {
	const [count, setCount] = useState(0)
	
	const handleClick = useCallback( () => {
		console.log("Button clicked, the count is: ", count); 
	}, [count]); 

	return (
		<button onClick={handleClick}>Click</button> 
	); 
}
```

In this case, the function will only be processed again if count changes, if other prop or state of the component changes it won't be re-calculated. 

This case is so much simpler but can help to improve an application performance like for exampling caching the result of a get() request over an API. 


## useCallback vs useMemo

`useCallback` is similar to `useMemo` callback with the difference that `useCallback` stores a memoized function and `useMemo` stores a memoized value. 




[^1]: Memoize is a technique for storing pre-calculated values for expensive operations. [[Memoize]]

