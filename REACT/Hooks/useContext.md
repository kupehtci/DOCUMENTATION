#REACT 

# useContext

The `useContext` react hooks allows to manage the context of the application[^1]. 

To create a context, `import { createContext, useContext } from 'react'`. 

Context workflow works as follows: 

1. A top level parent must create the context: 
```tsx
import { useState, createContext, useContext } from 'react'; 

const ThemeContext = createContext(); 
```

2. The child or nested elements that should have access to the context must be wrapped within the Provider of the context: 
```tsx
function ComponentA() {
	const [theme, setTheme] = useState("light"); 
	
	return (
		<UserContext.Provider value={theme}>
			<h1>My WebPage</h1>
			<!-- Other components that have access to the context-->
			<ComponentB />
		</UserContext.Provider>
	); 
}
```

3. Nested components from the Provider can have access to the context using `useContext()` hook: 
```tsx
function ComponentB() {
	const theme = useContext(ThemeContext); 
	
	return (
		<p>The theme settled in context is {theme}</p>
	); 
}
```

> Note! in case that the nested components or other components that use or set the context **are in other files** than the context initial creation, the context should be exported[^2]. 




[^1]: Context is the global state of the application. Can be used to store data or properties that various components can access to. [[React Context]]. 
[^2]: ES Modules exports: [[React - Import and Export]]