#NETWORKING 

### VoIP Voice over IP

Is the technology that allows voice carrying signaling and media traffic over the IP protocol. 
The origin were joining the PSTN [^1] and Internet. 

It has some challenges: 
##### Delay (Latency)

Because the nature of voice communication, a delay more than 200-250 ms  can make it intelligible. 

There are various sources of delay: 

*  On transmission side: packetization time, encoding time and transmission time
* In the network: propagation delay, routers add processing delay, queuing delay and switching delay
* In the receiver: processing delay and play-out buffer delay. 

##### Packet loss

VoIP accept more packet loss than other transmissions. Typically $< 5\%$ 

The tolerance limits depend on: 
* Codecs used
* If packet loss concealment (PLC) schemes are implemented

##### Available bandwidth

VoWLAN (VoIP over wireless) must limit the bandwidth. 

This bandwidth consumption depends on the codecs and packetizations. 


### VoIP

The PSTN is logically separated into: 

* a signaling subsystem: in charge of sending calling signals
* a media transport system: transport of the voice or image 

So by using internet to carry voice calls also requires a signaling systems and media transport. 

User's voice is transformed from analog voltage into digital samples (Sampling at 8 KHz)
Then is equalized and echo cancellation tested. 

Other topics are also relative: 

* Sampling
* Equalization
* Echo Cancellation
* Encoding
* Voice Activity Detection
* Redundancy: If N packets gets lost, the current packet can be used to recover them. Use of redundancy affects bandwidth. 
* Packetization: Voice frames before the codec are grouped into packets. This packets are then transmitted over the IP network.  More packetization periods are more efficient but introduce delay. 
* Tone detection: looks for particular combination of frequencies in the transmitted signal in order to cut the signaling tones. 


### VoIP architectures

VoIP systems can have various architectures. 
In the case of two VoIP devices are communicating, it uses a peer-to-peer communication. 

In case that a VoIP internet device needs to communicate with a PSTN device, a <span style="color:orange">VoIP gateway</span> is used to make the pass through the two different networks.

A <span style="color:orange">VoIP gateway</span> is a logical entity that interconnects two heterogeneous networks, such as PSTN and IP. 

Can be: 
* Based on functionality: 
	* Signaling gateway: translate PSTN signaling to VoIP signaling
	* Media gateway: transpases the communication media between the two networks. 
* Based on size/capacity: 
	* Residential gateway: deployed at customer premise. 
	* Trunking gateway: in ISP gateways. 

### Signaling protocols

Open stardards protocols like ITU and IETF
proprietary standards like Skype or cisco. 

Can be divided into: 

* Centralized methods: call state is maintained by centralized devices responsible or receiving the call state. 
* Distributed methods: each endpoint has knowledge of the current call state. 
###  Session Initiation Protocol (SIP)

SIP is the current leader in standards-baseed VoIP call-signaling protocols
* SIP is text-based and can run over UDP and TCP as well as TLS. 
* Is a distributed signaling protocol. 
* Uses SDP (Session Description Protocol) to describe media sessions
* Can be direct, peer-to-peer protocol
* <span style="color:orange;">SIP proxies</span> are intermediate SIP devices present in the networks. 

![[sip_call_message_exchange.png]]

---

[^1]: PSTN means Public Switched Telephone Network. Its the old common telephone networks maintained by the Telephonic services providers. 
