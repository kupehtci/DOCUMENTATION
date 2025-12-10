#REACT 

# useQuery

`useQuery` is normally used for data fetching in react to cache and manage the UI accordingly to API fetch query states.

The `useQuery` hook subscriber the component to a cached data identified by `queryKey` and automatically handles the fetching, catching, refetching and re-render of the component based on the query. 

A basic syntax for the hook is: 

```tsx
import { useQuery } from '@tanstack/react-query'; 

const fetchProducts = async () => {
	// function to fetch the products
}; 

function ProductsList() {
	const {data, isLoading, error} = useQuery({
		queryKey: ['products'],
		queryFn: fetchProducts, 
	}); 
	if(isLoading){
		return (
		<div>Loading...</div>
		); 
	}
	else if(error){
		return (
			<div>Error: {error.message}</div>
		); 
	}
	
	return (
	<ul>
		{data.map(product => <li key={product.id}>{product.name})}
	</ul>
	); 
}
```

