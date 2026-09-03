#AZURE_DEVOPS 

**PublishPipelineArtifact** task allows to publish (Upload) a file or directory as a pipeline artifact with name so other jobs or stages can download it afterwards. 

Its also available from the pipeline in the Azure DevOps web. 


Basic syntax of the task: 

```YAML
- task: PublishPipelineArtifact@1
  inputs:
    targetPath: '$(Pipeline.Workspace)' # string. Alias: path. Required. File or directory path. Default: $(Pipeline.Workspace).
    #artifact: # string. Alias: artifactName. Artifact name. 
    publishLocation: 'pipeline' # 'pipeline' | 'filepath'. Alias: artifactType. Required. Artifact publish location. Default: pipeline.
    #fileSharePath: # string. Required when publishLocation = filepath. File share path. 
    #parallel: false # boolean. Optional. Use when publishLocation = filepath. Parallel copy. Default: false.
    #parallelCount: '8' # string. Optional. Use when publishLocation = filepath && parallel = true. Parallel count. Default: 8.
    #properties: # string. Custom properties.
```

| Parameter          | Type                                          | Required    | Default                    | Description                                                                                       |
| -------------------- | ----------------------------------------------- | ------------ | ---------------------------- | --------------------------------------------------------------------------------------------------- |
| `targetPath`        | <span style="color:DodgerBlue">string</span>  | Yes          | `$(Pipeline.Workspace)`      | File or directory path to publish.                                                                 |
| `artifact`          | <span style="color:DodgerBlue">string</span>  | No           | -                            | Name of the artifact. Cannot contain `\`, `/`, `"`, `:`, `<`, `>`, `\|`, `*` or `?`.                |
| `publishLocation`   | <span style="color:DodgerBlue">string</span>  | Yes          | `pipeline`                   | Artifact publish location: `pipeline` (publish to the pipeline) or `filepath` (a file share).      |
| `fileSharePath`     | <span style="color:DodgerBlue">string</span>  | Conditional  | -                            | File share path. Required when `publishLocation: filepath`.                                        |
| `parallel`          | <span style="color:red">boolean</span>        | No           | `false`                      | Parallel copy. Used when `publishLocation: filepath`.                                              |
| `parallelCount`     | <span style="color:DodgerBlue">string</span>  | No           | `8`                          | Parallel count. Used when `publishLocation: filepath` && `parallel: true`.                         |
| `properties`        | <span style="color:DodgerBlue">string</span>  | No           | -                            | Custom properties.                                                                                  |
