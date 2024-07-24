#KUBERNETES 

A <span style="color:orange;">secret</span> is an object small amount of sensitive data such as passwords, tokens and keys.
This information can be stored within a pod specification or a container image but if its confidential must be in a secret. 

This <span style="color:orange;">Kubernetes secrets</span> are stored by default within API server's underlying data (etcd). Anyone with API's access  can access etcd. 

