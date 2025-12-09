#REACT 

# React - Components

A **component** within React is an independent section of code that works as a **Javascript / typescript** function but works isolated and need to return HTML in a JSX format. 

The component name must start with a capital letter or Upper case and need tor return HTML code: 
```jsx
function Button() {
	const handleClick = () =>{
		console.log("Button has been clicked"); 
	}; 

	return (
		<button type="button" onClick={handleClick}>
			Click the Button
		</button>
	); 
}
```


Once a component has been created, you can call the component and that will return the HTML code defined there: 

```tsx
function App(){
	return (
		<Button />
	); 
}
```