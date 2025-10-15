#AWS 

# AWS - Elastic Network Interfaces

An <span style="color:DodgerBlue;">Elastic Network Interface</span> or ENI is a virtual network interface that you can attach to an Amazon EC2 instance or other AWS services within a Virtual Private Cloud (VPC). 

ENIs represent a logical networking component in your VPC, enabling instances to communicate with each other, the internet, and other AWS services.

An ENI consists in a primary private IPv4 address, one or more secondary IPv4 addresses, an Elastic IP (if associated), a MAC address, and one or more security groups. 

ENIs are fundamental building blocks in AWS networking and provide flexibility for managing and configuring network access and communication.

> NOTE: Primary ENIs of an EC2 instance cannot be moved between resources. In case of needing a dynamic ENI, attach and use a secondary onez.  
### Components of an ENI

An ENI typically includes the following components:

- **Primary Private IPv4 Address:** The main IP address assigned to the ENI within the VPC.
- **Secondary IPv4 Addresses (Optional):** Additional IP addresses assigned to the ENI.
- **Elastic IP Address (Optional):** A static, public IPv4 address associated with the ENI.
- **MAC Address:** A unique identifier for the ENI.
- **Security Groups:** Network security rules applied to the ENI to control inbound and outbound traffic.
- **IPv6 Address (Optional):** An IPv6 address associated with the ENI.
- **Description:** A user-defined text description for the ENI.

### EMIs in terraform 

EMIs can be defined in terraform using the `aws_network_interface` resource: 

```hcl
resource "aws_network_interface" "example" {
  subnet_id       = aws_subnet.main.id
  private_ips     = ["10.0.1.100"]
  security_groups = [aws_security_group.sg.id]

  tags = {
    Name = "example-eni"
  }
}
```

And for assign them into another resource: 

```hcl
resource "aws_instance" "example" {
  ami           = "ami-0c55b159cbfafe1f0"
  instance_type = "t2.micro"

  network_interface {
    network_interface_id = aws_network_interface.example.id
    device_index         = 1
  }
}
```
