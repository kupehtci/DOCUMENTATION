#AZURE_DEVOPS 

# Azure DevOps - Agent Update 

Hosting your own Azure DevOps agents in your own servers, require updating the agent software constantly, as the cloud SaS platform requires normally the agent to be updated to the latest or closely to it. 



# Update agent manually

You can force an agent update by manually updating `bin`, `external`, `config.cmd` and other contents related to the agent execution in its folder: 

1. Download the latest version of the agent in Organization Settings > Agent Pool > {AGENT-POOL} > New Agent +. 
2. Remove the current agent service: 
	1. CD to the folder where the agent is installed
	2. Execute the command `.\config.cmd remove` and enter the valid PAT that was configured when the agent was installed. 
		1. If you don't have the PAT, check on [[Azure DevOps - Self-Hosted agent Install]] > Replace a current agent > Force service removal
3. Unzip the new agent installation binaries