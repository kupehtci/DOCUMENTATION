#REACT 

# useReducer

The `useReducer` hook allows for custom state logic that acts similar to `useState`[^1] hook. 

It allows to manage complex state logic in the components as an alternative that is more useful when state implies multiple sub-values or when the next state depends on the previous one. 

The **basic syntax** of the reducer is: 
```tsx
const [state, dispatch] = useReducer(reducer, initialState);
```

The `useReducer(<reducer>,<initial-state>)` accepts two main arguments: 
* `reducer` a function containing the custom logic that determines how the state should be updated. 
* `initialState`: the initial value of your state. 

And will return an array with two items:
* `state`: the current state value. 
* `dispatch` a function used to trigger state updates by actions to the reducer. 


The reducer function receives `state` the current state and `action` that has a `type` property that describes what should happen to the state. Optionally includes a `payload`
with some extra information. 

```tsx
import { useReducer } from 'react'

function reducerFunction(state, action) {
	switch (action.type){
		case 'increment': 
			return { count: state.count + 1}
		case 'decrement': 
			return { count: state.count - 1}
		case 'reset': 
			return { count: 0}
		default: 
			throw new Error(); 
	}
}

function Counter() {
	// pass to the useReducer hook the declared function and the state as an object with count property
	const [state, dispatch] = useReducer(reducerFunction, {count: 0}); 
	
	return (
		<>
			<h1> Counter: {state.count}</h1>
			<button onClick={() => dispatch({type: 'increment'})}>Increment</button>
			<!-- Other buttons or elements -->
		</>
	); 
}
```

When calling the reducer, you only need to pass the `action` argument, as state is automatically passed to the function. 

[^1]: `useState` hook allows to keep an state within a React component. 

