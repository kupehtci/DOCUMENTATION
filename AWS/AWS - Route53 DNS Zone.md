#AWS 

# AWS Route 53

Amazon Route 53 offers a highly available Domain Name System (DNS[^1]), domain name registration and Health checking for cloud services. 


## Policies

Route 53 offers different types of routing policies optimized for different goals: 

* **Simple**: single endpoint per name, just returns a single record. 
* **Weighted**: distributes traffic between different records by percentages settled (Example 80/20).
* **Latency-based**: send users to the region with lowest measured latency. 
	* For multi-region active-active to improve *user performance*
* **Failover**: Primary is always returned when its healthy and traffic shifts to secondary in case of a health check failure. 
	* For active-pasive infrastructure or DR patterns 
* **Geolocation**: routes (returns record) depending on user's geographic origin. 
	* Used to meet compliance, licensing or localization rules (Serve different content depending on location)
* **Geoproximity**: routes depending on users distance to the resource locations. 
	* Steer traffic between nearby regions. 
* **Multivalue**: returns up to 8 healthy records using a random algorithm.
	* Used for redundancy and imitate an ALB service.

Each policy can be attached to an Route 53 record. 

### Terraform

To declare a public Zone with subdomains: 

```yaml
resource "aws_route53_zone" "main" {
  name = "example.com"
}

resource "aws_route53_zone" "dev" {
  name = "dev.example.com"

  tags = {
    Environment = "dev"
  }
}

## Subdomain record lives in Main zone and points to subdomain zone. 
resource "aws_route53_record" "dev-ns" {
  zone_id = aws_route53_zone.main.zone_id
  name    = "dev.example.com"
  type    = "NS"
  ttl     = "30"
  records = aws_route53_zone.dev.name_servers
}
```

To declare a private zone, you must indicate at least one VPC associated with this DNS zone.

```yaml
resource "aws_route53_zone" "private" {
  name = "example.com"

  vpc {
    vpc_id = aws_vpc.example.id
  }
}
```


### Terraform data resource

To get a Route53 DNS Zone as a data resource: 

```yaml
data "aws_route53_zone" "main"{
  name = "data.com"
  private_zone = false # (Optional)
}
```

To get the resource, can be used as selector the `zone_id` or `name` property (But not either)


[^1]: Domain Name System [[DNS - Domain Name System]]