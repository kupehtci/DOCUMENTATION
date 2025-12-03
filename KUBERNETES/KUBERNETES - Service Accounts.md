#KUBERNETES 

## ServiceAccount

A <span style="color:orange;">Service Account</span> objects is a non-human account that provides a distinct identity. 

Application Pods, system components or entities outside the cluster can use an specific service account credentials to identify as it. 

This identity can be used to authenticate to an API server or implement identity-based security policies. 

When a cluster is created, a ServiceAccount `default` is created and replaced if deleted. When a pod is created within the cluster, uses this `default` ServiceAccount. 

The most common use-cases are: 

* Grant access to information stored in `secrets` [^1]
* Grant cross-namespaces access to other namespaces resources. 
* When the pods needs to communicate with an external service. 
* Authenticate to a private image registry using `imagePullSecret`
* An external service needs to authenticate within the cluster, as example a CD/CI pipeline. 
* Use a third-party software that relies on the ServiceAccount identity to group the pods into context. 



[^1]: Kubernetes secrets resources [[KUBERNETES - Secrets]]
[^iam]: IAM Role [[AWS - IAM]]