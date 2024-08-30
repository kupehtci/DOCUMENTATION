#KUBERNETES 

## KUBECTL

Kubectl is the command line too provided by kubernetes in order to be able to launch commands to manage a Kubernetes cluster. 

Can work with remote providers such as Azure AKS, Amazon EKS and similar and with local clusters such as Kind and minikube. 


### How to install it

The installation depend on the SO installed or command line application: 

##### LINUX 

```bash
# download binary 
curl -LO "https://dl.k8s.io/release/$(curl -L -s https://dl.k8s.io/release/stable.txt)/bin/linux/amd64/kubectl"

# Validate the binary with a checksum (Optional)
curl -LO "https://dl.k8s.io/release/$(curl -L -s https://dl.k8s.io/release/stable.txt)/bin/linux/amd64/kubectl.sha256"

echo "$(cat kubectl.sha256) kubectl" | sha256sum --check

# If is valid, the output should be : kubectl: OK

# Install the binary
sudo install -o root -g root -m 0755 kubectl /usr/local/bin/kubectl

# Check that is installed and the version
kubectl version --client
```