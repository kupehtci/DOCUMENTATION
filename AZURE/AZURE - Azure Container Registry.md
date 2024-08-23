#AZURE #AKS 


### Azure Container Registry

An <span style="color:DodgerBlue";>Azure Container Registry ACR</span> is a managed, private Docker registry provided by Microsoft Azure. 

Allows to store, pull, push and manage container images (Docker Images) that can be used in various Azure resources and services such as AKS[^1], ACI[^2], App Service or others. 

All the versions / tags of the same image are saved in the same repository within the registry. 
### Azure CLI

You can create an azure container registry with the command create `acr` resource: 

```bash
az acr create --resource-group <my-resource-group> --name <my-acr-name> --sku Basic
```

### Login to Container registry

In order to login to Azure Container registry, if admin user is enabled, in the azure portal should appear an Username and one or more passwords. 

Use this passwords in order to login into the Container Registry

```bash
docker login <acr-name>.azurecr.io 
```

And once you have login with this username and password, you can tag and push the image into the remote with the following command: 

```bash
docker tag <image-name>:<tag> <acr-name>.azurecr.io/<image-name>:<tag>
docker push <acr-name>.azurecr.io/<image-name>
```

If want to retrieve the image from the remote container registry you can do: 

```bash
docker pull <acr-name>.azurecr.io/<image-name>
```

`latest` tag can be used when pushing the image to the container registry


### Retrieve images

You can list the repositories within the registry: 
```bash
az acr repository list --name <acr-name> --output table
```

To list the different images under the repository in the registry
```bash
az acr repository show-tags --name <acr-name> --repository <image-name> --output table
```


[^1]: Azure Kubernetes Service or AKS [[AKS - Kubernetes cluster]]
[^2]: Azure Container Instance or ACI, its a single container running environment [[AZURE - Azure Container Instance]]