## CSS Media queries

The media queries allows css to apply certain styles depending on certain conditions that are commonly depending on the type of device or web browser: 

This allows to apply certain styles only if the declared conditions are meted. 

##### FORMAT

The condition need to follow the`@media` tag, similar to an if condition. 
And inside the media tag with the condition, the different styles that will be applied if the condition is meet. 
```css
@media <condition>{
	<tag>{
	
	}
}
```

Example: 

```css
/* This background will be blue if the screen is less than 600px wide */
@media only screen and (max-width: 600px) {  
	body {    
		background-color: lightblue;  
	}
}
```

### RESOLUTION

The resolution can be checked with the conditions `min-width` and `max-width` that can define the width of the screen at this time: 

The most common resolutions are: 

```css
/* Extra small devices */  
@media only screen and (max-width: 600px) {...}  
  
/* Small devices like mobile phones or tablets in portrait */
@media only screen and (min-width: 600px) {...}  
  
/* Medium devices like tablets in landscape mode*/ 
@media only screen and (min-width: 768px) {...}  
  
/* laptops or desktop screens */  
@media only screen and (min-width: 992px) {...}  
  
/* Large laptops or desktop screens*/  
@media only screen and (min-width: 1200px) {...}
```

### ORIENTATION

The orientation of the device can also be a condition for certain styles: 

```css
@media only screen and (orientation: landscape){
	/* Some style here */
}
```


### OTHER IMPLEMENTATIONS

Media queries can also be set for different elements via HTML [[]]or Javascript