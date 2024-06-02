#NETWORKING #IPv6
### IPv6

We need to migrate to IPv6 because the shortcomings of IPv4: 

* IPv4 address space is too small: the <span style="color:#ff1943;">theoretical limit is 4 billion addresses</span>. 
* <span style="color:#ff1943;">Classfull addressing model wastes space</span> because half of the space is unused.
* <span style="color:#ff1943;">Network addresses are used offline</span> even if not connected to internet. 
* <span style="color:#ff1943;">TCP is used everywhere</span> so addresses are depleted
* <span style="color:#ff1943;">New devices</span> and <span style="color:#ff1943;">New applications</span>. 

Also the objetives are: 

🟢 Limitless addresses 
	🔸 (Address space from 32 bits to 128 bits)
	🔸 No hidden networks, hosts reachable end-to-end security used. 

🟢 Improve routing efficiency
	🔸 Simpler, fixed size based header (40 octets)
	🔸 Improved separate options header. (IPv4 options plus more)
	🔸 no checksum

🟢 Extend address hierarchy
🟢 Mobility support
🟢 Security
🟢 Real-time services support
🟢 Rich transition scheme


The IPv6 features are: 

🔷 Aggregation
Multiple prefixes per site enables multihoming without affecting the aggregation. 

🔷 Support for resource allocation. 
By the use of `flow label` (ToS) field, can label packets of specific traffic flow and special handling (real time video)

🔷 Auto-configuration (plug and play)
Dynamic address assignment (DHCPv6)
Host assign addresses by themselves, no depending on the router.

🔷 Renumbering
By use of autoconfiguration and multiple prefixes, a router can indicate their devices to regenerate their IP's. 

🔷 Multicast
No broadcast allow efficient use of the network. 

🔷 Scoped groups
An address scope the region of the address can be defined as a unique identifier of an interface. 

🔷 Rich transition scheme
IPv4 and IPv6 interaction

🔷 Alignment to 64 bits 
Modern CPU's best access memories are 64 bits.

🔷 No checksum
Reduce processing time by adding checksum in other layers. 

🔷 New ICMPv6 
Additional message types like "Packet too big" and multicast group management functions. 



### IMPROVEMENTS


* More efficient routing

Reduces routing table size, making the routing more efficient and practical

* More efficient packaging processing

IPv6 gets rid of the IPv4 checksum because in data link layers also exists a checksum with also checks the IPv6 header correctness. 

* Directed data flows

IPv6 uses multicast instead of broadcast. Multicast uses bandwidth-intensive packet flows to be send to multiple destinations simultaneously. This saves bandwidth because no inecesary packets are send to disinterested hosts and these host no longer need to process and discard that packages. 

* Simplified networks configuration

Address auto-configuration (address assignment) is built in to IPv6. A router will send the prefix of the local link in its router advertisements. A host can generate its own IP address by appending its link-layer (MAC) address, converted into Extended Universal Identifier (EUI) 64-bit format [[Convert to EUI-64]], to the 64 bits of the local link prefix.

* More services and more robust

By the avoidance of the NAT (Network Address Translation) [^1] we get a true end-to-end connectivity and peer-to-peer connections are easier to create and maintain. 
This makes services like VoIP and Quality of service (QoS) more robust. 

* Security
IP**Sec** provides confidentiality, authentication and data integrity. This allows ICMPv6, the implementation of Internet Control Message Protocol of IPv6 to be allowed because of the usage of IPSec. 

---

[^1]: [[NAT]] NAT, Network Address translation

https://www.networkcomputing.com/ip-subnetting/six-benefits-of-ipv6

