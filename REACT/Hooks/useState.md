#REACT 

# useState

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