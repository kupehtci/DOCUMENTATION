#TERRAFORM 

The Output variables are used in order to be prompted when making the build. 

The different resources variables can be accessed via the Unique Identifier formed by the combination of `resource_type.resource_name`. 

Example: 
	Having  a `resource "aws_instance" "app_server"` can be accessed as `aws_instance.app_server` 

This output variables can be defined in a separated tf file. 

Example: 

```json
output "instance_id" {
  description = "ID of the EC2 instance"
  value       = aws_instance.app_server.id
}

output "instance_public_ip" {
  description = "Public IP address of the EC2 instance"
  value       = aws_instance.app_server.public_ip
}
```


### Sensitive values

When working with values marked as sensitive, in order to be outputted when apply, within the output block. `sensitive = true` needs to be marked. 

This is done to expose the variable but knowing that is a sensible value. 

Once it is outputted is is shown as: 
```
<variable-name> = (sensitive)
```

And in order to retrieve its value, you need to write: 
```bash
terraform output <variable-name>
```

This command will show the output value without the `(sensitive)` tag. 