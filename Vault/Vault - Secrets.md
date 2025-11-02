#VAULT 



### Fetch secrets


For fetching the key / value pairs contained in a secret, you can do an api call to: 

	<vault-url>/v1/<engine-path>/data/<secret-name>

```bash
# Example with a KV2 secret engine called secret and a secret called polaris
curl \
  --header "X-Vault-Token: root" \
  http://localhost:8200/v1/secret/data/polaris
```

By using Hashicorp's Vault, you can obtain secrets using HTTP or HTTPs requests. 

With a `token` authentication method, you can obtain a secret using: 

```bash
curl 
--header "X-Vault-Token: root" \
http://localhost:8200/v1/secret/data/PolarisDoc
```

And you will obtain a response like this one: 

```json
{
"request_id":"5ae0fa42-da4b-43b2-56a1-69aae3819662",
"lease_id":"",
"renewable":false,
"lease_duration":0,
"data":
{
  "data":
  {
    "API_TOKEN":"example_token_value"},
    "metadata":
    {
      "created_time":"2025-10-29T09:03:40.347963424Z",
      "custom_metadata":
      {
        "description":"Example API_TOKEN" "
      },
      "deletion_time":"",
      "destroyed":false,
      "version":1
   }
},
"wrap_info":null,
"warnings":null,
"auth":null,
"mount_type":"kv"
}
```

Indicating: 

* `request_id`	Unique ID assigned by Vault to this specific API request. Useful for tracing in logs.
* `lease_id`	Used when the response includes data that “expires” (like dynamic secrets). KV secrets don’t have leases, so it’s empty.
* `renewable`	Indicates if this secret’s lease can be renewed. For static KV secrets → false. For dynamic creds → true.
* `lease_duration`: How long the lease is valid (in seconds). KV secrets don’t expire, so 0.
* `wrap_info`	Contains wrapping information if response-wrapping was requested (used for secure secret handoff). null if not used.
* `warnings` Any non-fatal warnings returned by Vault (for example, deprecated API calls). null here.
* `auth` Present only in login responses, contains authentication info (client_token, policies, etc.). null for secret reads.
* `mount_type`	The type of secrets engine that served the request. In your case: kv (Key/Value secrets engine).

* `data.data` Data contains the actual key/value pairs for the secrets stored.
* `data.metadata`: metadata about the secrets stored. This metadata is defined by vault and some custom metadata that can be inserted when creating the secret. 
	* `data.metadata.created_time`Timestamp when this secret version was created.
* `data.metadata.custom_metadata`	Optional metadata you can attach manually when writing the secret (like a description, tags, etc.).
* `data.metadata.deletion_time`	When the secret version was deleted. Empty if not deleted.
* `data.metadata.destroyed`	Boolean — true if this version was permanently destroyed (KV v2 supports soft deletes and destroys).
* `data.metadata.version`	Version number of the secret (KV v2 supports versioning).


You can query specific secret values using `jq` command: 

```bash
curl \ 
--header "X-Vault-Token: root" \
http://localhost:8200/v1/secret/data/PolarisDoc  | jq '.data.data.API_TOKEN'
``` 

