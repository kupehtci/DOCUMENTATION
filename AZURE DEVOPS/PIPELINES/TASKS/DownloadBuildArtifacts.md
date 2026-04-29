#AZURE_DEVOPS 

# DownloadBuildArtifacts

`DownloadBuildArtifacts` is an Azure DevOps task that allows to download artifacts from a build. 

Syntax template:

```yaml
- task: DownloadBuildArtifacts@0
  inputs:
    # --- Source ---
    buildType: 'current'            # 'current' | 'specific'
    project: ''                     # Required if buildType == specific
    pipeline: ''                    # Alias: definition. Required if buildType == specific
    specificBuildWithTriggering: false  # Use triggering build (buildType == specific)
    buildVersionToDownload: 'latest'   # 'latest' | 'latestFromBranch' | 'specific'
    allowPartiallySucceededBuilds: false
    branchName: 'refs/heads/master'    # Required if buildVersionToDownload == latestFromBranch
    buildId: ''                     # Required if buildVersionToDownload == specific
    tags: ''                        # Filter by build tags

    # --- What to download ---
    downloadType: 'single'          # 'single' | 'specific'
    artifactName: ''                # Required if downloadType == single
    itemPattern: '**'               # Glob pattern to filter files

    # --- Destination ---
    downloadPath: '$(System.ArtifactsDirectory)'
    cleanDestinationFolder: false

    # --- Advanced ---
    parallelizationLimit: '8'
    checkDownloadedFiles: false
    retryDownloadCount: '4'
    retryRedirectDownloadCount: '0'
    extractTars: false              # Auto-extract .tar archives
```

* `buildType`: indicates if the artifact to download is from the current build or an `specific` build. (If `specific`, indicate the `project` and `pipeline` to download the build from)
* `project`: indicates the Azure DevOps project to download the build from. (Required when `buildType: specific`)
* `pipeline`: indicates the build pipeline name to extract the build from. (Required when `buildType: specific`)
* `buildVersionToDownload`: Indicates the build version to download (Required when `buildType: specific`): 
	* `latest`: latest build of the pipeline. 
	* `latestFromBranch`: latest build from an specific branch (Indicate the branch with `branchName` argument).
	* `specific`: download an specific version (Indicate the buildID of the versión with the `buildId` argument).
* `branchName`: branch to download the latest build from. (required when `buildVersionToDownload: latestFromBranch`). Default: `refs/heads/master`
* `tags`: list of tasks to select an specific build. (Required when `buildType == specific` && `buildVersionToDownload != specific`).

To define what to download: 
* `downloadType`: indicates whether to download an specific artifact (`single`) or specific files (`specific`). 
* `artifactName`: Name of the artifact to download. (required when `downloadType: single). 
* `itemPattern`: pattern to indicate the files to download. (required when `downloadType: specific`). By default `**`. 

To define the destination: 
* `downloadPath`: path inside the agent to download the artifacts to. By default `$(System.ArtifactsDirectory)`. 
* `cleanDestinationFolder`: clean the destination folder before downloading the artifacts to. By default `false`. 

* `extractTars`: de-compress an artifact that was published as a TAR file. Use this when `StoreAsTar` was enabled in `PublishBuildArtifacts`[^1] task used to publish the build artifact. 


[^1]: PublishBuildArtifacts is an Azure DevOps task that can be used to publish build artifacts into Azure DevOps pipelines or a file share. [[PublishBuildArtifacts]]


