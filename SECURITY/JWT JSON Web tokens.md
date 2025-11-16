#CONCEPTS 

# JSON Web Tokens or JWT

A **JSON Web Token** or JWT is a compact and URL-safe authentication way to securely transmit information between two parties.  

Its commonly used for authentication and security between Frontend and Backend applications (Web Applications).

When the users logins, the backend should generate a JWT and send it to the frontend. The client now will include this token in the header of all future requests to prove its identity. 

## Structure

A JWT consist in three different parts separated by a dot. 

```txt
header.payload.signature
```

* **Header**: contains metadata about the token (algorithm and type): 
```json
{
  "alg": "HS256",
  "typ": "JWT"
}
```
* **Payload**: contains the actual data of the token:
	* sub or subject
	* name or other data
	* iat or Issued At (timestamp)
```json
{
  "sub": "1234567890",
  "name": "John Doe",
  "iat": 1516239022
}
```
* **Signature**: contains a cypher to ensure the token has not been altered. It is obtained using a **secret key**, the encoded header and payload and signing them with the algorithm.

If someones tampers the JWT, the signature won't match. 

### Usage

The Frontend or the client when making requests it will send the token in an HTTP header, such as: 
```txt
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
```

