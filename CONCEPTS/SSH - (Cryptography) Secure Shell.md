#CONCEPTS 


#### SECURE SHELL SSH

Is an access credential used in SSH protocol. 

Its a cryptographic network protocol used for transferring encrypted data over the network. 

It used a kay pair: 

* **Public Key** - Everyone sees it and its not need of protection (used for encryption)
* **Private Key** - Stays in computer and must be protected (used for decryption)

The general functioning of SSH Authentication is: 

- Public keys from the local computers (system) are passed to the server which is to be accessed.
- Server then identifies if the public key is registered.
- If so, the server then creates a new secret key and encrypts it with the public key which was send to it via local computer.
- This encrypted code is send to the local computer.
- This data is unlocked by the private key of the system and is send to the server.
- Server after receiving this data verifies the local computer.
- SSH creates a route and all the encrypted data are transferred through it with no security issues.