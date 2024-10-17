#KUBERNETES 

A <span style="color:orange;">secret</span> is an object small amount of sensitive data such as passwords, tokens and keys.
This information can be stored within a pod specification or a container image but if its confidential must be in a secret. 

This <span style="color:orange;">Kubernetes secrets</span> are stored by default within API server's underlying data (etcd). Anyone with API's access  can access etcd. 

Kubernetes store this sensitive information in a <span style="color:MediumSlateBlue;">key-value map in base64-encoded format</span>, so you need to decode these values to retrieve the actual data. 
### Get Secret data

You can view the secret information by doing a `kubectl describe`: 

```bash
kubectl describe secret <secret-name> -n <namespace>
```

And retrieve the secret data in base64 format with `kubectl get -o yaml` to retrieve the curren

```bash 
kubectl get secret <secret-name> -n <namespace> -o yaml

# You will get a response like: 

apiVersion: v1
data:
  data1:Z2l0bGFiZGVzLmhpYmVydXMuY29tL3NxdWFkLWJ1bGJhc2F1ci9ib2lsZXJwbGF0
  example2: GFiZGVzLmhpYmVydXMuY29tL3NxdWFkLWJ1bGJhc2F1ci9lKhh7suhAKJjsdn
kind: Secret
metadata:
  annotations:
  creationTimestamp: "..."
  labels:
    app.kubernetes.io/part-of: <>
    app.kubernetes.io/version: v2.12.0
    helm.sh/chart: argo-cd-7.4.0
  name: <secret-name>
  namespace: <namespace>
  resourceVersion: "1005788"
  uid: XXXXXXXX-XXXX-XXXX-XXXXXXXXXXXXX
type: Opaque
```

And to retrieve a data value from the data section: 

```bash
kubectl get secret <secret-name> -n <namespace -o jsonpath="{.data.<key>}"

#Example

kubectl get secret example-secret -n default -o jsonpath="{.data.password}"
```

And to decode: 
```bash
base64 --decode
```

This can be concatenated using `|` like this: 
```bash
kubectl get secret example-secret -n default -o jsonpath="{.data.password}"
| base64 --decode
```