#HTML 

# HTML `<picture>` element

In HTML, `<picture>` element can be use to define an image with more than one source and fallback element. 

This element can be used in exchange of `<img>` for cases that we want to define different sources depending on a media query [[HTML - Media queries]]. 

Also we can set different image resolutions for the different devices. 


### Structure

Each image source need to be defined by using `<source>` tag within the element. 

We can also define an optional `<img>` parameter to provide fallback compatibility in case that source url's specified cannot be accessed. 

Example: 

```html
<picture>
<!-- Image wil change depending on orientation -->
  <source srcset="/img/surfer-240.jpg" media="(orientation: portrait)" />
  <img src="/img/painted-hand-298-332.jpg" alt="" />
</picture>
```




