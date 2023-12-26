#JS #HTMl #DOM 

### Set Attributes

To work with the HTML attributes and modify them when using DOM elements, the way is to modify DOM Element properties: 

```js
const element = document.querySelector("div");   // <div class="container"></div>
element.id = "page";           // <div id="page" class="container"></div>
element.style = "color: red";  // <div id="page" class="container" style="color: red"></div>
element.className = "data";    // <div id="page" class="data" style="color: red"></div>
```

### Check and get Attributes

We can still use the same properties to get the `attributes`like this: 

```JS
var divId = document.querySelector("div").id; 
```

But we have methos to get the attributes in a more clear and simple way

|Métodos|Descripción|
|---|---|
|`hasAttributes()`|Indica si el elemento tiene atributos HTML.|
|`hasAttribute(attr)`|Indica si el elemento tiene el atributo HTML `attr`.|
|`getAttributeNames()`|Devuelve un  con los atributos del elemento.|
|`getAttribute(attr)`|Devuelve el valor del atributo `attr` del elemento o  si no existe.|


```js
const element = document.querySelector("#page");

element.hasAttributes();              // true (tiene 3 atributos)
element.hasAttribute("data-number");  // true (data-number existe)
element.hasAttribute("disabled");     // false (disabled no existe)

element.getAttributeNames();          // ["id", "data-number", "class"]
element.getAttribute("id");           // "page"
```

### Special case : <span style="color:red;">boolean</span>

In the case of boolean attributes, the ones that in DOM has no value like `disables` cannot be setted by assigning them a true value. 

If we just set that attribute to true, would not work: 

```js
const button = document.querySelector("button");

button.setAttribute("disabled", true);   // ❌ <button disabled="true">Clickme!</button> 
button.disabled = true;                  // ✅ <button disabled>Clickme!</button>
button.setAttribute("disabled", "");     // ✅ <button disabled>Clickme!</button>
```

This attributes can be setted by: 
* Using DOM Element <span style="color:orange;">properties</span>. 
* Setting the atttribute and give it <span style="color:orange;">no value</span> (""). 

### Delete or modify

We also have some methods for modify the attributes or remove it in a safe way. 

|Métodos|Descripción|
|---|---|
|`setAttribute(attr, value)`|Añade o cambia el atributo `attr` al valor `value` del elemento HTML.|
|`toggleAttribute(attr, force)`|Añade atributo `attr` si no existe, si existe lo elimina.|
|`removeAttribute(attr)`|Elimina el atributo `attr` del elemento HTML.|