#SONARQUBE 

# SonarQube Scanner Configuration

SonarQube scanner behavior can be configured using a `sonar-project.properties` file defining all the properties that the project has to be analyzed with SonarQube. 

## `sonar-project.properties` Configuration file

This file is placed in the root of the project (Same level as .git for example). 
Its a raw text file with a `key=value` format (one per line) with comments using `#` that defines all the configuration of the scanner. 


## Configurations

This is a table with the most common configurations that can be defined in `sonar-project.properties` file: 

| Property               | Description                                    | Example                  |
| ---------------------- | ---------------------------------------------- | ------------------------ |
| `sonar.projectKey`     | Unique identifier for the project in SonarQube | `mi-empresa:mi-proyecto` |
| `sonar.projectName`    | Name shown in the SonarQube UI.                | `Mi App`                 |
| `sonar.projectVersion` | Versión of the project                         | `1.2.3`                  |
| `sonar.projectBaseDir` | Root of the project.                           | `.` o `/app`             |


## Azure DevOps SonarQubePrepare task

In Azure DevOps this configuration can be injected to the `SonarQubePrepare` task using the file in the project or directly by the `extraProperties` task' variable. 

