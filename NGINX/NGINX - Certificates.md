#NGINX 

# NGINX - Certificates

NGINX uses standard X.509 certificates[^1] to provide HTTPS and TLS protected connections. 
This certificates are configured per `server` block using `ssl_certificate` and `ssl_certificate_key` directives while listening on 443 port. 

A minimal configuration for SSL needs to be: 
* `listen 443 ssl` enables TLS on port 443 for that server. 
* `ssl_certificate /path/fullchain.pem` specify the server certificate and any intermediate CA certificates in one file. 
* `ssl_certificate_key /path/to/privatekey.pem`  path to the private key matching the certificate. 

In case os using same host let's encrypt instance, automated certificates will be placed under `/etc/letsencrypt/live/<domain>/` and can be referenced directly by NGINX certificate functionality. 


[^1]: X.509 certificates [[X.509 Certificates]]