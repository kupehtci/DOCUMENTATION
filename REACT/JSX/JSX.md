#REACT 

# JSX

JSX its Javascript XML that allows to write HTML directly in react. 

It allows to write HTML elements in Javascript and place them in the DOOM directly using the Root. 

```js
// With JSX
const myElement = <h1>I Love JSX!</h1>;

createRoot(document.getElementById('root')).render(
  myElement
);

// WIthout JSX (Some sort of vanilla JS) 
const myElement = React.createElement('h1', {}, 'I do not use JSX!');

createRoot(document.getElementById('root')).render(
  myElement
);
```

All the HTML code must be wrapped in only **one top level statement or HTML element**, so multiple elements can only be stores within a `<div>` or an empty fragment `<></>` (Avoid adding extra elements to the DOM tree). 

Also, larger HTML blocks can be inserted using parentheses: 
```jsx
const myShoopingList = (
	<ul>
		<li>Bread</li>
		<li>Bananas</li>
	</ul>
); 
```

## Expressions 

In JSX you can write **expressions**, that are a React variable, property or any other JS expression that will be executed in the JSX and returned the result: 

```js
const mElement = <p>The sum of 5 + 5 is { 5 + 5 }</p>
```

## Elements

A JSX element is an HTML element but in XML format. Its like traditional HTML but allow to close elements using `<Element />` instead of just only the opening and closing statement `<Element> </Element>`: 

```jsx
const mImg = <img src="assets/daniel.jpg" />
```

JSX elements can have the same attributes as HTML elements like `onClick` or `id` with the only exception of `class` that because JSX is rendered in Javascript and `class` is a reserved word, its named as `className`: 

```jsx
const mHeader = <h1 className="header">My title</h1>
```

Also, `style` attribute that define the style in CSS of an HTML component, in JSX accepts an Javascript object with camelCase CSS properties like `backgroundColor` instead of `background-color`. 
