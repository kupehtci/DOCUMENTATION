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


