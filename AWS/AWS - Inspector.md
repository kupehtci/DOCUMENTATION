#AWS 

# AWS - Inspector

**Amazon Inspector** is a security assessment and vulnerability management service in charge of securing AWS Workloads like EC2 instances, containers and Lambda functions. 

It scans resources for: 
* Known Software Vulnerabilities or CVEs
* Network exposure risks: 
	* Open ports
	* Risky public IPs
	* Misconfiguration or outdated packages. 

# How it works? 

* **Automatic Discovery**: automatically detects elegible resources like: 
	* Amazon EC2 instances
	* Amazon ECR images
	* AWS Lambda functions
* **Vulnerability scanning**: 
	* For EC2 scans installed OS and packagaes
	* For ECR scans container images for vulnerabilities before deployment. 
	* 