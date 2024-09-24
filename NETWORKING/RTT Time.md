#CONCEPTS #NETWORKING 

# RTT Round Trip Travel

RTT or Round Time Travel is the time of getting a response before sending a request in a network. 

Its the time from sending and receiving back the request in milliseconds. 

You pay 2 RTT, one for opening connection and one per each connection

The key factors that affect directly to the RTT are:

* `distance` is the physical distance between the source host and the server. 
* `transmition medium` the speed that the signal can reach by traveling in the medium. 
* `number of hops` the number of nodes from the network that the packet gets through to reach the target, increases the RTT. 
* `network traffic` if the network where the packet gets through has a high volume of traffic, this can affect due to hosts queues. 
* `response time of the server` depending on the requests and traffic that the target server is receiving, this could increment the RTT due to processing queues. 


### Best measures

An ideal RTT must be inferior to 100 milliseconds, 