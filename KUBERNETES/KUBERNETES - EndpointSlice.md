#KUBERNETES 

### EndpointSlice

An EndpointSlice contains the reference to a set of endpoints. 

The control plane created this components automatically for any kubernetes service that has a selector specified. 

Example of an EndpointSlice owned by `example` kubernetes service: 

```yaml
apiVersion: discovery.k8s.io/v1
kind: EndpointSlice
metadata:
  name: example-abc
  labels:
    kubernetes.io/service-name: example
addressType: IPv4
ports:
  - name: http
    protocol: TCP
    port: 80
endpoints:
  - addresses:
      - "10.1.2.3"
    conditions:
      ready: true
    hostname: pod-1
    nodeName: node-1
    zone: us-west2-a
```

Supports three types of addresses: 

* IPv4
* IPv6
* FQDN: Fully Qualified Domain Name

