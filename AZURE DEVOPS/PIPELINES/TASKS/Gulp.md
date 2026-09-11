#AZURE_DEVOPS #NODE 

# Gulp

`gulp` is an Azure DevOps task that runs the gulp Node.js streaming task-based build system.

> Note: gulp isn't preinstalled on all hosted agents; install it (and any plugins) with [[Npm]] before running this task.

Syntax template:

```yaml
- task: gulp@1
  inputs:
    #gulpFile: 'gulpfile.js'
    #targets: ''
    #arguments: ''

    # --- Advanced ---
    #workingDirectory: ''   # Alias: cwd.
    #gulpjs: ''

    # --- JUnit Test Results ---
    #publishJUnitResults: false
    #testResultsFiles: '**/TEST-*.xml'   # Required when publishJUnitResults = true.
    #testRunTitle: ''

    # --- Code Coverage ---
    #enableCodeCoverage: false
    #testFramework: 'Mocha'   # 'Mocha' | 'Jasmine'. Use when enableCodeCoverage = true.
    #srcFiles: ''
    #testFiles: 'test/*.js'   # Required when enableCodeCoverage = true.
```

| Parameter                | Type                                          | Required    | Default          | Description                                                                                                    |
| --------------------------- | ----------------------------------------------- | ------------ | ------------------- | ------------------------------------------------------------------------------------------------------------ |
| `gulpFile`                 | <span style="color:DodgerBlue">string</span>  | No           | `gulpfile.js`        | Relative path from the repo root of the gulp file to run.                                                     |
| `targets`                  | <span style="color:DodgerBlue">string</span>  | No           | -                    | Space-delimited list of gulp tasks to run. If not specified, the default task runs.                           |
| `arguments`                | <span style="color:DodgerBlue">string</span>  | No           | -                    | Additional arguments passed to gulp. `--gulpfile` is not needed since it's already added via `gulpFile`.       |
| `workingDirectory`         | <span style="color:DodgerBlue">string</span>  | No           | -                    | Working directory to run the script from. Defaults to the folder where the script is located.                |
| `gulpjs`                   | <span style="color:DodgerBlue">string</span>  | No           | -                    | Path to an alternative `gulp.js`, relative to the working directory, e.g. `node_modules/gulp/bin/gulp.js`.    |
| `publishJUnitResults`      | <span style="color:red">boolean</span>        | No           | `false`              | Publish JUnit test results produced by the gulp build to Azure Pipelines.                                     |
| `testResultsFiles`         | <span style="color:DodgerBlue">string</span>  | Conditional  | `**/TEST-*.xml`      | Test results files path, supports wildcards. Required when `publishJUnitResults: true`.                       |
| `testRunTitle`             | <span style="color:DodgerBlue">string</span>  | No           | -                    | Name for the test run. Used when `publishJUnitResults: true`.                                                 |
| `enableCodeCoverage`       | <span style="color:red">boolean</span>        | No           | `false`              | Enable code coverage using Istanbul.                                                                           |
| `testFramework`            | <span style="color:DodgerBlue">string</span>  | No           | `Mocha`              | Test framework: `Mocha` or `Jasmine`. Used when `enableCodeCoverage: true`.                                    |
| `srcFiles`                 | <span style="color:DodgerBlue">string</span>  | No           | -                    | Path to the source files to `hookRequire()`. Used when `enableCodeCoverage: true`.                             |
| `testFiles`                | <span style="color:DodgerBlue">string</span>  | Conditional  | `test/*.js`          | Path to the test script files. Required when `enableCodeCoverage: true`.                                       |

### Example of use

```yaml
steps:
- task: Npm@1
  inputs:
    command: 'install'

- task: gulp@1
  inputs:
    gulpFile: 'gulpfile.js'
    targets: 'build'
    gulpjs: 'node_modules/gulp/bin/gulp.js'
```
