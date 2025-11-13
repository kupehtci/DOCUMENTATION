#VAULT 

# VAULT - Unseal

When you run the Vault in production mode, the cluster will run in "sealed" mode. 
Meaning that 5 layers of encryption are applied and you need to "unseal" the first 3 ones to be able to work with Vault. 

To do this, follow this steps: 

1. Initialize the operator: 
```bash
# Inside CLI
vault operator init

# Docker image command
docker exec -it vault-pro vault operator init
```

This will prompt 5 seal tokens (Store them) and a Root token (Store it as well) valid for administrator initial login, with a message like this: 

```txt
> vault operator init
Unseal Key 1: xxxxxxxxxxxxxxxxx 
Unseal Key 2: xxxxxxxxxxxxxxxxx
Unseal Key 3: xxxxxxxxxxxxxxxxx
Unseal Key 4: xxxxxxxxxxxxxxxxx
Unseal Key 5: xxxxxxxxxxxxxxxxx

Initial Root Token: hvs.xxxxxxxxxxxxxxxxx

Vault initialized with 5 key shares and a key threshold of 3. Please securely distribute the key shares printed above. When the Vault is re-sealed,
restarted, or stopped, you must supply at least 3 of these keys to unseal itbefore it can start servicing requests.

Vault does not store the generated root key. Without at least 3 keys to
reconstruct the root key, Vault will remain permanently sealed!

It is possible to generate new unseal keys, provided you have a quorum of
existing unseal keys shares. See "vault operator rekey" for more information.
```

2. Unseal 3 layers by repeating this command, each time with a different token: 
```bash
docker exec -it vault-pro vault operator unseal <token>
```


