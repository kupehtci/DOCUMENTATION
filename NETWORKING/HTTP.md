#NETWORKING 

## HTTP - Hyper Text Transfer Protocol


Hyper-Text Transfer Protocol is an <span style="color:orange;">application layer protocol</span> capable of transfer Hyper-Text documents over TCP [[TCP - Handshake]]. 

The different Web Objects ([[HTTP - Key elements]]👀) like the HTML$^1$ webpage itself are highly localizable because are stored under an unique URI (Uniform  Resource Identifier) or an URL (Uniform Resource Locator). 


### BASIC FLOW

In order to retrieve an Hyper-Text document, its follows various steps in order to grant the connection to share the document. 

1. Client Starts the connection by creating a <span style="color:LIghtSeaGreen;">socket on port 80</span>.
2. Server accept this connection. 
3. Client sends an <span style="color:blue;">HTTP request message</span> on open socket
4. Server sends an <span style="color:blue;">HTTP response message</span> in return. 
5. TCP connection is closed. 

### STATELESS

HTTP is a stateless server protocol, meaning that servers sends the requested files to the Clients without storing a **state**$^2$. 

Each connection is <span style="color:Violet;">treated independently</span>. 

Stateless makes this protocol, simpler, easier to debug and implement and are not prone to inconsistencies. 

However, two main features require some states, Authentication and Caching. 

`AUTHENTICATION`

In order to provide state for authentication, HTTP provides certain status codes and headers to perform authentication: 
* **Token**.based authentication
* **Cookies**-based authentication

### HTTP Message Format

In HTTP requests and responses are sent in ASCII plain text messages until HTTP/2.0 that started to transmit in binary. 

There are two types of HTTP messages: 

* Requests messages (Client ➡ Server)
* Response messages (Client ⬅ Server)

### HTTP Request format

This is the format of an HTTP request from a Client to a Server: 

```TXT
GET /dir/index.html HTTP/1.1
Connection: close
User-agent: Mozilla/4.0
Accept: text/html, image/gif, image/jpeg
Accept-language:es

This is an example of the body
```

Being `GET /dir/index.html HTTP/1.1` the request line and the rest the header followed by the body content of the request. 

The <span style="color:violet;">request line</span> has the following structure: 

```txt
<method> <url/path/filename> <HTTP/X.X>
GET      URL                 Version    
POST
HEAD
...
```

The <span style="color:violet;">headers</span> add additional parameters of the request depending on the browser and the server. 
(Customizable (X-....))

The <span style="color:violet;">body</span> is just plain text formatted in JSON standard, that is only included by some methods. 

The different <span style="color:orange;">request methods</span> that can be used to indicate the action that server should do with a resource: 

* <span style="font-weight:bold;">GET</span> method: 
	* Safe and idempotent
	* Fetches an specified resource
	* Has no body, so use query params instead
* <span style="font-weight:bold;">HEAD</span> method
	* Safe and idempotent
	* Simulates a GET requests but only retrieves its headers
* <span style="font-weight:bold;">POST</span> method
	* Alters state of server by creating or uploading a new resource
* <span style="font-weight:bold;">PUT</span>
	* Idempotent
	* Alters the state of the server
	* Updates an existing resource
* <span style="font-weight:bold;">DELETE</span>
	* Alters the state of the server
	* Deletes the specified resource

\* **Idempotent** is when one single requests has same effect as making $n$ requests
\* **Safe** is when the requests don't modifies the server state. 
\* **Cacheable** is then once the request is executed, the response can be preserved to avoid repeating the execution. 

### HTTP Response format

This is the structure of a typical HTTP response message that the Server creates and send once the request is executed: 

```
HTTP/1.1 200 OK 
Connection: close
Date: Thu, 06 Aug 1998 12:00:15 GMT
Server: Apache/1.3.0 (Unix)
Last-Modified: Mon, 22 Jun 1998 09:23:24 GMT
Content-Length: 6821
Content-Type: text/html

This is an example of body
```

In the response, the most important data is the <span style="color:violet;">status code</span>: 

```
<HTTP/X.X> <status_number> <OK>
Version    Status number e.g. 200
```

### PERFORMANCE

In order to measure the performance of a website or an Web Object, we can measure and quantify the amount of time 

The <span style="color:orange;">Round-trip time (RTT)</span> is the time it takes for a small packet to travel from client to server and back. 

It takes into account: 
* Packet propagation delays
* Packet queuing delays in intermediate routers and switches
* Packet processing delay in Server and Client. 

In a <span style="color:violet;">non-persistent connection</span> each time it uses HTTP to retrieve a Hyper-text document, it closes the TCP connection. 

Otherwise, in <span style="color:violet;">persistent connection</span>, the server leaves the TCP connection open so multiple objects can be transmitted using the same connection by doing <span style="color:LIghtSeaGreen;">subsequent requests and responses</span>. 

We save the initial RTT used to open the connection each time into only one connection opening. 

![[./IMAGES/round_trip_time_http_performance_calculation.png|350]]

There are three types of <span style="color:violet;">persistent connections</span>: 
* **without pipelining**: one request and response at a time
* **with pipelining (HTTP/1.1)**: $n$ requests can be sent over a TCP connection without waiting for responses and responses will arrive in same order as sent. 
* **with multiplexing (HTTP/2.0)**: $n$ requests are sent *concurrently* over a single TCP connection and responses arrive at any order.

##### PERFORMANCE TIME CALCULATION

Given an HTML file, accessible at https://sample.com/file.html within
**20ms**

• An stable RTT (round-time trip) of **40ms**
• A load time of each image of **80ms**
• How long would a browser take till loading the full website? ⏱ that has 8 images with an URL: 

```HTML
<html>
	<body>
		<h1>Hello World</h1>
		<img alt="imgA" src ="https://picsum.photos/200">
		<img alt="imgA" src ="https://picsum.photos/200">
		<img alt="imgA" src ="https://picsum.photos/200">
		<img alt="imgA" src ="https://picsum.photos/200">
		<img alt="imgA" src ="https://picsum.photos/200">
		<img alt="imgA" src ="https://picsum.photos/200">
		<img alt="imgA" src ="https://picsum.photos/200">
		<img alt="imgA" src ="https://picsum.photos/200">
	</body>
</html>
```

The time it takes to load the entire webpage using a persistent connection is: 

$$RTT + RTT + Cost(HTML) + 8 * (RTT * Cost(Image))$$

A first initial RTT for opening the connection
An RTT and the load time for bringing to client the HTML 

Eight RTT and load image for each one of the imagenes that are encountered during the HTML file. 

---
$^1$ [[HTML - Basics]]
$^2$ State or even any type or information about the client