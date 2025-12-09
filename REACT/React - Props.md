#REACT 

# React - Props

As <a href="./React\ -\ Components.md">React Components</a>[^1] are functions, you can pass arguments into the component. This is called Props or Properties. 

When calling that component, you can send the props into it with the same syntax as HTML attributes: 
```tsx
function MyButton(props){
	<button type="button">props.innerText</button>
}


<MyButton innerText="Save" />
```

Each component can have any number of props and each prop can be any data type like string, variable, numbers, strings, objects, arrays and more. 

## Typing props

With default props format, you can pass `props` argument and this argument can have as many children as wanted. 
You can type the props so the properties passed to it will be limited using the `{}` and the properties. 

```tsx

function Cat({name, color}){
	return (
		<h1> Cat {name}</h1>
		<p> The cat {name} its {color}</p>
	); 
}

// Also splitting the properties needed within the component

function Cat(props){
	const {name, color} = props; 

	return (
		<h1> Cat {name}</h1>
		<p> The cat {name} its {color}</p>
	); 
}
```

Also a typed prop can have a **default value**, meaning that if that properties is not set, it will take the default value: 

```tsx
function Cat({name, color="orange"}){

	return (
		<h1> Cat {name}</h1>
		<p> The cat {name} its {color}</p>
	); 
}
```


[^1]: React components [[React - Components]]