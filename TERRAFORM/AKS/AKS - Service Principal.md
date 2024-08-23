#AZURE #AKS #TERRAFORM 


An **Azure Service Principal** is a security identity used by applications, services, and automation tools to access Azure resources. It represents an application's identity in Azure AD and is used for authentication and authorization to access resources in Azure.

An <span style="color:DodgerBlue;">Azure Service Principal</span> is a definition of policies and permissions that has an application within Azure. 

- **Application Identity**: Acts as a digital identity for applications or services.
- **Authentication**: Allows apps and services to authenticate against Azure AD.
- **Role-Based Access Control (RBAC)**: Enables granular control over Azure resource permissions.

Service principals are used in scenarios where automated processes or applications need to interact with Azure resources without manual intervention. Common use cases include:


### Terraform declaration

To provide a resource in terraform with a service principal, some prerequisites are needed

```hcl
provider "azurerm" {
  features {}
}

provider "azuread" {}

```


Define an Azure AD Application, which will be associated with the service principal:

```hcl
resource "azuread_application" "example" {
  name = "example-application"
}
```

Create the service principal linked to the Azure AD application:

```hcl
resource "azuread_service_principal" "example" {
  application_id = azuread_application.example.application_id
}

```

Generate a password also known as <span style="color:DodgerBlue";>client secret</span> for the service principal:

```hcl
resource "azuread_application_password" "example" {
  application_id = azuread_application.example.application_id
  display_name   = "example-password"
}
```

Grant the service principal permissions over Azure Resources with a role:

```hcl
resource "azurerm_role_assignment" "example" {
  principal_id         = azuread_service_principal.example.id
  role_definition_name = "Contributor"  # Or any other role as needed
  scope                = "/subscriptions/YOUR_SUBSCRIPTION_ID/resourceGroups/YOUR_RESOURCE_GROUP_NAME" 
  # or azurerm_resource_group.<rg-name>.id
}

```

The most common outputs for this service principal to extract the login information for use it in another contexts is: 

```hcl
output "service_principal_client_id" {
  value = azuread_application.example.application_id
}

output "service_principal_client_secret" {
  value = azuread_application_password.example.value
}

output "tenant_id" {
  value = data.azuread_client_config.current.tenant_id
}

output "subscription_id" {
  value = data.azurerm_client_config.current.subscription_id
}

```

