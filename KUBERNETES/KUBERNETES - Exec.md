#KUBERNETES 

# KUBERNETES Exec

You can exec shell commands in a pod to debug or configure certain things of its behavior by using Kubectl command line tool[^1]: 

The format of the command is: 
```bash
kubectl exec <pod-name> -n <namespace> -- <command>
```
Namespace can be omitted if the pod is placed in the default namespace or the one settled by the context as default. 

This is a summary of the most useful ones: 

### SH connection

You can connect via shell to an running container in a Pod by entering the cluster with its kubeconfig, getting the pod name and running the following command: 
```bash
kubectl exec -it <pod-name> -n <namespace> -- bash
```

`-it` flag is used for running an interactive terminal session, interesting for debugging purposes. 
### Environmental variables

You can check the defined environmental variables within a pod by using: 
```bash
kubectl exec <pod-name> -n <namespace> -- printenv
```

[^1]: Kubectl command line tool: [[KUBECTL]]