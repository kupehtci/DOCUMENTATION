#AZURE_DEVOPS 

# PublishTestResults

`PublishTestResults` is an Azure DevOps task that publishes test results files to Azure Pipelines, providing test reporting and analytics in the pipeline's **Tests** tab.

> Note: tasks like [[DotNetCoreCLI]] (`test` command), Visual Studio Test or Maven can publish their results automatically (`publishTestResults: true`). Use this task explicitly when that automatic publish is disabled, or when the results were generated outside of those tasks.

Syntax template:

```yaml
- task: PublishTestResults@2
  inputs:
    testResultsFormat: 'JUnit'          # Alias: testRunner. Required. Default: JUnit.
    testResultsFiles: '**/TEST-*.xml'   # Required. Default: **/TEST-*.xml.
    #searchFolder: '$(System.DefaultWorkingDirectory)'
    #mergeTestResults: false
    #failTaskOnFailedTests: false
    #failTaskOnFailureToPublishResults: false
    #failTaskOnMissingResultsFile: false
    #testRunTitle: ''

    # --- Advanced ---
    #buildPlatform: ''    # Alias: platform.
    #buildConfiguration: '' # Alias: configuration.
    #publishRunAttachments: true
```

| Parameter                              | Type                                          | Required | Default                            | Description                                                                                                                              |
| ----------------------------------------- | ----------------------------------------------- | --------- | -------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------- |
| `testResultsFormat`                      | <span style="color:DodgerBlue">string</span>  | Yes       | `JUnit`                                | Format of the results files to publish: `JUnit`, `NUnit`, `VSTest`, `XUnit` or `CTest`. `VSTest` refers to the TRX format.              |
| `testResultsFiles`                       | <span style="color:DodgerBlue">string</span>  | Yes       | `**/TEST-*.xml`                        | One or more test results files. Supports wildcards (`*`, `**`) and minimatch patterns, and multiple newline-separated paths. When `testResultsFormat: VSTest`, change the pattern to match `.trx` files, e.g. `**/TEST-*.trx`. |
| `searchFolder`                           | <span style="color:DodgerBlue">string</span>  | No        | `$(System.DefaultWorkingDirectory)`    | Folder to search for the test result files.                                                                                              |
| `mergeTestResults`                       | <span style="color:red">boolean</span>        | No        | `false`                                | Report results from all files against a single test run instead of one run per file. Results from more than 100 files are always merged regardless of this setting. |
| `failTaskOnFailedTests`                  | <span style="color:red">boolean</span>        | No        | `false`                                | Fail the task if any test in the results file is marked as failed.                                                                       |
| `failTaskOnFailureToPublishResults`      | <span style="color:red">boolean</span>        | No        | `false`                                | Fail the task if there is a failure while publishing the test results.                                                                   |
| `failTaskOnMissingResultsFile`           | <span style="color:red">boolean</span>        | No        | `false`                                | Fail the task if no result files are found.                                                                                              |
| `testRunTitle`                           | <span style="color:DodgerBlue">string</span>  | No        | -                                       | Name for the test run against which the results are reported. Pipeline variables can be used.                                           |
| `buildPlatform`                          | <span style="color:DodgerBlue">string</span>  | No        | -                                       | Build platform to report the test run against, e.g. `x64` or `x86`.                                                                      |
| `buildConfiguration`                     | <span style="color:DodgerBlue">string</span>  | No        | -                                       | Build configuration to report the test run against, e.g. `Debug` or `Release`.                                                           |
| `publishRunAttachments`                  | <span style="color:red">boolean</span>        | No        | `true`                                 | Upload the test result files as attachments to the test run.                                                                             |

### Supported result formats

* [CTest](https://cmake.org/cmake/help/latest/manual/ctest.1.html)
* [JUnit](https://github.com/windyroad/JUnit-Schema/blob/master/JUnit.xsd) (also used by PHPUnit and other runners)
* [NUnit 2 / NUnit 3](https://docs.nunit.org/)
* Visual Studio Test (`.trx`) — value `VSTest` in `testResultsFormat`
* [xUnit 2](https://xunit.net/docs/format-xml-v2)

### Example of use

Publish VSTest (`.trx`) results and fail the task if any test failed: 

```yaml
- task: PublishTestResults@2
  inputs:
    testResultsFormat: 'VSTest'
    testResultsFiles: '**/*.trx'
    failTaskOnFailedTests: true
```

Publish JUnit results merged into a single test run, with a custom title: 

```yaml
- task: PublishTestResults@2
  inputs:
    testResultsFormat: 'JUnit'
    testResultsFiles: '**/TEST-*.xml'
    searchFolder: '$(Build.SourcesDirectory)/test-results'
    mergeTestResults: true
    testRunTitle: 'Unit tests'
```

### Manual publish from DotNetCoreCLI

If [[DotNetCoreCLI]] `test` command is used with `publishTestResults: false`, generate a `.trx` file with `--logger trx` and publish it manually: 

```yaml
- task: DotNetCoreCLI@2
  inputs:
    command: 'test'
    projects: '**/*Tests.csproj'
    arguments: '--configuration Release --logger trx --results-directory $(Agent.TempDirectory)'
    publishTestResults: false

- task: PublishTestResults@2
  inputs:
    testResultsFormat: 'VSTest'
    testResultsFiles: '**/*.trx'
    searchFolder: '$(Agent.TempDirectory)'
```
