#AZURE_DEVOPS #JAVA 

# Maven

`Maven` is an Azure DevOps task that builds, tests and deploys projects with Apache Maven.

> Note: use [[JavaToolInstaller]] beforehand if the required JDK isn't already on the agent. SonarQube analysis configuration was moved out of this task into [[SonarQubePrepare]] / [[SonarQubeAnalyze]] / [[SonarQubePublish]]; this task only toggles running it (`sonarQubeRunAnalysis`).

Syntax template:

```yaml
- task: Maven@3
  inputs:
    mavenPOMFile: 'pom.xml'   # Required. Default: pom.xml.
    #goals: 'package'
    #options: ''

    # --- JUnit Test Results ---
    #publishJUnitResults: true
    testResultsFiles: '**/surefire-reports/TEST-*.xml'   # Required when publishJUnitResults = true.
    #testRunTitle: ''
    #allowBrokenSymlinks: true   # Alias: allowBrokenSymbolicLinks.

    # --- Code Coverage ---
    #codeCoverageToolOption: 'None'   # 'None' | 'Cobertura' | 'JaCoCo'. Alias: codeCoverageTool.
    #codeCoverageClassFilter: ''      # Alias: classFilter. Use when codeCoverageToolOption != None.
    #codeCoverageClassFilesDirectories: ''  # Alias: classFilesDirectories. Required for multi-module when codeCoverageToolOption = JaCoCo.
    #codeCoverageSourceDirectories: ''      # Alias: srcDirectories. Required for multi-module when codeCoverageToolOption = JaCoCo.
    #codeCoverageFailIfEmpty: false   # Alias: failIfCoverageEmpty.
    #codeCoverageRestoreOriginalPomXml: false  # Alias: restoreOriginalPomXml.

    # --- Advanced ---
    javaHomeOption: 'JDKVersion'   # 'JDKVersion' | 'Path'. Alias: javaHomeSelection. Required. Default: JDKVersion.
    #jdkVersionOption: 'default'   # Alias: jdkVersion. Use when javaHomeOption = JDKVersion.
    #jdkDirectory: ''              # Alias: jdkUserInputPath. Required when javaHomeOption = Path.
    #jdkArchitectureOption: 'x64'  # 'x86' | 'x64' | 'arm64'. Alias: jdkArchitecture.
    mavenVersionOption: 'Default'  # 'Default' | 'Path'. Alias: mavenVersionSelection. Required. Default: Default.
    #mavenDirectory: ''            # Alias: mavenPath. Required when mavenVersionOption = Path.
    #mavenSetM2Home: false
    #mavenOptions: '-Xmx1024m'     # Alias: mavenOpts.
    #mavenAuthenticateFeed: false  # Alias: mavenFeedAuthenticate.
    #effectivePomSkip: false       # Alias: skipEffectivePom.

    # --- Code Analysis ---
    #sonarQubeRunAnalysis: false   # Alias: sqAnalysisEnabled.
    #isJacocoCoverageReportXML: false   # Use when sonarQubeRunAnalysis = true && codeCoverageToolOption = JaCoCo.
    #sqMavenPluginVersionChoice: 'latest'  # 'latest' | 'pom'. Required when sonarQubeRunAnalysis = true.
    #checkStyleRunAnalysis: false  # Alias: checkstyleAnalysisEnabled.
    #pmdRunAnalysis: false         # Alias: pmdAnalysisEnabled.
    #findBugsRunAnalysis: false    # Alias: findbugsAnalysisEnabled.
    #spotBugsRunAnalysis: false    # Alias: spotBugsAnalysisEnabled.
    #spotBugsVersion: '4.5.3.0'    # Alias: spotBugsMavenPluginVersion. Use when spotBugsRunAnalysis = true.
    #spotBugsGoal: 'spotbugs'      # 'spotbugs' | 'check'. Use when spotBugsRunAnalysis = true.
    #failWhenBugsFound: true       # Alias: spotBugsFailWhenBugsFound. Use when spotBugsRunAnalysis = true && spotBugsGoal = check.
```

### Build

