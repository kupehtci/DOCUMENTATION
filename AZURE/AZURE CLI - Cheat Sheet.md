#AZURE 

### AZURE CLI Cheat Sheet

This is a cheat sheet of commands for azure cli

## Azure login

To login to the [Azure Portal](portal.azure.com) account you can login via: 

```bash
az login
```

This will open a web browser tab in order to login there. 
Once you login in the web, you can select the subscription that want to use this time


### Azure get tenant id and subscription

Once you have login, you can retrieve the tenant id and subscription id: 

```
az account show
```

This will print a json format information about the current account selected subscription: 

```json
{
  "environmentName": "AzureCloud",
  "homeTenantId": "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
  "id": "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
  "isDefault": true,
  "managedByTenants": [],
  "name": "Subscription whatever",
  "state": "Enabled",
  "tenantDefaultDomain": "companyexample.com",
  "tenantDisplayName": "My Company SL",
  "tenantId": "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
  "user": {
    "name": "myuser@company.com",
    "type": "user"
  }
}
```

Or you can even `grep` the content by: 

```bash
az account show --query "{subscriptionId:id, tenantId:tenantId}" --output tsv
```


### Check if a group exist

You can check if a certain group or other resources exist by using `az <resource> exist --property`

```bash
az group exist --name=<name_group_to_search>
```

