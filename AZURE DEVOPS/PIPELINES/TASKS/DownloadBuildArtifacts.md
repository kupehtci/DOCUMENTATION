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

### Source

| Parameter                       | Type                                          | Required                  | Default              | Description                                                                                                                    |
| -------------------------------- | ---------------------------------------------- | -------------------------- | --------------------- | -------------------------------------------------------------------------------------------------------------------------------- |
| `buildType`                      | <span style="color:DodgerBlue">string</span>  | No                          | `current`             | Whether the artifact to download is from the `current` build or a `specific` build. If `specific`, indicate `project` and `pipeline`. |
| `project`                        | <span style="color:DodgerBlue">string</span>  | Conditional                 | -                     | Azure DevOps project to download the build from. Required when `buildType: specific`.                                          |
| `pipeline`                       | <span style="color:DodgerBlue">string</span>  | Conditional                 | -                     | Build pipeline name to extract the build from. Required when `buildType: specific`.                                            |
| `specificBuildWithTriggering`    | <span style="color:red">boolean</span>        | No                          | `false`               | Use the triggering build instead of the one selected below, when `buildType: specific`.                                        |
| `buildVersionToDownload`         | <span style="color:DodgerBlue">string</span>  | Conditional                 | `latest`              | Build version to download. Required when `buildType: specific`. See values below.                                             |
| `branchName`                     | <span style="color:DodgerBlue">string</span>  | Conditional                 | `refs/heads/master`   | Branch to download the latest build from. Required when `buildVersionToDownload: latestFromBranch`.                           |
| `buildId`                        | <span style="color:DodgerBlue">string</span>  | Conditional                 | -                     | Build to download. Required when `buildVersionToDownload: specific`.                                                           |
| `allowPartiallySucceededBuilds`  | <span style="color:red">boolean</span>        | No                          | `false`               | Allow downloading artifacts from partially succeeded builds. Used when `buildType: specific`.                                  |
| `tags`                           | <span style="color:DodgerBlue">string</span>  | No                          | -                     | Comma-delimited list of tags to select a specific build. Used when `buildType: specific` && `buildVersionToDownload != specific`. |

`buildVersionToDownload` allowed values:
* `latest`: latest build of the pipeline.
* `latestFromBranch`: latest build from a specific branch (indicate the branch with `branchName`).
* `specific`: download a specific version (indicate the build with `buildId`).

### What to download

| Parameter       | Type                                          | Required    | Default | Description                                                                 |
| ---------------- | ---------------------------------------------- | ------------ | -------- | ------------------------------------------------------------------------------ |
| `downloadType`   | <span style="color:DodgerBlue">string</span>  | Yes          | `single` | Whether to download a specific artifact (`single`) or specific files (`specific`). |
| `artifactName`   | <span style="color:DodgerBlue">string</span>  | Conditional  | -        | Name of the artifact to download. Required when `downloadType: single`.        |
| `itemPattern`    | <span style="color:DodgerBlue">string</span>  | Conditional  | `**`     | Pattern to indicate the files to download. Required when `downloadType: specific`. |

### Destination

| Parameter                | Type                                          | Required | Default                          | Description                                                    |
| -------------------------- | ---------------------------------------------- | --------- | ----------------------------------- | ------------------------------------------------------------------ |
| `downloadPath`             | <span style="color:DodgerBlue">string</span>  | No        | `$(System.ArtifactsDirectory)`      | Path inside the agent to download the artifacts to.             |
| `cleanDestinationFolder`   | <span style="color:red">boolean</span>        | No        | `false`                             | Clean the destination folder before downloading the artifacts.  |

### Advanced

| Parameter                     | Type                                          | Required | Default | Description                                                                                                     |
| ------------------------------- | ---------------------------------------------- | --------- | -------- | --------------------------------------------------------------------------------------------------------------- |
| `parallelizationLimit`          | <span style="color:DodgerBlue">string</span>  | No        | `8`      | Number of files to download in parallel.                                                                        |
| `checkDownloadedFiles`          | <span style="color:red">boolean</span>        | No        | `false`  | Verify that all files are fully downloaded.                                                                     |
| `retryDownloadCount`            | <span style="color:DodgerBlue">string</span>  | No        | `4`      | Number of retries if a download fails.                                                                          |
| `retryRedirectDownloadCount`    | <span style="color:DodgerBlue">string</span>  | No        | `0`      | Number of retries if a redirect fails during download.                                                          |
| `extractTars`                   | <span style="color:red">boolean</span>        | No        | `false`  | De-compress an artifact that was published as a TAR file. Use when `StoreAsTar` was enabled in `PublishBuildArtifacts`[^1] task used to publish the build artifact. |


[^1]: PublishBuildArtifacts is an Azure DevOps task that can be used to publish build artifacts into Azure DevOps pipelines or a file share. [[PublishBuildArtifacts]]


