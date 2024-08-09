#NETWORKING 

## FTP or File Transfer Protocol

<span style="color:orange;">File transfer protocol</span> is an <span style="color:MediumSlateBlue;">application layer protocol</span> [[TPC - IP Layers]] that uses TCP to transfer files between a <span style="color:LightSeaGreen;">client and a server</span>. 

Its similar to [[SMTP]] because was developed after SMTP was created. 

Supports two connections (channels), one for control and one for data transfer: 
	* **Control connection (port 21)**: send [[ASCII]] commands and responses.
		* Authentication
		* Navigation
		* Server Status Replies
	* **Data transfer (port 20)**: sends the <span style="color:orange;">results of the commands</span> that were sent over the control connection and the <span style="color:orange;">stream of bytes</span> of the data sent.  
		* ASCII text
		* Stream of bytes

Follows a <span style="color:LightSeaGreen;">command & responses</span> and accept commands in ASCII format and responses in status code and phrases. 

Based on <span style="color:MediumSlateBlue; text-decoration:underline;">Client-Server architecture</span>.

### OPERATION MODES

When a client wants to send or receive data, a <span style="color:orange;">data connection</span> needs to be **created**. 
To do this, FTP has two modes or operation: 
* `Active`: The server connects to a port indicated by the client, establishing a TCP connection from its port number 20. Client use `PORT` command to specify the port and server connects. 
* `Passive`: The server indicates the client port where is waiting for a data connection and the client establishes the TCP connection to this port.  Client selects passive mode with `PASV` and server answers with `227 Entering Passive Mode (130, 206, 13, 2, 160, 131)`. Client starts a connection to `130.206.2.160:41091`. (Port is 160 * num(255) + 131)  

So in `active` client specify port, server connects, `passive` server specify port, client connects. 

Although `active` is simpler, we need two modes because is not usable under some conditions. 
Server is imposible to open a connection to a given port if has a <span style="color:orange;">firewall</span> or a <span style="color:orange;">NAT</span>. [[NAT]], [[Firewall]]. 

### COMMANDS

Has commands for what is needed to manage a file system, navigation, file creation, file retrieval, etc. 

Two categories of commands: 

* no data connection (response over control connection): 
	* `USER / PASS` : Login commands. 
	* `PORT`: Indicates the port to connect in active mode. 
	* `PASV`: requests a port to connect in passive mode.
	* `TYPE`: changes the type of transmission. 
	* `QUIT`: ends the connection
	* `MKD`: created a directory
	* `RMD`: removes a directory
	* `CWD`: changes the working directory
	* `PWD`: gets the working directory
	* `DELE`: removes a file
* data connection needed (responde will arrive in control and data in data connection)
	* `RETR`: download a file
	* `STOR`: upload a file
	* `LIST`: gets the result of a dir
### SECURITY - FTPS

As we know, **plain ASCII commands** and responses, make **FTP not secure**. As an application layer protocol, FTP can be run over <span style="color:orange;">TLS</span> to achieve more security. This is known as <span style="color:orange;">FTPS</span>. 

Its not the same as SFTP or SCP. 
* SFTP is Secure Shell SSH [[SSH - Secure Shell]] File Transfer Protocol. 
* SCP is Secure Copy Protocol. 

FTP supports <span style="color:orange;">annonymous connections</span>. 

### PASSIVE MODE

We prefer passive mode, when: 

* While client is behind a NAT or a firewall. 
* If server cannot initiate the connection. 

When entering `PASV` mode, the response back from the server is:

* 227 Entering Passive Mode (9,99,99,88,214,137) 

This is the way the server tells the client what port the server will be listening on for the client to reach out to it for the data connection.

- (9,99,99,88,214,137) these 6 numbers following in the servers response break down as follows:

First 4 are the ip address: 9.99.99.88 

The fifth and sixth numbers are the port. You take the fifth number multiply it by 256 then add the sixth number:

$214 * 256 = 54784 + 137 = 54921$ 

So the servers response is telling the client that it is listening at the ip/port of 9.99.99.88:54921***

If server is behind a firewall or a NAT, needs to let the specific ports open to enable connection.[[Networking Ports]]. 