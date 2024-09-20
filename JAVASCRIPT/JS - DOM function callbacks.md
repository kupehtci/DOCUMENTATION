#JS #HTML 

## DOM Add functions to callbacks 

You can add a javascript function in a newly created element using JS DOM. 

For doing this you can: 
1. Add to `onclick` JS property of element.
2. Add as an attribute


## 1. Add onclick as JS property 


All elements and at least the \<a\> elements and \<button\> can be assigned an `onclick` event callback: 

```JS
let element_a = document.createElement("a"); 
element_a.onclick = function() {console.log("Clicked on <a>"); }; 
```

## 2. Add as an attribute 

The same as we can assign attributes to newly created DOM elements, onclick function can be also assigned as an attribute of the HTML element. 

```JS
let element_a = document.createElement("a"); 
element_a.setAttribute("onclick", "console.log('Clicked on <a<');"); 
```


## 3?. DONT KNOW IF WORKS

```javascript
elemm.addEventListener('click', function(){ alert('blah');}, false);
```

