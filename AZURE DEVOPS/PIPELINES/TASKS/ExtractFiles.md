#AZURE_DEVOPS 

# ExtractFiles

`ExtractFiles` is an Azure DevOps task that extracts a variety of archive and compression files, such as `.zip`, `.jar`, `.war`, `.ear`, `.tar` and `.7z`.

Syntax template:

```yaml
- task: ExtractFiles@1
  inputs:
    archiveFilePatterns: '**/*.zip'   # Required. Default: **/*.zip.
    destinationFolder: ''              # Required.
    #cleanDestinationFolder: true
    #overwriteExistingFiles: false
    #pathToSevenZipTool: ''
```

| Parameter                    | Type                                          | Required | Default        | Description                                                                                                                                     |
| ------------------------------- | ----------------------------------------------- | --------- | ---------------- | ----------------------------------------------------------------------------------------------------------------------------------------------- |
| `archiveFilePatterns`           | <span style="color:DodgerBlue">string</span>  | Yes       | `**/*.zip`       | File paths or minimatch patterns (one per line) of the archives to extract, starting by default in the repo root. Matches only archive file paths, not folder paths, e.g. use `**/bin/**` instead of `**/bin`. |
| `destinationFolder`             | <span style="color:DodgerBlue">string</span>  | Yes       | -                 | Destination folder into which archive files are extracted. Use variables if files aren't in the repo, e.g. `$(Agent.BuildDirectory)`.          |
| `cleanDestinationFolder`        | <span style="color:red">boolean</span>        | No        | `true`            | Delete the entire content of the destination folder before extracting.                                                                          |
| `overwriteExistingFiles`        | <span style="color:red">boolean</span>        | No        | `false`           | Overwrite existing files in the destination folder if they already exist.                                                                       |
| `pathToSevenZipTool`            | <span style="color:DodgerBlue">string</span>  | No        | -                 | Custom path to the 7z utility, e.g. `C:\7z\7z.exe` on Windows or `/usr/local/bin/7z` on macOS/Ubuntu. If not set on Windows, uses the bundled 7zip. |

> Note: to extract files from another location (e.g. a pipeline artifact), first copy them into the repo root with [[CopyFiles]], then extract from there.

### Example of use

Extract all `.zip` files recursively: 

```yaml
- task: ExtractFiles@1
  inputs:
    archiveFilePatterns: '**/*.zip'
    destinationFolder: '$(Build.ArtifactStagingDirectory)/extracted'
    cleanDestinationFolder: true
    overwriteExistingFiles: false
```

Extract only `.zip` files directly inside a `test` folder (leaves nested archives untouched): 

```yaml
- task: ExtractFiles@1
  inputs:
    archiveFilePatterns: 'test/*.zip'
    destinationFolder: '$(Build.ArtifactStagingDirectory)/extracted'
```

To compress files instead, see [[ArchiveFiles]].
