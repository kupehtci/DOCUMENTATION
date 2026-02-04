#AZURE_DEVOPS 

# Azure DevOps - API REST - Get Project Properties

To get a collection of project properties, you can do a GET request to: 

```txt 
https://dev.azure.com/{{ORGANIZATION}}/_apis/projects/{{PROJECT_ID}}/properties?api-version=7.1-preview.1
```

> Note!: Requires project ID, not valid with Project Name. 

Returns a set of properties like: 

```json
{
    "count": 13,
    "value": [
        {
            "name": "System.CurrentProcessTemplateId",
            "value": "ee0d5583-bce8-4a3e-ab0f-edf091dc7859"
        },
        {
            "name": "System.OriginalProcessTemplateId",
            "value": "ee0d5583-bce2-4a3e-aa0f-edf091dc7859"
        },
        {
            "name": "System.ProcessTemplateType",
            "value": "b8afa935-7e91-48b8-a94c-606d37c3e9f2"
        },
        {
            "name": "System.MSPROJ",
            "value": ""
        },
        {
            "name": "System.Process Template",
            "value": "Scrum"
        },
        {
            "name": "System.Microsoft.TeamFoundation.Team.Count",
            "value": 1
        },
        {
            "name": "System.Microsoft.TeamFoundation.Team.Default",
            "value": "4306d650-accf-467b-baf0-f45fe725d8a1"
        },
        {
            "name": "System.SourceControlCapabilityFlags",
            "value": "2"
        },
        {
            "name": "System.SourceControlGitEnabled",
            "value": "True"
        },
        {
            "name": "System.SourceControlGitPermissionsInitialized",
            "value": "True"
        },
        {
            "name": "System.Wiki.69d652c9-2caf-4f2f-afb5-b5bead4263df",
            "value": ""
        },
        {
            "name": "Microsoft.TeamFoundation.Project.Tag.estado:activo",
            "value": "true"
        },
        {
            "name": "Microsoft.TeamFoundation.Project.Tag.tec:javascript",
            "value": "true"
        }
    ]
}
```

This set includes: 
* Wiki properties
* Tags assigned to the project. 
* If Git is enabled as the source control protocol. 



