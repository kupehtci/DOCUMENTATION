#NETWORKING 


## SSH vs TELNET

Telnet was one of the first internet application protocols and the other is FTP. 
It is used to initiate and maintain a terminal emulation session on a remote host.

[[SSH - Secure Shell]] and [[TELNET]] are functionally similar, with the primary difference being that the SSH protocol uses [public key cryptography](https://www.techtarget.com/searchsecurity/definition/asymmetric-cryptography) to authenticate endpoints when setting up a terminal session, as well as for encrypting session commands and output.

While Telnet is primarily used for terminal emulation, SSH can be used to do terminal emulation -- similar to the rlogin command -- as well as for issuing commands remotely as with rsh, transferring files using SSH File Transfer Protocol ([SFTP](https://searchcompliance.techtarget.com/definition/SFTP-Secure-File-Transfer-Protocol)) and tunneling other applications.