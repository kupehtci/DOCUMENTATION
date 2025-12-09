#REACT 

# React - Lists

Using JavaScript or TypeScript arrays or lists allow to keep the data in an structured set and work with them in conjunction. 

The core pattern in React is to keep the data in an array and transform it to an JSX using `map` function. 

```tsx
function Fruits(){
	const fruitList = ['Apple', 'Pineapple', 'Watermelon']; 
	
	return (
		<>
			<h1>List of Fruits</h1>
			<ul>
				{fruitList.map((fruit) => {<li>{ fruit }</li>}}
			</ul>
		</>
	)
}
```

## Keys

As React use independent component to re-render single elements, list' items needs to have an unique key so it can check old and new element efficiently so it decide what to update instead of re-rendering the whole list items. 

If you omit the keys, React may show a warning indicating *"Each child in a list should have a unique ‘key’ prop."*

You can solve this by passing a `key` prop to each JSX element that is returned within the `map` or the list: 

```tsx
const fruitList = [
	{id: 01, name: 'Apple'},
	{id: 01, name: 'Pineapple'}, 
	{id: 01, name: 'Watermelon'}
]; 

return (
	<ul>
		{fruitList.map((fruit) => {
			<li key={ fruit.id }>{ fruit.name }</li>
		})}
	</ul>
); 
```

And in cases that you have simple values and **each value is unique**, you can use the item content as the key without including extra information in each list element: 

```tsx
function Fruits(){
	const fruitList = ['Apple', 'Pineapple', 'Watermelon']; 
	
	return (
		<>
			<h1>List of Fruits</h1>
			<ul>
				{fruitList.map((fruit) => {
					<li key={fruit}>{ fruit }</li>
				}}
			</ul>
		</>
	)
}
```

Or in case that the list is static and wont be reordered or filtered, you can avoid indexes using the same array index as the `key`: 

```tsx
function Fruits(){
	const fruitList = ['Apple', 'Pineapple', 'Watermelon']; 
	
	return (
		<>
			<h1>List of Fruits</h1>
			<ul>
				{fruitList.map((fruit, index) => {
					<li key={index}>{ fruit }</li>
				}}
			</ul>
		</>
	)
}
```

> Note: in case the list gets reordered or filtered it won't work correctly, as the list items can appear attached to the wrong index or position in the list. 