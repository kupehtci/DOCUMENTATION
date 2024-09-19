#CERT-MANAGER #HELM #KUBERNETES 

# CERT-MANAGER AWS Helm configuration

This is a guide of how to configure Cert-manager when using its helm release to deploy it within a Kubernetes cluster. 


### Create a public domain name

In order to have a certificate signed public domain, you need to have a registered domain in a domain name registrar. 

You must need to create a Route53 DNS hosted zone with the domain name as Route53 name

```yaml
resource "aws_route53_zone" "main" {
  name = "example.com"
}

# Public subdomain
resource "aws_route53_zone" "dev" {
  name = "pre.example.com"

  tags = {
    environment = "dev"
  }
}

resource "aws_route53_record" "dev-ns" {
  zone_id = aws_route53_zone.main.zone_id
  name    = "dev.example.com"
  type    = "NS"
  ttl     = "30"
  records = aws_route53_zone.dev.name_servers
}
```
### Install cert manager

The helm release that installs the chart looks like this: 

```yaml
resource "helm_release" "certmanager" {
  name = "certmanager"
  namespace = "cert-manager"
  create_namespace = true

  version = "1.15.3"

  repository = "https://charts.jetstack.io"
  chart = "cert-manager"

  values = [
    file("${path.module}/values-certmanager.yaml")
  ]


  set{
    name = "replicaCount"
    value = 1
  }
}
```