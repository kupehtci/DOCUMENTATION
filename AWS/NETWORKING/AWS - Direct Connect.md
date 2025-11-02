#AWS 

# AWS - Direct Connect

**AWS Direct Connect** or **DX** is a dedicated, private and high-bandwidth network connection between on-premises data centers and AWS. 

Its key features are: 
* **Avoids internet**: has more predictable latency and security
* **High bandwidth**: supports from 50Mbps up to 100 Gbps. 
* **Large data transfers**: supports up to hundreds of gigabytes per day. 
* **Privates VIFs**: provides this private Virtual Interfaces to connect VPCs or a Transit Gateway. 



AWS Direct Connect is a physical fiber-optic connection from the on-premise data center to an AWS Direct Connect location.

Connection that can be purchased can be 1Gbps, 10 Gbps and 100Gbps in some locations.

### VPC Connection

Once the physical connection is stablished you need to configure the virtual interfaces: 

With a **private VIF** you can connect on-premise resources using a Virtual Prvate Gateway or a Transit Gateway to enable a private communication with the AWS Resources. 

With a **public VIF** you can connect on-premise resources to public AWS Resources like S3 but the traffic will go through AWS Direct Connect. 

You can also connect public endpoint resources like S3 using Interface Endpoints. This resources allow to privately connect to this resources without going through the internet. 