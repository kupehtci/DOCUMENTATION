Quick reference of the most used `vault` CLI commands, both for daily usage and for administering a [[Hashicorp Vault]] server/cluster.

> Placeholders are written as `{PLACEHOLDER}`. Most commands accept `-format=json` (or `VAULT_FORMAT=json`) to get a machine readable output.

## Environment variables

Before running any command the CLI must know where the server is and how to authenticate against it:

| Variable            | Purpose                                                                  |
| :------------------ | ------------------------------------------------------------------------ |
| `VAULT_ADDR`        | Address of the Vault server, e.g. `https://vault.example.com:8200`        |
| `VAULT_TOKEN`       | Token used to authenticate the requests                                   |
| `VAULT_NAMESPACE`   | Namespace where the commands are executed (Enterprise / HCP only)         |
| `VAULT_CACERT`      | Path to the CA certificate used to verify the server TLS certificate      |
| `VAULT_SKIP_VERIFY` | Skip TLS verification (`true`). Only for testing, never in production     |
| `VAULT_FORMAT`      | Default output format: `table`, `json` or `yaml`                          |

## General / helper commands

| Command                                        | Purpose                                                                      |
| :--------------------------------------------- | ---------------------------------------------------------------------------- |
| `vault version`                                | Print the CLI version                                                        |
| `vault status`                                 | Show seal status, HA mode, storage type, version, cluster name...            |
| `vault login`                                  | Authenticate with a token (see [[Vault - Login]])                            |
| `vault login -method=userpass username={USER}` | Authenticate using another auth method                                       |
| `vault print token`                            | Print the token currently stored by the CLI                                  |
| `vault path-help {PATH}`                       | Show the help and available endpoints of a path, e.g. `vault path-help sys/` |
| `vault read sys/health`                        | Health endpoint (initialized, sealed, standby, version...)                   |
| `vault read sys/leader`                        | Show which node is the current HA leader                                     |
| `vault read sys/seal-status`                   | Seal status in API format                                                    |
| `vault read sys/host-info`                     | Host information (CPU, memory, disk) of the node                             |
| `vault read sys/config/state/sanitized`        | Show the running server configuration without sensitive values               |

## Operator: initialization, seal and unseal

See [[Vault - Unseal]] for the full explanation of the seal/unseal process.

| Command                                                  | Purpose                                                                                   |
| :------------------------------------------------------- | ----------------------------------------------------------------------------------------- |
| `vault operator init`                                    | Initialize a new Vault (default 5 key shares, threshold 3). Returns unseal keys + root token |
| `vault operator init -key-shares=5 -key-threshold=3`     | Initialize choosing the number of key shares and the threshold                            |
| `vault operator init -recovery-shares=5 -recovery-threshold=3` | Initialize when using auto-unseal (returns recovery keys instead of unseal keys)    |
| `vault operator init -status`                            | Check if Vault is initialized (exit code `0` initialized, `2` not initialized)             |
| `vault operator unseal`                                  | Provide one unseal key (prompted). Repeat until the threshold is reached                   |
| `vault operator unseal -reset`                           | Discard the unseal keys provided so far                                                    |
| `vault operator seal`                                    | Seal the node. It stops serving requests until unsealed again                              |
| `vault operator step-down`                               | Force the active node to step down and let another node become leader                     |
| `vault operator members`                                 | List the nodes of the HA cluster                                                           |
| `vault operator diagnose -config={CONFIG-FILE}`          | Validate the configuration and environment before starting the server                     |

> Store the unseal keys and the root token in different secure places. Revoke the root token once the initial configuration is done (`vault token revoke {ROOT-TOKEN}`).

## Operator: keys and root token

| Command                                                            | Purpose                                                                    |
| :----------------------------------------------------------------- | -------------------------------------------------------------------------- |
| `vault operator key-status`                                        | Show the current encryption key term and install time                       |
| `vault operator rotate`                                            | Rotate the internal encryption key (keyring). Old keys are kept to decrypt old data |
| `vault operator rekey -init -key-shares=5 -key-threshold=3`        | Start a rekey process: generate new unseal keys (changes shares/threshold)  |
| `vault operator rekey`                                             | Provide current unseal keys to continue the rekey process                   |
| `vault operator rekey -status`                                     | Show the progress of the current rekey                                      |
| `vault operator rekey -cancel`                                     | Cancel an in-progress rekey                                                 |
| `vault operator rekey -target=recovery -init ...`                  | Rekey recovery keys (auto-unseal)                                           |
| `vault operator generate-root -generate-otp`                       | Generate the OTP used to encode the new root token                          |
| `vault operator generate-root -init -otp={OTP}`                    | Start the generation of a new root token                                    |
| `vault operator generate-root`                                     | Provide unseal/recovery keys (prompted) until reaching the threshold        |
| `vault operator generate-root -decode={ENCODED-TOKEN} -otp={OTP}`  | Decode the resulting root token                                             |
| `vault operator generate-root -cancel`                             | Cancel the root token generation                                            |

