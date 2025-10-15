#JS #HTML 

Javascript is meant to use in combination with HTML for web development

### Javascript in HTML

To use directly code in javascript embended in the web, can be done by the `<script></script>`tags. 
```HTML
<script>  
document.getElementById("demo").innerHTML = "Hello JavaScript!";  
</script>
```

Another way is by having an external Javascript code in a `.js`file and link it inside the HTMl. 
For doing that use the `<script>` tag with the `src` property. 

```HTML
<script type="text/javascript" src='./utils/ajax/request_product.js'></script>
```
### Where to place \<script\>

The location of the script changes completelly the invocation of the code. 

| Location | How it gets downloaded? | State of the webpage |
| ---- | ---- | ---- |
| In `<head>` | **BEFORE** starting to draw the page | Page not draw yet |
| In `<body>` | **WHILE** the drawing | Draw until the tag `<script>`. |
| Before `</body>` | **AFTER** drawing the page | 100% drawn |

If we want to be executed before the webpage gets show, needs to be placed in the `<head>`

This need to be taken into account because if want to use `document.getElementById(elementId); ` to query select an element or another `querySelector`, this need to be declared before the script execution. 

This happens because it gets the page content that its rendered until the script execution. 
