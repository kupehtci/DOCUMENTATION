#AWS 

# ArgoCD Configuration with AWS ALB


The argocd-server pod is the responsible of the dashboard view when doing a `port-forward` to it or exposing it to the internet. 

This pod us the one, whose service must be exposed: 

```yaml
apiVersion: networking.k8s.io/v1
kind: Ingress
metadata:
  name: argocd-ingress
  namespace: argocd
  annotations:
    alb.ingress.kubernetes.io/scheme: internet-facing
    alb.ingress.kubernetes.io/target-type: ip
    alb.ingress.kubernetes.io/backend-protocol: HTTPS
    alb.ingress.kubernetes.io/healthcheck-protocol: HTTPS
    alb.ingress.kubernetes.io/listen-ports: '[{"HTTPS":443}]'
    alb.ingress.kubernetes.io/subnets: subnet-1a, subnet-2
    alb.ingress.kubernetes.io/certificate-arn: arn:aws:acm:ap-south-...
spec:
  ingressClassName: alb
  rules:
    - host: devops.world
      http:
        paths:
          - path: /
            pathType: Prefix
            backend:
              service:
                name: argocd-server
                port:
                  number: 443
```