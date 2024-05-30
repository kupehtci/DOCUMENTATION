#NETWORKING 

Majority of VoIP implementations uses the RTP for media path. 

A media stream encapsulated within RTP: 

* A RTP header precedes each media packet. 
* A separate stream of control packages called <span style="color:#ff1493;">Real Time Control Protocol (RTCP)</span>. 
* Travels within an UDP [^1]packet.  (Its faster than TCP)
* Has special characteristics for real time systems


#### RTP Header structure

This is the header structure of a RTP packet. 
![[./IMAGES/RTP_header_structure.png]]
The header is <span style="color:orange;">12 bytes long</span> or 4 optional bytes more of countribuiting source identifiers. 

* <span style="color:#ff1943;">Version (V)</span>: First two bites define the version (Currently 2). 
* <span style="color:#ff1943;">Padding (P)</span>: One bit indicating if the RTP packets contains padding. (This allows to keep the data within a 32 bit boundaries). 
	* if Padding bit is set, means that padding bytes are present and at the end of the packet there is a counter of them. 
* <span style="color:#ff1943;">Extension (X)</span>: When the extension X bit is set, indicates that the extension header is present. 
* <span style="color:#ff1943;">Number of CRSC (CC)</span>: The 4-bit CC field indicates the number of contributing source identifiers. 
	* Example: if CC = 0000 by default, indicated that there are not contributing sources. 
* <span style="color:#ff1943;">Marker (M)</span>: The usage of M is determined by RTP payload. For voice is marked as the first voice packet. 
* <span style="color:#ff1943;">Payload (PT)</span>: Seven bits indicating the type of media carried. 
* <span style="color:#ff1943;">Sequence Number</span>: 16-bit sequence number field incremented for each RTP packet sent, that can be used to detect gaps in the stream
* <span style="color:#ff1943;">Timestamp</span>:  32 bit timestamp indicates the sampling time associated with the first sample in the payload. 
* <span style="color:#ff1943;">Synchronizing Source (SSRC)</span>: This 32 bit synchronizing source is a random identifier selected by the transmitter, used to identify the media session. 
	* This is used because some devices use ==same UDP port== for all media streams. 


#### RTCP - Real Time Control Protocol

Is a separated control protocol defined for being used within RTP. 

Designed for large multiuser multimedia conferences , but also applicable to point-to-point VoIP call. 
RTCP packets are exchanged periodically (UDP) between the two endpoints of a call. 

RTP Protocols ports are **even** and by convention, the RTCP port number used is one above the one used. 

---

[^1]: For more information about UDP[[UDP - User Datagram Protocol]]
