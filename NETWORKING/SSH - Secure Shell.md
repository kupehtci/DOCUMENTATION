#CONCEPTS #NETWORKING 


### Secure Shell

SSH or Secure Shell is a <span style="color:orange;">network protocol</span> that gives users and network administrators a <span style="color:MediumSlateBlue;">secure way</span> to connect to another computer over an unsecured network. 

Secure Shell provides <span style="color:orange;">strong password authentication</span> and public key authentication, as well as <span style="color:orange;">encrypted</span> [[SSH - (Cryptography) Secure Shell]] data communications between two computers connecting over an open network, such as the internet.

SSH was created for replacing unsecured connection like [[TELNET]], rlogin(remote login) and rsh (remote shell). 

### Client-Server model

SSH uses a Client-Server model, connecting a server that runs a session with the client, where the session is displayed. 

### Capabilities

The SSH network protocol has the following capabilities: 

- secure remote access to SSH-enabled network systems or devices for users, as well as automated processes;
- secure and interactive file transfer sessions;
- automated and secured file transfers;
- secure issuance of commands on remote devices or systems; and
- secure management of network infrastructure components.

### How to connect

The most basic usage of SSH to connect to a remote server is via the command console: 

```bash
ssh UserName@SSHserver.example.com
```

and for the first time negotiating a connection with this server, will return: 

```bash 
The authenticity of host 'sample.ssh.com' cannot be established.  
 DSA key fingerprint is 01:23:45:67:89:ab:cd:ef:ff:fe:dc:ba:98:76:54:32:10.  
 Are you sure you want to continue connecting (yes/no)?
```

If `yes` is introduces, it would save into `known_hosts` file the host key. 

This file is stored in `/.ssh/known_hosts`. 
### Keys

Runs on TCP (Transmision Control Protocol) [[TPC - IP Layers]] on port 22. [[Networking Ports]]. 






