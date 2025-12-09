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


Variables can be **scoped** so its not 