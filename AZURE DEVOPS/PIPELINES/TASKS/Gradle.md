#AZURE_DEVOPS #JAVA 

# Gradle

`Gradle` is an [[Azure DevOps]] task that builds a project using a Gradle wrapper script (`gradlew`).

> Note: use [[JavaToolInstaller]] beforehand if the required JDK isn't already on the agent. SonarQube analysis configuration was moved out of this task into [[SonarQubePrepare]] / [[SonarQubeAnalyze]] / [[SonarQubePublish]]; this task only toggles running it (`sonarQubeRunAnalysis`).

Syntax template:

```yaml
- task: Gradle@3
  inputs:
    gradleWrapperFile: 'gradlew'   # Alias: wrapperScript. Required. Default: gradlew.
    #workingDirectory: ''          # Alias: cwd.
    #options: ''
    tasks: 'build'                 # Required. Default: build.

    # --- JUnit Test Results ---
    #publishJUnitResults: true
    testResultsFiles: '**/TEST-*.xml'   # Required when publishJUnitResults = true.
    #testRunTitle: ''

    # --- Code Coverage ---
    #codeCoverageToolOption: 'None'   # 'None' | 'Cobertura' | 'JaCoCo'. Alias: codeCoverageTool.
    codeCoverageClassFilesDirectories: 'build/classes/main/'   # Alias: classFilesDirectories. Required when codeCoverageToolOption != None.
    #codeCoverageClassFilter: ''      # Alias: classFilter.
    #codeCoverageFailIfEmpty: false   # Alias: failIfCoverageEmpty.
    #codeCoverageGradle5xOrHigher: true   # Alias: gradle5xOrHigher. Use when codeCoverageToolOption = JaCoCo.

    # --- Advanced ---
    javaHomeOption: 'JDKVersion'   # 'JDKVersion' | 'Path'. Alias: javaHomeSelection. Required. Default: JDKVersion.
    #jdkVersionOption: 'default'   # Alias: jdkVersion. Use when javaHomeOption = JDKVersion.
    #jdkDirectory: ''              # Alias: jdkUserInputPath. Required when javaHomeOption = Path.
    #jdkArchitectureOption: 'x64'  # 'x86' | 'x64' | 'arm64'. Alias: jdkArchitecture.
    #gradleOptions: '-Xmx1024m'    # Alias: gradleOpts.

    # --- Code Analysis ---
    #sonarQubeRunAnalysis: false   # Alias: sqAnalysisEnabled.
    #sqGradlePluginVersionChoice: 'specify'   # 'specify' | 'build'. Required when sonarQubeRunAnalysis = true.
    #sonarQubeGradlePluginVersion: '2.6.1'    # Alias: sqGradlePluginVersion. Required when sonarQubeRunAnalysis = true && sqGradlePluginVersionChoice = specify.
    #checkStyleRunAnalysis: false  # Alias: checkstyleAnalysisEnabled.
    #findBugsRunAnalysis: false    # Alias: findbugsAnalysisEnabled.
    #pmdRunAnalysis: false         # Alias: pmdAnalysisEnabled.
    #spotBugsAnalysis: false       # Alias: spotBugsAnalysisEnabled.
    #spotBugsGradlePluginVersionChoice: 'specify'   # 'specify' | 'build'. Required when spotBugsAnalysis = true.
    #spotbugsGradlePluginVersion: '4.7.0'           # Required when spotBugsAnalysis = true && spotBugsGradlePluginVersionChoice = specify.
```

### Build

| Parameter             | Type                                          | Required | Default   | Description                                                                                                          |
| ------------------------ | ----------------------------------------------- | --------- | ----------- | ----------------------------------------------------------------------------------------------------------------- |
| `gradleWrapperFile`      | <span style="color:DodgerBlue">string</span>  | Yes       | `gradlew`   | Location of the `gradlew` wrapper within the repo. Windows agents must use `gradlew.bat`.                          |
| `workingDirectory`       | <span style="color:DodgerBlue">string</span>  | No        | -           | Working directory to run the Gradle build in. Defaults to the repository root.                                     |
| `options`                | <span style="color:DodgerBlue">string</span>  | No        | -           | Command line options passed to the Gradle wrapper.                                                                  |
| `tasks`                  | <span style="color:DodgerBlue">string</span>  | Yes       | `build`     | Space-separated list of Gradle task(s) to execute (see `gradlew tasks`).                                            |

### JUnit test results

| Parameter               | Type                                          | Required    | Default          | Description                                                                                     |
| -------------------------- | ----------------------------------------------- | ------------ | ------------------- | --------------------------------------------------------------------------------------------------- |
| `publishJUnitResults`      | <span style="color:red">boolean</span>        | No           | `true`               | Publish JUnit test results produced by the build to Azure Pipelines (see [[PublishTestResults]]). |
| `testResultsFiles`         | <span style="color:DodgerBlue">string</span>  | Conditional  | `**/TEST-*.xml`      | Test results files path, supports wildcards. Required when `publishJUnitResults: true`.           |
| `testRunTitle`             | <span style="color:DodgerBlue">string</span>  | No           | -                    | Name for the JUnit test case results. Used when `publishJUnitResults: true`.                       |

### Code coverage

