#VAULT 

# Vault - Installation

This is a guide for Hashicorp's vault installation as a Linux service (Daemon) in a Linux system. 

Baremetal installations of Vault are more recommended for an stable and secure production solution of vault. For containerized installation and development, you can check on [[Vault - Docker image]]. 

## Requirements

The machine requirements for installing Vault: 
* HTTPS (Port 443) access to `https://rpm.releases.hashicorp.com` (take into account for firewall on private networks)
* User `vault` with sudo permissions or administrator user. 
* Linux machine with enough resources for Vault. 

## Installation guide

This guide uses the linux's package manager, but binaries can be downloaded in [Install vault](https://developer.hashicorp.com/vault/install). 

1. Install vault cli tool using the package manager: 

```bash
# Install utilities
sudo yum install -y yum-utils
# Add the hashicorp repo to the package manager
sudo yum-config-manager --add-repo https://rpm.releases.hashicorp.com/RHEL/hashicorp.repo
# Install vault from that repository
sudo yum -y install vault
```

* If encountering some SSL errors when downloading releases.hashicorp, use the following command to avoid SSL verification. 
```bash
sudo curl -k -o /etc/yum.repos.d/hashicorp.repo https://rpm.releases.hashicorp.com/RHEL/hashicorp.repo
```

2. Verify the vault installation: 
```bash
vault --version
```

3. Create vault user and directories: 
	* create a **non-root** user for executing the service
	* create the directory for vault data, logs and configurations

```bash
sudo useradd --system --home /etc/vault.d --shell /bin/false vault

# Create the neccesary directories
sudo mkdir -p /opt/vault/data
sudo mkdir -p /etc/vault.d
sudo mkdir -p /var/log/vault

# Set ownership
sudo chown -R vault:vault /opt/vault
sudo chown -R vault:vault /etc/vault.d
sudo chown -R vault:vault /var/log/vault
```

4. Configure vault before starting the server. 
* Configuration is defined in `/etc/vault.d/vault.hcl` file using hashicorp language: 

```hcl
# REVIEW THIS
# Storage backend configuration
storage "raft" {
  path    = "/opt/vault/data"
  node_id = "vault-node-1"
}

# Listener configuration
listener "tcp" {
  address       = "0.0.0.0:8200"
  tls_disable   = 0
  tls_cert_file = "/etc/vault.d/tls/vault-cert.pem"
  tls_key_file  = "/etc/vault.d/tls/vault-key.pem"
}

# API and cluster addresses
api_addr = "https://vault.example.com:8200"
cluster_addr = "https://vault.example.com:8201"

# UI configuration
ui = true

# Disable mlock for development (enable for production)
disable_mlock = false

# Log level
log_level = "Info"

# Maximum lease TTL
max_lease_ttl = "876000h"
default_lease_ttl = "876000h"
```


* Restrict the permissions over the configuration file: 

```bash
sudo chown -R vault:vault /etc/vault.d 
sudo chmod 640 /etc/vault.d/vault.hcl
```

5. Configure a [[systemd service]] ([[systemd]]) for running the vault server: 

```ini
[Unit]
Description="HashiCorp Vault"
Documentation="https://www.vaultproject.io/docs/"
Requires=network-online.target
After=network-online.target
ConditionFileNotEmpty=/etc/vault.d/vault.hcl

[Service]
Type=notify
User=vault
Group=vault
ProtectSystem=full
ProtectHome=read-only
PrivateTmp=yes
PrivateDevices=yes
SecureBits=keep-caps
AmbientCapabilities=CAP_IPC_LOCK
Capabilities=CAP_IPC_LOCK+ep
CapabilityBoundingSet=CAP_SYSLOG CAP_IPC_LOCK
NoNewPrivileges=yes
ExecStart=/usr/bin/vault server -config=/etc/vault.d/vault.hcl
ExecReload=/bin/kill --signal HUP $MAINPID
KillMode=process
KillSignal=SIGINT
Restart=on-failure
RestartSec=5
TimeoutStopSec=30
StartLimitInterval=60
StartLimitBurst=3
LimitNOFILE=65536
LimitMEMLOCK=infinity

[Install]
WantedBy=multi-user.target
```

Example: 
```ini
[Unit]
Description="HashiCorp Vault"
Documentation="https://developer.hashicorp.com/vault/docs"
ConditionFileNotEmpty="${VAULT_CONFIG}/vault.hcl"

[Service]
User=vault
Group=vault
SecureBits=keep-caps
AmbientCapabilities=CAP_IPC_LOCK
CapabilityBoundingSet=CAP_SYSLOG CAP_IPC_LOCK
NoNewPrivileges=yes
ExecStart=${VAULT_BINARY} server -config=${VAULT_CONFIG}/vault.hcl
ExecReload=/bin/kill --signal HUP
KillMode=process
KillSignal=SIGINT

[Install]
WantedBy=multi-user.target
```

6. Machine should have the 8200 and 8201 (Only in HA) ports open. 
7. Enable the vault service: 

```bash
# Reload systemd to check for new services
sudo systemctl daemon-reload

# Enable vault to start on boot
sudo systemctl enable vault

# start the service on this session
sudo systemctl start vault

# Check status of the running service
sudo systemctl status vault

# Verify logs
sudo journalctl -u vault -f
```

8. Initialize the vault: 

```bash
export VAULT_ADDR='https://127.0.0.1:8200'

# Optional, only if using self-signed certificate
export VAULT_SKIP_VERIFY=1

# Initialize vault (Generate unseal keys and root token)
vault operator init
```

9. Unseal and manage the vault: 

```bash 
# Unseal with 3 different keys
vault operator unseal <unseal_key_1>
vault operator unseal <unseal_key_2>
vault operator unseal <unseal_key_3>

# Check status
vault status
```

10. Login and verification of the vault: 

```bash
# Login with root token
vault login <root_token>

# Enable secrets engine (example)
vault secrets enable -path=secret kv-v2

# Write a test secret
vault kv put secret/test password=mypassword

# Read the secret
vault kv get secret/test
```


Its recommended in production, once you have create the proper users to revoke the root token: 
```bash
vault token revoke <root_token>
```

### Service analysis

The service defined to run the vault server is defined with the following configuration: 

```ini
[Unit]
Description="HashiCorp Vault"
Documentation="https://developer.hashicorp.com/vault/docs"
ConditionFileNotEmpty="${VAULT_CONFIG}/vault.hcl"

[Service]
# User that will run the service
User=vault
# Group that will run the service
Group=vault

# Keep the capabilities when root user is dropped
SecureBits=keep-caps

# Add capabilities to the ambien so process has them even with no-root user
AmbientCapabilities=CAP_IPC_LOCK

# Define the caps that vault can gain
CapabilityBoundingSet=CAP_SYSLOG CAP_IPC_LOCK

# Prevent service from gaining more priviledges that the ones at startup
NoNewPrivileges=yes

# execute `vault server` command on start with config
ExecStart=${VAULT_BINARY} server -config=${VAULT_CONFIG}/vault.hcl

# kill the process on reload
ExecReload=/bin/kill --signal HUP

# process kill configuration
KillMode=process
KillSignal=SIGINT

[Install]
WantedBy=multi-user.target
```