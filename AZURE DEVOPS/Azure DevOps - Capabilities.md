#AZURE_DEVOPS 

# Azure DevOps - Self-Hosted Agent Capabilities

Some pipeline jobs, depending on the workflow and tasks that the pipeline implements; it requires the self-hosted agent to have certain software or requirements in order to properly execute the job. 

Each Self-Hosted agent ([[Azure DevOps - Self-Hosted agent]]) has agent capabilities, that are a set of attributes that describe the software, tools and the environmental variables available on an agent. 

This allows **Azure Pipelines to match the jobs with the appropriate agents**. It determines which jobs/tasks can an agent execute based on what is installed and configured in the machine. 

There are two types of capabilities: 
* **System capabilities**: automatically detected by the agent when it starts. These include: 
	* Operating system details, such as `Agent.OS`
	* Installed Software versions
	* Environmental Variables
	* Other tools discovered by the machine. 
	This values are captured in the agent's runtime and updated if those values changes when the agent is running. 

* **User capabilities**: manually defined key-value pairs that you can add to the agent to customize the capabilities that a certain agent has. This is useful for adding custom properties to an agent like `purpose: build` and `purpose: deploy` for separating agent purposes. Also is useful for declaring specialized tools that you have manually installed in Azure DevOps. 

You can add **user capabilities** in the *Capabilities* section: 
![[./IMAGES/user-defined-capabilities.png]]

## How the capabilities work with demands

Pipelines jobs can declare **demands** that specify which required capabilities an agent must have to run the job. 
For example, if certain agents have a particular build tools installed like NPM ([[NPM - Introduction]]) you can: 
* Add the tool as an **user capability** like for example `build: npm`. 
* Include the demands for a environmental variable that will be included as a **system capability**. This environmental variable is included automatically by the installed tool or by the user in the OS. 



