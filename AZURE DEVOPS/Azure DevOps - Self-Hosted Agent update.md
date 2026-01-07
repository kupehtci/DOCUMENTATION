#AZURE_DEVOPS 

# Azure DevOps - Agent Update 

Hosting your own Azure DevOps agents in your own servers, require updating the agent software constantly, as the cloud SaS platform requires normally the agent to be updated to the latest or closely to it. 

# Update agent automatically

You can auto-update the agent by going into: 
1. Azure DevOps > Organization Settings > 
2. Agent Pools 
3. Select the pool where the agent is placed 
4. Go into Agents tab and select the agent
5. Go into the three dots and click on Update Agent. 
6. 

# Update agent manually

You can force an agent update by manually updating `bin`, `external`, `config.cmd` and other contents related to the agent execution in its folder: 

1. Download the latest version of the agent in Organization Settings > Agent Pool > {AGENT-POOL} > New Agent +. 
2. Remove the current agent service: 
	1. CD to the folder where the agent is installed
	2. Execute the command `.\config.cmd remove` and enter the valid PAT that was configured when the agent was installed. 
		1. If you don't have the PAT, check on [[Azure DevOps - Self-Hosted agent Install]] > Replace a current agent > Force service removal
3. Unzip the new agent installation binaries and copy `bin`, `externals`, `config`, `config.cmd`, `reauth.cmd` and `run.cmd` files into the agent folder replacing the actual ones. 
4. You can preserve the `_work` and `_diag` folders in order to preserve the pipeline jobs contents.
5.  Reconfigure the agent, using `.\config.cmd ` and fulfilling the prompted configuration. (Check on [[Azure DevOps - Self-Hosted agent Install]]). 