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

## Typed interface

You can also use an `interface` for defining the props that an object can have. 

For this, create an `interface` with the attributes that you want to be passed into the component: 
```ts
interface ComponentProps{  
    attribute1: type;  
    // attribute2: type; 
    // ...
}  
```

And then, pass the class as `props`: 

```ts
function Component(props: ComponentProps){
	return(
		<>
			<p>{props.text}</p>
		</>
	); 
}
```

As an example: 

```ts
interface DropdownProps{  
    label: string;  
    children: React.ReactNode;  
}  
  
function Dropdown(props: DropdownProps){  
    const [isOpen, SetOpen] = useState(false);  
  
    return (  
        <li>  
            <button onClick={() => SetOpen(!isOpen)}>  
               {props.label}  
            </button>  
            {isOpen && props.children}  
        </li>  
    );  
}

// In other file, call the component such as: 
<Dropdown label="Options">
	<ul>
		<li>Dark theme</li>
		<li>Light theme</li>
	</ul>
</Dropdown>
```

You can also deconstruct the `props` within the `Component` arguments, for a cleaner code without using the `props` argument: 

```ts
function Dropdown({label, children}: DropdownProps){
	const [isOpen, SetOpen] = useState(false);  
  
    return (  
        <li>  
            <button onClick={() => SetOpen(!isOpen)}>  
               {label}  // Instead of props.label
            </button>  
            {isOpen && children}   // Instead of props.children
        </li>  
    );  
}
```


[^1]: React components [[React - Components]]