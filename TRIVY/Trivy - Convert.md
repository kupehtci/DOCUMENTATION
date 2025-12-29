#Trivy 

# Trivy - Convert

Trivy generates as output of the analysis a report in JSON format by default. If the report needs to be converted into other formats like HTML or JUnit you can use `trivy convert` command using the format: 

```bash
trivy convert [FLAGS] /path/to/trivy-scan.json

trivy --format [table|json|template|sarif|cyclonedx|spdx|github|cosign-vuln]
--output [file.ext]
--template [indicate template]
--severity [UNKNOWN, LOW, MEDIUM, HIGH, CRITICAL][Severities to show]
```

Its very common to do a single scan with a JSON output and then convert into other formats using this command. 


## Templates

You can use custom or default templates for fulfilling the convert output: 

```bash
# Using a template
trivy convert --format template \ 
--template "@html.tpm"
--output result.html 
```

You can download the raw templates from: 
* HTML: https://raw.githubusercontent.com/aquasecurity/trivy/main/contrib/html.tpl
* JUnit: https://raw.githubusercontent.com/aquasecurity/trivy/main/contrib/junit.tpl