#AZURE_DEVOPS 

# DotNetCoreCLI 

**DotNetCoreCLI** permite ejecutar comandos de la CLI de .NET Core (como `build`, `test`, `publish`, `restore`, `pack`, `run`). 

# Commands

This section explains the different configurations over the task depending on the command to execute: 
## Publish

`DotNetCoreCli` with command `publish` is used to prepare a .Net application for deployment by compiling the application and copying the needed files, dependencies and assets. 

## Build

`DotNetCoreCLI` with command `build` runs dotnet build in the pipeline to compile projects or solutions. A common YAML configuration looks like this:

```YAML
- task: DotNetCoreCLI@2
  displayName: 'Build solution'
  inputs:
    command: 'build'
    projects: '**/*.sln'
    arguments: '--configuration Release --no-restore'
    verbosity: 'minimal'
```

Main inputs: 

| Parameter        | Type                                          | Required | Default | Description                                                                                                                              |
| ------------------ | ----------------------------------------------- | --------- | -------- | --------------------------------------------------------------------------------------------------------------------------------------- |
| `command`         | <span style="color:DodgerBlue">string</span>  | Yes       | -        | `build` is required to run the compile step with `dotnet build`.                                                                        |
| `projects`        | <span style="color:DodgerBlue">string</span>  | No        | -        | `.sln` or `.csproj` files to build; wildcards are supported (for example `'**/*.sln'` or `'**/*WebApp.csproj'`).                        |
| `configuration`   | <span style="color:DodgerBlue">string</span>  | No        | -        | Build configuration (commonly `Release` or `Debug`).                                                                                    |
| `arguments`       | <span style="color:DodgerBlue">string</span>  | No        | -        | Extra flags passed to the underlying `dotnet build` call, e.g., `--no-restore`, `--configuration`, `-p:Property=Value`. See notes below. |
| `verbosity`       | <span style="color:DodgerBlue">string</span>  | No        | -        | Logging verbosity (e.g., `minimal`, `normal`, `detailed`, `diagnostic`) to help troubleshooting or reduce pipeline log noise.            |

Notes on `arguments`:
- `--no-restore`: skips NuGet restore during build; recommended when a separate restore step has already run to avoid redundant package downloads.
- `--no-incremental` / `/p:ContinuousIntegrationBuild=true`: control incremental build behavior and CI-specific build metadata.
- Output location: the task will honor dotnet `-o` or `--output`/`-p:OutputPath=` settings passed in `arguments`; otherwise build artifacts will be placed by default in `bin/<configuration>/` for example `bin/Release`.

## Restore

`DotNetCoreCLI` with command `restore` runs dotnet restore in the pipeline to download and resolve NuGet dependencies before build, test, or pack steps. A common YAML configuration looks like this:

```YAML
- task: DotNetCoreCLI@2
  displayName: 'Restore NuGet packages'
  inputs:
    command: 'restore'
    projects: '**/*.sln'
    feedsToUse: 'select'
    vstsFeed: 'your-feed-id-or-name'
```

If using a custom `.config` file (NuGet configuration file) instead of Azure Artifacts feed, an example looks like this: 

```YAML
- task: DotNetCoreCLI@2
  displayName: 'Restore packages from NuGet.config'
  inputs:
    command: 'restore'
    projects: 'src/MySolution.sln'
    feedsToUse: 'config'
    nugetConfigPath: 'NuGet.config'
    verbosityRestore: 'Minimal'
    restoreArguments: '--configfile NuGet.config'
```

Inputs: 

