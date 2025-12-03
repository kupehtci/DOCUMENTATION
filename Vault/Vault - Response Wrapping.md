#VAULT 

# Vault - Response Wrapping

Response Wrapping is a method in Vault for creating a single-use token to transmit the secret_id without sending directly the actual secret in the initial API response. 

This token can be unwrapped once, using the Vault API to reveal the actual secret.

As a security feature it offers: 
* Can only be **unwrapped once**, if try to unwrap it and returns an error, means that the token has be used by a not allowed party, 
* **TTL Control**: wrapping a token is defined with a token lifetime, independent from the actual secret's lease; that prevents exposure of the token if the actual recipient fails to unwrap it. 
* IT provides a **cover** by ensuring the value transmitted is not the actual secret. 


Using the `/sys/wrapping` path, the client can do different operations using the wrapping token: 

* `/sys/wrapping/lookup`: this allow to get information about a wrapped token without unwrapping it: 
	* Its an unauthenticated API path, so every wrapped token's holder is allowed to retrieve information about the token itself. 
* `/sys/wrapping/unwrap`: unwrap the given token, returning the response inside (secret). 
* `/sys/wrapping/rewrap`: allows to migrate or exchange the actual's token data to a new wrapping token with a new TTL. 
* `/sys/wrapping/wrap`: responses a wrapped token from the data sent. 

Creating a wrapped token from the response of a secret obtention can be done using the `X-Vault-Wrap-TTL` header indicating a string with seconds, minutes or hours that define the TTL of the wrapped token. 



