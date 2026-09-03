#AZURE_DEVOPS #SONARQUBE 

# SonarQubeAnalyze

`SonarQubeAnalyze` is an Azure DevOps tasks that execute an application's analysis using SonarQube and uploads the analysis results to the SonarQube server. 

The task need to be executed following the flow: 
* `SonarQubePrepare`: Prepare the SonarQube analysis. [[SonarQubePrepare]]
* Build the application. 
* `SonarQubeAnalyze`: Execute the analysis. 
* `SonarQubePublish`: Publish Quality Gate Result. [[SonarQubePublish]]

Basic syntax of the task: 

```yaml
- task: SonarQubeAnalyze@7
  inputs:
    jdkversion: 'JAVA_HOME_17_X64'
```

| Parameter      | Type                                          | Required | Default              | Description                                          |
| ---------------- | ----------------------------------------------- | --------- | ----------------------- | --------------------------------------------------------- |
| `jdkversion`    | <span style="color:DodgerBlue">string</span>  | No        | `JAVA_HOME`             | Java Runtime the analysis uses. See allowed values below. |

`jdkversion` allowed values:
* `JAVA_HOME`: uses the agent's `JAVA_HOME` environmental variable that define the installed Java. 
* `JAVA_HOME_17_X64`: uses the built-in Java 17 runtime on hosted agents. 
* `JAVA_HOME_21_X64`: uses the built-in Java 21 runtime on hosted agents. 

This task doesn't require so much configuration, as the project metadata and connection details has been declared in the prepare step. 
