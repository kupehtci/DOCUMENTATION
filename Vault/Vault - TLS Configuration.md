#VAULT 

# Vault - TLS Configuration

[[Hashicorp Vault]] exposes all its functionality through an HTTP API, so every client (CLI, UI, applications, other Vault nodes) talks to it over the network. **TLS** encrypts that traffic (encryption in transit) and lets clients verify they are talking to the real Vault server.

TLS is configured in the `listener` block of the Vault configuration file (see [[Vault - Configuration]]). In production TLS should **always** be enabled: `tls_disable = true` is only acceptable for local development.

## Ports and traffic types

Vault uses two different ports, and each one is protected in a different way:

|Port|Config parameter|Traffic|TLS managed by|
|---|---|---|---|
|`8200`|`address` / `api_addr`|API traffic: clients, UI, CLI, `retry_join` requests|**You** (certificates defined in the `listener` block)|
|`8201`|`cluster_address` / `cluster_addr`|Server-to-server traffic: request forwarding to the leader and Raft replication|**Vault itself** (automatic internal mTLS)|

> The important idea: the certificates you configure in the listener protect the **API port (8200)**. The **cluster port (8201)** is always protected with mutual TLS using certificates that Vault generates and rotates automatically. You do not configure certificates for port 8201.

## Certificate requirements

Before configuring Vault, you need:

* **CA certificate** (`ca.crt`): the certificate of the Certificate Authority that signed the server certificate. Clients use it to trust Vault.
* **Server certificate** (`vault.crt`): the certificate presented by Vault. If it was signed by an intermediate CA, the file must contain the **full chain**: server certificate first, followed by the intermediate certificates.
* **Private key** (`vault.key`): the private key of the server certificate. It must **not** be password protected, as Vault cannot prompt for a passphrase.

The **Subject Alternative Names (SAN)** of the server certificate must include every name or IP used to reach Vault, for example:

* The hostname / FQDN of each node (`vault-0.example.com`).
* The IP of each node, if clients or other nodes connect using IPs.
* The load balancer DNS name (`vault.example.com`).
* `localhost` and `127.0.0.1`, so the CLI can be used locally on each node.

> If the name used in `VAULT_ADDR`, `api_addr` or `leader_api_addr` is not present in the SANs, the connection fails with `x509: certificate is valid for X, not Y`.

### Generate certificates with OpenSSL (lab / internal CA)

For testing or an internal PKI, a private CA can be created with OpenSSL. In production, use the corporate PKI or a public CA.

```bash
# 1. Create the CA
openssl genrsa -out ca.key 4096
openssl req -x509 -new -nodes -key ca.key -sha256 -days 3650 \
  -subj "/CN=Vault Internal CA" -out ca.crt

# 2. Create the server key and the CSR
openssl genrsa -out vault.key 2048
openssl req -new -key vault.key -subj "/CN=vault.example.com" -out vault.csr

# 3. Define the SANs
cat > vault-san.ext <<EXT
basicConstraints=CA:FALSE
keyUsage=digitalSignature,keyEncipherment
extendedKeyUsage=serverAuth,clientAuth
subjectAltName=@alt_names

[alt_names]
DNS.1 = vault.example.com
DNS.2 = vault-0.example.com
DNS.3 = vault-1.example.com
DNS.4 = vault-2.example.com
DNS.5 = localhost
IP.1  = 127.0.0.1
IP.2  = 10.0.0.10
IP.3  = 10.0.0.11
IP.4  = 10.0.0.12
EXT

# 4. Sign the server certificate with the CA
openssl x509 -req -in vault.csr -CA ca.crt -CAkey ca.key -CAcreateserial \
  -out vault.crt -days 365 -sha256 -extfile vault-san.ext

# 5. Check the SANs
openssl x509 -in vault.crt -noout -text | grep -A1 "Subject Alternative Name"
```

> `clientAuth` in `extendedKeyUsage` is only needed if the same certificate is also going to be used as a **client** certificate (for example in `leader_client_cert_file` when the cluster requires mTLS on the API).

### File location and permissions

Copy the files to a directory readable by the `vault` user (the service user created during [[Vault - Installation]]):

