#JS 

## Javascript media queries

Javascript media queries are similar to CSS ones [[CSS - Media queries]] where you can check conditions related to the device or web browser characteristics. 

The format to retrieve this values is: 

```js
mql = window.matchMedia(mediaQueryString); 
```

By making a media query we can retrieve a **Media query List**. 

Example: 
```
if (window.matchMedia("(min-width: 400px)").matches) {
  // Screen has at least 400 pixel wide
} else {
  // Screen width is less than 400 pixels
}
```

