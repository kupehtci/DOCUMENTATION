#AZURE_DEVOPS  #SONARQUBE 

# SonarQubePrepare

`SonarQubePrepare` is an Azure DevOps task that prepare the analysis configuration for `SonarQubeAnalyze` task ([[SonarQubeAnalyze]]). 

```yaml
# Prepare Analysis Configuration v7
# Prepare SonarQube Server analysis configuration.
- task: SonarQubePrepare@7
  inputs:
    SonarQube: # string. Required. 
    scannerMode: 'dotnet' # 'dotnet' | 'cli' | 'other'. Required. C
    #msBuildVersion: # string.
    #cliVersion: # string. Alias: cliScannerVersion. Optional. 
    #configMode: 'file' # 'file' | 'manual'. Required when scannerMode = cli. Mode. Default: file.
    #configFile: 'sonar-project.properties' # string. Optional. 
    #cliProjectKey: # string. 
    projectKey: # string. Required when scannerMode = dotnet. Project Key. 
    #cliProjectName: # string. Optional. 
    #projectName: # string. Optional. 
    #cliProjectVersion: '1.0' # string. Optional.
    #projectVersion: '1.0' # string. Optional. 
    #cliSources: '.' # string. 
    #extraProperties: # string. 
```

* `SonarQube`: Name of the SonarQube Service Connection defined in the project. 
* `scannerMode`: Can be either `dotnet`, `cli` or `other`. Indicates the type of analysis. 
* `msBuildVersion`: Use when `scannerMode = dotnet`.NET Scanner Version. 
* `cliVersion`: Use when `scannerMode = cli`. Version of the CLI scanner. 
* `configFile`: (default `sonar-project.properties`)Use when scannerMode = cli && configMode = file. Settings File. Default: sonar-project.properties.
* `cliProjectKey`: Required when `scannerMode = cli` && `configMode = manual`. Project Key. 
* `cliProjectName`: Use when `scannerMode = cli` && `configMode = manual`. Project Name. 
* `projectName`: Use when `scannerMode = dotnet`. Project Name. 
* `cliProjectVersion`: Use when `scannerMode = dotnet`. Project Version. Default: `1.0`.
* `cliSources`: Required when `scannerMode = cli` && `configMode = manual`. Sources directory root. Default: `.`
* `extraProperties`: Additional Properties for SonarQube defined in YAML format like `sonar.{property}`. The available properties are defined in https://docs.sonarsource.com/sonarqube-server/analyzing-source-code/analysis-parameters:  
	
`extraProperties` need to be specified in multi-line string format: 
```yaml
	extraProperties: |
		sonar.verbose=true
		
```