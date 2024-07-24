### ARNs or Amazon Resource Names 

Amazon resource names are <span style="color:orange;">unique</span> identifiers assigned to individual AWS resources. 
It can be EC2 instances, load balancers, VPCs, route tables, etc. 

It has the following look: 

```txt
arn:aws:ec2:us-east-1:4575734578134:instance/i-054dsfg34gdsfg38
```

They are used to grant granular access to IAM policies. 

It has the following format: 

```
arn:aws:service:region:account-id:resource-id 
arn:aws:service:region:account-id:resource-type/resource-id arn:aws:service:region:account-id:resource-type:resource-id
```

