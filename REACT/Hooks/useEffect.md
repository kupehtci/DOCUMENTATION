#REACT 

# useEffect

The `useEffect` hook allows to perform side effects or executions in the component, like fetching data or update the DOM. 

Is called with two arguments: `useEffect(<function>, <dependency>)`
* Function that is called as a side effect. 
* Dependency is an array that tells to React when to re-run the effect. 
	* No dependency will re-execute the effect on each render. 
	* An empty array `[]` tells react to only render once at the initial render. 
	* An array with dependency variables will re-execute any time one of this variable changes. 

The `useEffect` inner content will run on each render of the component by default. Meaning that if the component state is changed (`useState`), it will call again `useEffect`. 

