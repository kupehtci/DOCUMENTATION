#VAULT 


## Create an AppRole

At the time of write this documentation, vault has no capabilities of creating a role inside an AppRole Authentication method directly on UI, but can be created using console. 

To create an AppRole's role follow this steps: 

1. Login into vault using the CLI: 
```bash
vault login --method=token
```

2. List authentication methods: 
```bash
vault auth list
```
It will print a list of all the authentication methods available so, select the AppRole needed one and take note about the name of the AppRole. 

3. Create a role: 
```bash
# Template
vault write auth/{AUTH_APPROLE_NAME}/role/{ROLE_NAME} \
    token_policies="default,{POLICY_NAME}"

# Example with "approle" authentication method and role names "myapp"
# And default and my-policy
vault write auth/approle/role/myapp \
    token_policies="default,my-policy"
```

4. List the available roles once you have created it: 
```bash
> vault write auth/approle/role/polarisdoc-pro \
token_policies="default,vault-pro_all"

Success! Data written to: auth/approle/role/polarisdoc-pro

> vault list /auth/approle/role
Keys
----
polarisdoc-pro
```

5. You can inspect the created role using: 
```bash
vault read /auth/{AUTH_APPROLE_NAME}/role/{ROLE_NAME}
Key                        Value
---                        -----
bind_secret_id             true
local_secret_ids           false
secret_id_bound_cidrs      <nil>
secret_id_num_uses         0
secret_id_ttl              0s
token_bound_cidrs          []
token_explicit_max_ttl     0s
token_max_ttl              0s
token_no_default_policy    false
token_num_uses             0
token_period               0s
token_policies             [default my-policy]
token_ttl                  0s
token_type                 default
```

6. Fetch the `role-id`: 
```bash
vault read /auth/{AUTH_APPROLE_NAME}/role/{ROLE_NAME}/role-id
Key        Value
---        -----
role_id    aa394e3b-b41f-6968-3dr3-422edc1f255a
```

7. Create a `secret-id`: 

```bash
vault write -f /auth/{AUTH_APPROLE_NAME}/role/{ROLE_NAME}/secret-id
```

## Authenticate

AppRoles can authenticate using `/v1/auth/{AUTH_APPROLE_NAME}/login` example: `www.vault-url.com/v1/auth/approle/login` with a POST request passing as data: 

```json
{
	"role_id": "role_id_value",
	"secret_id": "secret_id_value"
}
```

Example: 

```bash
curl --request POST \
  --data '{"role_id":"YOUR_ROLE_ID","secret_id":"YOUR_SECRET_ID"}' \
  http://127.0.0.1:8200/v1/auth/approle/login
```

This will return some data including a token: 

```bash
{
  "request_id": "151fc4d3-a6a3-e31f-82db-3916c2e75d26",
  "lease_id": "",
  "renewable": false,
  "lease_duration": 0,
  "data": null,
  "wrap_info": null,
  "warnings": null,
  "auth": {
    "client_token": "hvs.CBDSIGGT81dKyKDiaWy_3UhksadtW5aMnEjcpmbPrpR78_O-GGh4KHGh2cy45SHFnZ0M0cFQ4cF9jRnBaa1VJQzFyNII",
    "accessor": "ktKvjhEgtBrURMuEdFAQtr9m",
    "policies": [
      "default",
      "vault-pro_all"
    ],
    "token_policies": [
      "default",
      "vault-pro_all"
    ],
    "metadata": {
      "role_name": "polarisdoc-pro"
    },
    "lease_duration": 604800,
    "renewable": true,
    "entity_id": "b32b1576-9453-fac9-896a-6880357def59",
    "token_type": "service",
    "orphan": true,
    "mfa_requirement": null,
    "num_uses": 0
  },
  "mount_type": ""
}
```

