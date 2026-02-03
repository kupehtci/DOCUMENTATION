#SECURITY 

# OWASP Dependency Check Output

OWASP Dependency Check generates a detailed report that contains the known vulnerabilities (CVEs) in the project dependencies. 

The output reports can be in multiple formats: 
* **HTML**[^1]: user friendly web based report with interactive elements. 
* **XML**[^2]: structured data most commonly used. 
* **JSON**[^3]: structured data 
* **CSV**: Tabular format for an spreadsheet. 
* **ALL**: Generates the report in all available formats in a single execution. 

The report contains: 

* Vulnerable dependencies: list of third party libraries with identifies security issues. 
* CVE[^5] identifiers from the NVD[^6] database. 
	* Severity levels indicating the criticality of each vulnerability detected. 
* Evidence of each dependency, indicating name, version, file paths and other evidences of the detection of the dependency. 

In JSON format, the report looks like: 

```json
{  
    "reportSchema": "1.1",  
    "scanInfo": {  
        "engineVersion": "12.2.0",  
        "dataSource": [  
{  
                "name": "NVD API Last Checked",  
                "timestamp": "2026-01-30T11:14:02+01"  
            }  
,{  
                "name": "NVD API Last Modified",  
                "timestamp": "2026-01-30T09:15:51Z"  
            }  
        ]  
  
  
    },  
    "projectInfo": {  
        "name": "{{PROJECT_NAME}}",  
        "reportDate": "2026-01-30T10:52:43.494963600Z",  
        "credits": {  
            "NVD": "This product uses the NVD API but is not endorsed or certified by the NVD. This report contains data retrieved from the National Vulnerability Database: https://nvd.nist.gov",  
            "CISA": "This report may contain data retrieved from the CISA Known Exploited Vulnerability Catalog: https://www.cisa.gov/known-exploited-vulnerabilities-catalog",  
            "NPM": "This report may contain data retrieved from the Github Advisory Database (via NPM Audit API): https://github.com/advisories/",  
            "RETIREJS": "This report may contain data retrieved from the RetireJS community: https://retirejs.github.io/retire.js/",  
            "OSSINDEX": "This report may contain data retrieved from the Sonatype OSS Index: https://ossindex.sonatype.org"  
        }  
    },  
   "dependencies": [
    {
      "isVirtual": false,
      "fileName": "Newtonsoft.Json.13.0.1.nupkg",
      "filePath": "/packages/Newtonsoft.Json.13.0.1/",
      "md5": "abc123...",
      "sha1": "def456...",
      "sha256": "ghi789...",
      "description": "Json.NET is a popular high-performance JSON framework for .NET",
      "license": "MIT",
      "packages": [
        {
          "id": "pkg:nuget/Newtonsoft.Json@13.0.1",
          "confidence": "HIGHEST",
          "url": "https://www.nuget.org/packages/Newtonsoft.Json/13.0.1"
        }
      ],
      "vulnerabilityIds": [
        {
          "id": "CVE-2024-21907",
          "confidence": "HIGHEST"
        }
      ],
      "vulnerabilities": [
        {
          "source": "NVD",
          "name": "CVE-2024-21907",
          "severity": "HIGH",
          "cvssv2": {
            "score": 7.5,
            "accessVector": "NETWORK",
            "accessComplexity": "LOW",
            "authentication": "NONE",
            "confidentialityImpact": "PARTIAL",
            "integrityImpact": "PARTIAL",
            "availabilityImpact": "PARTIAL",
            "severity": "HIGH"
          },
          "cvssv3": {
            "baseScore": 7.5,
            "attackVector": "NETWORK",
            "attackComplexity": "LOW",
            "privilegesRequired": "NONE",
            "userInteraction": "NONE",
            "scope": "UNCHANGED",
            "confidentialityImpact": "HIGH",
            "integrityImpact": "NONE",
            "availabilityImpact": "NONE",
            "baseSeverity": "HIGH",
            "exploitabilityScore": 3.9,
            "impactScore": 3.6,
            "version": "3.1"
          },
          "cwes": [
            "CWE-502"
          ],
          "description": "Newtonsoft.Json before 13.0.3 allows attackers to cause a denial of service...",
          "notes": "",
          "references": [
            {
              "source": "https://nvd.nist.gov/vuln/detail/CVE-2024-21907",
              "name": "NVD Entry"
            },
            {
              "source": "https://github.com/JamesNK/Newtonsoft.Json/security/advisories/GHSA-5crp-9r3c-p9vr",
              "name": "GitHub Advisory"
            }
          ],
          "vulnerableSoftware": [
            {
              "software": {
                "id": "cpe:2.3:a:newtonsoft:json.net:*:*:*:*:*:*:*:*",
                "vulnerabilityIdMatched": "true",
                "versionEndIncluding": "13.0.2"
              }
            }
          ]
        }
      ],
      "relatedDependencies": [
        {
          "filePath": "D:\\agent\\_work\\315\\s\\MyProject\\MyProject.csproj",
          "sha256": "xyz123...",
          "sha1": "uvw456...",
          "md5": "rst789..."
        }
      ]
    },
    {
      "isVirtual": false,
      "fileName": "System.Text.Json.7.0.0.nupkg",
      "filePath": "/packages/System.Text.Json.7.0.0/",
      "md5": "aaa111...",
      "sha1": "bbb222...",
      "sha256": "ccc333...",
      "description": "Provides high-performance and low-allocating types...",
      "license": "MIT",
      "packages": [
        {
          "id": "pkg:nuget/System.Text.Json@7.0.0",
          "confidence": "HIGHEST",
          "url": "https://www.nuget.org/packages/System.Text.Json/7.0.0"
        }
      ],
      "vulnerabilities": []
    }
  ]
}
```

