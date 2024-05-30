#NETWORKING #CONCEPTS 

### UDP Protocol

UDP or User Datagram Protocol is a <span style="color:orange;background-color:#c9f5e2;">transport layer protocol</span>. 

In order to transmit and route the datagrams, UDP has the minimum mechanism posibles, being simple and quick to use. Only occupies 8 Bytes. 

Its fast by sending messages without control of the flow and don't maintain a connection between both devices. 

### 📈 PROS OF UDP

Ideal for low latency because don't need to establish and open a connection in order to transmit between endpoints

### 📉 CONS OF UDP

UDP doesn't establish a persistent connection between both endpoints. 
More packet loss rate. 



#### DATAGRAM STRUCTURE

It only stores: 
* Source port
* Destination port
* Length of datagram: length in bytes of the datagram. Minimum 8 bytes (length of datagram's header)
* Checksum: it's used for error checking of the headers and data. Is all filled with 0's if not used. 

![[udp_structure.png]]


---

[^1]: TCP or Transfer Control Protocol is other transport layer protocols to send information between two endpoints. It consist of a basic Handshake [[TCP - Handshake]] between both endpoints in order to start transmitting between then  [[TCP - Transfer Control Protocol]]. 