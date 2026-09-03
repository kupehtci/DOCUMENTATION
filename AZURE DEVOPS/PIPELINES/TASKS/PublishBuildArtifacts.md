#AZURE_DEVOPS 

# PublishBuildArtifacts

`PublishBuildArtifacts` is an Azure DevOps task that publishes build artifacts to Azure Pipelines, TFS or a file share. 


<span style="border: 1px solid red; border-radius: 10%; padding: 1rem; margin: 1rem; ">
Warning: This task is deprecated with PublishPipelineArtifacts. 
</span>


Basic syntax of the task: 


```yaml
- task: PublishBuildArtifacts@1
  inputs:
    PathtoPublish: '$(Build.ArtifactStagingDirectory)' # string. Required. Path to publish. Default: $(Build.ArtifactStagingDirectory).
    ArtifactName: 'drop' # string. Required. Artifact name. Default: drop.
    publishLocation: 'Container' # 'Container' | 'FilePath'. Alias: ArtifactType. Required. Artifact publish location. Default: Container.
    #MaxArtifactSize: '0' # string. Max Artifact Size. Default: 0.
    #TargetPath: # string. Required when ArtifactType = FilePath. File share path. 
    #Parallel: false # boolean. Optional. Use when ArtifactType = FilePath. Parallel copy. Default: false.
    #ParallelCount: '8' # string. Optional. Use when ArtifactType = FilePath && Parallel = true. Parallel count. Default: 8.
  # Advanced
    #StoreAsTar: false # boolean. Tar the artifact before uploading. Default: false.
```

| Parameter          | Type                                          | Required    | Default                            | Description                                                                                                          |
| -------------------- | ----------------------------------------------- | ------------ | ------------------------------------- | ------------------------------------------------------------------------------------------------------------------- |
| `PathtoPublish`     | <span style="color:DodgerBlue">string</span>  | Yes          | `$(Build.ArtifactStagingDirectory)`   | Folder or file path to publish. Its recommended to store the artifacts to publish in the `ArtifactStagingDirectory`. |
| `ArtifactName`      | <span style="color:DodgerBlue">string</span>  | Yes          | `drop`                                | Name of the artifact to create in the publish location.                                                             |
| `publishLocation`   | <span style="color:DodgerBlue">string</span>  | Yes          | `Container`                           | Type of storage to publish to: `Container` (Azure Pipelines artifact) or `FilePath` (a file share).                 |
| `MaxArtifactSize`   | <span style="color:DodgerBlue">string</span>  | No           | `0`                                   | Maximum size of the artifact to publish in **bytes**.                                                                |
| `TargetPath`        | <span style="color:DodgerBlue">string</span>  | Conditional  | -                                     | Path to the file share to publish the artifact. Required when `publishLocation: 'FilePath'`.                        |
| `Parallel`          | <span style="color:red">boolean</span>        | No           | `false`                               | Use multiple threads to do a parallel upload of the files of the artifact. Increases upload speed at the cost of agent's resources. Used with `publishLocation: 'FilePath'`. |
| `ParallelCount`     | <span style="color:DodgerBlue">string</span>  | No           | `8`                                   | Degree of parallelism to use in a parallel upload. Used when `Parallel: true`.                                      |
| `StoreAsTar`        | <span style="color:red">boolean</span>        | No           | `false`                               | Store the artifact contents in a TAR file before uploading, preserving UNIX permissions in the case of `FilePath`.  |


> Note: in case you want to use `DownloadBuildArtifacts` task, you can set `extractTars` when

### Example of use

The most recommended way to publish the build artifact is previously copy the necesary contents into the Build.ArtifactStagingDirectory [[Azure DevOps - Variables]]

```yaml
steps:
- task: CopyFiles@2
  inputs:
    contents: '_buildOutput/**'
    targetFolder: $(Build.ArtifactStagingDirectory)
- task: PublishBuildArtifacts@1
  inputs:
    pathToPublish: $(Build.ArtifactStagingDirectory)
    artifactName: MyBuildOutputs
```