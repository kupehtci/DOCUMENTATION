#AWS 






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


