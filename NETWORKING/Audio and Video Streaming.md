#NETWORKING 

## Audio and Video Streaming

For <span style="color:LightSeaGreen;">streaming</span>, a <span style="color:orange;">continuos transmission</span> of media over the internet is needed between a server and a client located over the network. 

This stream is fragmented in the server, travels in separated flows and is reassembled just-in-time in the client <span style="color:orange;">(Packetization)</span>. 

The main difference with the classic media transmission is that for streaming you don't need to receive and join all the file packages in order to be usable, this data is useful along its being received. 

##### Types

Depending on the type of transmission and the type of information sent to users: 

* <span style="color:IndianRed;"><b>Unicast</b></span>: Single source, single receiver. Each user receives a different data from the same server. 
* <span style="color:IndianRed;"><b>Multicast</b></span>: Same information is shared to multiple users. They are grouped within multicast groups. 

### ON-DEMAND STREAMING

Is a type of streaming where the user is able to interact with the data being received continually by requesting other data, pause, move forward and backwards, etc. 

Normally uses <span style="color:LightSeaGreen;">stored information</span> that is interactively retrieved from the server and transmitted. 

On-demand transmission is always used with <span style="color:orange;">stored information</span> and <span style="color:orange;">multicast is not allowed</span>. 
But there are techniques to combine multicast and on-demand video by using <span style="color:LightSeaGreen;">grouping techniques</span>. 

### NEAR ON-DEMAND DEMAND

Simulates the operation of the on-demand video using <span style="color:orange;">live video stream</span> and works with stored information and when the client interacts is incorporated to the closest stream to the new position. 

This means that various streams are sharing the same data but with a time diferenciation between them. 

### LIVE STREAMING 

In live streaming no previous data can be used, only the one that have beed just received. 

In this case the <span style="color:LightSeaGreen;">server</span> starts to transmit and users can connect and receive this information. 

So there is no <span style="color:orange;">interactivity</span> so only recent information is seen and if resumed the transmission after a pause, the new information is displayed. 

Normally uses <span style="color:LightSeaGreen;">in-live information</span>, being generated and then transmitted. 

---
### ARCHITECTURE

An audio/video streaming architecture is composed by: 

* Server, Client, Proxy, Network (Access and transport), protocols, production system, storage system and formats

### PROXY 

After all the proxy are the servers that are intermediary between the client and the server. 

The proxy has various functions: 
* <span style="color:Indigo;"><b>Splitter</b></span>: 
	* Receives an information flow and split into packages and send to the clients. 
	* Simulates the multicast system. 
* <span style="color:Indigo;"><b>Pass-through</b></span>: 
	* Used for live and on-demand streaming because data pass through it but is sent by the server. 
	* Acts as a security system (Admission control) that load share clients between redundant servers. 
* <span style="color:Indigo;"><b>Cache</b></span>: 
	* Stores information when its requested and sends the stored information the next time.
	* Decreases the number of streams that arrive to the server.