| Parameter                    | Type                                          | Required    | Default | Description                                                                                                                    |
| ------------------------------- | ----------------------------------------------- | ------------ | -------- | ----------------------------------------------------------------------------------------------------------------------------- |
| `command`                      | <span style="color:DodgerBlue">string</span>  | Yes          | -        | `restore` is required to run `dotnet restore`.                                                                                |
| `projects`                     | <span style="color:DodgerBlue">string</span>  | No           | -        | `.sln` or `.csproj` files to restore; wildcards are supported, such as `'**/*.sln'` or `'**/*.csproj'`.                       |
| `feedsToUse`                   | <span style="color:DodgerBlue">string</span>  | No           | -        | Whether the task uses a selected Azure Artifacts feed (`select`) or an external NuGet configuration (`config`).               |
| `vstsFeed`                     | <span style="color:DodgerBlue">string</span>  | Conditional  | -        | Azure Artifacts feed to use. Required when `feedsToUse: select`.                                                              |
| `nugetConfigPath`              | <span style="color:DodgerBlue">string</span>  | No           | -        | Path to the config file that contains the feed URLs and credentials setup. Used when `feedsToUse: config`. (`restoreArguments: '--configfile NuGet.config'` is optional if this is defined). |
| `noCache`                      | <span style="color:red">boolean</span>        | No           | `false`  | Disables NuGet local cache usage when a clean restore is required.                                                            |
| `disableParallelProcessing`    | <span style="color:red">boolean</span>        | No           | `false`  | Restores packages sequentially, which can help in troubleshooting feed or network issues.                                     |
| `verbosityRestore`             | <span style="color:DodgerBlue">string</span>  | No           | -        | Restore log detail, with values such as `Quiet`, `Minimal`, `Normal`, `Detailed`, and `Diagnostic`.                           |
| `restoreArguments`             | <span style="color:DodgerBlue">string</span>  | No           | -        | Extra restore flags passed to the underlying `dotnet restore` command, such as `--configfile`, `--force`, or `--ignore-failed-sources`. |

## Pack

`DotNetCoreCLI` with command `pack` is meant to run `dotnet pack` in the pipeline to create NuGet packages from `.csproj` or `.nuspec` files. A common YAML configuration looks like this: 

```YAML
- task: DotNetCoreCLI@2
  displayName: 'Pack NuGet packages'
  inputs:
    command: 'pack'
    packagesToPack: '**/*.csproj;!**/*Tests.csproj'
    configuration: 'Release'
    packDirectory: '$(Build.ArtifactStagingDirectory)'
    nobuild: true
    includesymbols: false
    includesource: false
    versioningScheme: 'off'
```

Main inputs: 

| Parameter          | Type                                          | Required | Default                             | Description                                                                                                          |
| -------------------- | ----------------------------------------------- | --------- | --------------------------------------- | ------------------------------------------------------------------------------------------------------------------- |
| `command`           | <span style="color:DodgerBlue">string</span>  | Yes       | -                                       | `pack` is required to run the packaging step with `dotnet pack`.                                                    |
| `packagesToPack`    | <span style="color:DodgerBlue">string</span>  | No        | -                                       | `.csproj` or `.nuspec` files to package; accepts wildcards and exclusion patterns such as `'**/*.csproj;!**/*Tests.csproj'`. |
| `configuration`     | <span style="color:DodgerBlue">string</span>  | No        | -                                       | Build configuration used for packing, commonly `Release`.                                                            |
| `packDirectory`     | <span style="color:DodgerBlue">string</span>  | No        | `$(Build.ArtifactStagingDirectory)`     | Output folder where the generated `.nupkg` files will be created.                                                    |

Inputs to control behavior: 

| Parameter          | Type                                          | Required | Default | Description                                                                                                          |
| -------------------- | ----------------------------------------------- | --------- | -------- | --------------------------------------------------------------------------------------------------------------------- |
| `nobuild`           | <span style="color:red">boolean</span>        | No        | `false`  | Skips building before packing. Maps to `--no-build`; recommended when the solution was already built in a previous step. |
| `includesymbols`    | <span style="color:red">boolean</span>        | No        | `false`  | Creates symbol packages in addition to the regular NuGet package. Maps to `--include-symbols`.                       |
| `includesource`     | <span style="color:red">boolean</span>        | No        | `false`  | Includes source code in the symbols package. Maps to `--include-source`.                                             |
| `verbosityPack`     | <span style="color:DodgerBlue">string</span>  | No        | -        | Detail level of the pack output, with values such as `Minimal`, `Normal`, `Detailed`, or `Diagnostic`.               |

