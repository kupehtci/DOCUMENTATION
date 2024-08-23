#AZURE 



### How to list roles

In order to debug and verify the roles that are assigned to an user or service principal[^sp], you can use the Azure CLI to list check the roles. 

```bash
az role assignment list --assignee {assignee}
#Example
az role assignment list --all --assignee me@contoso.com
```

You can also list all the role assignments that have a resource group as scope: 

```bash
az role assignment list --resource-group {resourceGroup}
```

For a subscription scope:

```bash
az role assignment list --scope "/subscriptions/{subscriptionId}"
```

[^sp]: Service Principal RBAC resource [[AZURE - Service Principal]]