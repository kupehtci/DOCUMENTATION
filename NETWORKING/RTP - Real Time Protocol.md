#NETWORKING 

Majority of VoIP implementations uses the RTP for media path. 

A media stream encapsulated within RTP: 

* A RTP header precedes each media packet. 
* A separate stream of control packages called <span style="color:#ff1493;">Real Time Control Protocol (RTCP)</span>. 
* Travels within an UDP [^1] packet.  (Its faster than TCP [^2])
* Has special characteristics for real time systems

By the use of CCRC and CC header fields , can be easily used by large multiuser and multimedia conferences. 

#### RTP Header structure

This is the header structure of a RTP packet. 
![[./IMAGES/RTP_header_structure.png]]
The header is <span style="color:orange;">12 bytes long</span> or 4 optional bytes more of countribuiting source identifiers. 

<div style="border: 1px solid DodgerBlue; padding: 1rem;">
<list>
<li><span style="color:#ff1943;">Version (V)</span>: First two bites define the version (Currently 2).</li>
<li><span style="color:#ff1943;">Padding (P)</span>: One bit indicating if the RTP packets contains padding. (This allows to keep the data within a 32 bit boundaries). </li>
&emsp; if Padding bit is set, means that padding bytes are present and at the end of the packet there is a counter of them.
<li><span style="color:#ff1943;">Extension (X)</span>: When the extension X bit is set, indicates that the extension header is present. </li>
<li><span style="color:#ff1943;">Number of CRSC (CC)</span>: The 4-bit CC field indicates the number of contributing source identifiers.</li>
&emsp; Example: if CC = 0000 by default, indicated that there are not contributing sources.
<li><span style="color:#ff1943;">Marker (M)</span>: The usage of M is determined by RTP payload. For voice is marked as the first voice packet.</li>
<li><span style="color:#ff1943;">Payload (PT)</span>: Seven bits indicating the type of media carried. </li>
<li><span style="color:#ff1943;">Sequence Number</span>: 16-bit sequence number field incremented for each RTP packet sent, that can be used to detect gaps in the stream</li>
<li><span style="color:#ff1943;">Timestamp</span>:  32 bit timestamp indicates the sampling time associated with the first sample in the payload.</li>
<li><span style="color:#ff1943;">Synchronizing Source (SSRC)</span>: This 32 bit synchronizing source is a random identifier selected by the transmitter, used to identify the media session.</li>
<li><span style="color:#ff1943;">Contributing sources (CCRC)</span>: Identifier of the source when there is more than one source in the session</li>
&emsp;This is used because some devices use <span style="color:IndianRed;">same UDP port</span> for all media streams.
</list> 
</div>

#### RTCP - Real Time Control Protocol

Is a separated control protocol defined for being used within RTP. 

Designed for large multiuser multimedia conferences , but also applicable to point-to-point VoIP call. 
RTCP packets are exchanged periodically (UDP) between the two endpoints of a call. 

RTP Protocols ports are **even** and by convention, the RTCP port number used is one above the one used. 
For example if RTP port is 513, RTCP will automatically use 514. [[PORTS USED]]

---

[^1]: For more information about UDP[[UDP - User Datagram Protocol]]
[^2]: TCP is slower because the need to establish and maintain a fixed connection between both endpoints. For more information look at [[TCP - Transfer Control Protocol]] and [[TCP handshake]]. 
