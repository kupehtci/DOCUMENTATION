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

