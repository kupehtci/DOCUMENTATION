#SONARQUBE 

# SonarQube

**SonarQube** is an automated platform for analyzing source code to track the quality state of the code and find bugs, security breaches and other issues. 

It detects: 
* Bugs
* Vulnerabilities
* Code Smells
* Duplicated code. 
* Excesive complexity. 

The rules for detecting this elements can be customized. 

## Infrastructure

SonarQube maintains a central server the stores and allows to browse the code analysis of different development projects. 
The analysis is normally integrated into CI/CD pipelines like Azure DevOps, GitHub actions or GitLab, in order to analyze every push of code. 

## Key features 

All of this rules and security measurements are prompted into dashboards that indicate: 
* Coverage (Percentaje of quality)
	* Estimated technical debt: (Time in 8h workdays to solve all the issues of the code)
* Complexity
* Code smells, duplications, reliability and others. 

All of this metrics can define a **quality gate**. This define the necessary metrics to <span style="color:green">pass</span> or <span style="color:red;">fail</span>, and for example block a merge request if the quality gate is not met. 


## Editions

SonarQube is available in various editions: 
* Self-hosted:
	* with open-source code (Community version)
	* Commercial edition (Additional rules and governance features)
* SonarCloud: fully managed SaaS service of SonarQube. 

