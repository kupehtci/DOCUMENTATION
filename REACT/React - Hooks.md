#REACT 

# React - Hooks

A **hook** in react allows a function to have access to an state and other features of React without using `React Classes`. 

The hooks in order to be used need to be imported from `'react'` like `import { useState } from 'react'`. 

Take into account that: 
* Hooks can only be called inside React `function` components and at the top level.
* Cannot be conditional or within an `if` statement. 

There are several react `hooks`: 

* `useState` allows to tract an state in a function component. 
	* state is referred to data or properties that can be tracked along the application runtime. 
* `useEffect`
* `useContext`
* `useRef`
* `useReducer`
* `useCallback`
* `useMemo`
* Custom Hooks


## `useState`

The `useState` hook stores the state (Data or properties) of a component. It needs to be initialized as follows: 

```txt
const [<state-name>, <function-to-update>] = useState("<default-value>")
```

* State name or the name of the variable or prop. 
	* Call the state name to read the value. 
* Name of the function to update the state
	* Call the function to update the value of the state
* Default or initial value of the state. 

It can store any kind of JavaScript / TypeScript data type, even arrays or objects. 

When the **state of a component is updated**, React schedules a **re-render** of the component and normally its children and updates the DOM where the state has changed. 

## `useEffect`

The `useEffect` hook allows to perform side effects or executions in the component, like fetching data or update the DOM. 

Is called with two arguments: `useEffect(<function>, <dependency>)`
* Function that is called as a side effect. 
* Dependency is an array that tells to React when to re-run the effect. 
	* No dependency will re-execute the effect on each render. 
	* An empty array `[]` tells react to only render once at the initial render. 
	* An array with dependency variables will re-execute any time one of this variable changes. 

The `useEffect` inner content will run on each render of the component by default. Meaning that if the component state is changed (`useState`), it will call again `useEffect`. 

## `useContext`

React Context

## `useRef`


## `useReducer`


## `useCallback`


## `useMemo`


%%TODO%%