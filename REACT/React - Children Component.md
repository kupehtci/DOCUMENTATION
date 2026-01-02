#REACT 

# React - Passing Children into a component

In the DOM [[JS - DOM elements Basics]], a children is an HTML element or React in this case that is under one parent element hierarchy (Between opening an closing tags). 

In React, every component has a single **props** object as its argument that contains all the children elements placed within the opening and closing tags of it. 

This children can be a string, single or multiple HTML or React element or even a function. 

If the props of the component contains `{children, ...}`, you can access them within the component, use the component as a container of them. 

Example: 

```typescript
// creates a wrapper class between the children
function Wrapper({children}){
	return (
		<div className='wrapper'>{children}</div>
	); 
}

// You call the class and assign the children
<Wrapper>
	<h1>Title</h1>
	<p>Hello world from inside the Wrapper<p>
	<Button>Click on me </Button>
</Wrapper>
```

You can also use **interface defined props** together with other properties (`children` is React.ReactNode): 

```typescript
interface WrapperProps{
	label: string; 
	children: React.ReactNode;
}

// creates a wrapper class between the children
function Wrapper({children}){
	return (
		<>
		<h1>{label}</h1>
		<div className='wrapper'>{children}</div>
		</>
	); 
}

// You call the class and assign the children
<Wrapper>
	<h1>Title</h1>
	<p>Hello world from inside the Wrapper<p>
	<Button>Click on me </Button>
</Wrapper>
```