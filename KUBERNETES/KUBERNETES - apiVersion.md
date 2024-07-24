#KUBERNETES 

## Kubernetes api version

In order to check the most recent version of the API for the different components for a k8s cluster version you can run the following command: 

```yaml
for kind in `kubectl api-resources | tail +2 | awk '{ print $1 }'`; do kubectl explain $kind; done | grep -e "KIND:" -e "VERSION:"
```

Producing an output of the different `kind` of elements with their correspondent version. 


The key feature is the `kubectl explain <resource>` command followed by the kind of component to evaluate. 

This generates an output like this: 

```bash
$ kubectl explain deploy
KIND:     Deployment
VERSION:  extensions/v1beta1 <== API Version

DESCRIPTION:
     DEPRECATED - This group version of Deployment is deprecated by
     apps/v1beta2/Deployment. See the release notes for more information.
     Deployment enables declarative updates for Pods and ReplicaSets.

FIELDS:
   apiVersion   <string>
     APIVersion defines the versioned schema of this representation of an
     object. Servers should convert recognized schemas to the latest internal
     value, and may reject unrecognized values. More info:
     https://git.k8s.io/community/contributors/devel/api-conventions.md#resources
```

You can see the different versions that can be applied to Kubernetes in : [AKS Release Status (azure.com)](https://releases.aks.azure.com/webpage/index.html). 

