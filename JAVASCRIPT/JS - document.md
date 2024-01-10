#JS #HTML 

## <span style='color:#ababf5;'>document</span> class

This class let you access the <span style="color:#abf5ab;">HTML document</span> that calls the javascript and can be used to acess any element in the web's DOM 

Take into account that if you want to interact with the document elements from javascript, this elements need to be declared. 
`<script>` placement is explained in [[JS - HTML implementation]] Where to place \<script\>. 


## Query Selectors

To be able to manipulate the DOM of HTML document, a reference to an HTMLElement need to be obtained from it. 

This can be done by: 

| document.getElementById(_id_) | Find an element by element id |
| ---- | ---- |
| document.getElementsByTagName(_name_) | Find elements by tag name |
| document.getElementsByClassName(_name_) | Find elements by class name |

## Alter HTML Elements


|Property|Description|
|---|---|
|_element_.innerHTML =  _new html content_|Change the inner HTML of an element|
|_element_._attribute = new value_|Change the attribute value of an HTML element|
|_element_.style._property = new style_|Change the style of an HTML element|
|Method|Description|
|_element_.setAttribute_(attribute, value)_|Change the attribute value of an HTML element|

## Add and delete items

|Method|Description|
|---|---|
|document.createElement(_element_)|Create an HTML element|
|document.removeChild(_element_)|Remove an HTML element|
|document.appendChild(_element_)|Add an HTML element|
|document.replaceChild(_new, old_)|Replace an HTML element|
|document.write(_text_)|Write into the HTML output stream|


## Change Event Handlers

|Method|Description|
|---|---|
|document.getElementById(_id_).onclick = function(){_code_}|Adding event handler code to an onclick event|