#AZURE 

The Azure RBAC or <span style="color:MediumSlateBlue;">Role Based Access Control</span> is an azure methodology to control cloud resources access, based on users, role and scope. 

A <span style="color:orange;">security entity</span> is an object that represents an: 
* user
* group
* Service Principal[^sp] - Service Account[^sa]
* Managed Identity
And roles can be assigned to this security entities.

##### Role

A <span style="color:DodgerBlue;">role</span> is a set of permissions or actions that can be performed in terms of read, write and delete permissions. 

This role can be custom defined or use one of the pre-defined of Azure: 

* `Contributor`: Allows whole access to the resources but cannot grant RBAC roles
* `Owner` Allows whole access to administer all the resources and assign RBAC roles
* `Reader` allows to see all resources but don't make changes
* `RBAC Admin` administers the access via RBAC and with no other access policy like Azure Policy.  
* `User Access Admin` allows to administer the user access to Azure Resources

There are also more roles but this ones are the more generic ones in order to grant basic access to the resources. 

#### Scope

This roles can be granted to all the resources or this set of resources can be limited. The <span style="color:Crimson";>scope</span> sets this resources and lets more limits or allowances to be assigned to a role. 


[^sp]: Service Principal RBAC Azure Resource [[AZURE - Service Principal]]
[^sa]: Service Account RBAC Azure Resource [[AZURE - Service Account]]