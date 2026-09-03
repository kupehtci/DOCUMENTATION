#AZURE #ENTRA_ID

# Azure - Entra ID Users

Microsoft Entra ID allows to create different types of users in your tenant allowing a great flexibility in the organization. 

## Types of users

A microsoft Entra workforce Tenant can have the following user types: 
* **Internal member**: internal organization user. (Full time)
* **Internal guest**: these user has an account in the tenant but have guest-level privileges. 
* **External member**: these users authenticate using an external account (In other tenant) but has member access to these tenant. (See multi-tenant organizations [[Azure - Entra ID Multi-tenant organizations]]). 
* **External guest**: These users authenticate using an external account and has guest-level privileges. 

Differences: 
* Internal member and guest: 
	* Credentials are stored in own tenant (Can reset password)
* External member and guest: 
	* Authenticate in their home Microsoft Entra tenant and the own Microsoft Entra authenticates the user through a federated sing-in
	* Credentials are stored in their home tenant. 


## Users basic fields

The users under creation has the following fields: 
* **User principal name**: Enter a **unique** username and select the domain from the menu. 
* **Mail nick name**: normally same as user principal name
* 
