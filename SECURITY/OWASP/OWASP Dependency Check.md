#SECURITY 

# OWASP Dependency Check

**OWASP** dependency check is an open source SCA ([[SCA Software Composition Analysis]]) tool that scans the dependencies of a project to detect known CVEs
([[CVEs Common Vulnerabilities and Exposures]]). 

The operating workflow is: 
1. Identifies third party libraries and frameworks used in the project. 
2. Tries to map each dependency to a Common Platform Enumeration (CPE) and then to CVEs extracted from sources like NVD (National Vulnerability Database). 
3. Generates a report in HTML, XML or JSON format for listing vulnerable components indicating the CVE details and the severity. 

The severity of the CVEs identified allows you to prioritize fixes.    

## CLI

OWASP dependency-check-cli is a command line tool that uses OWASP dependency check to detect the vulnerabilities associated with the scanned project dependencies. This tool generates a report listing the dependencies, the CPEs identified and the CVE entries declared for that dependencies. 

To install the tool in MacOS: 
```bash
brew install dependency-check

dependency-check --version
```

For windows, download the binaries from [GitHub Release](https://github.com/dependency-check/DependencyCheck/releases/download/v12.2.0/dependency-check-12.2.0-release.zip) and: 
```powershell
# windows
dependency-check.bat --project "My App Name" --scan "c:\java\application\lib"
```

You can check the CLI arguments that can be passed into the binary in [dependency-check-cli configuration](https://dependency-check.github.io/DependencyCheck/dependency-check-cli/arguments.html). 

### CLI Arguments

The most common arguments are: 
* `--project`: the name of the project to be scanned. 
* `--scan`: Path to the project to scan
* `--exclude`: patterns of files to exclude from the analysis. 
* `--out`: the path to write reports into. 
* `--format`: format of the output reports. Multiple options can be selected spanning the parameter multiple times or concatenating the values with `,`. Valid options are: 
	* `HTML`
	* `CSV`
	* `JSON`
	* `XML`
	* `JUNIT`
	* `SARIF`
	* `JENKINS`
	* `GITLAB`
	* `ALL`
* `--failOnCVSS`: set a maximum score between 0 and 10 so if a CVSS score of one of the CVEs identified have a value equal or superior, it will throw an error. 
* `--nvdApiKey`: API Key created in NVD API, for a privileged access to the [[NVD Database]]. 
* `--prettyPrint`: the XML and JSON reports will be pretty printed. 
* `--log`: file path to write the verbose logs of the analysis. 
* `--noupdate`: avoid updating the NVD database cache. 
* `--version`: prints the installed version of the CLI tool. 

For Node / NPM projects analysis: 
* `--disableYarnAudit`: disable the yarn analysis. By default, dependency check will trigger yarn analysis for projects that are Javascript like. 
* 


## Azure DevOps task

[[Azure DevOps]] has a marketplace plugin that includes an `dependency-check-build-task` task that automatically installs and maintains the dependency check tool and executes an analysis. 

Example of the task: 
```yaml
    - task: dependency-check-build-task@6
      inputs:
        projectName: ${{ parameters.ProyectoSonar }}
        scanPath: $(Build.SourcesDirectory)
        format: 'ALL' # Generate ALL formats (XML, HTML, JSON and CYCLONEDX) # 'HTML,JSON,XML'
        failOnCVSS: '7'
        # Set the NVD API Key, disable YARN analysis and disable Dev Dependencies analysis
        additionalArguments: '--nvdApiKey df6ea732-f6bd-4379-8a15-8b9781d71113 	--disableYarnAudit nodeAuditSkipDevDependencies'
        # Guardar reportes en el workspace del build para que SonarQube pueda acceder
      displayName: '[OWASP Dependency Check] - SCA Analisis'
      continueOnError: true
```