With the format: 
* `projectInfo`: 
	* `name`: project name. 
	* `reportDate`: ISO timestamp when the report was generated. 
	* `reportSchema`: schema version of the report format. 
	* `credits`: list of the external data sources used for the CVEs list. 
* `dependencies`: array of detected dependencies. 


Each dependency object contains detailed information about the dependency and if has vulnerabilities matching with NVD or other sources, indicates them: 
* `isVirtual`: whether is not a physical file on disk (A ephemeral package like NuGet or NPM) is `true` and `false` for real files. 
* `fileName`: 
* `filePath`: 
* `description`: 
* `license`: 
* `packages`: List of packages that compose the dependency with: 
	* `id`: NuGet or other package manager dependency identifier. 
	* `confidence`: indicates how sure the engine is about the identity of the detected package. x
* `relatedDependencies`: links to another dependencies in other projects.
* `vulnerabilityIds`: List of candidate CPE identifiers linked to this dependency. example `cpe:2.3:a:hangfire:hangfire:1.8.16:*:*:*:*:*:*:*` that identifies the name of the software product, vendor and the version. 
* `vulnerabilities`: List of CVE findings that matches with the vulnerability IDs inferred. If have no vulnerabilities, this field is empty or not present. 
* `evidenceCollected`: evidence that the engine used for inferring the CPE information: 
	* `productEvidence`: list of evidences for the product name. 
	* `vendorEvidence`: list of evidences used for detecting the vendor. 
	* `versionEvidence`: list of evidences used for detecting the version. 

Each evidence item has: 
* `source`: where it came from, that can be `msbuild`, `file`, `pom` or other compilers or sources. 
* `name`: name of the key or field founded in that source. 
* `type`: meaning. 
* `value`: identifies value like the name of the dependency, that matches with the evidenced dependency. 

Each vulnerability in the `vulnerabilities` list contains: 
* `name`: CVE identifier like for example `CVE-2017-10989`
* `description`: human readable description of the issue, impact and the guide or solving it. 
* `notes`: optional extra notes and comments. 
* `cvssv2` and `cvssv3`: indicates the CVSS ([[CVSS Common Vulnerability Scoring System]]) associated with the CVE. 
* `cwes`: list of CWE identifiers describing the weakness type like for example `CWE-125`. 
* `references`: external links to urls that describe the vulnerability. 
* `severity`: a severity label that can be `LOW`, `MEDIUM`, `HIGH` or `CRITICAL`. 
* `source`: the vulnerability database where the CVE is declared. 
* `vulnerableSoftware`: Indicates the ID of the software and the versions that are affected by the vulnerability. 



[^1]: HTML format [[HTML]]
[^2]: XML format [[XML - BASICS]]
[^3]: JSON format [[JSON vs XML]]
[^4]: CSV or Comma Separated Value spreadsheets [[CSV - Comma Separated Values]]
[^5]: CVE or Common Vulnerabilities and Exposures [[[CVEs Common Vulnerabilities and Exposures]]
[^6]: NVD Database [[NVD Database]]
[^7]: CPE are common identifiers that are standardized for component or software products. [[CPE - Common Platform Enumeration]]. 