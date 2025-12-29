#AZURE_DEVOPS 

# Agent Pool

An **agent pool** in Azure DevOps is a logical grouping of one or more build and release agents that can run the workload of the pipeline jobs. 

All the pipeline must target a agent in which the jobs are going to be executed, that can be over self-hosted agents (Own agents[[Azure DevOps - Self-Hosted agent]]) or microsoft-hosted. 

The pool manages: 
* **Isolation and governance**: the infrastructure can be separated between different technologies, security level and environments: like windows, linux, production deployment, etc. 
* **Sharing capacity**: a single pool can be shared between different projects within an organization so different projects can reuse the same machines instead of duplicated infrastructure. 
* **Scheduling and load balancing**: the jobs to execute are queued against a pool, any idle agent that mets the demand and capabilities can pick the job. 
	* The job is balanced between the available idle agents. 
	* The job is queued in the pool if all the agents are busy until one becomes idle. 

The pool can be determined in the YAML pipeline: 
* `pool.vmImage: 'ubuntu-latest'` for a microsoft-hosted. 
* `pool.name: '{POOL-NAME}'` for self-hosted. 

