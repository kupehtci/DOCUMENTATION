#AZURE #CLOUD 

# AZURE - Functions

<span style="color:DodgerBlue;">Azure functions</span> is a serverless compute service that executes event-driven[^1] applications without managing the underlying infrastructure. 

Azure abstracts for you the server, allowing to run code on demand when a request is received. 


The most relevant features are: 

* **Event driven**: so its only executed when its needed and then slow down to 0
* **Autoscaling** depending on the demand
* Supports **multiple programming language**
* **Integrated** with most azure services like CosmosDB, Event grid and Azure storage. 
* **Consumption and premium plans**: flexible pricing depending on usage and reserved capacity. 

### Other Providers similarities

The most similar services in other providers are AWS Lambda[^2] and Google Functions[^3]. The three are serverless solutions for executing event driven code. 

As a difference with AWS lambda is that in Azure you don't pay for execution, only for the resources and in AWS you per invocation and the execution time. In google functions you pay for resource usage in each execution. 

### Take into account 

In order to use Azure functions, you need to have a storage resource in order to store its runtime files. 

For azure you need to provision an Storage Account and give Azure functions access to it: 

### Create and manage using Azure CLI

You can create an  Azure functions resource using the Azure cli: 

```bash
az functionapp create --resource-group <RESOURCE_GROUP_NAME> --consumption-plan-location <LOCATION> --name <FUNCTION_APP_NAME> --storage-account <STORAGE_ACCOUNT_NAME> --runtime <RUNTIME>

# Example with a Node.js runtime
az functionapp create --resource-group MyResourceGroup --consumption-plan-location westeurope --name MyFunctionApp --storage-account mystorageaccount --runtime node
```

You can then check the logs with `log tail`

```bash
az functionapp log tail --name <FUNCTION_APP_NAME> --resource-group <RESOURCE_GROUP_NAME>
```

### Create and manage using Terraform

You can also create an Azure function using Terraform `hashicorp/azurerm` provider: 

Before creating the function app, create an storage account resource or retrieve it using data resource if already exists: 

```hcl
resource "azurerm_storage_account" "example" {
  name                     = "examplestorageaccount"
  resource_group_name      = azurerm_resource_group.example.name
  location                 = azurerm_resource_group.example.location
  account_tier             = "Standard"
  account_replication_type = "LRS"
}

##  Or get it using data of an existing storage account
## For that you need to specify the name and the resource group name of the
## Existing storage account

data "azurerm_storage_account" "example" {
  name = "examplestorageaccount" 
  resource_group_name = "example-resources" 
}
```

Firstly you need to define a service plan, that define an SKU for the execution
```hcl
resource "azurerm_app_service_plan" "function_service_app" {
  name                = "example-service-plan"
  location            = azurerm_resource_group.example.location
  resource_group_name = azurerm_resource_group.example.name
  sku {
    tier = "Dynamic"
    size = "Y1"
  }
}
```

And then create the Function app: 

```hcl
resource "azurerm_function_app" "example" {
  name                       = "<function-name>"
  location                   = azurerm_resource_group.example.location
  resource_group_name        = azurerm_resource_group.example.name
  app_service_plan_id        = azurerm_app_service_plan.function_service_app.id
  storage_account_name       = azurerm_storage_account.example.name
  storage_account_access_key = azurerm_storage_account.example.primary_access_key
}
```

[^1]: Event driven applications [[Event-driven programming]]
[^2]: AWS Lambda [[AWS - Lambda]]
[^3]: Google functions [[GCP - Cloud Functions]]