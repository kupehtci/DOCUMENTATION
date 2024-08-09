#AJAX

## INTRODUCTION



### BASIC CODE STRUCTURE


To make a basic request to ajax asynchronously: 

```JAVASCRIPT
var objXMLHttpRequest = new XMLHttpRequest();
objXMLHttpRequest.onreadystatechange = function() {
  if(objXMLHttpRequest.readyState === 4) {
    if(objXMLHttpRequest.status === 200) {
          alert(objXMLHttpRequest.responseText);
    } else {
          alert('Error Code: ' +  objXMLHttpRequest.status);
          alert('Error Message: ' + objXMLHttpRequest.statusText);
    }
  }
}
objXMLHttpRequest.open('GET', 'request_ajax_data.php');
objXMLHttpRequest.send();
```

1. Primero, inicializamos el objeto XMLHttpRequest, que es responsable de hacer llamadas AJAX.
2. First, we need to initialize the object XMLHttpRequest, that would handle the calls to AJAX. 
3. COnfigure a function that would be called when changing its state. 
4. A state of 4 means that the request has been completed. 