| Parameter        | Type                                          | Required | Default   | Description                                                                                             |
| ------------------ | ----------------------------------------------- | --------- | ----------- | --------------------------------------------------------------------------------------------------------- |
| `mavenPOMFile`     | <span style="color:DodgerBlue">string</span>  | Yes       | `pom.xml`   | Relative path from the repository root to the Maven POM file.                                           |
| `goals`            | <span style="color:DodgerBlue">string</span>  | No        | `package`   | Maven goal(s) to run, e.g. `package`, `install`, `deploy`. Must not be left blank.                       |
| `options`          | <span style="color:DodgerBlue">string</span>  | No        | -           | Additional Maven command-line options.                                                                   |

### JUnit test results

| Parameter               | Type                                          | Required    | Default                              | Description                                                                                        |
| -------------------------- | ----------------------------------------------- | ------------ | ----------------------------------------- | ---------------------------------------------------------------------------------------------------- |
| `publishJUnitResults`      | <span style="color:red">boolean</span>        | No           | `true`                                     | Publish JUnit test results produced by the Maven build to Azure Pipelines (see [[PublishTestResults]]). |
| `testResultsFiles`         | <span style="color:DodgerBlue">string</span>  | Conditional  | `**/surefire-reports/TEST-*.xml`           | Path/pattern of test results files to publish. Required when `publishJUnitResults: true`.           |
| `testRunTitle`             | <span style="color:DodgerBlue">string</span>  | No           | -                                           | Name for the test run. Used when `publishJUnitResults: true`.                                        |
| `allowBrokenSymlinks`      | <span style="color:red">boolean</span>        | No           | `true`                                      | If `false`, fails the build when a broken symbolic link is found while publishing results. Used when `publishJUnitResults: true`. |

### Code coverage

| Parameter                             | Type                                          | Required    | Default              | Description                                                                                                             |
| ---------------------------------------- | ----------------------------------------------- | ------------ | ----------------------- | --------------------------------------------------------------------------------------------------------------------- |
| `codeCoverageToolOption`                 | <span style="color:DodgerBlue">string</span>  | No           | `None`                  | Code coverage tool: `None`, `Cobertura` or `JaCoCo`. Enabling it inserts the `clean` goal into the Maven goals list.    |
| `codeCoverageClassFilter`                | <span style="color:DodgerBlue">string</span>  | No           | -                        | Comma-separated inclusion/exclusion filters, e.g. `+:com.*,+:org.*,-:my.app*.*`. Used when a coverage tool is set.      |
| `codeCoverageClassFilesDirectories`      | <span style="color:DodgerBlue">string</span>  | Conditional  | -                        | Comma-separated relative paths to directories with class/archive files. Required for multi-module projects with `JaCoCo`. |
| `codeCoverageSourceDirectories`          | <span style="color:DodgerBlue">string</span>  | Conditional  | -                        | Comma-separated relative paths to source directories. Required for multi-module projects with `JaCoCo`.                |
| `codeCoverageFailIfEmpty`                | <span style="color:red">boolean</span>        | No           | `false`                 | Fail the build if code coverage produced no results.                                                                    |
| `codeCoverageRestoreOriginalPomXml`      | <span style="color:red">boolean</span>        | No           | `false`                 | Restore the original `pom.xml` after execution (coverage tools modify it to produce results).                          |

### Advanced (Java / Maven)

| Parameter                | Type                                          | Required    | Default        | Description                                                                                                                                     |
| --------------------------- | ----------------------------------------------- | ------------ | ---------------- | ----------------------------------------------------------------------------------------------------------------------------------------------- |
| `javaHomeOption`            | <span style="color:DodgerBlue">string</span>  | Yes          | `JDKVersion`      | How to set `JAVA_HOME`: `JDKVersion` (discovered during the build) or `Path` (manual).                                                          |
| `jdkVersionOption`          | <span style="color:DodgerBlue">string</span>  | No           | `default`         | JDK version to discover, e.g. `1.21`, `1.17`, `1.11`, `1.8`. Used when `javaHomeOption: JDKVersion`. On self-hosted agents relies on `JAVA_HOME_{version}_{arch}` (see [[JavaToolInstaller]]). |
| `jdkDirectory`              | <span style="color:DodgerBlue">string</span>  | Conditional  | -                 | Path to set `JAVA_HOME` to. Required when `javaHomeOption: Path`.                                                                               |
| `jdkArchitectureOption`     | <span style="color:DodgerBlue">string</span>  | No           | `x64`             | JDK architecture: `x86`, `x64` or `arm64`. Used when `jdkVersionOption != default`.                                                              |
| `mavenVersionOption`        | <span style="color:DodgerBlue">string</span>  | Yes          | `Default`         | Maven version: `Default` or `Path` (custom installation).                                                                                        |
| `mavenDirectory`            | <span style="color:DodgerBlue">string</span>  | Conditional  | -                 | Custom path to the Maven installation, e.g. `/usr/share/maven`. Required when `mavenVersionOption: Path`.                                        |
| `mavenSetM2Home`            | <span style="color:red">boolean</span>        | No           | `false`           | Set the `M2_HOME` variable to the custom Maven installation path. Used when `mavenVersionOption: Path`.                                          |
| `mavenOptions`              | <span style="color:DodgerBlue">string</span>  | No           | `-Xmx1024m`       | Sets `MAVEN_OPTS`, used to pass command-line arguments to the JVM (`-Xmx` sets the max memory).                                                  |
| `mavenAuthenticateFeed`     | <span style="color:red">boolean</span>        | No           | `false`           | Automatically authenticate with Azure Artifacts feeds. Deselect for faster builds if feeds aren't used.                                          |
| `effectivePomSkip`          | <span style="color:red">boolean</span>        | No           | `false`           | Authenticate with Artifacts feeds using only the POM (skip generating the effective POM).                                                       |

