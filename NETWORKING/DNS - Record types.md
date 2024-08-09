#NETWORKING 

In the different DNS [[DNS - Domain Name System]] servers there can be different types of Resource Records (RR)  for domain names stored, that always follow the same structure: 

```
RR Format: (name, value, type, ttl)
```

##### Type=A

* Name is a hostname
* Value is the IP address associated to that hostname
* A record always define an IP address
* Its stored in a 32-bit binary value

##### Type=NS (Name server record)

* Name is a domain such as "foo.com"
* Value is a hostname of a server that knows how to obtain the IP of the host of the domain
* The record is used to route the DNS queries along the query chain. This specifies an authoritative name server for a domain and is represented as domain names (Sequence of labels)

##### Type=CNAME

* Name is an alias hostname
* Value is a canonical hostname
* This record can provide querying hosts the canonical name for a hostname

##### Type=MX

* Name is an alias hostname
* Value is a hostname of a mail server
* This type of record allows the hostnames of mail servers to have simple and shorter aliases
* Example: \[foo.com      MX     mail.bar.foo.com\]


### NON-AUTHORITATIVE RESPONSES

If a server is non-authoritative for a particular hostname, the server will contain: 

* A NS record for the domain specifying the hostname
* A type A record that contains the IP address of the name server in the value field of the NS record (A DNS translation of the query chain server)


### TTL

TTL is the life-span of a resource record within a server.
It determines the time at which the resource should be removed from a cache. 