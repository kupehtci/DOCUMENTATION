#VAULT 

# Hashicorp/Vault - Docker image

You can launch Hashicorp/Vault from an docker image using the following commands: 

```bash
# Firstly pull the oficial image
docker pull hashicorp/vault:latest

docker volume create vault_data

# Run the image with arguments
# DEVELOPMENT MODE
docker run --cap-add=IPC_LOCK -d \
--name=vault-dev \
-p 8200:8200 \ 
-e 'VAULT_DEV_ROOT_TOKEN_ID=root' \ 
hashicorp/vault

# PRODUCTION MODE
docker run --cap-add=IPC_LOCK -d \
--name=vault-pro \
-p 8200:8200 \
-v vault_data:/vault/file \
-e 'VAULT_LOCAL_CONFIG={
	"storage": {"file": {"path": "/vault/file"}},
	"api_addr": "http://127.0.0.1:8200", 
	"listener": [{"tcp": { "address": "0.0.0.0:8200", "tls_disable": true}}],
	"default_lease_ttl": "168h",
	"max_lease_ttl": "720h",
	"ui": true
  }' \
hashicorp/vault server

# Check the running container
docker ps
```

The image accept the following arguments: 
* `--cap-add=`: IPC_LOCK
* `-e 'VAULT_DEV_ROOT_TOKEN_ID=root'` define the value for a root "user" token value for login.
* `server`: this last command overwrites the last CMD command in the Dockerfile, overwriting `server -dev` with `server` that runs in production mode.

Take into account that docker image common run won't work without arguments: 

```bash
# Basic run won't work
docker run -d -p 3000:80 hashicorp/vault
```


Once you have run it, remember to update the Vault's address accordingly if you have not set TLS (HTTPs) connection or it will indicate: 

```bash
$ vault operator init
WARNING! VAULT_ADDR and -address unset. Defaulting to https://127.0.0.1:8200.
```

Execute this to set the VAULT_ADDR variable: 
```bash
export VAULT_ADDR="http://127.0.0.1:8200"
```



#### Notes


```bash
 docker run --cap-add=IPC_LOCK -d \
--name=vault-pro \
-p 8200:8200 \
-v vault_data:/vault/file \
-e 'VAULT_LOCAL_CONFIG={
        "storage": {"file": {"path": "/vault/file"}},
        "api_addr": "http://0.0.0.0:8200", 
        "listener": [{"tcp": { "address": "0.0.0.0:8200", "tls_disable": true}}],
        "default_lease_ttl": "168h",
        "max_lease_ttl": "720h",
        "ui": true
  }' \
hashicorp/vault server
```


```bash
docker run --cap-add=IPC_LOCK -d \
--name=vault-pro \
-p 8200:8200 \
-v vault_data:/vault/file \
-e 'VAULT_LOCAL_CONFIG={
        "storage": {"file": {"path": "/vault/file"}},
        "api_addr": "http://0.0.0.0:8200", 
        "listener": [{"tcp": { "address": "0.0.0.0:8200", "tls_disable": true}}],
        "default_lease_ttl": "168h",
        "max_lease_ttl": "720h",
        "ui": true
  }' \
hashicorp/vault server
```