```bash
sudo mkdir -p /opt/vault/tls
sudo cp ca.crt vault.crt vault.key /opt/vault/tls/
sudo chown -R vault:vault /opt/vault/tls
sudo chmod 0644 /opt/vault/tls/ca.crt /opt/vault/tls/vault.crt
sudo chmod 0600 /opt/vault/tls/vault.key
```

The CA certificate should also be added to the operating system trust store of the clients, so tools like `curl` trust Vault without extra flags:

```bash
# RHEL / CentOS / Rocky
sudo cp ca.crt /etc/pki/ca-trust/source/anchors/vault-ca.crt
sudo update-ca-trust

# Debian / Ubuntu
sudo cp ca.crt /usr/local/share/ca-certificates/vault-ca.crt
sudo update-ca-certificates
```

## Listener TLS configuration

Minimal configuration for a single node with TLS enabled:

```hcl
listener "tcp" {
  address       = "0.0.0.0:8200"
  tls_disable   = false
  tls_cert_file = "/opt/vault/tls/vault.crt"
  tls_key_file  = "/opt/vault/tls/vault.key"
}

api_addr = "https://vault.example.com:8200"
```

> When TLS is enabled, `api_addr` and `cluster_addr` must use `https://`.

### TLS parameters of the listener

|Parameter|Default|Description|
|---|---|---|
|`tls_disable`|`false`|Disables TLS. Only for development.|
|`tls_cert_file`|-|Path to the server certificate (PEM). Can include the intermediate chain.|
|`tls_key_file`|-|Path to the private key (PEM).|
|`tls_min_version`|`tls12`|Minimum TLS version accepted (`tls12`, `tls13`).|
|`tls_max_version`|`tls13`|Maximum TLS version accepted.|
|`tls_cipher_suites`|Go defaults|Comma-separated list of allowed cipher suites. Only applies to TLS 1.2 (TLS 1.3 suites are not configurable).|
|`tls_client_ca_file`|-|CA used to validate **client certificates** (mTLS).|
|`tls_require_and_verify_client_cert`|`false`|Rejects any client that does not present a valid certificate signed by `tls_client_ca_file`.|
|`tls_disable_client_certs`|`false`|Vault will not request client certificates at all. Incompatible with the TLS certificates auth method on this listener.|

### Hardened example

```hcl
listener "tcp" {
  address         = "0.0.0.0:8200"
  cluster_address = "0.0.0.0:8201"

  tls_disable     = false
  tls_cert_file   = "/opt/vault/tls/vault.crt"
  tls_key_file    = "/opt/vault/tls/vault.key"
  tls_min_version = "tls12"

  tls_cipher_suites = "TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384,TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384,TLS_ECDHE_ECDSA_WITH_CHACHA20_POLY1305,TLS_ECDHE_RSA_WITH_CHACHA20_POLY1305"
}
```

### Mutual TLS (mTLS) for clients

With mTLS, Vault also verifies the identity of the client through a certificate. This is useful when only known machines or applications should be able to reach the API:

```hcl
listener "tcp" {
  address                            = "0.0.0.0:8200"
  tls_cert_file                      = "/opt/vault/tls/vault.crt"
  tls_key_file                       = "/opt/vault/tls/vault.key"
  tls_client_ca_file                 = "/opt/vault/tls/clients-ca.crt"
  tls_require_and_verify_client_cert = true
}
```

> If `tls_require_and_verify_client_cert = true`, **everything** connecting to port 8200 needs a client certificate: CLI, UI (the browser must have the certificate installed), health checks of the load balancer and the other Raft nodes when they join the cluster (see `leader_client_cert_file` below).

> Do not confuse this with the **TLS Certificates auth method** (`vault auth enable cert`). mTLS at the listener only protects the connection; the cert auth method uses the client certificate to **log in** and obtain a token (see [[Vault - Authentication and Authorization]]).

## Client configuration (CLI)

The Vault CLI reads the TLS configuration from environment variables:

