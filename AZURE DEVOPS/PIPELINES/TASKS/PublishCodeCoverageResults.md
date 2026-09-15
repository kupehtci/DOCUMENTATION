#AZURE_DEVOPS 

# PublishCodeCoverageResults

`PublishCodeCoverageResults` is an [[Azure DevOps]] task that publishes code coverage results (line, branch, method, class) to Azure Pipelines, providing a coverage summary and an HTML report in the pipeline's **Code Coverage** tab.

> Note: tasks like [[DotNetCoreCLI]] (`test` command) or [[Maven]] can publish coverage automatically when a coverage collector/tool is configured (`publishTestResults: true` + a coverage collector for .NET, or `codeCoverageToolOption` for Maven). Use this task explicitly when that automatic publish is disabled, when coverage is generated outside of those tasks (e.g. npm/Node tooling), or when several coverage files need to be merged/published together.

For the underlying concepts (coverage report formats, `.coverage` vs `.xml`, .NET and npm tooling), see [[Azure Pipelines - Unit Testing and Code Coverage]].

There are two versions of this task with different inputs.

## PublishCodeCoverageResults@2 (recommended)

Since v2, the report format (Cobertura or JaCoCo) is auto-detected from the summary file, so `codeCoverageTool` is no longer needed.

```yaml
- task: PublishCodeCoverageResults@2
  inputs:
    summaryFileLocation: '$(Agent.TempDirectory)/**/coverage.cobertura.xml'   # Required.
    #pathToSources: ''
    #failIfCoverageEmpty: false
```

| Parameter               | Type                                          | Required | Default | Description                                                                                                                              |
| -------------------------- | ----------------------------------------------- | --------- | -------- | ------------------------------------------------------------------------------------------------------------------------------------------ |
| `summaryFileLocation`     | <span style="color:DodgerBlue">string</span>  | Yes       | -        | Path to the coverage summary file(s) with the coverage statistics, in Cobertura or JaCoCo format. Supports wildcards and multiple newline-separated paths. |
| `pathToSources`           | <span style="color:DodgerBlue">string</span>  | No        | -        | Path to the source files, used to resolve human-readable class names. Required for JaCoCo **multi-module** projects.                     |
| `failIfCoverageEmpty`     | <span style="color:red">boolean</span>        | No        | `false`  | Fail the task if the coverage summary produced no results.                                                                               |

## PublishCodeCoverageResults@1 (deprecated)

```yaml
- task: PublishCodeCoverageResults@1
  inputs:
    codeCoverageTool: 'Cobertura'   # 'Cobertura' | 'JaCoCo'. Required.
    summaryFileLocation: '$(Agent.TempDirectory)/**/coverage.cobertura.xml'   # Required.
    #pathToSources: ''
    #reportDirectory: ''
    #additionalCodeCoverageFiles: ''
    #failIfCoverageEmpty: false
```

| Parameter                      | Type                                          | Required | Default | Description                                                                                                                  |
| --------------------------------- | ----------------------------------------------- | --------- | -------- | -------------------------------------------------------------------------------------------------------------------------- |
| `codeCoverageTool`               | <span style="color:DodgerBlue">string</span>  | Yes       | -        | Coverage report format to publish: `Cobertura` or `JaCoCo`.                                                                |
| `summaryFileLocation`            | <span style="color:DodgerBlue">string</span>  | Yes       | -        | Path to the coverage summary file(s). Supports wildcards and multiple newline-separated paths.                             |
| `pathToSources`                  | <span style="color:DodgerBlue">string</span>  | No        | -        | Path to the source files. Required for JaCoCo multi-module projects.                                                       |
| `reportDirectory`                | <span style="color:DodgerBlue">string</span>  | No        | -        | Path to a pre-generated HTML coverage report directory to publish alongside the summary, for browsing in the pipeline UI.   |
| `additionalCodeCoverageFiles`    | <span style="color:DodgerBlue">string</span>  | No        | -        | Additional coverage files (e.g. per-class HTML files) to publish together with the summary file.                          |
| `failIfCoverageEmpty`            | <span style="color:red">boolean</span>        | No        | `false`  | Fail the task if the coverage summary produced no results.                                                                 |

### Supported formats

`PublishCodeCoverageResults` only understands two XML report formats: **Cobertura** and **JaCoCo**. Any other coverage output (VSTest `.coverage`, OpenCover, lcov, Istanbul JSON...) must be converted to one of these two before publishing — see [[Azure Pipelines - Unit Testing and Code Coverage]] for the conversion tools per stack.

### Example of use

Publish .NET coverage generated with Coverlet's `XPlat Code Coverage` collector (outputs Cobertura directly, one file per test project):

```yaml
- task: DotNetCoreCLI@2
  inputs:
    command: 'test'
    projects: '**/*Tests.csproj'
    arguments: '--configuration Release --collect:"XPlat Code Coverage"'
    publishTestResults: false

- task: PublishCodeCoverageResults@2
  inputs:
    summaryFileLocation: '$(Agent.TempDirectory)/**/coverage.cobertura.xml'
```

Publish npm/Node coverage generated with Jest/Istanbul (Cobertura reporter):

```yaml
- script: npx jest --ci --coverage --coverageReporters=cobertura
  displayName: 'Run unit tests with coverage'

- task: PublishCodeCoverageResults@2
  inputs:
    summaryFileLocation: '$(System.DefaultWorkingDirectory)/coverage/cobertura-coverage.xml'
```

Publish JaCoCo coverage from a multi-module Maven build, with sources so class names resolve correctly:

```yaml
- task: PublishCodeCoverageResults@1
  inputs:
    codeCoverageTool: 'JaCoCo'
    summaryFileLocation: '$(System.DefaultWorkingDirectory)/**/jacoco.xml'
    pathToSources: '$(System.DefaultWorkingDirectory)/src/main/java/'
```
