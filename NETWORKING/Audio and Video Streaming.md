#NETWORKING 

## Audio and Video Streaming

For <span style="color:LightSeaGreen;">streaming</span>, a <span style="color:orange;">continuos transmission</span> of media over the internet is needed between a server and a client located over the network. 

This stream is fragmented in the server and reassembled just-in-time in the client <span style="color:orange;">(Packetization)</span>. 

The main difference with the classic media transmission is that for streaming you don't need to receive and join all the file packages in order to be usable, this data is useful along its being received. 

##### Types

Depending on the type of transmission and the type of information sent to users: 

* **Unicast**: Single source, single receiver. Each user receives a different data from the same server. 
* **Broadcast**: A source to all users within a network segment. // Not for Audio an video streamings normally over the internet.   
* **Multicast**: Same information is shared to multiple users. 

### ON-DEMAND STREAMING

Is a type of streaming where the user is able to interact with the data being received continually by requesti ng other data, pause, move forward and backwards, etc. 

Normally uses <span style="color:LightSeaGreen;">stored information</span> that is interactively retrieved from the server and transmitted. 

On-demand transmission is always used with <span style="color:orange;">stored information</span> and <span style="color:orange;">multicast is not allowed</span>. 
But there are techniques to combine multicast and on-demand video by using <span style="color:LightSeaGreen;">Grouping techniques</span>. 

### NEAR ON-DEMAND DEMAND

Simulates the operation of the on-demand video using <span style="color:orange;">live video stream</span> and works with stored information and when the client interacts is incorporated to the closest stream to the new position. 

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

After all the proxy is the servers that are intermediary between the client and the server. 

The proxy is used to: 

* Splitter: 
	* Receives an information flow and split into packages and send to the clients. 
* Pass-through
	* Used for live and on-demand streaming because data pass through it but is sent by the server. 
	* Acts as a security system (Admission control) that load share clients between redundant servers. 
* Cache: 
	* Stores information when its requested and sends the stored information the next time.
	* Decreases the number of streams that arrive to the server.
