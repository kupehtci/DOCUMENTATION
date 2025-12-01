#AWS 

## EKS IAM Roles for Service Accounts

IAM Roles for Service Accounts (IRSA) is an EKS feature that allows to associate AWS IAM Roles directly to Kubernetes Service Accounts[^2]. 

This allows to manage the credentials for the Kubernetes applications in the similar way that other resources like EC2. 

This enables to enforce **granular access control**, as each service account can have its own IAM Role with specific permissions rather that all pods sharing the same EKS's IAM Role with all kind of permissions. 

IRSA requires to set up a trust relationship between the IAM roles for the service accounts and an OpenID Connect (OIDC) identity provider, as an OIDC token is needed for this type of authentication. 

### EKS Service Account

For granting access from the EKS cluster to AWS resources and viceversa, we can create a ServiceAccount for granting this permissions. 

This Service account will be associated with an IAM Role[^iam]   by following this format: 

```yaml
apiVersion: v1
kind: ServiceAccount
metadata:
  name: <service-account-name> 
  namespace: kube-system
  annotations:
    eks.amazonaws.com/role-arn: arn:aws:iam::XXXXXXXXXXXX:role/<role-name>
```

The associated IAM Role needs to be defined in service account's `metadata.annotations` in `eks.amazonaws.com/role-arn`. 

When a pod using the service account starts: 
1. EKS injects an OIDC token and sets the AWS appropriate variables. 
2. The AWS SDK inside the pos will use the token to call AWS STS to performa an AssumeRoleWithWebIdentity.


[^iam]: IAM Roles: [[AWS - IAM Roles]]
[^2]: Kubernetes Service Accounts[[KUBERNETES - Service Accounts]]