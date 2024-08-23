#NETWORKING 

In DNS there are three types of name servers: 

##### LOCAL NAME SERVER

The local name server is the default DNS server provided by your ISP and its the one that the device id connected. 

Its close to the client and is configured by DHCP serve automatically or by hand. 

##### ROOT NAME SERVER

A root name server is the one hierarchically main of a root zone, which is the global list of top level domains . 

##### AUTHORITATIVE NAME SERVER

Every host is registered in an authoritative name server. 
And a name server is authoritative for a host if always has a DNS record that translates this hostname to the host's IP address. 
Meaning that this DNS record is not stored in cache, is permanently stored within the server. 