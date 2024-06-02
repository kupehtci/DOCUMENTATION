#JS #CSS 

### Javascript Style

By using Javascript you can change the style of an HTMLElement queried. 

You can assign new style to the element by using the `style` property of an `HTMLElement`. 
```js
var htmlelement = document.querySelector('example'); 
htmlelemtent.style="color: DodgerBlue; display: block; "
```

Also you can restart the style map to the default assigned by CSS by clearing the <span style="color:MediumSlateBlue;">attribute style map</span>. 
```js
let enrollButton = document.querySelector('#enroll-button'); 

enrollButton.style="color: grey; background-color: white;"

enrollButton.attributeStyleMap.clear();   // reset new style
```