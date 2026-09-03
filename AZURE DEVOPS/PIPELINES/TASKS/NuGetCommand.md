#AZURE_DEVOPS #DOTNET 

# NuGetCommand

**NuGetCommand** is an Azure DevOps pipeline task to execute `nuget` commands in order to restore, pack or insert NuGet packages for .Net applications. 

This task allows to interact with public `nuget.org` as well as Azure Artifacts[^1] or other repositiories like Nexus [^2]. 


Basic syntax: 
```yaml
- task: NuGetCommand@2
  inputs:
    command: 'restore' # 'restore' | 'pack' | 'push' | 'custom'. Required. 
    restoreSolution: '**/*.sln' 
    #packagesToPush: # required with command: 'push'
    #nuGetFeedType: # required with command: 'push' 
    #publishVstsFeed: # string. Alias: feedPublish. Required when command = push && nuGetFeedType = internal. Target feed. 
    #allowPackageConflicts: false # boolean. Optional. Use when command = push && nuGetFeedType = internal. Allow duplicates to be skipped. Default: false.
    #publishFeedCredentials: # string. Alias: externalEndpoint. Required when command = push && nuGetFeedType = external. NuGet server. 
    #packagesToPack: '**/*.csproj' # string. Alias: searchPatternPack. Required when command = pack. Path to csproj or nuspec file(s) to pack. Default: **/*.csproj.
    #configuration: '$(BuildConfiguration)' # string. Alias: configurationToPack. Optional. Use when command = pack. Configuration to package. Default: $(BuildConfiguration).
    #packDestination: '$(Build.ArtifactStagingDirectory)' # string. Alias: outputDir. Optional. Use when command = pack. Package folder. Default: $(Build.ArtifactStagingDirectory).
    #arguments: # string. Required when command = custom. Command and arguments. 
  # Feeds and authentication
    feedsToUse: 'select' # 'select' | 'config'. Alias: selectOrConfig. Required when command = restore. Feeds to use. Default: select.
    #vstsFeed: # string. Alias: feedRestore. Optional. Use when selectOrConfig = select && command = restore. Use packages from this Azure Artifacts/TFS feed. Select from the dropdown or enter [project name/]feed name. 
    #includeNuGetOrg: true # boolean. Optional. Use when selectOrConfig = select && command = restore. Use packages from NuGet.org. Default: true.
    #nugetConfigPath: # string. Optional. Use when selectOrConfig = config && command = restore. Path to NuGet.config. 
    #externalFeedCredentials: # string. Alias: externalEndpoints. Optional. Use when selectOrConfig = config && command = restore. Credentials for feeds outside this organization/collection. 
  # Advanced
    #noCache: false # boolean. Optional. Use when command = restore. Disable local cache. Default: false.
    #disableParallelProcessing: false # boolean. Optional. Use when command = restore. Disable parallel processing. Default: false.
    #restoreDirectory: # string. Alias: packagesDirectory. Optional. Use when command = restore. Destination directory. 
    #verbosityRestore: 'Detailed' # 'Quiet' | 'Normal' | 'Detailed'. Optional. Use when command = restore. Verbosity. Default: Detailed.
  # Advanced
    #publishPackageMetadata: true # boolean. Optional. Use when command = push && nuGetFeedType = internal. Publish pipeline metadata. Default: true.
    #verbosityPush: 'Detailed' # 'Quiet' | 'Normal' | 'Detailed'. Optional. Use when command = push. Verbosity. Default: Detailed.
  # Pack options
    #versioningScheme: 'off' # 'off' | 'byPrereleaseNumber' | 'byEnvVar' | 'byBuildNumber'. Required when command = pack. Automatic package versioning. Default: off.
    #includeReferencedProjects: false # boolean. Optional. Use when versioningScheme = off && command = pack. Include referenced projects. Default: false.
    #versionEnvVar: # string. Required when versioningScheme = byEnvVar && command = pack. Environment variable. 
    #majorVersion: '1' # string. Alias: requestedMajorVersion. Required when versioningScheme = byPrereleaseNumber && command = pack. Major. Default: 1.
    #minorVersion: '0' # string. Alias: requestedMinorVersion. Required when versioningScheme = byPrereleaseNumber && command = pack. Minor. Default: 0.
    #patchVersion: '0' # string. Alias: requestedPatchVersion. Required when versioningScheme = byPrereleaseNumber && command = pack. Patch. Default: 0.
    #packTimezone: 'utc' # 'utc' | 'local'. Optional. Use when versioningScheme = byPrereleaseNumber && command = pack. Time zone. Default: utc.
    #includeSymbols: false # boolean. Optional. Use when command = pack. Create symbols package. Default: false.
    #toolPackage: false # boolean. Optional. Use when command = pack. Tool Package. Default: false.
  # Advanced
    #buildProperties: # string. Optional. Use when command = pack. Additional build properties. 
    #basePath: # string. Optional. Use when command = pack. Base path. 
    #verbosityPack: 'Detailed' # 'Quiet' | 'Normal' | 'Detailed'. Optional. Use when command = pack. Verbosity. Default: Detailed.
```


