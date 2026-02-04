#AZURE_DEVOPS 

# Azure DevOps - Variables

The **variables** in Azure DevOps are key-value pairs used in the execution of the pipeline. 
Variables are always **strings** and can store values like `int` or `bool` but in text format. 

They are meant for data that need to be reused across the pipeline tasks and pass data between tasks. 

The variables declared independently of the scope can be accessed using `$(<var-name>)` format or `${{ variables.<var-name> }}` so will be evaluated in compilation time. 

## Scopes

Variables can be **scoped** so its usage and value its restricted to a certain block in the pipeline. 
They can be scoped at: 
* **root (whole pipeline)**: visible to every stage and job in the pipeline. 
```yaml
variables: 
	appName: "My Application"
```

* **stage**: restricted and only visible to the stage where its declared. 
```yaml
stages: 
- stage: Build
  variables: 
	  buildConfig: "Release"
```

* **job**: restricted and only visible to the job where its declared. 
```yaml
jobs:
- job: TestJob
  variables:
    testPath: "src/tests"
  steps:
  - script: echo $(testPath)
```


## Variables versus Parameters

The key difference between variables and parameters in Azure DevOps its the evaluation and processing time of this key-value pairs. 

Parameters are evaluated and used in the analysis phase of the pipeline execution and are processed before the pipeline starts to executing. Once the pipeline starts, its values are **inmutable**. 

Variables in comparison, are meant for the execution of the pipeline tasks and the values can change dynamically during the execution. 


Variables can be **scoped** so cannot be access outside its scope, rather than parameters that are file-wide. 

## Pre-defined variables

Azure DevOps agent, sets some variables, in order to give extra information that may be useful during the pipeline execution. 

This variables are set by the agent and are **read-only**: 
* `Pipeline.Workspace`: 

* `Build.Reason`: The event that triggered the build: 
	* `Manual`: a user manually executed the pipeline. 
	* `IndividualCI`: CI triggered by a git push. 
	* `BatchedCI`: CI triggered by a git push and batch changes is selected. 
* `Build.SourcesDirectory`: local file in the agent where the source files are downloaded (For example `c:\agent\_work\1\s`). 
> Note!: If only one repository is checkout on the pipeline execution, `Build.SourcesDirectory` is an exact path to the repository ( `$(Pipeline.Workspace)/s/{REPO_NAME}` ), otherwise; if multiple Git repositories are checkout, this point to the `s` folder within the pipeline folder ( `$(Pipeline.Workspace)/s` )

* `Build.SourceBranchName`
* `Build.SourceBranch`
* `Build.Repository.Uri`
* `Build.Repository.Tfvc.Workspace`
* `Build.Repository.LocalPath`
* `Build.Repository.ID`
* `Build.Repository.Name`
* `Build.Repository.Provider`
* `Build.RequestedForEmail`
* `Build.RequestedForId`
* `Build.RequestedFor`


%%TODO%%

