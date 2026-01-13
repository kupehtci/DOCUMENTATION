#powershell 

# Invoke-WebRequest

`Invoke-WebRequest` is a PowerShell ([[PowerShell]]) cmdlet ([[cmdlet]]) that send an HTTP, HTTPs, FTP or FILE request to an Uri[^3]. 

`Invoke-WebRequest` retrieves the web content and parses the response containing all the HTML. 
It also supports all HTTP methods ([[API REST - HTTP Methods]]) like GET, POST, PUT and DELETE. 

Its useful for: 
* Check API interactions
* File downloads
* Web Scrapping
* Form submission using POST. 
* Session management for maintaining stateful connections with cookies and credentials. 

The basic syntax of the command is: 
```powershell
Invoke-WebRequest -Uri "url" [-Method <string>] [-Headers <hashtable>] [-Body <string>] [-OutFile <string>]
```

* **Uri**: URL of the web resource. 
* **Method**: HTTP method to use
* **Headers**: hashtable of the HTTP headers to send with the request. 
```powershell
# Hashtable
@{'Accept' = 'application/json'; 'X-My-Header' = 'Hello World'}
```
* **Body**: data to be send with the request in the body. 
* **OutFile**: saves the response to a file instead of prompting it to the CMD. 

Response can also be stored into a variable: 
```powershell
$Response = Invoke-WebRequest -Uri "https://url.com"
```

Its similar to the Unix / Linux command `curl` ([[curl]]). 



[^3]: URI or Universal Resource Identifier: [[URI]]



