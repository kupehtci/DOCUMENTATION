#REACT 

# React - Import and Export

In React is commonly used the standard ES module exports and imports to pass components, functions and other code between files. 

You can choose between named and default exports: 

* **Named exports** allows to export several things from one file and must be imported using the same name using curly braces. 
```tsx
export const Button = () => {}

// In another file
import {Button} from "./Button"; 
```

* **Default exports** export a single main value per file and then can be imported with another name. 
```tsx
export const Button = () => {}

export default Button; 

import Button from "./Button"; 
```


The standard is to use **named exports** when you have multiple exports per file and **default exports** when having a single component per file (reusability). 

