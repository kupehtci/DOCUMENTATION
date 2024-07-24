#TERRAFORM 

### Variables

We can define a set of hard-coded values as values and allows to write a configuration more flexible and adapted to easy changes. 

We can create a separated file with `.tf` extension in order to declare there the variables. Terraform will load all the `.tf` files in the current directory so this configuration files

You need to declare the variable following this format: 

```json
variable "instance_name" {
  description = "Value of the Name tag for the EC2 instance"
  type        = string 
  default     = "ExampleAppServerInstance"
  validation{
	  condition = <condition>
	  error_message = "Error message"
  }
  sensitive = true | false
  nullable = true | false 
}
```

The properties of a variable are: 

* `description`: input variable documentation 
* `type`: define the values that are acceptable for this variable
* `default`: a default value for the variable
* `validation`: define validation rules and type constrains for the variable's value
* `sensitive`: Limit the variable to be exposed in terraform UI
* `nullable`: specify if the variable can be null or not

And then the variable can be accessed as `var.instance_name` , this is an example of how to use it: 

```json
resource "aws_instance" "app_server" {
   ami           = "ami-08d70e59c07c61a3a"
   instance_type = "t2.micro"

   tags = {
     Name = "ExampleAppServerInstance"
     Name = var.instance_name
   }
 }
```

There are some different ways to modify or set the value of the variable: 

### CLI

This variable value can also be overwritten on terraform apply in the CLI: 

```bash
terraform apply -var "instance_name=YetAnotherName"
```

Take into account that changing this variables value over apply command will not change its value in the configuration file. 

This is the last variable values replacement that terraform apply does, so if the value is overwritten in different ways, this will be the last one applied and the persistent one.
### tfvars

The variables can be set without a default value and then be declared in a `terraform.tfvars` in a list format and used in the same way: `var.<variable_name>`. 

Example of the variables.tf: 

```
variable "dns_zone_hostname" {
  type = string
}
variable "tags" {
  description = "Tags that are going to be common between all resources"
  type        = map(string)
}
```

Example of the terraform.tfvars: 

```
dns_zone_hostname    = "dns.foo.com"
tags                 = { "environment" = "arch", "department" = "architecture", "source" = "terraform" }
```

Terraform will automatically load some `.tfvars` files if: 
* its named `terraform.tfvars` or `terraform.tfvars.json`
* any file that ends in `.auto.tfvars` or `.auto.tfvars.json`

### Variable types

By defining the `type` argument of the variable, its restricted to belong to a type of value. 

Type constrain is optional but is recommended to be used always. 

A variable can be a keyword or a type constructor: 

* string
* number
* bool
* list()
* set()
* map() 
* tuple()

Or in case of not restricting to a certain type, you can define it as `any` 