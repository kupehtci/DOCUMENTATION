#SONARQUBE 

# SonarQube - CI/CD Parameters

Some parameters needs to be settled and configured in CI/CD host that analyzes the source code and publish the analysis into the SonarQube server. 

Mandatory parameters: 
* `sonar.token`: token used by the scanner to authenticate to the SonarQube server. Can be authenticated using a SonarQube Service Connection. 
* `sonar.host.url`: url of the SonarQube server. This parameter is mandatory if have not been defined in a Service Connection. 
* `sonar.projectKey`: Project's unique name that identifies the project in SonarQube. 

Optional parameters: 
* `sonar.projectName`: Name of the project that will be displayed on the SonarQube web. If its set in the web, it will be displayed and cannot be changed. 
* `sonar.projectVersion`: version of the project that need to be set if using branch analysis. 
	* In case that you want to use the new code definition based on the previous version. (New code will be the difference between new version and previous)
* `sonar.projectDescription`: Description of the project. 
	* This parameter is not supported in `dotnet`

Logging: 
* `sonar.verbose`: true | false. Indicates that debug verbosity is enabled so logs are more verbose. Enables the `sonar.log.level` as `DEBUG`. 
* `sonar.log.level`: Controls the quantity and contents of the logs produced during an analysis. Can be `INFO`, `DEBUG` or `TRACE` (Includes DEBUG and additional logs from plugins)

* `sonar.sources`: The scope for the main source code analysis. This path can be relative to `sonar.projectBaseDir` or absolute. 
* `sonar.projectBaseDir`: base directory of the project to analyze. By default is the path from where the analysis has been executed. 

Branching of the project: 
* `sonar.branch.name`: name of the branch that sonarqube scanner analyzes. 
* `sonar.pullrequest.key`: Unique identifier of the pull request. Must be the same ID that identifies the Pull Request in the DevOps platform. 
* `sonar.pullrequest.branch`: Branch that contains the changes to be merged.
* `sonar.pullrequest.base`: Branch to where the pull request will be merged to. 
	* Default is `main` branch. 

OWASP Dependency Check plugin ([[OWASP Dependency Check plugin]], [[SonarQube - Dependency Check]]): 
* `sonar.dependencyCheck.jsonReportPath`: path to the JSON report generated with OWASP Dependency check for the dependency-check plugin. 
* `sonar.dependencyCheck.reportPathpath`: path to the XML report generated with OWASP Dependency check for the dependency-check plugin. 
* `sonar.dependencyCheck.htmlReportPath`: pathto the HTML report generated with OWASP Dependency check for the dependency-check plugin. 