Inputs for versioning: 

| Parameter           | Type                                          | Required    | Default | Description                                                                                                                          |
| --------------------- | ----------------------------------------------- | ------------ | -------- | ------------------------------------------------------------------------------------------------------------------------------------- |
| `versioningScheme`   | <span style="color:DodgerBlue">string</span>  | No           | `off`    | Automatic package versioning for the `pack` command. Supported values: `off`, `byPrereleaseNumber`, `byEnvVar`, `byBuildNumber`, `bySemVerBuildNumber`. |
| `versionEnvVar`      | <span style="color:DodgerBlue">string</span>  | Conditional  | -        | Variable name that holds the package version. Required when `versioningScheme: byEnvVar`.                                            |
| `majorVersion`       | <span style="color:DodgerBlue">string</span>  | Conditional  | -        | Major version segment. Used when `versioningScheme: byPrereleaseNumber` to generate a SemVer-style prerelease package version.        |
| `minorVersion`       | <span style="color:DodgerBlue">string</span>  | Conditional  | -        | Minor version segment. Used when `versioningScheme: byPrereleaseNumber`.                                                              |
| `patchVersion`       | <span style="color:DodgerBlue">string</span>  | Conditional  | -        | Patch version segment. Used when `versioningScheme: byPrereleaseNumber`.                                                              |
| `buildProperties`    | <span style="color:DodgerBlue">string</span>  | No           | -        | Additional token/value pairs used during packing, especially for `.nuspec` token replacement scenarios.                              |

## Test

`DotNetCoreCli` with command `test` is meant to run `dotnet test` as part of the pipeline. 

A common YAML configuration looks like: 
```yaml 
- task: DotNetCoreCLI@2
  displayName: 'Run tests'
  inputs:
    command: 'test'
    projects: '**/*Tests.csproj'
    arguments: '--configuration Release --no-build --logger trx'
    publishTestResults: true
    testRunTitle: 'Unit tests'
```

Inputs: 

| Parameter               | Type                                          | Required | Default | Description                                                                                                    |
| ------------------------- | ----------------------------------------------- | --------- | -------- | ---------------------------------------------------------------------------------------------------------------- |
| `command`                | <span style="color:DodgerBlue">string</span>  | Yes       | -        | `test` is required to run `dotnet test`.                                                                       |
| `projects`               | <span style="color:DodgerBlue">string</span>  | No        | -        | `.csproj` or solution files to test, accepting wildcards for selecting multiple ones, such as `'**/*Tests.csproj'`. |
| `arguments`              | <span style="color:DodgerBlue">string</span>  | No        | -        | Extra flags for configurations like build configuration, filtering, no-build and others. See notes below.      |
| `publishTestResults`     | <span style="color:red">boolean</span>        | No        | `true`   | Enables automatic publish of the test results and code coverage into the Azure DevOps pipeline.                |
| `testRunTitle`           | <span style="color:DodgerBlue">string</span>  | No        | -        | Name for the test execution.                                                                                    |

Notes on `arguments`:
* `--configuration`: `Release` or `Debug` chooses the build configuration. 
* `--no-build`: skips building the code before testing. Its recommendable if the code has been builded previously in the pipeline. 
* `--no-restore`: skips package restore. Its recommendable if the dependencies has been restored previously in the pipeline. 
* `--filter` allows to filter which tests to run, for example by category or name. 
* `--logger trx` writes a TSX test result file, useful for Azure DevOps to publish into the test results. 
* `--results-directory "..."` defines where the `.trx` files will be written in the agent. 

### Manual results publishing

If you need more control over how the results are published into Azure DevOps pipeline, you can set `publishTestResults: false` so they are not automatically published and control the publish with `PublishTestResults` task[^1]. 


%%TODO%%

[^1]: `PublishTestResults` Azure DevOps task: [[PublishTestResults]]
