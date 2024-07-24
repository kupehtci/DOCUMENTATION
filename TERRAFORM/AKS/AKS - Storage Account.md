#TERRAFORM #AZURE #AKS 

We must use the storage account in order to store the <span style="color:MediumSlateBlue;">tfstate</span> 


It can be accessed like an endpoint: 

```
https://*mystorageaccount*.blob.core.windows.net/*mycontainer*/*myblob*
```
#### Storage account name

The storage account name has some limitations. 

- Storage account names must be between 3 and 24 characters in length and may contain numbers and lowercase letters only.
- Your storage account name must be unique within Azure. No two storage accounts can have the same name. This is like this because must be accesible from the internet like an endpoint \[https:\/\/\<storage-account\>.web.core.windows.net\]. 

So its common use to apply the name as a local variable[^2]


[^2]: Terraform local variables [[TERRAFORM - Locals]]
[^3]: Replace function in terraform configuration language [[TERRAFORM - replace function]]
[^4]: Lower function in terraform configuration language [[TERRAFORM - lower function]]