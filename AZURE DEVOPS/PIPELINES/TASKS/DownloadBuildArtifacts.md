#AZURE_DEVOPS 

# DownloadBuildArtifacts

`DownloadBuildArtifacts` is an Azure DevOps task that allows to download artifacts from a build. 



* `extractTars`: de-compress an artifact that was published as a TAR file. Use this when `StoreAsTar` was enabled in `PublishBuildArtifacts`[^1] task used to publish the build artifact. 


[^1]: PublishBuildArtifacts is an Azure DevOps task that can be used to publish build artifacts into Azure DevOps pipelines or a file share. [[PublishBuildArtifacts]]


