#VAULT 

# Hashicorp's Vault

Vault is an application created by Hashicorp as a centralized secrets manager tool. (Similar to Azure Key Vault).

It solves the problem of securely store secrets that an application uses for integrations, logins, API and others like TLS certificates, encryption keys or Username & password credentials. 

It offers an authentication and policies feature to control access to the secrets and other resources using users, tokens or other authentication methods and checking authorization though a policy / permissions system. 

With hashicorp's vault you have: 

* Secrets stored in a **secure and encrypted format**.
	* Encryption at rest (Data is encrypted when stored).
	* Encryption at transit (Data is encrypted when being transmitted over the network (Using HTTPs))
* **Secrets centrally stored** in a homogeneous solution for all the applications and authentication methods. 
* **Fine-grained access control**, as admins can define who can access, which secrets can access and under that conditions. 

### How it works

Vault is an API driven system that allow that all communication between the clients and the vault are done through Vault API. 


### Secrets Engines

Secrets Engines 


## Authentication method

An authentication method defines how can user, application or service can prove who they are to Vault. 
It provides some logins credentials and determine the authentication flow. 


## Entity

A logical entity in vault that represents a human or a service. 


### Entity alias

An entity alias is a mapping between a login form an auth method and an entity. 

