#AZURE_DEVOPS  #SONARQUBE 

# SonarQubePrepare

`SonarQubePrepare` is an Azure DevOps task that prepare the analysis configuration for `SonarQubeAnalyze` task ([[SonarQubeAnalyze]]). 

Basic syntax of the task: 
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

| Parameter            | Type                                          | Required    | Default                       | Description                                                                                                             |
| ---------------------- | ----------------------------------------------- | ------------ | -------------------------------- | ------------------------------------------------------------------------------------------------------------------------- |
| `SonarQube`           | <span style="color:DodgerBlue">string</span>  | Yes          | -                                 | Name of the SonarQube Service Connection defined in the project.                                                       |
| `scannerMode`         | <span style="color:DodgerBlue">string</span>  | Yes          | `dotnet`                          | Type of analysis: `dotnet`, `cli` or `other`.                                                                            |
| `msBuildVersion`      | <span style="color:DodgerBlue">string</span>  | No           | -                                 | .NET Scanner Version. Used when `scannerMode: dotnet`.                                                                  |
| `cliVersion`          | <span style="color:DodgerBlue">string</span>  | No           | -                                 | Version of the CLI scanner. Used when `scannerMode: cli`.                                                               |
| `configMode`          | <span style="color:DodgerBlue">string</span>  | Conditional  | `file`                            | Configuration mode: `file` or `manual`. Required when `scannerMode: cli`.                                               |
| `configFile`          | <span style="color:DodgerBlue">string</span>  | No           | `sonar-project.properties`        | Settings file. Used when `scannerMode: cli` && `configMode: file`.                                                      |
| `cliProjectKey`       | <span style="color:DodgerBlue">string</span>  | Conditional  | -                                 | Project Key. Required when `scannerMode: cli` && `configMode: manual`.                                                  |
| `projectKey`          | <span style="color:DodgerBlue">string</span>  | Conditional  | -                                 | Project Key. Required when `scannerMode: dotnet`.                                                                       |
| `cliProjectName`      | <span style="color:DodgerBlue">string</span>  | No           | -                                 | Project Name. Used when `scannerMode: cli` && `configMode: manual`.                                                     |
| `projectName`         | <span style="color:DodgerBlue">string</span>  | No           | -                                 | Project Name. Used when `scannerMode: dotnet`.                                                                          |
| `cliProjectVersion`   | <span style="color:DodgerBlue">string</span>  | No           | `1.0`                             | Project Version. Used when `scannerMode: cli` && `configMode: manual`.                                                  |
| `projectVersion`      | <span style="color:DodgerBlue">string</span>  | No           | `1.0`                             | Project Version. Used when `scannerMode: dotnet`.                                                                       |
| `cliSources`          | <span style="color:DodgerBlue">string</span>  | Conditional  | `.`                               | Sources directory root. Required when `scannerMode: cli` && `configMode: manual`.                                       |
| `extraProperties`     | <span style="color:DodgerBlue">string</span>  | No           | -                                 | Additional properties for SonarQube defined in YAML format like `sonar.{property}`. See the [available properties](https://docs.sonarsource.com/sonarqube-server/analyzing-source-code/analysis-parameters). |

`extraProperties` need to be specified in multi-line string format: 
```yaml
	extraProperties: |
		sonar.verbose=true
		
```