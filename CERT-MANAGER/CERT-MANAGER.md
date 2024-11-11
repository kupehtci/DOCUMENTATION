#CERT-MANAGER #KUBERNETES 

# CERT-MANAGER 

Cert-manager is an Cluster addon that creates TLS certificates fro workloads of Kubernetes Cluster resources or OpenShift cluster and renews the certificates before they expire. 

Cert-manager can obtain the certificates from various certificate authorities, like <span style="color:orange;">Let's encrypt</span>, Hashicorp Vault, Venafi or a private PKI. 


Uses <span style="color:MediumSlateBlue;">Certificate</span> CRD and store private key and certificate in a Kubernetes Secret[^2] mounted by an application Pod or used by the ingress controller in order to maintain a secure connection. 

With CSI driver, istio CSR, the private key is generated on demand, tehe private key leaves the node and its not stored within a secret. 



[^2]: Kubernetes secret [[KUBERNETES - Secrets]]