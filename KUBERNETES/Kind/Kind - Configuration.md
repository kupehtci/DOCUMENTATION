#Kind #KUBERNETES 

# Kind - Configuration

You can configure a Kind's kubernetes cluster by  using a custom YAML file. 
For information about the different settings, check the official documentation [Kind > Configuration](https://kind.sigs.k8s.io/docs/user/configuration/). 

## Multi-node cluster

For a multi node cluster, indicate the different nodes as a list in the configuration: 

```yaml
kind: Cluster
apiVersion: kind.x-k8s.io/v1alpha4
nodes:
- role: control-plane
- role: worker
- role: worker
```

> Note!: one control plane needs to be defined, followed with at least one worker. 

## Control-plane HA

You can have an HA by deploying multiple control plane nodes: 
```yaml
kind: Cluster 
apiVersion: kind.x-k8s.io/v1alpha4
nodes:
- role: control-plane
- role: control-plane
- role: control-plane
- role: worker
- role: worker
- role: worker
```

## Example of configuration

```yaml
# this config file contains all config fields with comments
# NOTE: this is not a particularly useful config file
kind: Cluster
apiVersion: kind.x-k8s.io/v1alpha4
# patch the generated kubeadm config with some extra settings
kubeadmConfigPatches:
- |
  apiVersion: kubelet.config.k8s.io/v1beta1
  kind: KubeletConfiguration
  evictionHard:
    nodefs.available: "0%"
# patch it further using a JSON 6902 patch
kubeadmConfigPatchesJSON6902:
- group: kubeadm.k8s.io
  version: v1beta3
  kind: ClusterConfiguration
  patch: |
    - op: add
      path: /apiServer/certSANs/-
      value: my-hostname
# 1 control plane node and 3 workers
nodes:
# the control plane node config
- role: control-plane
# the three workers
- role: worker
- role: worker
- role: worker
```