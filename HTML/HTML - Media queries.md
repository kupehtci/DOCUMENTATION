#HTML #CSS 
## HTML Media property

Like in CSS [[CSS - Media queries]], we can set some conditions relative to device characteristics that can condition the appearance or if an element appears or not: 

We can set a condition for an element to appear by the `media=` property: 

```html
<!-- Change the title depending on the device screen resolution -->
<body>
	<h1 media="(min-width: 601px)">This is a title for desktop</h1>
	<h1 media="(max-width: 600px)">This is a title for Mobile devices</h1>
</body>
```


Another example can be to change an image depending on the device: 

```html
<picture>  
  <source srcset="img_smallflower.jpg" media="(max-width: 400px)">  
  <source srcset="img_flowers.jpg">  
  <img src="img_flowers.jpg" alt="Flowers">  
</picture>
```

Remember that if you use `<picture>` html element, also add an `<img>` within it for the devices that doesn't support `<picture>`. 