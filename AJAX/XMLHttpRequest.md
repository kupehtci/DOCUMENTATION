#AJAX 

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
* 200: "OK"  
* 403: "Forbidden"  
* 404: "Not Found"