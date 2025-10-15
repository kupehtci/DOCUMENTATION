

# NPM - Self signed certificate in chain

Sometimes when installing dependencies from a remote repository that is served under an HTTPs method that uses SSL for security, the following error can appear in SSL validation: 

```
npm error code SELF_SIGNED_CERT_IN_CHAIN

npm error errno SELF_SIGNED_CERT_IN_CHAIN

npm error request to [https://url.example.com:8443/repository/npm-OMC/@packages%2fframework]() failed, reason: self-signed certificate in certificate chain

npm error A complete log of this run can be found in: C:\Users\LS_ACC_DevOpsComp\AppData\Local\npm-cache\_logs\2025-06-17T09_30_19_973Z-debug-0.log
```

Indicating in the error `failed, reason: self-signed certificate in certificate chain`. 

To solve this, you can set the config for `strict-ssl` to false before doing `npm install`: 
```bash
npm config set strict-ssl false
```

And then again: 
```bash
npm install
```