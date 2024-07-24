#TERRAFORM 

### Terraform locals

A local value in terraform is a name assigned to an expression that can be reused multiple times within the same document. 

Its used to avoid redundancy in names within the same file. Also eases the flexibility of changes in the document. 

This is how to use local variables: 

```hcl
locals{
	service_name = "dns"
	owner = "me"
}

resource "aws_instance" "example_aws_instance"{
	tags = local.service_name
}
```