## Operator: Raft integrated storage

See [[Vault - Raft Storage]].

| Command                                                           | Purpose                                                          |
| :---------------------------------------------------------------- | ---------------------------------------------------------------- |
| `vault operator raft list-peers`                                  | List the Raft peers, their state (leader/follower) and voter status |
| `vault operator raft join {LEADER-API-ADDR}`                      | Join the current node to an existing Raft cluster                 |
| `vault operator raft remove-peer {NODE-ID}`                       | Remove a node from the Raft cluster                               |
| `vault operator raft snapshot save {FILE}.snap`                   | Take a snapshot (backup) of the whole Vault data                  |
| `vault operator raft snapshot restore {FILE}.snap`                | Restore a snapshot                                                |
| `vault operator raft snapshot restore -force {FILE}.snap`         | Restore a snapshot taken from a different cluster (different keys)|
| `vault operator raft autopilot state`                             | Show the autopilot state and the health of every node             |
| `vault operator raft autopilot get-config`                        | Show the autopilot configuration                                  |
| `vault operator raft autopilot set-config -cleanup-dead-servers=true -dead-server-last-contact-threshold=10m -min-quorum=3` | Configure autopilot to remove dead nodes automatically |

## Secrets engines

See [[Vault - Secrets]].

| Command                                                         | Purpose                                                              |
| :-------------------------------------------------------------- | -------------------------------------------------------------------- |
| `vault secrets list`                                            | List the enabled secrets engines                                     |
| `vault secrets list -detailed`                                  | List them with more details (version, TTLs, accessor, options)       |
| `vault secrets enable -path={PATH} kv-v2`                       | Enable a KV version 2 engine on `{PATH}`                             |
| `vault secrets enable -path={PATH} -version=1 kv`               | Enable a KV version 1 engine                                         |
| `vault secrets enable -path={PATH} -description="{TEXT}" {TYPE}` | Enable any engine (`database`, `pki`, `transit`, `aws`, `ssh`...)   |
| `vault secrets disable {PATH}`                                  | Disable an engine. **All the secrets stored on it are deleted**      |
| `vault secrets move {OLD-PATH} {NEW-PATH}`                      | Move an engine to another path                                       |
| `vault secrets tune -default-lease-ttl=1h -max-lease-ttl=24h {PATH}` | Change the TTLs of an engine                                    |
| `vault secrets tune -audit-non-hmac-request-keys={KEY} {PATH}`  | Show a request key in plain text in the audit logs                   |
| `vault kv enable-versioning {PATH}`                             | Upgrade a KV v1 engine to v2                                         |

### KV secrets

| Command                                                   | Purpose                                                       |
| :-------------------------------------------------------- | ------------------------------------------------------------- |
| `vault kv list {MOUNT}/{PATH}`                            | List the secrets under a path                                 |
| `vault kv get {MOUNT}/{PATH}`                             | Read the latest version of a secret                           |
| `vault kv get -version={N} {MOUNT}/{PATH}`                | Read a specific version                                       |
| `vault kv get -field={KEY} {MOUNT}/{PATH}`                | Read only one field of the secret                             |
| `vault kv put {MOUNT}/{PATH} {KEY}={VALUE} {KEY2}={VALUE2}` | Create/overwrite a secret (new version)                     |
| `vault kv put {MOUNT}/{PATH} @{FILE}.json`                | Create a secret from a JSON file                              |
| `vault kv patch {MOUNT}/{PATH} {KEY}={VALUE}`             | Update only some fields keeping the rest                      |
| `vault kv delete {MOUNT}/{PATH}`                          | Soft delete the latest version (recoverable)                  |
| `vault kv undelete -versions={N} {MOUNT}/{PATH}`          | Recover a soft deleted version                                |
| `vault kv destroy -versions={N} {MOUNT}/{PATH}`           | Permanently destroy a version                                 |
| `vault kv rollback -version={N} {MOUNT}/{PATH}`           | Create a new version with the content of version `{N}`        |
| `vault kv metadata get {MOUNT}/{PATH}`                    | Show the metadata and versions of a secret                    |
| `vault kv metadata put -max-versions={N} {MOUNT}/{PATH}`  | Configure the number of versions kept                         |
| `vault kv metadata delete {MOUNT}/{PATH}`                 | Delete the secret with all its versions and metadata          |

