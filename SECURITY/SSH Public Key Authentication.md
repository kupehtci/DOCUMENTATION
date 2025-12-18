#SECURITY #Linux 

# SSH Public Key Authentication

SSH[^1] is a network protocol for remotely access and manage computers over an insecure network using the 22 protocol and an authentication to the machine you are connecting to. 

In order to authenticate to the system, the most common authentication format is the use of a pair of asymmetric keys (Public and private)[^2]. 

In order to set this authentication: 

1. You generate the key pairs in your system using `ssh-keygen` for example that will create a private key that must be kept secretly and a public key that can be shared. 
	1. The principle of asymmetric cryptography is that a content ciphered by the public key can only be deciphered with the private key associated to it. 
2. The public key must be copied into the server under `~/.ssh/authorized_keys` directory
3. When you try to connect using `ssh {user}@{host}`: 
	1. The client offers the public key to the server you are connecting to
	2. If that public key is stored under `authorized_keys` it will send a cryptographic challenge that can only be responded correctly by the host that has the private key. This proves the posesion of the private key and the server grants the access. 

The **first time** the authentication needs to be using password, then copy the generated public key into the `authorized_keys` directory so the following logins are SSH key based authentication.

The key needs to be appended using: 
```bash
echo "ssh-ed25519 AAAA... email@example.com" >> ~/.ssh/authorized_keys
```

## Security

Its very recommended to set `600` permissions over the `authorized_keys` file, preventing tampering from other users in the server. This won't block the SSH server daemon[^3] as it runs as user. 


[^1]: SSH Networking protocol [[SSH - Secure Shell]]
[^2]: Asymmetric encryption [[Key Pairs]]
[^3]: Linux daemon [[Daemon]]
