#Trivy 

# Trivy - Databases

Trivy uses its own vulnerability and checks databases that are kept updated with vulnerabilities information, mapping and checks that the application should perform on a scan. 

It uses three databases: 
* Vulnerabilities DB (`trivy-db`)
* Java DB (`trivy-java-db`)
* Checks bundle (`trivy-checks`)

Trivy relay on a CVE database that consist in a public catalog of known CVEs ([[CVEs Common Vulnerabilities and Exposures]]) where each vulnerability is labeled with an unique CVE ID. 

**Java DB** is used to map Java artifacts and **Checks bundle** is a set of common IaC and misconfiguration rules to check over the code. 

Trivy databases are composed in its own format (Vuln list) and can be retrieved from the following repositories: 

|Registry|Image Address|Link|
|---|---|---|
|GHCR|`ghcr.io/aquasecurity/trivy-db`|[https://ghcr.io/aquasecurity/trivy-db](https://ghcr.io/aquasecurity/trivy-db)|
||`ghcr.io/aquasecurity/trivy-java-db`|[https://ghcr.io/aquasecurity/trivy-java-db](https://ghcr.io/aquasecurity/trivy-java-db)|
||`ghcr.io/aquasecurity/trivy-checks`|[https://ghcr.io/aquasecurity/trivy-checks](https://ghcr.io/aquasecurity/trivy-checks)|
|Docker Hub|`aquasec/trivy-db`|[https://hub.docker.com/r/aquasec/trivy-db](https://hub.docker.com/r/aquasec/trivy-db)|
||`aquasec/trivy-java-db`|[https://hub.docker.com/r/aquasec/trivy-java-db](https://hub.docker.com/r/aquasec/trivy-java-db)|
||`aquasec/trivy-checks`|[https://hub.docker.com/r/aquasec/trivy-checks](https://hub.docker.com/r/aquasec/trivy-checks)|
|AWS ECR|`public.ecr.aws/aquasecurity/trivy-db`|[https://gallery.ecr.aws/aquasecurity/trivy-db](https://gallery.ecr.aws/aquasecurity/trivy-db)|
||`public.ecr.aws/aquasecurity/trivy-java-db`|[https://gallery.ecr.aws/aquasecurity/trivy-java-db](https://gallery.ecr.aws/aquasecurity/trivy-java-db)|
||`public.ecr.aws/aquasecurity/trivy-checks`|[https://gallery.ecr.aws/aquasecurity/trivy-checks](https://gallery.ecr.aws/aquasecurity/trivy-checks)|
By default: `mirror.gcr.io/aquasec`
## How to set DB

You can set the different db used in the command: 

```bash
trivy [command] \
  "$target" \
  --db-repository aquasec/trivy-db \  
  --java-db-repository aquasec/trivy-java-db \
  --checks-bundle-repository aquasec/trivy-checks \
```


You can force only a DB download using: 
```bash
trivy image --download-db-only
```

And even remove the cached databases: 
```bash
# Remove all databases
trivy clean --all

# Remove checks bundle database
trivy clean --checks-bundle

# Remove java artifacts database
trivy clean --java-db

# Remove vulnerabilities database
trivy clean --vuln-db
```