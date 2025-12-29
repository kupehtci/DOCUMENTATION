#SECURITY 

# SBOM - Software Bill of Materials

An SBOM or Software Bill of Materials is a structured list of all the components that compose a information system or software piece (libraries, framework, dependencies and others) with detailed information like version. 

Its normally used for security, compliance and operational reasons. 

SBOM is normally a machine readable inventory in JSON or XML format that enumerates all the components including all the direct and transitive dependencies.

Its useful for: 
* **Security purposes**: when a new CVE appears [[CVEs Common Vulnerabilities and Exposures]] an SBOM lets you to quickly see the application vulnerable components and where are installed. 
* **Compliance and licenses**: SBOM allows to track open source licenses and obligations to reduce the legal risk of using third-party code. 
* **Supply chain visibility**: shows a transparent view of the underlying components of an application. 

The SBOM normally contains: 
* Component identifiers like name, package reference, URL, supplier, ...
* Dependency relationships when the component depends on others. 
* License information and in case they are exposed, know vulnerabilities references indicating the CVE ID [^1]

Its generation is normally automated using SCA[^2] / SBOM tools like Trivy ([[Trivy]]) in SPDX or CycloneDX formats. 



[^1]: CVE ID or Common Vulnerability ID is the unique identifier, given by a CVE Numbering Authorities to a cybersecurity vulnerability [[CVEs Common Vulnerabilities and Exposures]]. 
[^2]: SCA or Software Composition Analysis is a type of scan that analyzes all the open-source and third party components of an application in search of vulnerabilities. [[SCA Software Composition Analysis]]

