#REACT 

# React - Events

React has the same events as HTML that react based on user events, like click, change, mouseover and others. 

This events are written in camelCase syntax instead of plain text like `onClick` instead of `onclick` and the React event handlers need to be written in between `{}`: 

```tsx

function Document(){
	const save = () => {
		alert("Document has been saved"); 
	}
	
	return(
		<button onClick={save}>Save the document</button>
	); 
}
```



