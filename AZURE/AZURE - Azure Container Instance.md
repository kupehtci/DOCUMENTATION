#AZURE #AKS 

An Azure Container Instance or ACI is a single container running environment without an underlying infrastructure.
This results in quick starting, simple and easy to maintain isolated containers 




#### Scaling

Azure Container Instances are not meant to support scaling out, but you can manually create and manage multiple instances within the same <span style="color:DodgerBlue;">Azure Container Group</span> or use orchestration tools like Kubernetes auto scaling. 

#### Networking 

By default, ACI instances can be exposed to the internet with a Public IP and a FQDN[^fqdn]. 

##### Storage

In case of needing <span style="color:orange;">data persistence</span> you can mount Azure File Shares[^afs] to store the container persistent data. 

For mounting the file share in the ACI via terraform, add the following `volume` block within the `container` block: 

```hcl
volume {
      name                 = "<volume-name>"
      mount_path           = "/home/atlantis/"
      share_name           = azurerm_storage_share.atlantis-storage-share.name
      storage_account_name = azurerm_storage_account.storage-account.name
      storage_account_key  = azurerm_storage_account.storage-account.primary_access_key
    }
```

Set the `share_name`, `storage_account_name` and `storage_account_key`. 

### Azure CLI create an ACI

To create a container via azure CLI: 

```bash
# Log into Az
az login

# Create Resource group or retrieve its name
az group create --name <rg-name> --location <rg-location>

# Create the container instance
az container create --resource-group <rg-name> --name <container-name> --image <image-path/direction> --cpu x --memory x --ports xxxx

# Retrieve FQDN and IP address
az container show --resource-group <rg-name --name <container-name> --query "{FQDN:ipAddress.fqdn,State:instanceView.state}" --out table

```

### Terraform create an ACI

To create an ACI using terraform, this is a basic template to define it:

```bash

# Create a Resource Group or import it as data
resource "azurerm_resource_group" "rg" {
  name     = "<rg-name>"
  location = "Spain Central"
}

# Create a Container Instance
resource "azurerm_container_group" "example" {
  name                = "<aci-name>"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  os_type             = "Linux"

  container {
    name   = "<container-name>"
    image  = "<container-direcion>"
    cpu    = "X.X"
    memory = "X.X"

    ports {
      port     = 80
      protocol = "TCP"
    }
  }

  ip_address {
    type = "Public"
    ports {
      port     = 80
      protocol = "TCP"
    }
  }
}
```
### Container logs

You can retrieve the logs of a container within an Azure Container Instance. In order to get the logs, you can use the following command: 

```bash
az container logs --resource-group <rg-name> --name <aci-name> --container-name <container-name>
```

* `<rg-name>` name of the resource group where the ACI is placed. 
* `<aci-name` name of the ACI to launch the command into.  
* `<container-name>` name of the container to retrieve its logs
### Debug a container

To debug a container inside an Azure Container Instance, you can execute a `/bin/sh` command inside it to be able to execute commands inside the machine: 

```bash
az container exec --resource-group <rg-name> --name <aci-name> --exec-command "/bin/sh"
```

* `<rg-name>` name of the resource group where the ACI is placed. 
* `<aci-name` name of the ACI to launch the command into.  
* `--exec-command "_"` command to be executed inside the machine. Other commands that are available by the machine can be launched within it, not only `/bin/sh`

### Restart a container

You can start an stopped container: 
```bash
az container start --resource-group myResourceGroup --name mycontainer
```

Also stop a currently running container: 

```bash
az container stop --resource-group myResourceGroup --name mycontainer
``` 

And restart a container: 

```bash
az container restart --resource-group myResourceGroup --name mycontainer
```

[^fqdn]: Fully Qualified Domain Name 
[^afs]: Azure File Share within an Azure Storage Account 