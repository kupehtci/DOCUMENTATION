
### Subnets specified must be in at least two different AZs

Error type like: 

```txt
creating EKS Cluster (pre-eks): operation error EKS: CreateCluster, https response error StatusCode: 400, RequestID: b2930182-13a3-4276-bdca-8fbc987f117f, InvalidParameterException: Subnets specified must be in at least two different AZs
```

This may be derivation from the EKS parameter: 

```
subnets_id = [...]
```



### `aws_lb_target_group_attachment` IP address X is not a valid IPv4 address

This error: 
```txt
│ Error: registering ELBv2 Target Group (arn:aws:elasticloadbalancing:eu-north-1:811561672552:targetgroup/boilerplate-pre-alb/2dc315d7c18bb31b) target: operation error Elastic Load Balancing v2: RegisterTargets, https response error StatusCode: 400, RequestID: 19ce6c09-f727-4824-9bdc-49193c2a4c59, api error ValidationError: The IP address 'arn:aws:elasticloadbalancing:eu-north-1:811561672552:loadbalancer/app/boilerplate-pre-alb/68e77d4a8432884e' is not a valid IPv4 address
│
│   with aws_lb_target_group_attachment.alb_tg,
│   on lb.tf line 102, in resource "aws_lb_target_group_attachment" "alb_tg":
│  102: resource "aws_lb_target_group_attachment" "alb_tg" {
```

Its usually caused when the Target group that you are trying to attach to the load balancer is set to `ip` but 