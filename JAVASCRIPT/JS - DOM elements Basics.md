#JS #DOM #HTML 

## Working with DOM Elements

When working with DOM elements of <span style="color:orange;">HTML</span> from javascript, you can use the methods from `document` class. 

You can create a DOM element by: 
```JS
var newDiv = document.createElement("div"); 
```

|Métodos|Descripción|
|---|---|
|`.createElement(tag, options)`| Create and return the specified element by the `tag`. |
|`.createComment(text)`|Crea y devuelve un nodo de comentarios HTML `<!-- text -->`.|
|`.createTextNode(text)`|Crea y devuelve un nodo HTML con el texto `text`.|
|`.cloneNode(deep)`|Clona el nodo HTML y devuelve una copia. `deep` es **false** por defecto.|
|`.isConnected`|Indica si el nodo HTML está insertado en el documento HTML.|


#### Use `Fragment`


When working with javascript maybe we need to insert a lot of new elements consecutivelly and a way to don't affect the webpage by each single append, we can use `fragments`. 
This let us append use the fragment to append all new content to it and then, once we have finished appending, append the fragment to the `document`. 

```js
const fragment = document.createDocumentFragment();

for (let i = 0; i < 5000; i++) {
  const div = document.createElement("div");
  div.textContent = `Item número ${i}`;
  fragment.appendChild(div);
}

document.body.appendChild(fragment);
```

This doesn't affect the `reflow` of the webpage and makes a huge improvement in performance. 
Fragment has some <span style="color:orange;">special characteristics</span>: 
* Doesn't has father element. Its placed away from the document. 
* Its light weight and more simple than a DOM document. 
* Making changes to it doesn't affect the `reflow` of the webpage. (Repaint of the web). 
* 
#### Clone method

Take into account that when trying to repeat a DOM Element, its not functional to assign the new element to other because is not making a copy, its creating a <span style="color:#ababf5;">reference</span> of the other one: 

```js
const div = document.createElement("div");
div.textContent = "Elemento 1";

const div2 = div;   // iIts NOT making a copy
div2.textContent = "Elemento 2";

div.textContent;  // 'Elemento 2'
```

The correct way of duplicating a DOM element is by using the `cloneNode()`method. 

```js
const div = document.createElement("div");
div.textContent = "Elemento 1";

const div2 = div.cloneNode();   // Ahora SÍ estamos duplicando
div2.textContent = "Elemento 2";

div.textContent;  // 'Elemento 1'
```


#### isConnected() 

This property tells uf if the new element is correctly added inside the DOM structure in the page: 

