#AWS #CLOUD 

# AWS - Cognito

**AWS Cognito** is a fully managed identity and access management service for end users. 

Its not related with authorizing identities into AWS Cloud management, its meant for **end users** to authenticate into applications. 

it allows to easily add user sign-up, sign-in, authentication (JWT) and access control to a web or mobile applications without needed to build a custom authentication service. 

Its AWS managed so it can scale up to millions of users and integrates with Amazon API Gateway, AppSync and other AWS Services. 

It has different features: 

## User Pools (Authentication)

A user pool is a user directory that handles: 

* User registration (sign-up)
* User sign-in (with email, username or social logins)
* MFA (multi-factor authentication)
* Password recovery service and account management.

It uses JSON Web Tokens (JWT)[^1] after a successful login that can be used to securely access the backend services. This JWT is then checked by Cognito on each request. 

## Identity Pools

An **Identity Pool** allows to give temporary AWS Credencials to users so they can access AWS Services Directly like S3 or DynamoDB. 

Can federate identities from: 
* Cognito user pools
* Social Identity Providers (Google, Facebook or Apple)
* Enterprise IdPs via SAML
* Guests or unauthenticated users. 

It its a way to give users access to AWS Resources. 

Cognito Identity Pools (Federated identities) are not for authentication, they authorize over an AWS resource after the authentication. 
When a user authenticates (With cognito user pool, social identity provider or with other IDP): 
1. Cognito validates the identity (Authentication)
2. Maps that identity to an IAM Role [^5] (Authorization)
3. Request temporary AWS credentials for the AWS Security Token Service (STS)
4. Returns that credentials to the user for accessing AWS Resources according to the IAM role assigned[^5]. 

In terms of the **IAM Role** you need to define an Authenticated role (Assigned to users with successful login) and an unauthorized role (Assigned t users that hasn't logging (guest users)). 

## Federation using other Identity Providers

Cognito also serves as a federation hub, allowing users to also login with:
* Social Identity Providers (Google, Facebook or Apple)
* SAML 2.0 providers (Okta, Azure AD)
* OpenID Connect Providers

# Other features
## Risk-based adaptive authentication

Cognito Risk-based adaptive authentication is a security feature that automatically detects and respond to potentially risks sign-in attempts. 

Its based in different factors: 
* Device fingerprint
* IP Address
* Sign-in patterns
* Geolocation
* Multiple sign-in attempts

Based on the risk result (low, medium or high) you can configure certain actions like allow, require MFA, block or notify user. 

# Integrations

Its integrates with other services: 

## Cognito + Amazon API Gateway

Cognito User Pool handles the sign-ups and sign-ins and when the user logs in returns a JWT tojen. 

API Gateway uses a **Cognito Authorizer** to validate the token that will re-send the Frontend so if the token is valid it will grant access to the Backend. 

It allows to implement authentication seamesly without implementing a custom one. 

## Cognito + AWS Lambda

Cognito can trigger a Lambda function[^3] on Authentication events like sign-up, post confirmation or token customization. 

It can be used for example to **automatize** a welcome email sending after each user sign-up. 

## Cognito + Amazon S3 / DynamoDB

Together with S3[^4] you can use Cognito Identity Pools to echange a user's identity for temporary AWS Credentials using STS (Security Token Service). 

These credentials can be used to access S3 buckets, DynamoDB tables and other resources based on IAM policies.

An example can be a mobile app that let users to upload their own photos directly to an S3 bucket. 

## Cognito + IAM (security and authorization)

Cognito Identity Pools map the authenticated and unauthenticated users to specific IAM roles that define the AWS resources that they can access. 


[^1]: JWT or JSON Web Tokens [[JWT JSON Web tokens]]
[^2]: Amazon API Gateway [[AWS - Amazon API gateway]]
[^3]: Amazon Lambda [[AWS - Lambda]]
[^4]: Amazon S3 buckets [[AWS - S3]]
[^5]: IAM Identity [[AWS - IAM]]



