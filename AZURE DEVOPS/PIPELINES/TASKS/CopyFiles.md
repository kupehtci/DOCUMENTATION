#AZURE_DEVOPS 

# CopyFiles

`CopyFiles` is an Azure DevOps task that copies files from a source folder to a target folder using match patterns. Patterns only match file paths, not folder paths.

Syntax template:

```yaml
- task: CopyFiles@2
  inputs:
    #SourceFolder: ''
    Contents: '**'          # Required. Default: **.
    TargetFolder: ''        # Required.

    # --- Advanced ---
    #CleanTargetFolder: false
    #OverWrite: false
    #flattenFolders: false
    #preserveTimestamp: false
    #retryCount: '0'
    #delayBetweenRetries: '1000'
    #ignoreMakeDirErrors: false
```

| Parameter               | Type                                          | Required | Default                          | Description                                                                                                                                     |
| -------------------------- | ----------------------------------------------- | --------- | ------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------- |
| `SourceFolder`             | <span style="color:DodgerBlue">string</span>  | No        | `$(Build.SourcesDirectory)`           | Folder that contains the files to copy. If the build produces artifacts outside of the sources directory, use `$(Agent.BuildDirectory)`.       |
| `Contents`                 | <span style="color:DodgerBlue">string</span>  | Yes       | `**`                                  | File paths to include, supports multiline minimatch patterns matching only file paths (not folder paths), e.g. `**\bin\**` instead of `**\bin`. |
| `TargetFolder`             | <span style="color:DodgerBlue">string</span>  | Yes       | -                                      | Target folder or UNC path that will contain the copied files, e.g. `$(Build.ArtifactStagingDirectory)`.                                        |
| `CleanTargetFolder`        | <span style="color:red">boolean</span>        | No        | `false`                               | Delete all existing files in the target folder before copying.                                                                                  |
| `OverWrite`                | <span style="color:red">boolean</span>        | No        | `false`                               | Replace existing files in the target folder. If `false`, matched files that already exist are skipped without failing the task.                |
| `flattenFolders`           | <span style="color:red">boolean</span>        | No        | `false`                               | Flatten the folder structure and copy all matched files into the target folder.                                                                 |
| `preserveTimestamp`        | <span style="color:red">boolean</span>        | No        | `false`                               | Preserve the target file timestamp using the original source file's timestamp.                                                                  |
| `retryCount`               | <span style="color:DodgerBlue">string</span>  | No        | `0`                                    | Retry count to copy a file, useful for intermittent issues such as UNC target paths on a remote host.                                           |
| `delayBetweenRetries`      | <span style="color:DodgerBlue">string</span>  | No        | `1000`                                 | Delay in milliseconds between two retries.                                                                                                       |
| `ignoreMakeDirErrors`      | <span style="color:red">boolean</span>        | No        | `false`                               | Ignore errors during creation of the target folder, useful when several agents write to the same target folder in parallel.                    |

### Example of use

Copy build output to the artifact staging directory and publish it: 

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

Copy everything from the source directory except `.git`: 

```yaml
- task: CopyFiles@2
  inputs:
    SourceFolder: '$(Build.SourcesDirectory)'
    Contents: |
      **/*
      !.git/**/*
    TargetFolder: '$(Build.ArtifactStagingDirectory)'
```

Copy only specific executables using an OR condition: 

```yaml
- task: CopyFiles@2
  inputs:
    Contents: |
      **\bin\**\?(*.exe|*.dll)
      readme.txt
    TargetFolder: '$(Build.ArtifactStagingDirectory)'
```

For extracting compressed archives, see [[ExtractFiles]]; for removing files instead of copying them, see [[DeleteFiles]].
