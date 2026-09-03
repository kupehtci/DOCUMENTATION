#AZURE_DEVOPS 

# Azure Pipelines - Templates

**Templates** allows you to define reusable content, logic and parameters in the YAML pipelines that can be called from a pipeline. 

Templates by default can contain: 
* **Steps**: reusable steps (tasks) that can be called from a job: 

```yaml
# template-npm.yaml
steps:
- script: npm install
- script: npm test
```

```yaml
# main.yaml
jobs:
- job: Build
  pool:
    vmImage: 'ubuntu-latest'
  steps:
  - template: templates/template-npm.yaml
```

* **Jobs**: Reusable jobs that can be called from an stage. Define a full job with one or more steps, pool definition and optional variables and outputs. 

```YAML
# template-build-dotnet.yaml
parameters: 
	- name: projects
	  type: string
	  default '**/*.sln'
	  
jobs: 
	- job: BuildDotNet
	  displayName: 'Build .Net'
	  pool: 'ubuntu-latest'
	  steps: 
		- checkout: self
		- task: UseDotNet@2
		  displayName: 'Use .Net SDK'
		  inputs: 
			  packageType: 'sdk' 
			  version: '7.x'    
			  
```

Usage in the pipeline: 

```YAML 
# main.yaml
stages:

	- stage: Build
	  jobs: 
		  - template: template/template-build-dotnet.yaml
		    parameters: 
			    projects: 'src/MyApp.sln'
```
 
* **Stages**: One or more jobs and the stage-level configuration (Variables, conditions and dependencies). 

```YAML
# build-and-test-stage.yaml
parameters:
  - name: pool
    type: object
    default:
      vmImage: 'ubuntu-latest'
  - name: solution
    type: string
    default: '**/*.sln'
  - name: testProjects
    type: string
    default: '**/*Tests.csproj'

stages:
  - stage: BuildAndTest
    displayName: 'Build and Test'
    jobs:
      - job: Build
        pool: '${{ parameters.pool }}'
        steps:
          - checkout: self
          - task: UseDotNet@2
            displayName: 'Use .NET SDK'
            inputs:
              packageType: 'sdk'
              version: '7.x'
          - task: DotNetCoreCLI@2
            displayName: 'Build'
            inputs:
              command: 'build'
              projects: '${{ parameters.solution }}'
              arguments: '--configuration Release'

      - job: Test
        dependsOn: Build
        pool: '${{ parameters.pool }}'
        steps:
          - checkout: self
          - task: DotNetCoreCLI@2
            displayName: 'Run tests'
            inputs:
              command: 'test'
              projects: '${{ parameters.testProjects }}'
              arguments: '--configuration Release --collect:"XPlat Code Coverage"'
          - task: PublishTestResults@2
            displayName: 'Publish test results'
            inputs:
              testResultsFormat: 'VSTest'
              testResultsFiles: '**/*.trx'
```

Usage in the pipeline: 

```YAML
# azure-pipelines.yml
trigger:
  - main

stages:
  - template: templates/build-and-test-stage.yaml
    parameters:
      pool:
        vmImage: 'windows-latest'
      solution: 'src/MyApp.sln'
      testProjects: 'tests/**/*Tests.csproj'
```