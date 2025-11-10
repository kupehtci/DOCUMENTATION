#AWS 

# AWS Web Application Firewall


AWS WAF is a web application firewall that helps to protect the web application from common web exploits that affect availability, security or consume resources like DDOS attacks. 

WAF can block:
* Botnets
* SQL Injection
* XSS
* Known malicious IPs
* Anonymous proxies
* Requests exceeding rate limits (Rate limiting)

It can be attached to: 
* Amazon CloudFront [^1]
* Application Load Balancer (ALB) [^2]
* API Gateway REST APIs [^3]
* AWS AppSync [^4]
* AWS Cognito

When its attached to one of this AWS's services, it inspects: 
* HTTP headers
* Query string parameters
* Request body
* IP origin
* Request patterns

And evaluate the configured rules to determine when to apply one of the following actions: 
* Block
* Allow
* Rate-limit
* CAPTCHA or a Challenge to validate origin. 
* Log into CloudWatch or a Kinesis Firehose


[ˆ1]: Amazon CloudFront its a CDN service by AWS that allows caching and static content serve [[AWS - CloudFront]]
[^2]: ALB or Application Load Balancer is a Layer 7 Application balancer service by AWS [[AWS - ALB]]
[^3]: API Gateway [[AWS - API gateway]]
[^4]: AWS AppSync [[AWS - AppSync]]
