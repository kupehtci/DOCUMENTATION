#NETWORKING 

### TCP BASICS

TCP treats data to be transmitted as an unstructured stream of bytes, and TCP has no acknowledge of the content of the data it sends. 

In order to transmit between two endpoints, need to make a [[TCP handshake]] in order to start a connection between them. 

It consist in three basic messages: 
* Connection initiation (SYN): client asks for connection. 
* Server acknowledgement (SYN-ACK): server responses with an acknowledgement of the connection start message. 
* Client acknowledgement (ACK): Client responses as has received the server message and starts a connection. 

### 📈 PROS OF TCP

* Reliability: because a connection is keep between both devices, keeps a reliable transmission of packets. 
* Ordered delivery: will follow a preassigned path, that make packets to arrive ordered, preventing wrong information. 

### 📉 CONS OF TCP

* Overhead: the need of a handshake introduces overhead that impact over the connection speed. 
* Latency: due to the need of a three message handshake and more header reliability, keeps a higher latency than UDP as example[^2]

---

[^2]: UDP or User Datagram Protocol is other of the most used transport layer protocols as well as TCP. It keep a more faster transmission but less reliable than TCP. 



