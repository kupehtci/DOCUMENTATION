#REACT 

# useMemo

The `useMemo` hook stores a memoized[^1] value, so stores the result of an expression (A value) and only re-compute the expression when one of the dependencies of the dependency array changes. 

In case that the dependency value didn't change in a re-render of the element, the function calls are skipped and replaced with the previously stored result. 

This is meant to avoid re-running expensive computations on re-renders of the components when an state changes. 

The basic syntax of the `useMemo` hook is:
```tsx
import { useMemo } from 'react'
// instead of const value = heavyCompute(a, b)
const value = useMemo(() => heavyCompute(a, b), [a, b]);
```

Calling it with the following arguments: 
* A function whose result is memoized
* An array of dependencies that is one changes it will re-execute the function. 


[^1]: A memoized is a technique for saving computation costs by storing a function or a value result of an execution cached. 