|Variable|Description|
|---|---|
|`VAULT_ADDR`|Vault address. Must start with `https://`.|
|`VAULT_CACERT`|Path to the CA certificate used to verify the server.|
|`VAULT_CAPATH`|Directory with CA certificates (alternative to `VAULT_CACERT`).|
|`VAULT_CLIENT_CERT`|Client certificate (only if mTLS is enabled).|
|`VAULT_CLIENT_KEY`|Client private key (only if mTLS is enabled).|
|`VAULT_TLS_SERVER_NAME`|Name used for SNI and certificate validation, when it differs from the host in `VAULT_ADDR`.|
|`VAULT_SKIP_VERIFY`|Disables certificate verification. **Never in production**, only for quick troubleshooting.|

```bash
export VAULT_ADDR="https://vault.example.com:8200"
export VAULT_CACERT="/opt/vault/tls/ca.crt"
vault status
```

The same with `curl`:

```bash
curl --cacert /opt/vault/tls/ca.crt https://vault.example.com:8200/v1/sys/health
```

## TLS in a Raft cluster

When Vault uses Integrated Storage (see [[Vault - Raft Storage]]), several Vault nodes form a cluster. TLS is involved in three different moments:

1. **Clients → any node** (port 8200): protected by the listener certificate, as described above.
2. **Node joining the cluster → leader** (port 8200): the new node calls the API of the leader to request joining. This is a normal HTTPS request, so the joining node must **trust the leader certificate**.
3. **Node ↔ node** (port 8201): Raft replication and request forwarding. Protected by the **internal mTLS** that Vault manages automatically. Once a node has joined, it receives the cluster certificates from the leader.

```
            HTTPS (8200)                    HTTPS (8200)
  Client ─────────────────► vault-1   vault-2 ─────────────► vault-1 (leader)
                                       (join request, verified with leader_ca_cert_file)

                   mTLS internal (8201) - automatic
         vault-1 ◄──────────────────────────────────► vault-2 / vault-3
                  (Raft replication + request forwarding)
```

### Addresses of each node

Every node must announce its own addresses using `https`:

```hcl
api_addr     = "https://vault-0.example.com:8200"
cluster_addr = "https://vault-0.example.com:8201"
```

* `api_addr`: address the other nodes and the clients use to reach **this node's API**. Must be in the SANs of the node certificate.
* `cluster_addr`: address used for node-to-node traffic. Always `https`, even though you do not provide certificates for it.

### Certificates per node

There are two common approaches:

* **One certificate shared by all nodes**, with the SANs of every node plus the load balancer. Simple, but every node can impersonate the others and any change requires reissuing the certificate for all of them.
* **One certificate per node** (recommended), signed by the same CA. Each certificate contains the SANs of that node, the load balancer name, `localhost` and `127.0.0.1`. Since all of them are signed by the same CA, a single `ca.crt` is enough to trust all the nodes.

### `retry_join` with TLS

`retry_join` in the `storage "raft"` block lets the nodes join the cluster automatically on start. When the API uses TLS, each `retry_join` block must tell the node how to verify the leader:

```hcl
storage "raft" {
  path    = "/opt/vault/data"
  node_id = "vault-0"

  retry_join {
    leader_api_addr         = "https://vault-0.example.com:8200"
    leader_ca_cert_file     = "/opt/vault/tls/ca.crt"
    leader_client_cert_file = "/opt/vault/tls/vault.crt"
    leader_client_key_file  = "/opt/vault/tls/vault.key"
  }

  retry_join {
    leader_api_addr         = "https://vault-1.example.com:8200"
    leader_ca_cert_file     = "/opt/vault/tls/ca.crt"
    leader_client_cert_file = "/opt/vault/tls/vault.crt"
    leader_client_key_file  = "/opt/vault/tls/vault.key"
  }

  retry_join {
    leader_api_addr         = "https://vault-2.example.com:8200"
    leader_ca_cert_file     = "/opt/vault/tls/ca.crt"
    leader_client_cert_file = "/opt/vault/tls/vault.crt"
    leader_client_key_file  = "/opt/vault/tls/vault.key"
  }
}
```

