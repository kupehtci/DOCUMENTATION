#AZURE_DEVOPS 

# Azure DevOps - Parameters

Parameters in **Azure DevOps pipelines** are key-value pairs that allow to dinamically configure a pipeline by modifying its values. 

This parameters are defined in the YAML and used like this: 

```yml
parameters:
- name: technology
  displayName: technology
  type: string
  default: node
  values:
  - node
  - java
  - dotnet

trigger: none

jobs:
- job: build
  displayName: build  
  steps:
  - script: echo Technology is ${{ parameters.technology }}
```

You need to define its parameter in the `parameters` block like an array using: 
* `name`: name of the parameter. 
* `displayName`: name to be displayed in the "Run" pipeline message box
* `type`: data type
* `default`: default value for the parameter.
* `values`: optional array list of possible values that the parameter can have. It will prompt an error if the value is not contained in this array. 

# Parameters data types

This parameters support various **data types** passed into the runtime: 

* `string`: basic text value
* `stringList` a list of items and multiple can be selected. (Not available in templates)
* `number`: numerical value
* `boolean`: true or false
* `object`: accepts any YAML structure that conform an object
* `step`: a single step
* `stepList`: a sequence of steps
* `job`: a single job
* `jobList`: a sequence of jobs
* `deployment`: a single deployment job
* `deploymentList`: a sequence of deployment jobs
* `stage`: a single stage
* `stageList`: a sequence of stages