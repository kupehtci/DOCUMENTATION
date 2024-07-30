#TERRAFORM 

If configuration is changed, the build is updated with the execution plan, only holding the changes that are going to be made in order to reach the desired state. 

Once the changes are made into configuration we can apply those changes by input: 

```bash
terraform init      #init the configuration
terraform apply     #Apply the new configuration and respond to the confirmation
```


The infrastructure can also be changed by modifying an existing configured variable [^1]



[^1]: Terraform variables : [[TERRAFORM - Variables]]. 
