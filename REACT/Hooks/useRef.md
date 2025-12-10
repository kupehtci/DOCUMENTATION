#REACT 

# useRef

The `useRef` hooks allows to persist some values between renders of a component. 
It stores a mutable value that can be changed without causing a re-render of the component. 

The `useRef()` returns an object called current, for example: 
```tsx
const counter = useRef(0)

// counter = {current: 0}
```

It is normally used to store DOM elements for direct manipulation of them. As making a change to them won't trigger a re-render of the component. 

Also another use is to store previous values for comparison. 

In order to **attach an element to a ref** you need to use the **`ref` prop** and you will be able to call it using `<ref-var>.current`: 

```tsx
import { useRef } from 'react'

function MyComponent() {
	const inputRef = useRef(null); 
	
	const focusInput = () => {
		inputRef.current.focus(); 
	}; 
	
	return(
		<>
			<input type="text" ref={inputRef} />
			<button onClick={focusInput}>Focus the input</button>
		</>
	); 
}
```


## useState vs useRef

Use `useRef` when you need to track values that should not trigger re-renders when its updated and `useState` for changes that should change the UI or the HTML returned in the element. 