### Command

| Parameter          | Type                                          | Required    | Default   | Description                                                                                                                          |
| -------------------- | ----------------------------------------------- | ------------ | ----------- | --------------------------------------------------------------------------------------------------------------------------------------- |
| `command`           | <span style="color:DodgerBlue">string</span>  | Yes          | `restore`  | Nuget command to execute: `restore`, `pack`, `push` or `custom`.                                                                    |
| `arguments`         | <span style="color:DodgerBlue">string</span>  | Conditional  | -          | Command and arguments. Required when `command: custom`.                                                                              |

### Restore (`command: restore`)

| Parameter                    | Type                                          | Required    | Default   | Description                                                                                                                          |
| ------------------------------- | ----------------------------------------------- | ------------ | ----------- | --------------------------------------------------------------------------------------------------------------------------------------- |
| `restoreSolution`              | <span style="color:DodgerBlue">string</span>  | Yes          | `**/*.sln` | Path to the solution, `packages.config`, or `project.json` to execute the command over. Recommended to set it as `'$(Build.Repository.LocalPath)/${{ parameters.SolutionPath }}'` using `Build.Repository.LocalPath`. |
| `feedsToUse`                   | <span style="color:DodgerBlue">string</span>  | Yes          | `select`   | Feeds to use: `select` (Azure Artifacts/TFS feed) or `config` (external NuGet configuration).                                       |
| `vstsFeed`                     | <span style="color:DodgerBlue">string</span>  | No           | -          | Azure Artifacts/TFS feed to use packages from. Used when `feedsToUse: select`. Enter `[project name/]feed name`.                    |
| `includeNuGetOrg`              | <span style="color:red">boolean</span>        | No           | `true`     | Use packages from NuGet.org. Used when `feedsToUse: select`.                                                                          |
| `nugetConfigPath`              | <span style="color:DodgerBlue">string</span>  | No           | -          | Path to `NuGet.config`. Used when `feedsToUse: config`.                                                                               |
| `externalFeedCredentials`      | <span style="color:DodgerBlue">string</span>  | No           | -          | Credentials for feeds outside this organization/collection. Used when `feedsToUse: config`.                                          |
| `noCache`                      | <span style="color:red">boolean</span>        | No           | `false`    | Disable local NuGet cache.                                                                                                            |
| `disableParallelProcessing`    | <span style="color:red">boolean</span>        | No           | `false`    | Disable parallel processing.                                                                                                          |
| `restoreDirectory`             | <span style="color:DodgerBlue">string</span>  | No           | -          | Destination directory for the restored packages.                                                                                     |
| `verbosityRestore`             | <span style="color:DodgerBlue">string</span>  | No           | `Detailed` | Verbosity: `Quiet`, `Normal` or `Detailed`.                                                                                            |

### Push (`command: push`)

