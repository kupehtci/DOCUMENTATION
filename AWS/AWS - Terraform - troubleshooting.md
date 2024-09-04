
### Subnets specified must be in at least two different AZs

Error type like: 

```txt
creating EKS Cluster (pre-eks): operation error EKS: CreateCluster, https response error StatusCode: 400, RequestID: b2930182-13a3-4276-bdca-8fbc987f117f, InvalidParameterException: Subnets specified must be in at least two different AZs
```

This may be derivation from the EKS parameter: 

```
subnets_id = [...]
```

