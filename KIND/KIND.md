#KUBERNETES 

Kind is a tool for creating a Kubernetes cluster in a local environment using Docker[^1]

It places each node of the cluster within a Docker container. 


In order to start using it, you can create a <span style="color:DodgerBlue;">Kind cluster</span> that will act as the kubernetes cluster. 
This will create a Kubernetes cluster that can be managed using kubectl by changing its context to `kind`: 

```bash
$ kind create cluster -h
Creates a local Kubernetes cluster using Docker container 'nodes'

Usage:
  kind create cluster [flags]

Flags:
      --config string       path to a kind config file
  -h, --help                help for cluster
      --image string        node docker image to use for booting the cluster
      --kubeconfig string   sets kubeconfig path instead of $KUBECONFIG or $HOME/.kube/config
      --name string         cluster name, overrides KIND_CLUSTER_NAME, config (default kind)
      --retain              retain nodes for debugging when cluster creation fails
      --wait duration       wait for control plane node to be ready (default 0s)

Global Flags:
      --loglevel string   DEPRECATED: see -v instead
  -q, --quiet             silence all stderr output
  -v, --verbosity int32   info log verbosity
```

You can define a custom cluster for defining the number of control planes and workers of it: 

```yaml
kind: Cluster
apiVersion: kind.x-k8s.io/v1alpha4
nodes:
- role: control-plane
- role: worker
- role: worker
```

Example: 

```bash
$ kind create cluster
Creating cluster "kind" ...
 ✓ Ensuring node image (kindest/node:v1.20.2) 🖼
 ✓ Preparing nodes 📦  
 ✓ Writing configuration 📜 
 ✓ Starting control-plane 🕹️ j
 ✓ Installing CNI 🔌 
 ✓ Installing StorageClass 💾 
Set kubectl context to "kind-kind"
You can now use your cluster with:

kubectl cluster-info --context kind-kind

Have a nice day! 👋
```


[^1]: Docker [[DOCKER]]
