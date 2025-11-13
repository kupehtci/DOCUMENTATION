#VAULT 

# Vault - Policies

A **policy** in Vault is a ...


### Policy format


### Copy

You can copy a custom policy into docker container into folder %%TODO%%

Policies can be created in **Policies > Create new policy** and write the policy in HCL language. 


## Deny policy

An AppRole's role with an implicit deny policy like: 

```hcl
path "vault-pro/data/*" { 
	capabilities = ["deny"] 
}
```

Wont be able to do this request: 
```bash
curl --header "X-Vault-Token: hvs.CAE...longtoken..." \
http://127.0.0.1:8200/v1/vault-pro/data/polarisdoc-pro
```

Or access any other data inside that is inside `vault-pro` secret engine.

This `deny` policy can be combined with an `allow` policy to restrict traffic to a single secret inside a secret engine for example: 

```hcl
path "vault-pro/data/*" { 
	capabilities = ["deny"] 
} 

path "vault-pro/data/example" { 
	capabilities = ["read"] 
}
```
