#HTTP #NETWORKING 


### Cache-Control

The `Cache-Control` header attribute defines how is the cache behaviour related with the sent content trough the body of the HTTP header. 

It can define: 

* `max-age` time in seconds that the content can be cached and taken from the cache. Once this time has passed, need to be updated from the server. 
* `no-cache` imply that response can be cached but needs to be revalidated in order to be used. 
* `must-revalidate` imply that once the max-age is ended and cached content is no longer fresh, needs to be revalidated with the server. 



### PUBLIC VS PRIVATE CACHE

There is two types of privacy in terms of cache between an http transaction. 

Cache can be public, meaning that is stored within the server and client. 

Otherwise, can be private, meaning that is stored within the user device