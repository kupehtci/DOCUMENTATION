#AZURE 

## Storage share directories

Within an Storage share inside an storage account[^1] you can create directories using Azure CLI with the command: 

```bash
az storage directory create 
--name 
--share-name 
[--account-key]
[--account-name]
[--auth-mode {key, login}]
[--backup-intent]
[--connection-string]
[--disallow-trailing-dot {false, true}]
[--fail-on-exist] 
[--file-endpoint]
[--metadata]
[--sas-token]
[--snapshot]
[--timeout]
```

With: 
* `--name` name of the directory to create (Mandatory)
* `--share-name` name of the storage share to create the directory within (mandatory)
* `--account-name` name of the storage account that holds the storage share (optional)


[^1]: Azure Storage Account [[AKS - Storage Account]]