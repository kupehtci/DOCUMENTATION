#TERRAFORM #AKS #AZURE 

### TERRAFORM - Backend

A <span style="color:orange;">backend</span> defined where Terraform stores its state data files. 

Terraform uses a persistent data to keep track of the managed resources. This data can be stored in HCP Terraform or use a backend remote storage like Azure Storage Account[^1]


#### Take into account

Something to take into account when configuring a backend: 

* backend stores the configuration in two plain text files, that are not updated, so time restricted credentials better be passed as environmental variables. 
* If the configuration contains a `cloud` component, cannot include a `backend` block. 



[^1]: Azure storage account for persistent data [[AKS - Storage Account]]