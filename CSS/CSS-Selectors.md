#CSS 

The `selector` are used to find data within an HTML document. 

We can divide CSS selectors into five categories:

- Simple selectors (select elements based on name, id, class)
- [Combinator selectors](https://www.w3schools.com/css/css_combinators.asp) (select elements based on a specific relationship between them)
- [Pseudo-class selectors](https://www.w3schools.com/css/css_pseudo_classes.asp) (select elements based on a certain state)
- [Pseudo-elements selectors](https://www.w3schools.com/css/css_pseudo_elements.asp) (select and style a part of an element)
- [Attribute selectors](https://www.w3schools.com/css/css_attribute_selectors.asp) (select elements based on an attribute or attribute value)

```CSS
	/*Select all <p> items*/
	p{
		font-size: 2rem; 
		color: white; 
	}
```

If we want to differ between items of the same tag, we can assign them a class or an id and the tag can be selected differently if its a class or an id:  [[HTML-Class or id]]

If its an class, just use a point before the class name: 

```CSS 
	.title-class{
		background-color: rgb(255,255,255); 
	}
```

And you can differenciate depending of the primitive tag: 

```CSS
	p .first{
		color: rgb(128,0,255); 
		text-align: center; 
	}
```
In this case, only `<p>` elements with the class ="center" would be affected. 


If its a **id**, use the `#` symbol to select the item: 

```CSS
	#title-id{
		background-color: rgb(125,255,0); 
	}
```


### GROUPS

To assign different tags same properties we can group them in a selector: 

```CSS 
	h1, h2, li{
		font-weight: bold; 
		color: blue; 
	}
```

And you can also group classes and ids, not only primitive tags :

```CSS
	.title, .container-info{
		border: 1px solid black; 
		border-radius: 0.5rem; 
	}
	#title, #container-info{
		border: 1px solid black; 
		border-radius: 0.5rem; 
	}
```

### UNIVERSAL SELECTOR

If we want to apply certain properties to all document items, we can select all by using the `*` item: 

``` CSS
	*{
		text-align: center; 
		color: black; 
	}
```