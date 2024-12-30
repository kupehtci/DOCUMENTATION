#NodeJS 

# NODE JS - API REST - HTTP Methods


These are the nine HTTP methods typically associated with RESTful web development and the HTTP: 

1. GET.
2. PUT.
3. POST.
4. DELETE.
5. PATCH.
6. HEAD.
7. OPTIONS.
8. TRACE.
9. CONNECT.

### GET Method

The most commonly used HTTP method is GET.

The purpose of the GET method is to simply retrieve data from the server. The GET method is used to request any of the following resources:

- A webpage or HTML file.
- An image or video.
- A JSON document.
- A CSS file or JavaScript file.
- An XML file.

The GET request method is said to be a safe operation, which means it should not change the state of any resource on the server.

### POST Method

The POST HTTP request method sends data to the server for processing.

The data sent to the server is typically in the following form:

- Input fields from online forms.
- XML or JSON data.
- Text data from query parameters.

The HTTP specification enables the developer to decide the type of processing for the data sent through an HTTP POST method. Prototypical uses of the POST method include the following:

- Post a message to a bulletin board.
- Save data from HTML forms to a database.
- Calculate a result based on data submitted.

A POST operation is not considered a safe operation, as it has the power to update the state of the server and cause potential side effects to the server’s state when executed.

The HTTP POST method is not required to be idempotent either, which means it can leave data and resources on the server in a different state each time it is invoked.

### HEAD Method

The HTTP HEAD method simply returns metadata about a resource on the server. This HTTP request method returns all of the headers associated with a resource at a given URL, but does not actually return the resource.

The HTTP HEAD method is commonly used to check the following conditions:

- The size of a resource on the server.
- If a resource exists on the server or not.
- The last-modified date of a resource.
- Validity of a cached resource on the server.

The following example shows sample data returned from a HEAD request:

HTTP/1.1 200 OK 
Date: Fri, 19 Aug 2023 12:00:00 GMT 
Content-Type: text/html 
Content-Length: 1234 
Last-Modified: Thu, 18 Aug 2023 15:30:00 GMT

[![safe and idempotent HTTP verbs and methods](https://itknowledgeexchange.techtarget.com/wp-content/uploads/2023/08/safe-vs-idempotent.png)](https://itknowledgeexchange.techtarget.com/wp-content/uploads/2023/08/safe-vs-idempotent.png)

Most HTTP request methods are safe and idempotent.

## Version 1.1 HTTP request methods

Version 1.1 of the Hypertext Transfer Protocol introduced five new HTTP verbs:

1. PUT.
2. DELETE.
3. OPTIONS.
4. TRACE.
5. CONNECT.

## PUT

The HTTP PUT method is used to completely replace a resource identified with a given URL.

The HTTP PUT request method includes two rules:

1. A PUT operation always includes a payload that describes a completely new resource definition to be saved by the server.
2. The PUT operation uses the exact URL of the target resource.

If a resource exists at the URL provided by a PUT operation, the resource’s representation is completely replaced. If a resource does not exist at that URL, a new resource is created.

The payload of a PUT operation can be anything that the server understands, although JSON and XML are the most common data exchange formats for RESTful webservices and microservices.

### Idempotent and safe

PUT operations are said to be unsafe but idempotent.

- They are not safe because they change the state of a resource on the server.
- They are idempotent because multiple invocations leave the server in the same state.

For example, if a PUT operation sets the status of a flight to _ontime_, that operation could be invoked 100 times and the status would always end up being _ontime_. That’s the idea behind idempotence.

In [contrast to PUT, POST](https://www.theserverside.com/blog/Coffee-Talk-Java-News-Stories-and-Opinions/PUT-vs-POST-Whats-the-difference) operations are not idempotent.

### DELETE Method

The HTTP DELETE method is self-explanatory. After execution, the resource a DELETE operation points to is removed from the server.

As with PUT operations, the HTTP DELETE method is idempotent and unsafe.

|Safe vs idempotent HTTP eequest methods|   |   |
|---|---|---|
||**SAFE**|**IDEMPOTENT**|
|GET|Yes|Yes|
|POST|No|No|
|PUT|N0|Yes|
|PATCH|No|No|
|DELETE|No|Yes|
|TRACE|Yes|Yes|
|HEAD|Yes|Yes|
|OPTIONS|Yes|Yes|
|CONNECT|No|No|
|PRI|Yes|Yes|

### TRACE Method

The TRACE HTTP method is used for diagnostics, debugging and troubleshooting. It simply returns a diagnostic trace that logs data from the request-response cycle.

The content of a trace is often just an echo back from the server of the various request headers that the client sent.

### OPTIONS Method

The server does not have to support every HTTP method for every resource it manages.

Some resources support the PUT and POST operations. Other resources only support GET operations.

The HTTP OPTIONS method returns a listing of which HTTP methods are supported and allowed.

The following is a sample response to an HTTP OPTIONS method call to a server:

OPTIONS /example/resource HTTP/1.1 
Host: www.example.com HTTP/1.1 200 OK 
Allow: GET, POST, DELETE, HEAD, OPTIONS 
Access-Control-Allow-Origin: * 
Access-Control-Allow-Methods: GET, POST, DELETE, OPTIONS 
Access-Control-Allow-Headers: Authorization, Content-Type

### CONNECT Method

The connect operation is used to create a connection with a server-side resource. The most common target of the HTTP method CONNECT is a proxy server, which a client must access to tunnel out of the local network.

RESTful API designers rarely interact with the CONNECT HTTP request method.

### PATCH Method

Sometimes object representations get very large. The requirement for a PUT operation to always send a complete resource representation to the server is wasteful if only a small change is needed to a large resource.

The PATH HTTP method, added to the Hypertext Transfer Protocol independently as part of [RFC 5789](https://www.rfc-editor.org/rfc/rfc5789), allows for updates of existing resources. It is significantly more efficient, for example, to send a small payload rather than a complete resource representation to the server.