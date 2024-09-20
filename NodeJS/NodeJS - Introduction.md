#NodeJS

# NodeJS Introduction

NodeJS is an runtime environment built over Chrome's V8 Javascript engine. 
It allows developers to execute Javascript[^j] code outside a web browser. 

Architecture based in events

The key features of NodeJS are: 

* <span style="color:SteelBlue;">Asynchronous</span>: Utilizes event driven architecture, so can handle multiple requests concurrently. 
* <span style="color:SteelBlue;">Non-blocking I/O</span>: only using a main thread, its mandatory to not block it for callign a function or waiting an API's response or similar. 
* <span style="color:SteelBlue;">Modular architecture</span>: has multiple modules with pre-built functionality, reducing development time and effort. 
* <span style="color:SteelBlue;">Scalability</span>: its lightweight and an event driven approach and can scale efficiently. 

### Single threaded

Is single threaded, this imply that processes the all the requests sequentially. It imply that non function call or API request can block the execution of the following requests. 

Its based in the <span style="color:DodgerBlue;">Event Loop</span>. 

The <span style="color:DodgerBlue;">Event Loop</span> is a central concept that governs the asynchronous operations. 
It monitors the new events and executes the appropriate function in response. 

Consists in a queue of events, stack of operations and execution code. 

* <span style="color:orange;">Event Queue</span>: list of events that are waiting to be processed
* <span style="color:crimson;">Callback queue</span>: a queue with the callback functions that are going to be executed. 
* <span style="color:DarkTurquoise;">Execution stack</span>: hold the current code that is being executed. 
* <span style="color:MediumPurple;">NodeJS Event Loop</span>: manages the flow of an execution. 

When a <span style="color:MediumSlateBlue;">Callback function</span> its called, it is stacked into the <span style="color:crimson;">Callback queue</span>, then when it turn arrives, it will be pushed to the execution stack and executed. 

When a new event is detected, the corresponding <span style="color:MediumSlateBlue;">callback function</span> is pushed into the <span style="color:crimson;">callback queue</span> until the event loop processes it. 

 

[^j]: Javascript is an scripting language built for web execution in runtime 