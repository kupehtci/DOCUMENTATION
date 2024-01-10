 #AJAX 

## TYPES OF REQUEST 

The request can be send in a GET or POST Request method. 
This can be done this way. 

GET Example: 
```JS
var xhr = new XmlHttpRequest();
xhr.onreadystatechange = () => {
	if(xhr.readyState !== 4) {return; }
	if(xhr.status !== 200){  
	    alert('Error Code: ' +  req.status);  
	    alert('Error Message: ' + req.statusText);  
	    return;  
	}
	// Code goes here for recieving the completed state 
}
let data = "some_data"; 
xhr.open('GET', 'get_data.php?data='+data); 
xhr.send(); 
```

POST Example: 
```JS
var http = new XMLHttpRequest();
var params = 'orem=ipsum&name=binny';
http.open('POST', 'get_data.php', true);

//Send the proper header information along with the request
http.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');

http.onreadystatechange = function() {//Call a function when the state changes.
    if(http.readyState == 4 && http.status == 200) {
        alert(http.responseText);
    }
}
http.send(params);
```

Also if we have an object, its parameters can be concatenated into a `params` format by doing: 
By turning the data object into an array of URL-encoded key/value pairs.

```JS
var params = new Object();
params.myparam1 = myval1;
params.myparam2 = myval2;

let urlEncodedData = "", urlEncodedDataPairs = [], name;
for( name in params ) {
 urlEncodedDataPairs.push(encodeURIComponent(name)+'='+encodeURIComponent(params[name]));
}
```

## Properties

### readyState

Holds the status of the XMLHttpRequest.  
	0: request not initialized   
	1: server connection established  
	2: request received   
	3: processing request   
	4: request finished and response is ready

The different states: 

```CSHARP 
ajaxRequest.onreadystatechange = function(){
	if(ajaxRequest.readyState == 1){
		console.log("Established server connection.");
	}
	else if(ajaxRequest.readyState == 2){
		console.log("Request received by server.");
	}
	else if(ajaxRequest.readyState == 3){
		console.log("Processing request.");
	}
	else if(ajaxRequest.readyState == 4){
		console.log("Done loading!");
	}
	else{
		console.log("Something went wrong. :(");
	}
}
```
### onreadystatechange

Function called when readyState property changes. 

### status 

Returns the status-number of a request  made asynchronous. 
* 200: "OK"  send when data is fetched correctly and get the return. 
* 403: "Forbidden"  unable to fetch data because access is blocked. 
* 404: "Not Found" didn't found or unable to reach the url. 

