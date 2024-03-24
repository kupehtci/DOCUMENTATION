#NETWORKING 

By default and in order of standarization, all protocols usually have a default por assigned for its usage. 

In the following table, all the reserved ports are detailed: 

| PORT      | PROTOCOL           | TCP / UDP  | DETAILS                                                                                         |
| --------- | ------------------ | ---------- | ----------------------------------------------------------------------------------------------- |
| 7         | ECHO               | TCP / UDP  |                                                                                                 |
| 19        | Chargen            | TCP        |                                                                                                 |
| 20 - 21   | FPT                | TCP / UDP  | 20 for control channel and 21 for data channel                                                  |
| 22        | SSH                | TCP        |                                                                                                 |
| 23        | Telnet             | TCP        |                                                                                                 |
| 25        | SMTP               | TCP        |                                                                                                 |
| 53        | DNS                | UDP        | Domain Name System                                                                              |
| 69        | TFTP               | UDP        | Trivial Transfer File Protocol                                                                  |
| 80        | HTTP               | TCP / UDP  | Hyper-text Transfer Protocol (HTTP 3 uses QUIC$^1$)                                             |
| 88        | Kerberos           | TCP        | Network Authentication System                                                                   |
| 110       | POP3               | TCP        | Post-Office Protocol                                                                            |
| 143       | IMAP4              | TCP        |                                                                                                 |
| 443       | HTTPS              | TCP        |                                                                                                 |
| 902       | VmWare Server      | unofficial | VmWare ESXi                                                                                     |
| 989 - 990 | FTP over SSL / TLS | TCP, UDP   | File Transfer Protocol (FTP) over TSL or SSL, uses 2 channels; 989 for data and 990 fot control |
| 993       | IMAP4 over SSL     | TCP        | Internet Message Access Protocol over TLS/SSL (IMAPS)                                           |

---
$^1$ QUIC is a transport layer protocol built over UDP. 

Take a look into [DevOps School](https://www.devopsschool.com/blog/common-popular-ports-number-used-in-os/). 
