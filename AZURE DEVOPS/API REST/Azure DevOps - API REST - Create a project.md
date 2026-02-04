#AZURE_DEVOPS 

You can use the API REST to create a project under the organization, using a POST request over: 
```txt 
https://dev.azure.com/{{ORGANIZATION}}/_apis/projects?api-version=7.1
```

And in the body of the request, indicate a JSON with the properties of the newly created project: 

```json
{
  "name": "NameOfProject",
  "description": "Description of the project",
  "capabilities": {
    "versioncontrol": {
      "sourceControlType": "Git"
    },
    "processTemplate": {
      "templateTypeId": "id (Optional)"
    }
  }
}
```


The responde if has been correctly created will be a `queued` response: 

```txt
{
  "id": "id-of-the-created-project",
  "status": "queued",
  "url": "https://dev.azure.com/url/of/the/operation"
}
```

The URL returned is the URL to the creation operation that has been queued. 