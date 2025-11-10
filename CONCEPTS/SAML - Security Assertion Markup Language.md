#CONCEPTS 

# SAML - Security Assertion Markup Language

## What is SAML? 

**SAML** (Security Assertion Markup Language) is an standard protocol for exchanging authentication and authorization data between two different parties: 

* An Identity Provider (IdP) idenfies **who** you are (LDAP, Azure AD, Okta)
* A Service Provider (SP) that is **what** you access that requires login (Like AWS).

Its like an standardize language for integrating this two services where the IdP tells the SP "this user has been authenticated correctly and this are their permissions". 


## How it works? 

SAML works as follows: 

1. User tries to access the SP service
2. The SP redirects to the IdP login
3. User logs in with IdP credentials
4. IdP creates a SAML assertion indicating that "User is authenticated".
5. IdP sends the SAML assertion to the SP. 
6. SP trust the assertion and grant the access to the user. 

So in the communication between an SP and an LDAP server for example, a SAML broker is needed to mediate this authentication.

## Format

```xml
<saml:Assertion> 
	<saml:Subject> 
		<saml:NameID>john@company.com</saml:NameID> 
	</saml:Subject> 
	<saml:AttributeStatement> 
		<saml:Attribute Name="Role"> 
			<saml:AttributeValue>Developer</saml:AttributeValue> 
		</saml:Attribute> 
	</saml:AttributeStatement> 
</saml:Assertion>
```

