#Trivy

# Trivy

**Trivy** is an open-source security scanner that can be used to detect common vulnerabilities and misconfigurations in filesystems ("Plain applications"), container images, code repositories and cloud infrastructure. 

Trivi focuses in detecting CVEs ([[CVEs Common Vulnerabilities and Exposures]]) in OS packages and application dependencies in addition to exposed secrets exposure and insecure configurations. 

Trivy can scan: 
* container images (Docker, PodMan and registries)
* filesystem: local path of the application for vulnerable packages and libraries
* git repositories
* VM images 
* Kubernetes Clusters [^1]
* Cloud IaC configurations like: 
	* Terraform [^2]
	* CloudFormation [^4]
* Dockerfiles [^3]
* OS packages from linux, windows and macos

Trivy is used as an a CLI tool that can be installed and used directly in local [[Trivy - Install]] that can also be implemented as a pipeline task for Github Actions[^5] or Azure DevOps pipelines[^6]


[^1]: Kubernetes cluster [[KUBERNETES - Basics]]
[^2]: Terraform is an IaC language for provisioning infrastructure [[Terraform]]
[^3]: Dockerfiles are files that define how a docker image is built [[Dockerfile]] 
[^4]: Cloudformation [[AWS - CloudFormation]]
[^5]: Github Actions are automations that can be defined to perform CI/CD workflows with github 
[^6]: Azure DevOps pipelines allow to automate CI/CD workflows and integrations with other services directly from the Azure DevOps
