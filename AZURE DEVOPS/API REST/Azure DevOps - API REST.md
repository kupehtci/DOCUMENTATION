#AZURE_DEVOPS 

# Azure DevOps - API REST

Azure DevOps API REST is a set of HTTP endpoints that allow to access and manage resources in Azure DevOps such as: 

* Work items
* GIT repositories
* CI / CD pipelines
* Builds
* Releases
* Artifacts
* Permisions

The authentication is done using the PAT or Personal Access Token from the user that can be generated using Azure DevOps UI. 

A basic example of the API: 
```txt
curl -u :{PAT} \ https://dev.azure.com/{organization}/_apis/projects?api-version=7.2-preview
```

