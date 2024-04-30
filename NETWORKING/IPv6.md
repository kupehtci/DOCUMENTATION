#NETWORKING 
### IPv6

We need to migrate to IPv6 because the main 

### IMPROVEMENTS


* More efficient routing

Reduces routing table size, making the routing more efficient and practical

* More efficient packaging processing

IPv6 gets rid of the IPv4 checksum because in data link layers also exists a checksum with also checks the IPv6 header correctness. 

* Directed data flows

IPv6 uses multicast instead of broadcast. Multicast uses bandwidth-intensive packet flows to be send to multiple destinations simultaneously. This saves bandwidth because no inecesary packets are send to disinterested hosts and these host no longer need to process and discard that packages. 


* Simplified networks configuration

Address auto-configuration (address assignment) is built in to IPv6. A router will send the prefix of the local link in its router advertisements. A host can generate its own IP address by appending its link-layer (MAC) address, converted into Extended Universal Identifier (EUI) 64-bit format, to the 64 bits of the local link prefix.

* More services and more robust

By the avoidance of the NAT (Network Address Translation) [^1] we get a true end-to-end connectivity and peer-to-peer connections are easier to create and maintain. 
This makes services like VoIP and Quality of service (QoS) more robust. 

* Security
IP**Sec** provides confidentiality, authentication and data integrity. This allows ICMPv6, the implementation of Internet Control Message Protocol of IPv6 to be allowed because of the usage of IPSec. 

---

[^1]: [[NAT]] NAT, Network Address translation

https://www.networkcomputing.com/ip-subnetting/six-benefits-of-ipv6