|Parameter|Description|
|---|---|
|`leader_api_addr`|API address of a possible leader. Must use `https` and a name present in its certificate.|
|`leader_ca_cert_file`|CA used to verify the certificate of the leader. **Required** when the leader certificate is not signed by a CA trusted by the OS.|
|`leader_client_cert_file`|Client certificate the node presents to the leader. Only needed if the leader listener requires client certificates (`tls_require_and_verify_client_cert = true`).|
|`leader_client_key_file`|Private key of the client certificate.|
|`leader_tls_servername`|Name used to verify the leader certificate (SNI) when `leader_api_addr` uses a name or IP that is not in the SANs.|
|`leader_ca_cert`, `leader_client_cert`, `leader_client_key`|Same as the `*_file` variants, but with the PEM content inline instead of a path.|
|`auto_join` / `auto_join_scheme`|Cloud auto-discovery of nodes (by tags). `auto_join_scheme` must be `https` when TLS is enabled (default).|

> A node can include a `retry_join` block pointing to itself. Vault ignores it, so the same configuration can be used on every node, changing only `node_id`, `api_addr`, `cluster_addr` and the certificate paths.

### Manual join

Instead of `retry_join`, a node can be joined manually with the CLI. The same TLS options are passed as flags:

```bash
vault operator raft join \
  -leader-ca-cert=@/opt/vault/tls/ca.crt \
  -leader-client-cert=@/opt/vault/tls/vault.crt \
  -leader-client-key=@/opt/vault/tls/vault.key \
  https://vault-0.example.com:8200
```

Check the cluster members:

```bash
vault operator raft list-peers
```

### Full example of a Raft node configuration

`/etc/vault.d/vault.hcl` on `vault-1`:

```hcl
ui            = true
disable_mlock = true

api_addr     = "https://vault-1.example.com:8200"
cluster_addr = "https://vault-1.example.com:8201"

listener "tcp" {
  address         = "0.0.0.0:8200"
  cluster_address = "0.0.0.0:8201"
  tls_cert_file   = "/opt/vault/tls/vault-1.crt"
  tls_key_file    = "/opt/vault/tls/vault-1.key"
  tls_min_version = "tls12"
}

storage "raft" {
  path    = "/opt/vault/data"
  node_id = "vault-1"

  retry_join {
    leader_api_addr     = "https://vault-0.example.com:8200"
    leader_ca_cert_file = "/opt/vault/tls/ca.crt"
  }
  retry_join {
    leader_api_addr     = "https://vault-1.example.com:8200"
    leader_ca_cert_file = "/opt/vault/tls/ca.crt"
  }
  retry_join {
    leader_api_addr     = "https://vault-2.example.com:8200"
    leader_ca_cert_file = "/opt/vault/tls/ca.crt"
  }
}
```

> Remember that after joining, each new node must be **unsealed** (see [[Vault - Unseal]]) unless auto-unseal is configured.

### Load balancer in front of the cluster

* The load balancer usually points to port **8200** of all nodes, using the health endpoint `/v1/sys/health` to send traffic to the active node.
* **TLS passthrough** (the LB does not decrypt traffic) is the simplest option: the client validates directly the node certificate, so the LB name must be in the SANs of every node certificate.
* **TLS termination** at the LB is possible, but then the LB must re-encrypt the traffic towards Vault and, to keep the real client IP, `x_forwarded_for_authorized_addrs` must be configured in the listener.
* **Never put port 8201 behind a load balancer or a TLS-terminating proxy.** The cluster traffic uses Vault's own mTLS and must go directly from node to node.

### Vault on Kubernetes (Helm chart)

With the official Helm chart, TLS is usually provided through a Kubernetes secret mounted in the pods:

```bash
kubectl create secret generic vault-tls -n vault \
  --from-file=vault.crt=vault.crt \
  --from-file=vault.key=vault.key \
  --from-file=vault.ca=ca.crt
```

