#NETWORKING 

### VoIP Voice over IP

Is the technology that allows voice carrying signaling and media traffic over the IP protocol. 
The origin were joining the PSTN [^1] and Internet. 

It has some challenges: 
##### Delay (Latency)

Because the nature of voice communication, a delay more than 200-250 ms  can make it intelligible. 

There are various sources of delay: 

* <span style="color:IndianRed;">On transmission side</span>: packetization time, encoding time and transmission time
* <span style="color:IndianRed;">In the network</span>: propagation delay, routers add processing delay, queuing delay and switching delay
* <span style="color:IndianRed;">In the receiver</span>: processing delay and play-out buffer delay. 
* <span style="color:IndianRed;">Jitter delay</span>: variable delay depending on the sending / receiving timespan difference. 
##### Packet loss

VoIP accept more packet loss than other transmissions. Typically $< 5\%$ 

The tolerance limits depend on: 
* Codecs used
* If packet loss concealment (PLC) schemes are implemented

##### Available bandwidth

VoWLAN (VoIP over wireless) must limit the bandwidth. 

This bandwidth consumption depends on the codecs, redundancy and packetization. 
### VoIP

The PSTN is logically separated into: 

* a signaling subsystem: in charge of sending calling signals
* a media transport system: transport of the voice or image 

So by using internet to carry voice calls also requires a signaling systems and media transport. 

User's voice is transformed from analog voltage into digital samples (Sampling at 8 KHz)
Then is equalized and echo cancellation tested. 

Other topics are also relative: 

* <span style="color:LightSeaGreen;">Sampling</span>: converting voice analog signal into digital samples. 
* <span style="color:LightSeaGreen;">Equalization</span>: enhancing voice quality and constrain not used frequencies. 
* <span style="color:LightSeaGreen;">Echo Cancellation</span>: prevent from getting residuals of the own voice back. 
* <span style="color:LightSeaGreen;">Encoding</span>: translating the raw samples into a compressed format. 
* <span style="color:LightSeaGreen;">Voice Activity Detection</span>: detect the user speech and avoid sending empty packets over the network. 
* <span style="color:LightSeaGreen;">Redundancy</span>: If N packets gets lost, the current packet  extra information about the N previous packets can be used to recover them. Use of redundancy affects bandwidth. 
* <span style="color:LightSeaGreen;">Packetization</span>: Voice frames before the codec are grouped into packets. This packets are then transmitted over the IP network.  More packetization periods are more efficient but introduce delay. 
* <span style="color:LightSeaGreen;">Tone detection</span>: looks for particular combination of frequencies in the transmitted signal in order to cut the signaling tones. 


### VoIP architectures

VoIP systems can have various architectures. 
In the case of two VoIP devices are communicating, it uses a peer-to-peer communication. 

In case that a VoIP internet device needs to communicate with a PSTN device, a <span style="color:orange">VoIP gateway</span> is used to make the pass through the two different networks.

A <span style="color:orange">VoIP gateway</span> is a logical entity that interconnects two heterogeneous networks, such as PSTN and IP. 

Based on functionality: 
* <span style="color:IndianRed;">Signaling gateway</span>: translate PSTN signaling to VoIP signaling
* <span style="color:IndianRed;">Media gateway</span>: transfer the communication media between the two networks. 

Based on size/capacity: 
* <span style="color:IndianRed;">Residential gateway</span>: deployed at customer premise. 
* <span style="color:IndianRed;">Trunking gateway</span>: in ISP gateways. 

### Signaling protocols

There are two different types: 
* Open standards protocols like ITU and IETF
* Proprietary standards like Skype or cisco. 

Can be divided into: 

* <span style="color:MediumSlateBlue;">Centralized methods</span>: call state is maintained by centralized devices responsible or receiving the call state. 
* <span style="color:LightSeaGreen;">Distributed methods</span>: each endpoint has knowledge of the current call state. 
###  Session Initiation Protocol (SIP)

SIP is the current leader in standards-baseed VoIP call-signaling protocols
* SIP is <span style="color:IndianRed;">text-based</span> and can run over UDP and TCP as well as TLS. 
* Is a distributed signaling protocol. 
* Uses SDP (Session Description Protocol) to describe media sessions
* Can be direct, peer-to-peer protocol
* <span style="color:orange;">SIP proxies</span> are intermediate SIP devices present in the networks. 

![[sip_call_message_exchange.png]]

---

[^1]: PSTN means Public Switched Telephone Network. Its the old common telephone networks maintained by the Telephonic services providers. 
