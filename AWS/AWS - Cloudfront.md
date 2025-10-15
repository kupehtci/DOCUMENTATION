
#AWS 

# AWS CloudFront

Amazon CloudFront is a Content Delivery Network or CDN[^1] that reduces RTT of your applications by delivering content closer to the end user. 

Reduces latency of a web requests by caching information across dispersed servers supported with network mapping and intelligent routing. 

It allows to: 

* Deliver fast and more secure content in milliseconds. 
* Accelerate dynamic content delivery and APIs
* Stream live and on-demand video quickly. 
* Distribute patches and updates at high transfer rate. 

The key benefits of using AWS CloudFront are: 
* It cached content at **Edge locations** worlwide.
* Reduces load on the **origin** (S3, EC2, ...)
* DDoS protection integrating AWS Shield.
* Supports AWS WAF for security rules.
* HTTPs support with custom SSL and TLS certificates. 
* Supports both **static content (HTML, videos and images)** and **dynamic content (API responses, personalized webpages)**. 

It can be configured with different origins: 
* S3
* EC2
* ALB
* API Gateway
* Others
Also can have multiple origins and route traffic to secondary origin in case of primary origin's failover. 

It has different behaviors configured: 
* Which origin to use
* Caching settings
* Allowed HTTP methods
* TTL or Time To Live for caching


### Caching behaviors

You can define different caching settings that define how CloudFront serves and caches content based on path patterns like `/images/*`. 

You can set to **forward** a header. This implies that the header will be sent to the origin and CloudFront will generate different cache versions depending on that header value. 

#### Language specific content

You can use CloudFront to send and chache language specific content.
If your website has different websites depending on the language like: 
```txt
/en/index.html
/es/index.html
/fr/index.html
```

You can set CloudFront caching behaviour to forward the `Accept-Language` header.


# WAF

Cloudfront can be integrated with a Web Application Firewall[^2] and adds an extra layer of security: 

It adds or offers: 
* Firewall protect the Web application from web vulnerabilities by using filters. 
* ACL integration to grant granular access to web applications



[^1]: Content Delivery Network [[CDN - Content Delivery Network]]
[^2]: Web Application Firewall [[AWS - WAF Web Application Firewall]]