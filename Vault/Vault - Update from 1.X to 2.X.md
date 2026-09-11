#VAULT 

# Vault - Update from 1.X to 2.X

In order to upgrade vault in a RPM/YUM installed version: 

```bash
# Check actual version
vault version
rpm -qi vault 
cat /etc/yum.repos.d/hashicorp.repo

# Update the packages index
sudo dnf clean all 
sudo dnf makecache

# Check vault available versions
sudo dnf list available vault

# Update
sudo dnf upgrade vault
# or to force an specific version
sudo dnf install vault-2.0.4

# Restart the service
sudo systemctl restart vault
sudo systemctl status vault

# Verify status
export VAULT_ADDR=http://127.0.0.1:8200 # Or https
vault status
```

