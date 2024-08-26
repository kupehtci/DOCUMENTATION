#TERRAFORM  

### Terraform Show

In case that you want to know all the resources that are managed by the current Terraform project, you can "list" all the resources and their properties by doing a Terraform show command. 

This command will list all the resources declared in the files: 

```bash
terraform show
```

In some cases the terraform output will exceed the current console lines limit to show, so its recomendable to write this output into a txt file or similar: 

```bash
terraform show > example.txt
```

