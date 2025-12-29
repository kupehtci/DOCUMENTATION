#AZURE_DEVOPS 

# Agent Pool Maintenance

Inside `_work` folder within the self-hosted agent folder, numerated directories are created for each pipeline job and when its executed again it will reuse the assigned folder. 

The **pool maintenance job** is an automatic cleanup task that is periodically run against an agent pool to remove the build / release working directories and git directories on the agents, mainly to prevent disk space issues and keep the agents healthy. 

It mainly does: 
* Clean old working directories under `C:\agent\work` on windows self hosted agents that has not been used in a configured number of days. 
* Clean stale repositories and other cached data. 
* Runs per agent pool, nor per machine, under the schedule and retention rules configured in the pool's settings. 

It can be configured under **Organization Settings > (Pipelines) Agent Pools > Maintenance Job**, where you can enable/disable the maintenance job and set the following properties: 
* **Maintenance job timeout in minutes**: maximum timeout for the maintenance job. 
* **Maximum percentage of agents running maintenance concurrently**: percentage of the agents within the pool that can be executing its maintenance job at the same time. 
* **Number of maintenance job records to keep**: number of the records of the maintenance job executions that must be kept. 
* **Days to keep unused working directories (0 indicates forever)**: time in days that the work of the pipelines must be stored in the agent. Maintenance jobs history can be look at: > Maintenance History, section close to the *Settings* one. 
* Scheduling: 
	* **Start maintenance job at this time**: indicates the time to start the maintenance job.
	* **Run maintenance job on these days** days of the week when the pipelines must run. 

![[./IMAGES/ado_maintenance_job.png]]