```yaml
global:
  tlsDisable: false

server:
  extraEnvironmentVars:
    VAULT_CACERT: /vault/userconfig/vault-tls/vault.ca
  volumes:
    - name: vault-tls
      secret:
        secretName: vault-tls
  volumeMounts:
    - name: vault-tls
      mountPath: /vault/userconfig/vault-tls
      readOnly: true
  ha:
    enabled: true
    raft:
      enabled: true
      config: |
        ui = true
        listener "tcp" {
          address         = "[::]:8200"
          cluster_address = "[::]:8201"
          tls_cert_file   = "/vault/userconfig/vault-tls/vault.crt"
          tls_key_file    = "/vault/userconfig/vault-tls/vault.key"
        }
        storage "raft" {
          path = "/vault/data"
          retry_join {
            leader_api_addr     = "https://vault-0.vault-internal:8200"
            leader_ca_cert_file = "/vault/userconfig/vault-tls/vault.ca"
          }
          retry_join {
            leader_api_addr     = "https://vault-1.vault-internal:8200"
            leader_ca_cert_file = "/vault/userconfig/vault-tls/vault.ca"
          }
          retry_join {
            leader_api_addr     = "https://vault-2.vault-internal:8200"
            leader_ca_cert_file = "/vault/userconfig/vault-tls/vault.ca"
          }
        }
        service_registration "kubernetes" {}
```

The certificate SANs must include the Kubernetes service names: `vault`, `vault.vault.svc`, `vault.vault.svc.cluster.local`, `*.vault-internal`, `*.vault-internal.vault.svc.cluster.local`, `127.0.0.1`.

## Certificate rotation

Vault reloads the listener certificate and key **without restarting** when it receives a `SIGHUP` signal. This avoids sealing the node (a restart would seal it again).

```bash
# Replace the files and then:
sudo systemctl reload vault
# or
sudo kill -HUP $(pidof vault)
```

In a Raft cluster, rotate **one node at a time** and check that the cluster stays healthy (`vault operator raft list-peers`) before moving to the next one. If the CA changes, distribute the new `ca.crt` to all the nodes (`leader_ca_cert_file`) and clients **before** replacing the server certificates.

> The internal cluster certificates (port 8201) are rotated automatically by Vault; no action is required.

## Verification and troubleshooting

```bash
# Check the certificate presented by Vault, its chain and SANs
openssl s_client -connect vault.example.com:8200 -servername vault.example.com -showcerts </dev/null

# Check expiration date of a certificate
openssl x509 -in /opt/vault/tls/vault.crt -noout -enddate

# Check that the key matches the certificate (both hashes must be equal)
openssl x509 -noout -modulus -in vault.crt | openssl md5
openssl rsa  -noout -modulus -in vault.key | openssl md5

# Health of the node
curl --cacert /opt/vault/tls/ca.crt https://vault.example.com:8200/v1/sys/health
```

Common errors (see also [[Vault - Logs]]):

|Error|Cause|Solution|
|---|---|---|
|`x509: certificate signed by unknown authority`|The client does not trust the CA.|Set `VAULT_CACERT`, add the CA to the OS trust store or set `leader_ca_cert_file` in `retry_join`.|
|`x509: certificate is valid for X, not Y`|The hostname/IP used is not in the SANs.|Reissue the certificate with the missing SAN, or use `leader_tls_servername` / `VAULT_TLS_SERVER_NAME`.|
|`http: server gave HTTP response to HTTPS client`|Vault listener has TLS disabled but the client uses `https`.|Set `tls_disable = false` and the certificate paths.|
|`client sent an HTTP request to an HTTPS server`|Client uses `http://` against a TLS listener.|Use `https://` in `VAULT_ADDR`, `api_addr` and `leader_api_addr`.|
|`tls: bad certificate` / `certificate required`|The listener requires client certificates (mTLS) and none was sent.|Configure `VAULT_CLIENT_CERT`/`VAULT_CLIENT_KEY` or `leader_client_cert_file`/`leader_client_key_file`.|
|`failed to join raft cluster` with TLS errors|The joining node cannot validate the leader.|Check `leader_ca_cert_file`, SANs of the leader certificate and that `leader_api_addr` uses `https`.|
|`permission denied` reading key at startup|The `vault` user cannot read the files.|Fix ownership and permissions of `/opt/vault/tls`.|

## References

* Vault TCP listener configuration: https://developer.hashicorp.com/vault/docs/configuration/listener/tcp
* Integrated Storage (Raft) configuration: https://developer.hashicorp.com/vault/docs/configuration/storage/raft
* Vault environment variables: https://developer.hashicorp.com/vault/docs/commands#environment-variables
