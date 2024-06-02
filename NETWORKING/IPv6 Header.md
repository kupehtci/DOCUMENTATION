#NETWORKING #IPv6 

### IPv6 and IPv4 Header comparison

![[./IMAGES/ipv6_ipv4_header_comparison.png]]

The main differences between IPv6 and IPv4 headers are: 

* IPv6 header is <span style="color:orange;">twice the size</span> of the IPv4 one. 
* Separated options header
* No checksum
* Version is the only option that remains the same. (same position and meaning) (4 bits)
* <span style="color:orange;">Flow label</span> is the only new field added
* MTU[^1] must be at least 1280 bytes ( > 1500) versus the 68 of IPv4. 

Parts of a IPv6 header: 

* <span style="color:#ff1943;">Version</span>: = 6 (4 bits: 0110)
* <span style="color:#ff1943;">Traffic class</span>: (8 bits) 
	* Equivalent to TOS (Type of Service) in IPv4
	* Indicates the different classes or priorities of datagram (diffserv)
	* A router can associate with each datagram a particular resource allocation. 
		* FLOW Abstraction: a flow is a path along which intermediate routers guarantee a certain QoS (Quality of service). 
* <span style="color:#ff1943;">Flow label</span> (20 bits)
	* Used by hosts for indicate **special handling** (Labeling the sequence of packets)
	* Used by routers to forward datagrams along prearranged path. 
	* <span style="color:#D4AC0D;">Example:</span> Two applications need to send and receive video can establish a flow with a guaranty bandwidth and delay. 
* <span style="color:#ff1943;">Payload length</span> (16 bits)
	* Equivalent to total length in IPv4
	* Includes the $length(headers + user data) <= 64K\ octets$ [^2]
	* Provision of `jumbogram` option [^3]
* <span style="color:#ff1943;">Next Header</span>: (8 bits)
	* Equivalent to protocol header in IPv4
	* Identifies type of header
	* Points to first extension header or next layer up
	* Used to identify the encapsulated protocol (TCP=6, UDP=17, ICMPv6=58)
* <span style="color:#ff1943;">HOP Limit</span> (8 bits)
	* Equivalent to TTL in IPv4
	* HOP limit = 255 hops
	* Decrement by each forwarded router and discarded if reaches 0. 
* <span style="color:#ff1943;">Source Address</span>: (128 bits)
* <span style="color:#ff1943;">Destination address</span> (128 bits)

* <span style="color:#ababf5;">Extension Header info</span>: (Variable length)
	* Most extension headers are assessed at destination, exceot hop-by-hop and routing headers. 
	* Has two headers: 
		* Next header: defines type of header extension
		* Header len: gives size of extension header

![[./IMAGES/extension_header_info.png|350]]
![[header_extension_estructure.png]]
### Types of IPv6 Addresses

No use of address classes like IPv4. 

Special types of addresses: 

* <span style="color:#ff1943;">Unicast</span>: One to one delivery
	* IP of a single destination interface
* <span style="color:#ff1943;">Multicast</span>: One to many delivery
	* IP of multiple destinations - maybe a different sites
	* Packet delivered to all interfaces in the group
* <span style="color:#ff1943;">Anycast</span>: One to one of many delivery
	* Packet delivered to the closes interface in the group of hosts with the same prefix (only routers). 
* <span style="color:#ff1943;">No broadcast</span>: subset of multicast


### Address Notation

A IPv6 address looks like: 

```XXXX:XXXX:XXXX:XXXX:XXXX:XXXX:XXXX:XXXX```

Where each group of X is a 16-bit hexadecimal number. 
Example:  ```68E6:8C64:FFFF:FFFF:0:1180:96A:FFFF```

Also consecutive 0's can be omitted, but only one time to avoid confusion:

* `47CD:0000:0000:0000:0000:0000:A456:0124` = `47CD::A456:0124`
* `0000:0000:0000:0000:0AFF:A456:000F:0024` = `::AFF:A456:F:24`

### Transition from IPv4 to IPv6

Two types of IPv6 address can contain a IPv4 address: 
* IPv4 compatible address (Deprecated, for nodes that understand both) 
	* Example: `::130.166.190.7`
* IPv4 mapped address (For nodes that only understand IPv4)
	* Example: `::FFFF:130.166.190.7`

Other option is: 
* `Tunneling`: embed a IPv6 packet within a IPv4 one. In a URL is enclosed within brackets: \http://\[2001:1:4F3A::206:AE14\]:8080/index.html o


### IPv6 Addressing Structure

Addresses have a scope and this score define a <span style="color:MediumSlateBlue;">region</span> where an address can be defined as unique. 

This span can be: 

* <span style="color:DodgerBlue;">Link</span>: corresponding to link-local addresses. Only used between nodes in same link
* <span style="color:Olive;">unique local</span>: between nodes in same site network
* <span style="color:IndianRed;">global</span>: unique in global addresses. Allocated by the IANA [^4]. 

| LINK                                      | UNIQUE LOCAL                                   | GLOBAL                                                           |
| ----------------------------------------- | ---------------------------------------------- | ---------------------------------------------------------------- |
| Link-local addresses                      |                                                | For generic global reachable IPv6 usage                          |
| Only between nodes with the same link     | Only between nodes in same site network        |                                                                  |
| Cannot be routed on internet              | Cannot be routed on internet                   | Routable across the internet                                     |
| FE80 + remaining(54b) + interface ID(64b) | FD00 + Global_ID(40b)+Subnet_ID + Interface_ID | Registry + ISP_Prefix + Site_Prefix+Subnet_Prefix + Interface_ID |

##### Special addresses

* <span style="color:PowderBlue">DHCP request</span>: Unspecified 0:0:0:0:0:0:0:0 or :: or ::/128
* <span style="color:PowderBlue">Default route</span>: ::/0
* <span style="color:PowderBlue">Localhost</span>: - 0:0:0:0:0:0:0:1 or ::1 or ::1/128
* <span style="color:PowderBlue">IPv6 multicast prefix</span>: FF00::/8, valid for sending packet to a multicast group

![[ipv6_formatr.png]]

Global unicast: 
* Routable across internet
* Structured as hierarch to allow address aggregation
* | Register | Global ISP | Intermediate ISP | Site prefix | Subnet prefix | Interface ID |
![[ipv6_IP_aggregation.png]]

### Convert to EUI-64 (Extended Universal Identifier)

In order to expand from a 48b IEE 802 MAC address to a 64-bits Extender Unique Identifier[^5] here is a method to transform from this MAC to the EUI format.

Broke the MAC address by the middle, Insert "FF:FE" and convert from the first 8 bits to binary and flip the 7th bit in order to define as globally unique. 

The first part is filled with this FF:FE and the prefix of the router assigned from the ISP and the other half of the IP is the MAC of the device. 




---

[^1]: MTU: Maximum transfer unit, is the maximum size that can be transfer using a communication protocol.   
[^2]: Octet: Equivalent to 1 Byte or 8 bits. Term used in data transmission. 

[^3]: Jumbogram packet is a packet that exceeds the size of a MTU size. In case of IPv6 is the case that has a payload bigger than 65.535octets. 

[^4]: IANA is the Internet Assigned Numbers Authority. Is the entity in charge of granting the different IP's. 

[^5]: More information about the steps to pass from one format to other at [[Convert to EUI-64]]. 
