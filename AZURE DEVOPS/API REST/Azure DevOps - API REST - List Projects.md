#AZURE_DEVOPS 

# Azure DevOps - API REST - List projects

You can List the available projects in an Azure DevOps organization using the API REST. 

To do so, send a GET request to the following path with the corresponding "Basic" authentication: 
```txt 
https://dev.azure.com/{{ORGANIZATION}}/_apis/projects
```

You will get a list of projects with the following format: 

```json 
{
    "count": 2,
    "value": [
        {
            "id": "35f9b1e4-38ac-456e-b2a7-d242074295da",
            "name": "ASD",
            "description": "Application for...",
            "url": "https://dev.azure.com/{organization}/_apis/projects/35f9b1e4-38ac-456e-b2a7-d242074295da",
            "state": "wellFormed",
            "revision": 990,
            "visibility": "private",
            "lastUpdateTime": "2025-07-08T10:45:48.003Z"
        },
        {
            "id": "c21a2c4f-eff8-402e-b0e4-8f657c459f8f",
            "name": "EXAMPLE_PROJECT",
            "description": "Proyecto de prueba para aplicaciones Node que funcionen con el lenguaje Typescript.",
            "url": "https://dev.azure.com/{organization}/_apis/projects/c21a2c4f-eff8-402e-b0e4-8f657c459f8f",
            "state": "wellFormed",
            "revision": 839,
            "visibility": "private",
            "lastUpdateTime": "2025-02-11T15:25:15.767Z"
        }
	]
}
```