| Parameter                    | Type                                          | Required    | Default   | Description                                                                                                                          |
| ------------------------------- | ----------------------------------------------- | ------------ | ----------- | --------------------------------------------------------------------------------------------------------------------------------------- |
| `packagesToPush`               | <span style="color:DodgerBlue">string</span>  | Yes          | `$(Build.ArtifactStagingDirectory)/**/*.nupkg;!$(Build.ArtifactStagingDirectory)/**/*.symbols.nupkg` | Path to the NuGet packages to publish.                       |
| `nuGetFeedType`                | <span style="color:DodgerBlue">string</span>  | Yes          | `internal` | Target feed location: `internal` (hosted in the Azure DevOps organization, Azure Artifacts[^1]; define `publishVstsFeed`) or `external` (outside the organization; define `publishFeedCredentials`). |
| `publishVstsFeed`              | <span style="color:DodgerBlue">string</span>  | Conditional  | -          | Target Azure Artifacts feed. Required when `nuGetFeedType: internal`.                                                                |
| `allowPackageConflicts`        | <span style="color:red">boolean</span>        | No           | `false`    | Allow duplicates to be skipped. Used when `nuGetFeedType: internal`.                                                                 |
| `publishFeedCredentials`       | <span style="color:DodgerBlue">string</span>  | Conditional  | -          | NuGet service connection to an external server. Required when `nuGetFeedType: external`.                                            |
| `publishPackageMetadata`       | <span style="color:red">boolean</span>        | No           | `true`     | Publish pipeline metadata with the package. Used when `nuGetFeedType: internal`.                                                     |
| `verbosityPush`                | <span style="color:DodgerBlue">string</span>  | No           | `Detailed` | Verbosity: `Quiet`, `Normal` or `Detailed`.                                                                                            |

### Pack (`command: pack`)

| Parameter                    | Type                                          | Required    | Default                             | Description                                                                                                        |
| ------------------------------- | ----------------------------------------------- | ------------ | --------------------------------------- | ---------------------------------------------------------------------------------------------------------------- |
| `packagesToPack`               | <span style="color:DodgerBlue">string</span>  | Yes          | `**/*.csproj`                          | Path to `.csproj` or `.nuspec` file(s) to pack.                                                                   |
| `configuration`                | <span style="color:DodgerBlue">string</span>  | No           | `$(BuildConfiguration)`                | Configuration to package.                                                                                          |
| `packDestination`              | <span style="color:DodgerBlue">string</span>  | No           | `$(Build.ArtifactStagingDirectory)`    | Package output folder.                                                                                             |
| `versioningScheme`             | <span style="color:DodgerBlue">string</span>  | Yes          | `off`                                   | Automatic package versioning: `off`, `byPrereleaseNumber`, `byEnvVar` or `byBuildNumber`.                          |
| `includeReferencedProjects`    | <span style="color:red">boolean</span>        | No           | `false`                                 | Include referenced projects. Used when `versioningScheme: off`.                                                   |
| `versionEnvVar`                | <span style="color:DodgerBlue">string</span>  | Conditional  | -                                       | Environment variable holding the version. Required when `versioningScheme: byEnvVar`.                             |
| `majorVersion`                 | <span style="color:DodgerBlue">string</span>  | Conditional  | `1`                                     | Major version. Required when `versioningScheme: byPrereleaseNumber`.                                              |
| `minorVersion`                 | <span style="color:DodgerBlue">string</span>  | Conditional  | `0`                                     | Minor version. Required when `versioningScheme: byPrereleaseNumber`.                                              |
| `patchVersion`                 | <span style="color:DodgerBlue">string</span>  | Conditional  | `0`                                     | Patch version. Required when `versioningScheme: byPrereleaseNumber`.                                              |
| `packTimezone`                 | <span style="color:DodgerBlue">string</span>  | No           | `utc`                                   | Time zone (`utc` or `local`). Used when `versioningScheme: byPrereleaseNumber`.                                   |
| `includeSymbols`               | <span style="color:red">boolean</span>        | No           | `false`                                 | Create a symbols package.                                                                                          |
| `toolPackage`                  | <span style="color:red">boolean</span>        | No           | `false`                                 | Package as a dotnet tool package.                                                                                  |
| `buildProperties`              | <span style="color:DodgerBlue">string</span>  | No           | -                                       | Additional build properties, especially for `.nuspec` token replacement.                                          |
| `basePath`                     | <span style="color:DodgerBlue">string</span>  | No           | -                                       | Base path for the files defined in the `.nuspec` file.                                                            |
| `verbosityPack`                | <span style="color:DodgerBlue">string</span>  | No           | `Detailed`                             | Verbosity: `Quiet`, `Normal` or `Detailed`.                                                                        |

[^1]: Azure Artifacts [[Azure Artifacts]]
[^2]: Nexus [[Nexus]]

