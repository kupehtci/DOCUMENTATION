#SECURITY 

# OWASP Dependency Check

**OWASP** dependency check is an open source SCA ([[SCA Software Composition Analysis]]) tool that scans the dependencies of a project to detect known CVEs
([[CVEs Common Vulnerabilities and Exposures]]). 

The operating workflow is: 
1. Identifies third party libraries and frameworks used in the project. 
2. Tries to map each dependency to a Common Platform Enumeration (CPE) and then to CVEs extracted from sources like NVD (National Vulnerability Database). 
3. Generates a report in HTML, XML or JSON format for listing vulnerable components indicating the CVE details and the severity. 

The severity of the CVEs identified allows you to prioritize fixes.                



