#AZURE_DEVOPS 

# PublishBuildArtifacts

`PublishBuildArtifacts` is an Azure DevOps task that publishes build artifacts to Azure Pipelines, TFS or a file share. 

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

* `PathtoPublish`: (By default `$(Build.ArtifactStagingDirectory)`) Indicates the folder or file path to publish. Its recommended to store the artifacts to publish in the `ArtifactStagingDirectory`. 
* `ArtifactName`: name of the artifact to create in the publish location. 
* `publishLocation`: Indicates the type of storage to publish to: 
	* `Container`: Azure Pipelines artifact. 
	* `FilePath`: a file share. 

Optional: 
* `MaxArtifactSize`: maximum size of the artifact to publish in **bytes**. 
* `TargetPath` (Mandatory if `publishLocation: 'FilePath'`) indicates the path to the file share to publish the artifact. 
* `Parallel` (Can be used with `publishLocation: 'FilePath'`) (Default `false`)enables the use of multiple threads to do a parallel upload of the files of the artifact. This option increases the upload speed by using more agent's resources. 
* `ParallelCount`: Degree of parallelism to use in a parallel upload. 
* `StoreAsTar`: Store the artifact contents in a TAR file before uploading, preserving UNIX permissions in the case of filePath. 


> Note: in case you want to use `DownloadBuildArtifacts` task, you can set `extractTars` when
