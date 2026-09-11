#KUBERNETES 

# KUBERNETES - NGINX Ingress Controller

NGINX Ingress Controller is a reverse proxy and load balancer working in layer 7 (HTTP and HTTPs) that exposes services within the cluster to the exterior. 

The traffic flows within the client to the pod following this path: 

* Client
* External Load Balancer 
* Ingress Controller (NGINX pod)
* Service (ClusterIP or NodePort)
* Pod (Application pod)

The **NGINX ingress controller** is a pod executing NGINX within the cluster to: 
* Listen the Kubernetes API to detect changes in `Ingress` [[KUBERNETES - Ingress]] resources. 
* Generates a dynamic configuration of the NGINX (virtual hosts, location and upstreams) based in the Ingress resources defined rules. 
* Acts as a reverse proxy receiving HTTP and HTTPs requests, applying rules, TLS rewrites and flows them to the backend. 


### Ingress Resource

An example of an NGINX Ingress Controller resource is: 

```YAML
apiVersion: networking.k8s.io/v1
kind: Ingress
metadata:
  name: app-ingress
  annotations:
    nginx.ingress.kubernetes.io/rewrite-target: /
spec:
  ingressClassName: nginx
  rules:
    - host: api.ejemplo.com
      http:
        paths:
          - path: /users
            pathType: Prefix
            backend:
              service:
                name: users-service
                port:
                  number: 80
          - path: /orders
            pathType: Prefix
            backend:
              service:
                name: orders-service
                port:
                  number: 80
```

* `ingressClassName: nginx` defines that the Ingress must be managed by the NGINX controller. 
* `host` and `path` define the flow rules. 