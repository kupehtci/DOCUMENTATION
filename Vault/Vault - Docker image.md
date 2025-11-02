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
	"api_addr": "http://127.0.0.1:8200"
	"listener": [{"tcp": { "address": "0.0.0.0:8200", "tls_disable": true}}],
	"default_lease_ttl": "168h",
	"max_lease_ttl": "720h",
	"ui": true
  }' \
hashicorp/vault

# Check the running container
docker ps
```

The image accept the following arguments: 
* `--cap-add=`: IPC_LOCK
* `-e 'VAULT_DEV_ROOT_TOKEN_ID=root'` define the value for a root "user" token value for login.

Take into account that docker image common run won't work without arguments: 

```bash
# Basic run won't work
docker run -d -p 3000:80 hashicorp/vault
```