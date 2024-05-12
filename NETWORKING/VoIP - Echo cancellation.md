#NET 

## Echo in VoIP systems

VoIP by itself doesn't create echo, but due to temporal aspects of the echo, VoIP systems tend to increase this echo during telephonic conversations. 

Echo is caused by the return of the speaker's voice to the speaker. Echo by itself is caused by an analog environment due to two reasons: 

* `Hybrid echo`: improper balance of hybrid circuit, two to four-wire interface can allow the signal to appear in the receive path
* `Acoustic echo`: by the handsets or speaker mode, allows the microphone to pick up sounds from an earpiece. 


To deal with this additional latency due to the return of the signal, <span style="color:orange;">Acoustic Echo Suppression (AES)</span> or <span style="color:orange;">Acoustic Echo Cancelation (AEC)</span>circuitry was created. This suppression is done by Digital Signal Processors (DSPs). 

But if latency is too high or the DSP don't have enough memory or CPU to precess the amplitude leves, echo can pass through the receiver. 

### How to solve it

There are some ways to solve the echo within the VoIP systems: 

* Renew the devices between the connection in order to avoid old AES systems or even low latency devices. 
* Optimize routes or call paths for RTP packets
* Remove intermediary devices that can slow down packet flow like firewalls or older routers
* Ensure that WoS is properly configured on congested LAN and WAN paths. 
* Choose more lower latency codecs for the data transmission
