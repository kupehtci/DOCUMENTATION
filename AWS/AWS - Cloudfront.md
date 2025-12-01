
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


### CloudFront Invalidation

A **CloudFront invalidation** is a request to remove cached objects from its edge locations before the TTL[^3] expires. 

Invalidation requests can be done using AWS CLI: 
```bash
aws cloudfront create-invalidation \
    --distribution-id ABCDE12345 \
    --paths "/<path>/<object-to-invalidate>"
```

If you for example update `/index.html` from the S3, CloudFront still serves the old cached version, and for invalidate it: 

```bash
aws cloudfront create-invalidation \
    --distribution-id ABCDE12345 \
    --paths "/index.html"
```

---
# Certificates

For assigning certificates to CloudFront using an AWS ACM, the certificate needs to be **created in us-east-1 region** independently of the CloudFront origin resources' Region. 

---

# WAF

Cloudfront can be integrated with a Web Application Firewall[^2] and adds an extra layer of security: 

It adds or offers: 
* Firewall protect the Web application from web vulnerabilities by using filters. 
* ACL integration to grant granular access to web applications

# Costs

The costs of CloudFront are: 

| **Category**                                | **Concept**                   | **Description**                                                                         | **Notes / Best Practices**                                             |
| ------------------------------------------- | ----------------------------- | --------------------------------------------------------------------------------------- | ---------------------------------------------------------------------- |
| **Data Transfer Out to Internet**           | Per GB                        | Data delivered from CloudFront edge locations to end users.                             | Varies by region — cheaper than S3 direct internet transfer.           |
| **Data Transfer from Origin to CloudFront** | Per GB                        | Data pulled from the origin (e.g., S3, EC2, custom origin) into CloudFront.             | Free if your origin is **Amazon S3 in the same region**.               |
| **HTTP/HTTPS Requests**                     | Per 10,000 requests           | Billed separately for HTTP and HTTPS requests.                                          | HTTPS requests cost slightly more.                                     |
| **Invalidation Requests**                   | Per path (after free tier)    | Removing cached objects before they expire.                                             | **First 1,000 paths/month free**; wildcards like `/*` count as 1 path. |
| **Field-Level Encryption Requests**         | Per 10,000 requests           | Encrypt sensitive data fields at edge locations.                                        | Used for PCI/HIPAA-compliant applications.                             |
| **Real-Time Logs**                          | Per GB delivered              | Cost for streaming detailed request logs to a destination (like Kinesis Data Firehose). | Optional; useful for analytics.                                        |
| **Origin Shield (optional)**                | Per GB                        | Adds a centralized caching layer between origins and edges.                             | Reduces origin load; small additional cost.                            |
| **Lambda@Edge Invocations**                 | Per invocation + compute time | Charges for each Lambda@Edge execution and duration.                                    | Billed separately from CloudFront.                                     |
| **Dedicated IP Custom SSL**                 | Monthly fee per certificate   | For custom SSL/TLS certs using dedicated IP addresses.                                  | Most users use **SNI Custom SSL** (free).                              |
|                                             |                               |                                                                                         |                                                                        |

And included in **free tier**: 

| Concept                            | Free tier limit        |
| :--------------------------------- | ---------------------- |
| Data transfer out                  | 1 TB                   |
| HTTP / HTTPS requests              | 10,000,000             |
| Invalidation paths                 | 1,000                  |
| Lambda@edge invocations            | 1,000,000              |
| Data transfer origin to CloudFront | Free if in same region |



[^1]: Content Delivery Network [[CDN - Content Delivery Network]]
[^2]: Web Application Firewall [[AWS - WAF Web Application Firewall]]
[^3]: TTL or Time To Live 