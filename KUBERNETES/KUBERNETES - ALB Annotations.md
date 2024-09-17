#AWS #KUBERNETES #NETWORKING 

# KUBERNETES ALB annotations

For letting the AWS load balancer helm release to auto discover the ingress[^1] resources and create the appropriate Target group, roules and listener in the AWS Application Load Balancer, some annotations must be set in the Ingress resources. 

The annotations must be in the following format: 


```yaml 
annotations: {
    kubernetes.io/ingress.class: alb,        
    alb.ingress.kubernetes.io/scheme: internet-facing, 
    alb.ingress.kubernetes.io/target-type: ip, 
    alb.ingress.kubernetes.io/healthcheck-protocol: HTTP, 
    alb.ingress.kubernetes.io/healthcheck-interval-seconds: '10', 
    alb.ingress.kubernetes.io/backend-protocol: HTTPS, 
    alb.ingress.kubernetes.io/listen-ports: '[{"HTTP":80}]', 
    alb.ingress.kubernetes.io/group.name: "test-pro-alb-tg-http"
    # alb.ingress.kubernetes.io/ssl-redirect: '443' 
}
```

* `kubernetes.io/ingress.class: alb` specify the type of ingress, in this case Application Load Balancer
* `alb.ingress.kubernetes.io/scheme: internet-facing` scheme indicated whether the Load Balancer will be facing the public internet. If its going to be for internal network only, set this to `internal`
* `alb.ingress.kubernetes.io/inbound-cidrs: 10.0.0.0/24` inbound CIDRs can be set in case that `alb.ingress.kubernetes.io/scheme` is set to internal to restrict the access to the resource to a limited CIDR block

* `alb.ingress.kubernetes.io/healthcheck-interval-seconds: '10'` indicates the interval in seconds between each healthcheck.
* `alb.ingress.kubernetes.io/backend-protocol: HTTPS` specify the protocol used in the traffic routed between the ALB and the pods. 
* `alb.ingress.kubernetes.io/subnets` this need to be set to specify the subnets where the ALB should deploy target groups for this ingress. This is not needed if subnets are available for SUbnet Auto Discovery[^1]
* `alb.ingress.kubernetes.io/certificate-arn: ""` this must be set to a certificate ARN if the listener port is set to 443 for routing HTTPS traffic.
* `alb.ingress.kubernetes.io/listen-ports: '[{"HTTP":80}]'` specify the HTTP or HTTPS or both traffic protocols that will be listening for internet incomming traffic. If both procotol are accepted, this can be set to `'[{"HTTP": 80}, {"HTTPS": 443}, {"HTTP": 8080}, {"HTTPS": 8443}]'`. 
* `alb.ingress.kubernetes.io/target-type: ip` specify how the route to pods is made, by `instance`or by `ip`

[^x]: Subnets must be tagged in AWS with `kubernetes.io/cluster/${cluster-name} = {owned|shared}` and `kubernetes.io/role/internal-elb = 1` or `kubernetes.io/role/elb = 1` for letting the ALB to autodiscover the subnets.


[^1]: Ingress resources [[KUBERNETES - Ingress]]