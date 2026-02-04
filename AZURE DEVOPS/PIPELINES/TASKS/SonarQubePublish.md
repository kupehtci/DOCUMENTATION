#AZURE_DEVOPS  #SONARQUBE 

# SonarQubePublish

`SonarQubePublish` is an Azure DevOps task that publish the results of the Quality Gate from SonarQube ([[SonarQube]]) into the Azure DevOps pipeline. 

Basic syntax of the task: 
```yaml
- task: SonarQubePublish@7
  inputs:
    pollingTimeoutSec: '300' # string, timeput in seconds. Required.Default: 300.
```

* `pollingTimeoutSec`: indicates the maximum time in seconds that this task will wait for the SonarQube analisis to end. 


Requires a `SonarQubePrepare` ()