#Kind #KUBERNETES 

# Kind

**Kind** (Also written as **KinD**) is a tool for running a local Kubernetes cluster using Docker containers as the Kubernetes nodes. 

## Characteristics

* Runs Kubernetes Control Plane ([[KUBERNETES - Architecture]]) and worker nodes inside docker containers instead of VMs inside the same device. 
* Its recommendable for local development, CI testing and learning kubernetes. 

## (MacOS) How to install

Docker Desktop needs to be installed in order to run the workloads. 

To install kind, its recommendable to use **homebrew** (`brew`): 

```bash
brew update
brew install kind
brew install kubectl # Optional if not installed yet. 
```

To verify the installed versions: 
```bash
kind --version
kubectl version --client # Check kubectl CLI version
```

## How to start

The first step, once `kind` and `kubectl` its installed, its to create a cluster: 
```bash
kind create cluster
```

With additional configuration: 
* `--wait`: waits and blocks the execution until the control plane reaches a ready status. Also can specify the time in natural language (`5m`, `30s`, ...) to wait. 
* `--name {name}`: name of the cluster. 
* `--config {file_path}`: custom configuration for the cluster: 

