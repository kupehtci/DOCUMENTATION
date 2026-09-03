#AZURE_DEVOPS 

# DownloadPipelineArtifact

`DownloadPipelineArtifact` is an Azure DevOps task that allows to download pipeline artifacts from earlier stages in the same pipeline, or from another pipeline run.

> Note: This task is only supported on Azure DevOps Services. On Azure DevOps Server / TFS use [[DownloadBuildArtifacts]] instead.

Syntax template:

```yaml
- task: DownloadPipelineArtifact@2
  inputs:
    # --- Source ---
    buildType: 'current'            # 'current' | 'specific'. Alias: source. Required. Default: current.
    #project: ''                    # Required if buildType == specific
    #pipeline: ''                   # Alias: definition. Required if buildType == specific
    #specificBuildWithTriggering: false  # Alias: preferTriggeringPipeline. Optional. Use when buildType == specific. Default: false.
    #buildVersionToDownload: 'latest'    # Alias: runVersion. 'latest' | 'latestFromBranch' | 'specific'. Required if buildType == specific. Default: latest.
    #branchName: 'refs/heads/master'     # Alias: runBranch. Required if buildVersionToDownload == latestFromBranch. Default: refs/heads/master.
    #pipelineId: ''                 # Alias: runId | buildId. Required if buildVersionToDownload == specific
    #tags: ''                       # Optional. Use when buildType == specific && buildVersionToDownload != specific
    #allowPartiallySucceededBuilds: false # Optional. Use when buildType == specific && buildVersionToDownload != specific. Default: false.
    #allowFailedBuilds: false       # Optional. Use when buildType == specific && buildVersionToDownload != specific. Default: false.

    # --- What to download ---
    #artifactName: ''               # Alias: artifact. Name of the artifact to download. Leave empty to download all artifacts.
    #itemPattern: '**'              # Alias: patterns. Glob pattern to filter files. Default: **.

    # --- Destination ---
    targetPath: '$(Pipeline.Workspace)' # Alias: path | downloadPath. Required. Default: $(Pipeline.Workspace).
```

### Source

| Parameter                       | Type                                          | Required    | Default              | Description                                                                                                                                      |
| ---------------------------------- | ----------------------------------------------- | ------------ | ----------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------- |
| `buildType`                       | <span style="color:DodgerBlue">string</span>  | Yes          | `current`              | Whether the artifact to download is from the `current` pipeline run or from a `specific` pipeline run. If `specific`, indicate `project` and `pipeline`. |
| `project`                         | <span style="color:DodgerBlue">string</span>  | Conditional  | -                       | Azure DevOps project (name or GUID) to download the artifact from. Required when `buildType: specific`.                                            |
| `pipeline`                        | <span style="color:DodgerBlue">string</span>  | Conditional  | -                       | `definitionId` of the pipeline to download the artifact from. Found in the `System.DefinitionId` variable, or in the pipeline overview URL (`...&_build?definitionId=78&...`). Required when `buildType: specific`. |
| `specificBuildWithTriggering`     | <span style="color:red">boolean</span>        | No           | `false`                 | Download artifacts from the triggering build instead of the build selected below, when there is one. Used when `buildType: specific`.              |
| `buildVersionToDownload`          | <span style="color:DodgerBlue">string</span>  | Conditional  | `latest`                | Pipeline run to download. Required when `buildType: specific`. See values below.                                                                    |
| `branchName`                      | <span style="color:DodgerBlue">string</span>  | Conditional  | `refs/heads/master`     | Branch to download the latest run from. Required when `buildVersionToDownload: latestFromBranch`.                                                  |
| `pipelineId`                      | <span style="color:DodgerBlue">string</span>  | Conditional  | -                       | Identifier of the pipeline run to download from. Found in the `Build.BuildId` variable, or in the run summary URL (`..._build/results?buildId=1088&...`). Required when `buildVersionToDownload: specific`. |
| `tags`                            | <span style="color:DodgerBlue">string</span>  | No           | -                       | Comma-delimited list of tags to filter tagged builds. Untagged builds are not returned. Used when `buildType: specific` && `buildVersionToDownload != specific`. |
| `allowPartiallySucceededBuilds`   | <span style="color:red">boolean</span>        | No           | `false`                 | Allow downloading artifacts from partially succeeded builds. Requires `allowFailedBuilds: true` too. Used when `buildType: specific` && `buildVersionToDownload != specific`. |
| `allowFailedBuilds`               | <span style="color:red">boolean</span>        | No           | `false`                 | Allow downloading artifacts from failed builds. Used when `buildType: specific` && `buildVersionToDownload != specific`.                            |

`buildVersionToDownload` allowed values:
* `latest`: latest run of the pipeline.
* `latestFromBranch`: latest run from a specific branch (indicate the branch with `branchName`, optionally filter by `tags`).
* `specific`: download a specific run (indicate the run with `pipelineId`).

### What to download

| Parameter        | Type                                          | Required | Default | Description                                                                                                                            |
| ------------------- | ----------------------------------------------- | --------- | -------- | ------------------------------------------------------------------------------------------------------------------------------------------ |
| `artifactName`     | <span style="color:DodgerBlue">string</span>  | No        | -        | Name of the artifact to download. If left empty, downloads **all** artifacts of the run (a sub-directory is created per artifact).      |
| `itemPattern`      | <span style="color:DodgerBlue">string</span>  | No        | `**`     | Pattern(s) to filter the downloaded files. Unlike other tasks, files matching **any** pattern are downloaded; exclude patterns cannot remove files already matched. |

### Destination

| Parameter     | Type                                          | Required | Default                    | Description                                                          |
| --------------- | ----------------------------------------------- | --------- | ----------------------------- | ------------------------------------------------------------------------ |
| `targetPath`   | <span style="color:DodgerBlue">string</span>  | Yes       | `$(Pipeline.Workspace)`       | Relative or absolute path inside the agent to download the artifacts to. |

### Output variables

| Variable       | Description                                                                                        |
| ---------------- | ------------------------------------------------------------------------------------------------------ |
| `BuildNumber`   | Stores the build number of the pipeline artifact source. (For backwards compatibility, this actually returns the `BuildId`) |

### Example of use

Download a specific artifact from the current run: 

```yaml
- task: DownloadPipelineArtifact@2
  inputs:
    artifactName: 'WebApp'
    targetPath: $(Build.SourcesDirectory)/bin
```

Download the latest artifacts from a different pipeline: 

```yaml
- task: DownloadPipelineArtifact@2
  inputs:
    buildType: 'specific'
    project: 'FabrikamFiber'
    pipeline: 12
    buildVersionToDownload: 'latest'
```

Download from a specific run of another pipeline: 

```yaml
- task: DownloadPipelineArtifact@2
  inputs:
    buildType: 'specific'
    artifactName: 'WebApp'
    targetPath: $(Build.SourcesDirectory)/bin
    project: 'FabrikamFiber'
    pipeline: 12
    buildVersionToDownload: 'specific'
    pipelineId: 40
```

> Note: to publish the artifact consumed by this task, use [[PublishPipelineArtifact]].
