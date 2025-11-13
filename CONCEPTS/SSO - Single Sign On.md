#CONCEPTS 

# SSO Single Sign On

**Single Sign On** or **SSO** its an authentication scheme that lets users to log into multiple independent applications, systems or services using a single set of credentials.

# How it works? 

It relies in a centralized IDP or Identity Provider that verifies the user credentials. After sucesfully login into the IDP, it issues an authentication token which is shared with the different applications, granting access to them without additional logins. 

## Secure exchange of data

An application trusts an SSO provider by establishing a cryptographic trust relationship where public key its shared with the Application and each request the SSO Provider send its cypher with its private key. 

When the login is successful, the SSO issues a SAML[^2] assertion or an OIDC ID token that identifies claims like subject, email, groups, issuer and timestamps.
OSA
# Relationship with OpenID Connector (OIDC)

Enterprise SSO solutions supports multiple protocols, normally using **OpenID Connectors (OIDC)** with modern Mobile / Web Applications and SAML for legacy browser apps.

SSO its the pattern and OpenID the protocol that enables SSO communication with the applications.


[^1]: OpenID [[OpenID]]
[^2]: SAML or Security Assertion Markup Language its an XML-based language to claim the identity exchange between two parties [[SAML - Security Assertion Markup Language]]