## Authentication methods

See [[Vault - Authentication and Authorization]].

| Command                                                        | Purpose                                                     |
| :------------------------------------------------------------- | ----------------------------------------------------------- |
| `vault auth list`                                              | List all available authentication methods                   |
| `vault auth list -detailed`                                    | List all available authentication methods with more details |
| `vault auth list -format=json`                                 | List all available authentication methods with JSON format  |
| `vault auth enable {TYPE}`                                     | Enable an auth method on its default path (`auth/{TYPE}`)    |
| `vault auth enable -path={PATH} {TYPE}`                        | Enable an auth method on a custom path                       |
| `vault auth disable {PATH}`                                    | Disable an auth method. **Revokes all the tokens it issued** |
| `vault auth move auth/{OLD-PATH} auth/{NEW-PATH}`              | Move an auth method to another path                          |
| `vault auth tune -default-lease-ttl=1h -max-lease-ttl=8h {PATH}` | Change the TTLs of the tokens issued by the method        |
| `vault auth tune -listing-visibility=unauth {PATH}`            | Show the method in the UI login page                         |
| `vault auth help {TYPE}`                                       | Show how to log in with a certain method                     |

Use `-format=json` for getting Authentication method's accessors that are needed for creating entity aliases.

### AppRole

For interacting with vault's roles from the AppRole Authentication method you can use the following command, supposing you have an enabled AppRole with "approle" name (see [[Vault - AppRole]]):

Path: `/auth/{METHOD-NAME}/role/{[OPT]ROLE-NAME}`

| Command                                                                                              | Purpose                                                                            |
| :--------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------- |
| `vault list auth/approle/role`                                                                       | List all declared roles                                                            |
| `vault read auth/approle/role/{ROLE-NAME}`                                                           | Get metadata from a single role                                                    |
| `vault write auth/approle/role/{ROLE-NAME} token_policies="policy-one,policy-two"`                   | Create a role under "approle" with `{ROLE-NAME}` name and policies attached to it. |
| `vault read auth/approle/role/{ROLE-NAME}/role-id`                                                   | Get the `role_id` from a role.                                                     |
| `vault write -f auth/approle/role/{ROLE-NAME}/secret-id`                                             | Create a new `secret_id` for the role and retrieve it.                             |
| `vault list auth/approle/role/{ROLE-NAME}/secret-id`                                                 | List the accessors of the `secret_id`s generated for the role                      |
| `vault write auth/approle/role/{ROLE-NAME}/secret-id-accessor/destroy secret_id_accessor={ACCESSOR}` | Revoke a `secret_id` by its accessor                                               |
| `vault write auth/approle/login role_id={ROLE-ID} secret_id={SECRET-ID}`                             | Login with an AppRole's role using the `role_id` and `secret_id`.                  |
| `vault delete auth/approle/role/{ROLE-NAME}`                                                         | Delete a role                                                                      |

Take into account that `write` command has an -f as force, meaning that won't prompt requesting an input, it will create the `secret_id` itself and prompt it.

### Userpass

| Command                                                                         | Purpose                         |
| :------------------------------------------------------------------------------ | ------------------------------- |
| `vault write auth/userpass/users/{USER} password={PASSWORD} token_policies={POLICY}` | Create/update a user        |
| `vault list auth/userpass/users`                                                | List users                      |
| `vault write auth/userpass/users/{USER}/password password={PASSWORD}`           | Change a user's password        |
| `vault delete auth/userpass/users/{USER}`                                       | Delete a user                   |

## Policies

See [[Vault - Policies]].

| Command                                   | Purpose                                                              |
| :---------------------------------------- | -------------------------------------------------------------------- |
| `vault policy list`                       | List all the policies                                                |
| `vault policy read {POLICY}`              | Show the content of a policy                                         |
| `vault policy write {POLICY} {FILE}.hcl`  | Create/update a policy from an HCL file                              |
| `vault policy write {POLICY} -`           | Create/update a policy reading it from stdin                         |
| `vault policy delete {POLICY}`            | Delete a policy                                                      |
| `vault policy fmt {FILE}.hcl`             | Format an HCL policy file                                            |
| `vault token capabilities {PATH}`         | Capabilities of the current token over a path                        |
| `vault token capabilities {TOKEN} {PATH}` | Capabilities of a given token over a path (useful to debug policies) |

