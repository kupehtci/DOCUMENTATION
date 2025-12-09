#AZURE_DEVOPS #DEVOPS #SONARQUBE

# SonarQube integration in Azure DevOps

SonarQube can be integrated in Azure DevOps in order to integrate the code analysis for quality assurance and security in the repositories. 

With this integration, you can: 
* Import the Azure DevOs repositories into a SonarQube server. 
* Integrate SonarQube analysis into azure build pipeline with the Azure DevOps extension installed in SonarQube. 
* Report the analysis' Quality gate into the Azure Pipeline Build Summary page: 
	* Allows to check the quality gate pass/fail status directly in Azure DevOps' pipeline page. 


The extension can be set in one of the following modes that need to be chosen depending on the project tipology: 

* .NET: for .Net projects
* Maven or Gradle

# .Net 

For a .Net project, you can configure the SonarQube integration as follows: 

```yaml
parameters: 
	- name: SonarProyect
	  type: string
	  
	- name: ProjectPath
	  type: string

# Prepare the SonarQube analysis before the compilation
- task: SonarQubePrepare@7  
  displayName: 'Preparación de análisis SonarQube'  
  inputs:  
    SonarQube: 'Sonarqube'  
    scannerMode: 'dotnet'  
    projectKey: '${{ parameters.ProyectoSonar }}'  
    projectName: '${{ parameters.ProyectoSonar }}'
    
# COMPILATION
# Compile the project
# ...

# Analysis of the compilation    
- task: SonarQubeAnalyze@7  
  displayName: '[SonarQube] Análisis'  
  inputs:  
    jdkversion: 'JAVA_HOME'
```

# Maven (JAVA)

For a Java project, it requires to have the following plugin installed and referenced in `pom.xml`: 

```xml
<plugin>
	  <groupId>org.sonarsource.scanner.maven</groupId>
	  <artifactId>sonar-maven-plugin</artifactId>
	  <version>5.1.0.4751</version>
</plugin>
```

Also, some properties need to be set to configure the SonarQube Analysis: 

* `sonar.sources`: indicate the source files folder for analysis. 
* `sonar.tests`: indicate the test files for analysis. 

For running the SonarQube preparation task for java, set as follows: 
```yaml
parameters: 
	- name: SonarProyect
	  type: string
	  
	- name: ProjectPath
	  type: string

steps: 
  - task: SonarQubePrepare@7
	displayName: 'Prepare SonarQube Analysis'
	inputs:
	  SonarQube: 'SonarQube Service Connection' 
	  scannerMode: 'Other' 
	  configMode: 'manual'
	  projectKey: '${{ parameters.SonarProyect }}'
	  projectName: '${{ parameters.SonarProyect }}'
	  extraProperties: |
		sonar.projectBaseDir=${{ proyecto.ProjectPath }}
		sonar.sources=src/main/java
		sonar.java.binaries=target/classes
```

With:
* `task.inputs.SonarQube`: name of the Service Connection settled for SonarQube
* `task.inputs.scannerMode`: Set mode as 'Other' for Java projects.
* `task.inputs.projectKey`: indicate the name of the Project within SonarQube server
* `task.inputs.projectName`: indicate the name of the Project within SonarQube server
* `task.inputs.extraProperties`: used for setting SonarQube related variables: 
	* `sonar.projectBaseDir`: indicate the path of the project within the repository.
	* `sonar.sources`: indicate the path of the source files inside the `projectBaseDir`, by default `src/main/java`.
	* `sonar.java.binaries`: comma separated list of directories for searching binaries within the project. 

## Skip the SonarQube analysis

You can skip the SonarQube analysis of the pipeline for a certain Java module by using `<sonar.skip>true</sonar.skip>` in the `pom.xml` of the module you want to exclude. 

---

# SonarQube publishing

Once a SonarQube analysis has been completed, you can publish the results of the quality gate into the Azure DevOps pipeline, by using the following task: 

```yaml
- task: SonarQubePublish@7  
  displayName: 'Publicar resultados SonarQube'  
  inputs:  
    pollingTimeoutSec: '300'
```

