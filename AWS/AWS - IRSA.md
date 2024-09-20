#AWS #KUBERNETES #CLOUD #EKS 

# AWS IRSA IAM Roles for Service Accounts

IAM Roles for Service Accounts or IRSA is an EKS[^1] feature that allows to grant to pods granular access to AWS resources. 

IRSA works by using an OpenID Connect Identity provider (OIDC) for authenticate pods to AWS identity and Identity Access Management Service (IAM[^2])

Allows to: 

* Associate IAM roles. By using IRSA, you can associate IAM roles directly to a Kubernetes Service Account[^3]. This imply that pods in a Kubernetes cluster can use that service to assume an IAM role and perform some authorized actions over AWS resources. 

>Note: For doing so, the IAM role must have an associate IAM policy that allow that actions. 

* Secure access to AWS resources: this can grant IAM role permissions to certain pods without using an internal application access credentials


[^1]: EKS or Elastic Kubernetes Service is a Kubernetes cluster resource within the AWS cloud [[./AWS - EKS Elastic Kubernetes Service]]
[^2]: IAM access based services in AWS [[./AWS - IAM]]
[^3]: Kubernetes Service Account Resource [[../KUBERNETES/KUBERNETES - ServiceAccounts]]

