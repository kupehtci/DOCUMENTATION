#AZURE_DEVOPS #DOTNET #NODE 

# Unit Testing and Code Coverage in Azure Pipelines

This page covers the concepts behind unit testing and code coverage in a pipeline, the tooling used in .NET and npm/Node projects to produce them, and how the resulting files (`.trx`, `.coverage`, `.xml`) are converted and published with [[PublishTestResults]] and [[PublishCodeCoverageResults]].

For general testing theory (testing types, purpose, limitations), see [[Testing]].

## Unit testing concepts

* A **unit test** exercises a single unit of code (a method or class) in isolation from its dependencies (database, network, filesystem), which are replaced with fakes/mocks. This keeps tests fast and deterministic, so they can run on every build.
* A **test run** is the execution of a set of tests; its outcome (pass/fail/skipped counts, duration, stack traces) is what gets published to the pipeline's **Tests** tab.
* **Test results files** (`.trx`, JUnit-style `.xml`) describe *what ran and whether it passed* — they say nothing about how much of the source code those tests actually exercised. That is the role of **code coverage**.
* A pipeline typically has two related but independent publishing steps:
  * [[PublishTestResults]] → publishes the **test run outcome** (pass/fail).
  * [[PublishCodeCoverageResults]] → publishes the **coverage** achieved by that run.

## Code coverage concepts

Code coverage measures how much of the source code was executed while the tests ran. It answers "how much of my code did the tests touch", not "is my code correct" — 100% coverage does not mean the code is bug-free, it only means every line/branch ran at least once during the tests.

Common coverage metrics:

| Metric              | Meaning                                                                 |
| ---------------------- | -------------------------------------------------------------------------- |
| Line coverage         | % of executable source lines run at least once.                        |
| Branch coverage       | % of `if`/`switch`/loop branches (both true and false paths) exercised. |
| Method/function coverage | % of methods or functions invoked at least once.                    |
| Class coverage        | % of classes with at least one method covered.                         |

Coverage is produced by an **instrumentation/collector** that hooks into the test run (e.g. Coverlet, Istanbul, JaCoCo), and is written out as a **report file** in one of several formats. Azure Pipelines' [[PublishCodeCoverageResults]] task only understands two of those formats natively: **Cobertura** and **JaCoCo** — everything else needs to be converted first.

| Format         | Typical origin                          | Natively supported by `PublishCodeCoverageResults`? |
| ----------------- | ------------------------------------------ | ------------------------------------------------------ |
| Cobertura `.xml`  | Coverlet (.NET), Istanbul/nyc (Node), Python `coverage.py` | Yes                                                  |
| JaCoCo `.xml`     | JaCoCo (Java/Maven/Gradle)              | Yes                                                  |
| VSTest `.coverage`| Visual Studio Test Platform (`--collect "Code Coverage"`) | No — binary format, must be converted to `.xml` first |
| OpenCover `.xml`  | Coverlet (alternate output format)      | No — convert to Cobertura first                     |
| lcov `.info`      | Istanbul/nyc (Node), many native tools  | No — convert to Cobertura first                     |

## .NET unit testing and coverage

### Running tests

Unit tests run with `dotnet test` (via the [[DotNetCoreCLI]] task, `test` command), which executes xUnit/NUnit/MSTest projects and can emit a `.trx` results file with `--logger trx`, later published with [[PublishTestResults]] (`testResultsFormat: VSTest`).

### Producing coverage: `.coverage` vs Cobertura `.xml`

.NET has two common ways to collect coverage during `dotnet test`, and they produce different file types:

