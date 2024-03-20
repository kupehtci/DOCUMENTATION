#NETWORKING #CONCEPTS 

### UDP Protocol

UDP or User Datagram Protocol is a <span style="color:orange;background-color:#c9f5e2;">transport layer protocol</span>. 

In order to transmit and route the datagrams, UDP has the minimum mechanism posibles, being simple and quick to use. Only occupies 8 Bytes. 

It only stores: 
* Source port
* Destination port
* Length of datagram: length in bytes of the datagram. Minimum 8 bytes (length of datagram's header)
* Checksum: it's used for error checking of the headers and data. Is all filled with 0's if not used. 

![[udp_structure.png]]