## Tokens

| Command                                                           | Purpose                                                              |
| :---------------------------------------------------------------- | -------------------------------------------------------------------- |
| `vault token lookup`                                              | Information of the current token (policies, TTL, entity...)          |
| `vault token lookup {TOKEN}`                                      | Information of another token                                         |
| `vault token lookup -accessor {ACCESSOR}`                         | Information of a token by its accessor                               |
| `vault token create -policy={POLICY} -ttl=1h`                     | Create a child token with a policy and TTL                           |
| `vault token create -policy={POLICY} -period=24h`                 | Create a periodic token (renewable indefinitely inside the period)   |
| `vault token create -orphan -policy={POLICY}`                     | Create an orphan token (not revoked when its parent is revoked)      |
| `vault token create -use-limit={N} -policy={POLICY}`              | Create a token usable only `{N}` times                               |
| `vault token create -wrap-ttl=5m ...`                             | Create a response-wrapped token (see [[Vault - Response Wrapping]])  |
| `vault token renew`                                               | Renew the current token                                              |
| `vault token renew -increment=1h {TOKEN}`                         | Renew a token for a certain time                                     |
| `vault token revoke {TOKEN}`                                      | Revoke a token and all its children                                  |
| `vault token revoke -mode=orphan {TOKEN}`                         | Revoke a token keeping its children (they become orphan)             |
| `vault token revoke -accessor {ACCESSOR}`                         | Revoke a token by its accessor                                       |
| `vault token revoke -self`                                        | Revoke the current token                                             |
| `vault list auth/token/accessors`                                 | List the accessors of all the tokens (requires `sudo`)               |
| `vault write auth/token/roles/{ROLE} allowed_policies={POLICY} orphan=true` | Create a token role                                        |
| `vault token create -role={ROLE}`                                 | Create a token from a token role                                     |
| `vault write -f auth/token/tidy`                                  | Clean up invalid token entries and leases                            |

## Leases

| Command                                          | Purpose                                                      |
| :----------------------------------------------- | ------------------------------------------------------------ |
| `vault list sys/leases/lookup/{PREFIX}`          | List the leases under a prefix, e.g. `database/creds/{ROLE}` |
| `vault lease lookup {LEASE-ID}`                  | Information of a lease                                       |
| `vault lease renew {LEASE-ID}`                   | Renew a lease                                                |
| `vault lease renew -increment=1h {LEASE-ID}`     | Renew a lease for a certain time                             |
| `vault lease revoke {LEASE-ID}`                  | Revoke a lease                                               |
| `vault lease revoke -prefix {PREFIX}`            | Revoke all the leases under a prefix                         |
| `vault lease revoke -force -prefix {PREFIX}`     | Force removal even if the backend revocation fails           |

## Identity: entities, aliases and groups

Entities:

| Command                                                            | Purpose                                         |
| :----------------------------------------------------------------- | ----------------------------------------------- |
| `vault list identity/entity/name`                                  | List all entities by name                       |
| `vault list identity/entity/id`                                    | List all entities by id                         |
| `vault read identity/entity/name/{ENTITY-NAME}`                    | Get information about a certain entity by name  |
| `vault read identity/entity/id/{ENTITY-ID}`                        | Get information about a certain entity by id    |
| `vault write identity/entity name="{ENTITY-NAME}" policies="{POLICY}"` | Create an entity with a certain name        |
| `vault write identity/entity/name/{ENTITY-NAME} disabled=true`     | Disable an entity (its tokens stop working)     |
| `vault delete identity/entity/name/{ENTITY-NAME}`                  | Delete an entity                                |
| `vault write identity/entity/merge from_entity_ids={ID} to_entity_id={ID}` | Merge entities                          |

Work with aliases:

| Command                                                                                        | Purpose                                            |
| :--------------------------------------------------------------------------------------------- | -------------------------------------------------- |
| `vault list identity/entity-alias/id`                                                          | List all aliases                                   |
| `vault read identity/entity-alias/id/{ALIAS-ID}`                                               | Get information about an alias                     |
| `vault write identity/entity-alias name="{AUTH-USER-NAME}" canonical_id={ENTITY-ID} mount_accessor={AUTH-ACCESSOR}` | Link a user of an auth method to an entity |
| `vault delete identity/entity-alias/id/{ALIAS-ID}`                                             | Delete an alias                                    |

