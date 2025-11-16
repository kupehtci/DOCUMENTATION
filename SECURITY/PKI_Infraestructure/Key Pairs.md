#SECURITY 

# Key Pairs

Key Pairs is one of the fundamental concepts of the core of cryptography, essentially in asymmetric encryption Keys. 

A Key Pair consists in two mathematical linked cryptographic keys: 
* **Public Key**: can be shared openly: 
	* Used for encrypting data. 
* **Private Key**: needs to be kept secretly by the owner. 
	* Used to decrypt data cypher by the public key. 
	* Create digital signatures

In **encryption**, the data is encrypted with the public key, so only the private key can be used to decrypt it. 

In **identity verification**, data can be signed with the private key so others can verify the identity using the public key associated. 

Its used in: 
* **SSL** (Secure Socket Layer)[^1] and **TLS** (Transport Layer Security)[^2] protocols for secure web traffic over HTTPS
* SSH or Secure Shell for secure remote access to a machine. 
* Email Encryption using S/MIME [^4]

# How are they generated? 

Using an algorithm like: 
* RSA
* ECC
* DSA
A secure random number is generates (not a pseudo-random) is generated and a private key is derived from this random value. 

The public key is then computed using a mathematical function based on the private key and the chosen algorithm's rules:
* RSA: works with prime numbers 
* ECC: works using a point on an elliptic curve. 

## How to generate them manually

A Key Pair can be generated using `ssh-keygen` command in Linux like: 

```bash
ssh-keygen -t rsa -b 2048 -f my_ssh_key
```

That will produce an `my_ssh_key` file that contains the private key and a `my_ssh_key.pub` that contains the public Key. 


[^1]: SSL or Secure Socker Layer [[SSL - Secure Sockets Layer]]
[^2]: TLS or Transport Layer Security [[TLS - Transport Layer Security]]
[^3]: SSH or Secure Shell [[SSH - Secure Shell]]
[^4]: S/MIME