### Code analysis

| Parameter                    | Type                                          | Required    | Default      | Description                                                                                                             |
| -------------------------------- | ----------------------------------------------- | ------------ | -------------- | ------------------------------------------------------------------------------------------------------------------- |
| `sonarQubeRunAnalysis`           | <span style="color:red">boolean</span>        | No           | `false`         | Run SonarQube/SonarCloud analysis after the goals in `goals`. Requires a [[SonarQubePrepare]] task earlier in the pipeline. |
| `isJacocoCoverageReportXML`      | <span style="color:red">boolean</span>        | No           | `false`         | Use XML JaCoCo reports for SonarQube analysis. Used when `sonarQubeRunAnalysis: true && codeCoverageToolOption: JaCoCo`. |
| `sqMavenPluginVersionChoice`     | <span style="color:DodgerBlue">string</span>  | Conditional  | `latest`        | SonarQube Maven plugin version: `latest` or `pom` (version declared in `pom.xml`). Required when `sonarQubeRunAnalysis: true`. |
| `checkStyleRunAnalysis`         | <span style="color:red">boolean</span>        | No           | `false`         | Run Checkstyle with the default Sun checks (or the config in `pom.xml`); results are uploaded as build artifacts.       |
| `pmdRunAnalysis`                | <span style="color:red">boolean</span>        | No           | `false`         | Run the PMD static analysis tool; results are uploaded as build artifacts.                                              |
| `findBugsRunAnalysis`           | <span style="color:red">boolean</span>        | No           | `false`         | Run the FindBugs static analysis tool; results are uploaded as build artifacts.                                         |
| `spotBugsRunAnalysis`           | <span style="color:red">boolean</span>        | No           | `false`         | Run the SpotBugs analysis plugin (successor to FindBugs).                                                               |
| `spotBugsVersion`               | <span style="color:DodgerBlue">string</span>  | No           | `4.5.3.0`       | SpotBugs Maven plugin version. Used when `spotBugsRunAnalysis: true`.                                                   |
| `spotBugsGoal`                  | <span style="color:DodgerBlue">string</span>  | No           | `spotbugs`      | SpotBugs goal: `spotbugs` (report) or `check` (fails the pipeline on bugs). Used when `spotBugsRunAnalysis: true`.      |
| `failWhenBugsFound`             | <span style="color:red">boolean</span>        | No           | `true`          | Fail when bugs are found. Used when `spotBugsRunAnalysis: true && spotBugsGoal: check`.                                 |

### Example of use

```yaml
- task: Maven@3
  inputs:
    mavenPOMFile: 'pom.xml'
    goals: 'package'
    javaHomeOption: 'JDKVersion'
    jdkVersionOption: '1.17'
    mavenVersionOption: 'Default'
    publishJUnitResults: true
    testResultsFiles: '**/surefire-reports/TEST-*.xml'
    codeCoverageToolOption: 'JaCoCo'
```

> Note: for multi-module projects, `codeCoverageClassFilesDirectories` and `codeCoverageSourceDirectories` are required, not optional.

For Gradle-based Java projects, see [[Gradle]].
