#UNIX 

### SS Socket Statistics command

The `ss` CLI command is used to show network statistics. 


It shows an structure like this: 

```unix
Netid	State 	Recv-Q 	Send-Q  Local Address:Port	Peer Address: Port 	Process
u_str 	ESTAB	0	0			     * 23609			* 44
```

Where it indicates: 

* `Netid` type of socket. In this case, "u_str" is a Unix Stream. Also more available types can be "udp" or "tcp"
* `State` the current state of the socket
* `Recv-Q` the number of received packets
* `Send-Q` the number of received packets
* `Local Address:Port` the local address and port for the socket transmision
* `Peer Address:Port` the remote address and port

### Options

*  `ss -l` in order to -l (listening) see the ports that are listening
* `ss -a` to see all ports
* `ss -a -t` to see all TCP sockets
* `ss -a -u` to see all UDP sockets
* `ss -a -x` to see all Unix sockets
* `ss -a -4` to see all TCP/IPv4 protocol sockets
* `ss -a -6` to see all TCP/IPv6 protocol sockets
* `ss -t -r state <state_to_search>` to list all sockets with the specified state
* `ss -a dst xxx.xxx.xxx.xxx` to list all the connections to a particular IP destination address


### States of a socket