* **`--collect "Code Coverage"`** uses the Visual Studio Test Platform collector. It produces a binary **`.coverage`** file. This format is Windows/Visual Studio-oriented, not human-readable, and **not** directly accepted by [[PublishCodeCoverageResults]] — it must be converted to XML first (see below).
* **`--collect "XPlat Code Coverage"`** uses [Coverlet](https://github.com/coverlet-coverage/coverlet)'s cross-platform data collector (bundled with `Microsoft.NET.Test.Sdk`), which works on Windows, Linux and macOS agents. It writes coverage directly as **`coverage.cobertura.xml`** under `$(Agent.TempDirectory)`, one file per test project — no conversion needed, so this is the recommended option for Azure Pipelines.

```yaml
- task: DotNetCoreCLI@2
  displayName: 'Run tests with coverage'
  inputs:
    command: 'test'
    projects: '**/*Tests.csproj'
    arguments: '--configuration Release --logger trx --collect:"XPlat Code Coverage"'
    publishTestResults: false   # published explicitly below for clarity

- task: PublishTestResults@2
  inputs:
    testResultsFormat: 'VSTest'
    testResultsFiles: '**/*.trx'

- task: PublishCodeCoverageResults@2
  inputs:
    summaryFileLocation: '$(Agent.TempDirectory)/**/coverage.cobertura.xml'
```

Coverlet can also be referenced directly as a package (`coverlet.msbuild` or `coverlet.console`) instead of the collector, with output format chosen explicitly:

```bash
dotnet test --configuration Release /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput=./TestResults/coverage/
```

### Converting `.coverage` to `.xml`

If the pipeline (or a Windows-only step) already produces a `.coverage` binary file and Cobertura output isn't an option, convert it with the cross-platform `dotnet-coverage` CLI tool (`dotnet tool install -g dotnet-coverage`):

```bash
dotnet-coverage merge TestResults/**/*.coverage -f xml -o TestResults/coverage.xml
```

This produces an XML file in the VSTest coverage schema, not Cobertura. To get a Cobertura file that [[PublishCodeCoverageResults]] can consume directly, run the merge with `-f cobertura` instead:

```bash
dotnet-coverage merge TestResults/**/*.coverage -f cobertura -o TestResults/coverage.cobertura.xml
```

> Older/Windows-only alternative: `CodeCoverage.exe analyze` (bundled with Visual Studio) converts `.coverage` → `.coveragexml`, which then needs a tool like [ReportGenerator](https://github.com/danielpalme/ReportGenerator) to turn into Cobertura for publishing, or into an HTML report for browsing.

## npm / Node unit testing and coverage

### Running tests

Tests run with the project's own runner (Jest, Mocha, Jasmine, Vitest), invoked via the [[Npm]] task or a plain `script` step. There is no built-in "collect+publish" wiring like [[DotNetCoreCLI]] has — results and coverage are published explicitly afterwards.

### Producing coverage

* **Jest**: has built-in coverage via Istanbul. Configure `coverageReporters` in `jest.config.js` (or CLI flags) to include `cobertura` alongside the human-readable `text`/`html` reporters:

```yaml
- task: Npm@1
  inputs:
    command: 'ci'

- script: npx jest --ci --reporters=default --reporters=jest-junit --coverage --coverageReporters=cobertura --coverageReporters=html
  displayName: 'Run tests with coverage'
  env:
    JEST_JUNIT_OUTPUT_DIR: './test-results'

- task: PublishTestResults@2
  inputs:
    testResultsFormat: 'JUnit'
    testResultsFiles: 'test-results/*.xml'

- task: PublishCodeCoverageResults@2
  inputs:
    summaryFileLocation: '$(System.DefaultWorkingDirectory)/coverage/cobertura-coverage.xml'
```

(`jest-junit` is a reporter package that turns Jest's results into JUnit XML for [[PublishTestResults]]; Jest has no native JUnit output.)

* **Mocha / other runners**: instrument with [nyc](https://github.com/istanbuljs/nyc) (the Istanbul CLI) and ask it for a Cobertura report:

```bash
npx nyc --reporter=cobertura --reporter=lcov mocha 'test/**/*.spec.js'
```

This writes `coverage/cobertura-coverage.xml` (ready for [[PublishCodeCoverageResults]]) and `coverage/lcov.info` (useful for other tools, e.g. IDE coverage gutters or SonarQube).

### Converting `lcov.info` to Cobertura

If only an `lcov.info` file is available (a common default for JS coverage tools) and the reporter can't be reconfigured to emit Cobertura directly, convert it with a small converter package, for example [`lcov-to-cobertura-xml`](https://www.npmjs.com/package/lcov-to-cobertura-xml):

```bash
npx lcov-to-cobertura-xml coverage/lcov.info -o coverage/cobertura-coverage.xml
```

## Summary: file types involved

| File                          | Produced by                                              | Consumed by                                                  |
| -------------------------------- | ----------------------------------------------------------- | ------------------------------------------------------------ |
| `.trx`                          | `dotnet test --logger trx`                                | [[PublishTestResults]] (`testResultsFormat: VSTest`)          |
| JUnit `.xml`                    | Jest + `jest-junit`, Mocha + `mocha-junit-reporter`, etc.  | [[PublishTestResults]] (`testResultsFormat: JUnit`)            |
| `.coverage`                     | `dotnet test --collect "Code Coverage"` (VSTest collector) | Nothing directly — convert to `.xml`/Cobertura with `dotnet-coverage` first |
| `coverage.cobertura.xml`        | Coverlet (`XPlat Code Coverage` collector or package), Istanbul/nyc `cobertura` reporter | [[PublishCodeCoverageResults]] directly                       |
| `lcov.info`                     | Istanbul/nyc `lcov` reporter                              | Convert to Cobertura first (e.g. `lcov-to-cobertura-xml`), then [[PublishCodeCoverageResults]] |
| `jacoco.xml`                    | JaCoCo (Java)                                              | [[PublishCodeCoverageResults]] directly (`codeCoverageTool: JaCoCo` on v1)      |

See [[PublishTestResults]] and [[PublishCodeCoverageResults]] for the full task syntax and parameters.
