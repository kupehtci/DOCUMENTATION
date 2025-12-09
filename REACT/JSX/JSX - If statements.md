#REACT 

# JSX - If statements

React supports `if` conditional statements but cannot be inside the JSX element. (Within the return (...)) . 

So `if` conditions can be defined in different formats:

* The `if` statement within the function: 

```ts
function Counter() {
	const a = 5; 
	b = "Is superior than 5"
	if(a <= 5){
		b = "Is less or equal to 5"
	}

	return (
		<p>The number a {b}</p>
	); 
}
```

* Using a **ternary expression**: 

```ts
function Counter() {
	const a = 5; 

	return (
		<p>The number a {b <= 5 ? "Is less or equal to 5" : "Is superior than 5"}</p>
	); 
}
```

* Using the **return statement**: 

```tsx
function Counter() {
	const a = 5; 

	if(a <= 5){
		return (
			<p>The number a is less or equal to 5</p>
		); 
	}
	else{
		return (
			<p>The number a is superior than 5</p>
		); 
	}
}
```