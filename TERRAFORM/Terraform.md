#TERRAFORM

The `terraform{}` block contains Terraform settings including requires providers to provision the infraestructure. 

For each <span style="color:MediumSlateBlue;">provider</span>, source attribute defines the namespace/provider type. 
This type needs to be registered within Terraform Registry: 

```
terraform {
  required_providers {
    provider = {
      source  = "source/defined_source"
      version = "~> X.XX"
    }
}
```

The documentation for each provider can be found in: [Browse Providers | Terraform Registry](https://registry.terraform.io/browse/providers). 
 
This is an AWS example: 

```json
terraform {
  required_providers {
    aws = {
      source  = "hashicorp/aws"
      version = "~> 4.16"
    }
}

  required_version = ">= 1.2.0"
}

provider "aws" {
  region  = "us-west-2"
}

resource "aws_instance" "app_server" {
  ami           = "ami-830c94e3"
  instance_type = "t2.micro"

  tags = {
    Name = "ExampleAppServerInstance"
  }
}
```

A <span style="color:MediumSlateBlue;">resource block</span> is used to define components of an infrastructure. 
This resource must be a physical or virtual component such as an EC2 instance. 

It needs to specify a: 
* resource type: the prefix indicates the type of provider and specifies the type of resource. 
* resource name: name of the resource. Its joined to the type in order to give an unique ID to each resource. 

This unique ID will be form as `resource_type.resource_name`. 

Resource blocks contains arguments used to configure the resource, like machine size, disk image names or VPC IDs. To check the different providers required and optional arguments check on [Terraform providers documentation]](https://registry.terraform.io/browse/providers?product_intent=terraform). 

The syntax is as follows: 

```json
resource <resource_type> <resource_name>{

}
```


### Initialize directory

When creating a new configuration or check out an existing configuration from version control, we need to initialize the directory with: `terraforn init`. 

This will download the specified providers dependencies and store in a hidden subdirectory named <span style="color:orange;">.terraform</span>. 
Also creates a lock file <span style="color:orange;">.terraform.lock.hcl</span> that specifies the providers version installed.

### Format and validate

By using `terraform fmt` command automatically updates configuration in the current directory for readability and consistency. 

You can also validate that the configuration is syntactically correctly and consistent by doing: 

```bash
$ terraform validate
Success! The configuration is valid.
```

### Create the infrastructure

Apply the configuration now with the terraform apply command.
This will show an execution plan that is going to be applied by the terraform new configuration in a similar way as the diff format of Git. 

### Inspect the state

When the configuration is applied, this current state of the configuration is stored in a config file called `terraforn.tfstate`. 

It stores the IDs and properties of the resources it manages in this files. 

Also, you can inspect the current state by using `terraform show` without needing to read the file. 