Groups:

| Command                                                                                                   | Purpose                                     |
| :-------------------------------------------------------------------------------------------------------- | ------------------------------------------- |
| `vault list identity/group/name`                                                                          | List all groups                             |
| `vault read identity/group/name/{GROUP-NAME}`                                                             | Get information about a group               |
| `vault write identity/group name="{GROUP-NAME}" policies="{POLICY}" member_entity_ids="{ID1},{ID2}"`     | Create an internal group with members       |
| `vault write identity/group name="{GROUP-NAME}" type=external policies="{POLICY}"`                       | Create an external group (LDAP, OIDC...)    |
| `vault write identity/group-alias name="{EXTERNAL-GROUP}" mount_accessor={AUTH-ACCESSOR} canonical_id={GROUP-ID}` | Link an external group to a Vault group |
| `vault delete identity/group/name/{GROUP-NAME}`                                                           | Delete a group                              |

## Audit devices

See [[Vault - Logs]].

| Command                                                              | Purpose                                                  |
| :------------------------------------------------------------------- | -------------------------------------------------------- |
| `vault audit list -detailed`                                         | List the enabled audit devices                           |
| `vault audit enable file file_path=/var/log/vault/audit.log`         | Enable a file audit device                               |
| `vault audit enable -path={NAME} file file_path={FILE}`              | Enable a second file audit device with another name      |
| `vault audit enable syslog tag="vault" facility="AUTH"`              | Enable a syslog audit device                             |
| `vault audit enable socket address={HOST}:{PORT} socket_type=tcp`    | Send audit logs to a socket                              |
| `vault audit disable {PATH}`                                         | Disable an audit device                                  |
| `vault write sys/audit-hash/{PATH} input="{VALUE}"`                  | Get the HMAC of a value to search it in the audit logs   |

> If all the enabled audit devices fail to write, Vault stops serving requests. Enable at least two audit devices in production.

## Namespaces (Enterprise / HCP)

| Command                                       | Purpose                                         |
| :-------------------------------------------- | ----------------------------------------------- |
| `vault namespace list`                        | List the child namespaces                       |
| `vault namespace create {NAMESPACE}`          | Create a namespace                              |
| `vault namespace lookup {NAMESPACE}`          | Information of a namespace                      |
| `vault namespace delete {NAMESPACE}`          | Delete a namespace and everything inside it     |
| `vault {COMMAND} -namespace={NAMESPACE} ...`  | Run any command inside a namespace              |

## Plugins

| Command                                                                          | Purpose                                         |
| :------------------------------------------------------------------------------- | ----------------------------------------------- |
| `vault plugin list`                                                              | List the available plugins (built-in and external) |
| `vault plugin list secret`                                                       | List only the secrets engine plugins            |
| `vault plugin info {TYPE} {NAME}`                                                | Information of a plugin                         |
| `vault plugin register -sha256={SHA} -command={BINARY} {TYPE} {NAME}`            | Register an external plugin in the catalog      |
| `vault plugin reload -plugin={NAME}`                                             | Reload a plugin (e.g. after an upgrade)         |
| `vault plugin deregister {TYPE} {NAME}`                                          | Remove a plugin from the catalog                |

## Monitoring and troubleshooting

| Command                                                     | Purpose                                                                  |
| :---------------------------------------------------------- | ------------------------------------------------------------------------ |
| `vault monitor -log-level=debug`                            | Stream the server logs in real time                                      |
| `vault debug -duration=5m -output={FILE}.tar.gz`            | Collect metrics, config, host info and pprof data for troubleshooting    |
| `vault read -format=json sys/metrics`                       | Get the telemetry metrics                                                |
| `vault operator usage`                                      | Client count report (entities and non-entity tokens)                     |
| `vault read sys/internal/counters/activity`                 | Client activity counters                                                 |
| `vault read sys/license/status`                             | License status (Enterprise)                                              |
| `vault read sys/replication/status`                         | Replication status (Enterprise)                                          |
| `vault write sys/loggers level=debug`                       | Change the log level at runtime without restarting                       |
| `vault read sys/mounts`                                     | Raw list of every mount (secrets engines) with their configuration       |
| `vault read sys/auth`                                       | Raw list of every auth method with their configuration                   |
