#AZURE #AKS #CLOUD 
# AZURE Container Troubleshoot

This is a set of practices and commands that can be used to debug and solve the troubles that a container can cause in Azure Cloud[^a]

You can connect via shell to an running container in a Pod by entering the cluster with its kubeconfig, getting the pod name and running the following command: 
```bash
kubectl exec -it <pod-name> -n <namespace> -- bash
```

In case that the container is running in an ACI[^1] you can access via SH through the following command. To do so you need to be able to login into the azure cloud with a user that has enough permissions to do that and specify the resource group name where the ACI is contained and the ACI name:  
```bash
`az container exec --resource-group <rg-name> --name <aci-name> --exec-command "/bin/sh"`
```

[^a]: Azure Cloud [[AZURE]]
[^1]: Azure Container Instance [[AZURE - Azure Container Instance]]