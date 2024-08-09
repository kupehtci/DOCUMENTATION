#NETWORKING 

## IPv4

Is the actual internet protocol used to routing devices by the use of addresses. 

Uses 32 bits addresses separated into 12 numerical characters separated in clocks of 3 numbers from \[0, 255\]. ($2^8$)

All hosts within a network share same network direction but each one holds a unique one in order to be able to communicate. 

The devices IP address must be unique within the same network, meaning that in the global internet network, the router must have a unique one and within the local network also uniques. 

This both networks are joined by the [[NAT]]. 


### IPv4 classes

IPv4 addresses can belong to 3 different classes: 

* <span style="color:MediumSlateBlue;">Class A</span>: uses only first byte to identify network prefix, leaving 3 bytes for host identification
* <span style="color:MediumSlateBlue;">Class B</span>: uses only first 2 bytes to identify network prefix, leaving 2 bytes for host identification
* <span style="color:MediumSlateBlue;">Class C</span>: uses only first 3 bytes to identify network prefix, leaving 1 bytes for host identification

```txt
00000000 xxxxxxxx xxxxxxxx xxxxxxxx (Class A) 
00000000 00000000 xxxxxxxx xxxxxxxx (Class B)
00000000 00000000 00000000 xxxxxxxx (Class C)
```