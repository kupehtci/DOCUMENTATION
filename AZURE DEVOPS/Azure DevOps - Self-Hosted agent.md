#AZURE_DEVOPS 
# Azure DevOps - Self-Hosted Agent

A Self-hosted agent in Azure DevOps is a machine that can be physical, a VM or a container where you install the azure devops agent software to run the pipelines. 

It allows to: 
* Bring CI/CD to a on-prem environment: 
	* Network and security: the agent live inside the private network so it can reach internal services, private endpoints, on-prem servers to deploy and resources. 
	* Performance: as tools are reused between jobs and the caches, the installations persist and can make builds faster.
* Host and maintains the agent: 
	* Control the packages installed
	* More control and debug over the automations
* Avoid extra costs of an Azure VM. 

# Communication URLs 

If you are running an agent in a secure network behind a firewall, the agent must be able to communicate with the following URLs: 

| Domain URL                                            | Description                                                                                                     |
| ----------------------------------------------------- | --------------------------------------------------------------------------------------------------------------- |
| `https://{organization_name}.pkgs.visualstudio.com`   | Azure DevOps Packaging API for organizations using the `{organization_name}.visualstudio.com` domain            |
| `https://{organization_name}.visualstudio.com`        | For organizations using the `{organization_name}.visualstudio.com` domain                                       |
| `https://{organization_name}.vsblob.visualstudio.com` | Azure DevOps Telemetry for organizations using the `{organization_name}.visualstudio.com` domain                |
| `https://{organization_name}.vsrm.visualstudio.com`   | Release Management Services for organizations using the `{organization_name}.visualstudio.com` domain           |
| `https://{organization_name}.vssps.visualstudio.com`  | Azure DevOps Platform Services for organizations using the `{organization_name}.visualstudio.com` domain        |
| `https://{organization_name}.vstmr.visualstudio.com`  | Azure DevOps Test Management Services for organizations using the `{organization_name}.visualstudio.com` domain |
| `https://*.blob.core.windows.net`                     | Azure Artifacts                                                                                                 |
| `https://*.dev.azure.com`                             | For organizations using the `dev.azure.com` domain                                                              |
| `https://*.vsassets.io`                               | Azure Artifacts via CDN                                                                                         |
| `https://*.vsblob.visualstudio.com`                   | Azure DevOps Telemetry for organizations using the `dev.azure.com` domain                                       |
| `https://*.vssps.visualstudio.com`                    | Azure DevOps Platform Services for organizations using the `dev.azure.com` domain                               |
| `https://*.vstmr.visualstudio.com`                    | Azure DevOps Test Management Services for organizations using the `dev.azure.com` domain                        |
| `https://app.vssps.visualstudio.com`                  | For organizations using the `{organization_name}.visualstudio.com` domain                                       |
| `https://dev.azure.com`                               | For organizations using the `dev.azure.com` domain                                                              |
| `https://login.microsoftonline.com`                   | Microsoft Entra sign-in                                                                                         |
| `https://management.core.windows.net`                 | Azure Management APIs                                                                                           |
| `https://download.agent.dev.azure.com`                | Agent package                                                                                                   |

Extracted from: https://learn.microsoft.com/en-us/azure/devops/pipelines/agents/windows-agent?view=azure-devops&tabs=IP-V4. 