| Parameter                             | Type                                          | Required    | Default                 | Description                                                                                                                            |
| ---------------------------------------- | ----------------------------------------------- | ------------ | --------------------------- | -------------------------------------------------------------------------------------------------------------------------------------- |
| `codeCoverageToolOption`                 | <span style="color:DodgerBlue">string</span>  | No           | `None`                      | Code coverage tool: `None`, `Cobertura` or `JaCoCo`.                                                                                   |
| `codeCoverageClassFilesDirectories`      | <span style="color:DodgerBlue">string</span>  | Conditional  | `build/classes/main/`       | Comma-separated directories with class/archive files. Required when a coverage tool is set. For Gradle 4+, typically `build/classes/java/main`. |
| `codeCoverageClassFilter`                | <span style="color:DodgerBlue">string</span>  | No           | -                            | Comma-separated inclusion/exclusion filters, e.g. `+:com.*,+:org.*,-:my.app*.*`.                                                       |
| `codeCoverageFailIfEmpty`                | <span style="color:red">boolean</span>        | No           | `false`                     | Fail the build if code coverage produced no results.                                                                                    |
| `codeCoverageGradle5xOrHigher`           | <span style="color:red">boolean</span>        | No           | `true`                      | Set to `true` if the Gradle version is >= 5.x. Used when `codeCoverageToolOption: JaCoCo`.                                              |

### Advanced (Java / Gradle)

| Parameter                | Type                                          | Required    | Default        | Description                                                                                                                   |
| --------------------------- | ----------------------------------------------- | ------------ | ---------------- | --------------------------------------------------------------------------------------------------------------------------- |
| `javaHomeOption`            | <span style="color:DodgerBlue">string</span>  | Yes          | `JDKVersion`      | How to set `JAVA_HOME`: `JDKVersion` (discovered during the build) or `Path` (manual).                                       |
| `jdkVersionOption`          | <span style="color:DodgerBlue">string</span>  | No           | `default`         | JDK version to discover, e.g. `1.17`, `1.11`, `1.8`. Used when `javaHomeOption: JDKVersion`.                                 |
| `jdkDirectory`              | <span style="color:DodgerBlue">string</span>  | Conditional  | -                 | Path to set `JAVA_HOME` to. Required when `javaHomeOption: Path`.                                                            |
| `jdkArchitectureOption`     | <span style="color:DodgerBlue">string</span>  | No           | `x64`             | JDK architecture: `x86`, `x64` or `arm64`. Used when `jdkVersionOption != default`.                                          |
| `gradleOptions`             | <span style="color:DodgerBlue">string</span>  | No           | `-Xmx1024m`       | Sets `GRADLE_OPTS`, used to pass command-line arguments to the JVM (`-Xmx` sets the max memory).                             |

### Code analysis

| Parameter                             | Type                                          | Required    | Default      | Description                                                                                                              |
| ---------------------------------------- | ----------------------------------------------- | ------------ | -------------- | ------------------------------------------------------------------------------------------------------------------------ |
| `sonarQubeRunAnalysis`                    | <span style="color:red">boolean</span>        | No           | `false`         | Run SonarQube/SonarCloud analysis after the tasks in `tasks`. Requires a [[SonarQubePrepare]] task earlier in the pipeline. |
| `sqGradlePluginVersionChoice`             | <span style="color:DodgerBlue">string</span>  | Conditional  | `specify`       | SonarQube Gradle plugin version source: `specify` or `build` (plugin applied in `build.gradle`). Required when `sonarQubeRunAnalysis: true`. |
| `sonarQubeGradlePluginVersion`            | <span style="color:DodgerBlue">string</span>  | Conditional  | `2.6.1`         | SonarQube Gradle plugin version. Required when `sqGradlePluginVersionChoice: specify`.                                   |
| `checkStyleRunAnalysis`                   | <span style="color:red">boolean</span>        | No           | `false`         | Run Checkstyle with the default Sun checks; results are uploaded as build artifacts.                                     |
| `findBugsRunAnalysis`                     | <span style="color:red">boolean</span>        | No           | `false`         | Run FindBugs (removed in Gradle 6.0+; use SpotBugs instead).                                                             |
| `pmdRunAnalysis`                          | <span style="color:red">boolean</span>        | No           | `false`         | Run the PMD static analysis tool; results are uploaded as build artifacts.                                               |
| `spotBugsAnalysis`                        | <span style="color:red">boolean</span>        | No           | `false`         | Run SpotBugs (Gradle 5.6+).                                                                                               |
| `spotBugsGradlePluginVersionChoice`       | <span style="color:DodgerBlue">string</span>  | Conditional  | `specify`       | SpotBugs plugin version source: `specify` or `build`. Required when `spotBugsAnalysis: true`.                            |
| `spotbugsGradlePluginVersion`             | <span style="color:DodgerBlue">string</span>  | Conditional  | `4.7.0`         | SpotBugs Gradle plugin version. Required when `spotBugsGradlePluginVersionChoice: specify`.                              |

### Example of use

```yaml
- task: Gradle@3
  inputs:
    gradleWrapperFile: 'gradlew'
    tasks: 'build'
    javaHomeOption: 'JDKVersion'
    jdkVersionOption: '1.17'
    publishJUnitResults: true
    testResultsFiles: '**/TEST-*.xml'
```

### Generating the wrapper

```bash
gradle wrapper
```

This creates `gradlew`, `gradlew.bat` and `gradle/wrapper/` in the repo root; commit them so the agent can build without any Gradle install beyond the JVM.

For Maven-based Java projects, see [[Maven]].
