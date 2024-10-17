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

If admin user is enabled you can retrieve the admin username and password with the following commands: 

```bash
# make sure the admin is correcly enabled
az acr show --name <acr-name> --query "adminUserEnabled"

# Retrieve the username
az acr credential show --name <acr-name> --query "username" --output tsv

# Retrieve first password for the admin user
az acr credential show --name <acr-name> --query "passwords[0].value" --output tsv
```

### Login to Container registry

In order to login to Azure Container registry, if admin user is enabled, in the azure portal should appear an Username and one or more passwords. 

Use this passwords in order to login into the Container Registry

```bash
docker login <acr-name>.azurecr.io 
```

Otherwise, if admin username and password are not enabled you can use Azure AAD (Azure Active Directory) authentication to login into the ACR:  

```bash
# Firstly login into az account
az login

# Select the subcription if you havent do it when login
az account set --subscription <subscription-id>

# Use az to login into docker
az acr login --name <acr-name>
```

In this case you must have `AcrPull` and `AcrPush` permissions over the resource group or the ACR itself in order to have access to make this push / pull operations. 

And once you have login, you can tag and push the image into the remote with the following command: 

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

### Terraform definition

To create an Azure Container Registry using terraform you need to use an `azurerm_container_registry` resource from `azure` provider. 

This is an example of how to declare it: 

```hcl
resource "azurerm_container_registry" "acr" {
  name                = "exampleacr1"
  resource_group_name = azurerm_resource_group.azure-boilerplate-aks.name
  location            = var.location
  sku                 = "Basic"

  identity {
    type = "SystemAssigned"
  }
  
  admin_enabled = true
}   
```

* `admin_enabled` is set to true to be able to have an admin username and password to access the container registry when pulling and pushing images into the registry


[^1]: Azure Kubernetes Service or AKS [[AZURE - AKS Azure Kubernetes Service]] Service]]]]
[^2]: Azure Container Instance or ACI, its a single container running environment [[AZURE - Azure Container Instance]]