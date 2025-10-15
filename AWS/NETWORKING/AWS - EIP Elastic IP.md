#AWS 

# AWS Elastic IP

AWS EIP or Elastic IP is an public IPv4 address that can be reachable from the internet. 


When an EC2[^1] is deployed, its granted with an public IPv4 address but if its restarted or re-launched, it receives a new IP address. This difficult to reach this IP from the internet or register it in a DNS. So Elastic IP gives an static IP allocated for an AWS resource.  
Elastic IPs allow AWS to manage its dynamic computing services.

[^1]: EC2 or Elastic Cloud Compute is an AWS resource that offers 