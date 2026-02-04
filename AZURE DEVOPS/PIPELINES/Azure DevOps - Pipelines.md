#AZURE_DEVOPS 

# Azure DevOps Pipelines 

Azure DevOps pipelines is a cloud based service that automates the building, test and deployment of the code projects using continuous integration (CI) and continuous deployment (CD) workflows. 

Build pipelines are defined in YAML[^1] format or in classic pipelines (UI) to organize the logical phases and executions made to build, test and pack the application. 

The core concepts of a pipeline are: 
* **stages**: organize the pipelines into logical and isolated phases. 
* **jobs**: runs on agents [[Azure DevOps - Agent Pool]] and contain the actual work to be performed by the pipeline. 
* **steps**: smallest execution unit that can be a pre-defined task or a script. 
	* **tasks**: pre-packed scripts the perform specific actions. 
	* **script**: custom script. 
* **Agents**: software installed in the infrastructure to execute the jobs workload.
* **Triggers**: events that start the pipeline execution.
* **Artifacts**: files or packages produced by the pipeline for future deployment. 

## Basic structure

The basic structure of a yaml pipeline define workflow. A template of this structure: 

```yaml
# define the triggers of the pipeline
trigger: 
	- main
# Define the parameters used in the pipeline	  
parameters:  
  - name: test  
    type: string  
    default: 'default'

	
# [Optional] Define the stages of the pipeline 
stages: 
- stage: {NAME}
  # Define the jobs of the stage
  jobs: 
  - job: 
    displayName: '{JOB_NAME}'
    pool: 
		name: '{AGENT_POOL_NAME}'
		demands # Custom demands for the agent pool
	steps: 
		- task: {TASK_NAME}@{VERSION}
		  
	  
```

[^1]: YAML Format [[YAML]]