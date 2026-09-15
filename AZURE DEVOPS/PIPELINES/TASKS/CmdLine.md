#AZURE_DEVOPS 

# CmdLine

`CmdLine` is an [[Azure DevOps]] task that runs a command line script using Bash on Linux/macOS and `cmd.exe` on Windows.

Syntax template:

```yaml
- task: CmdLine@2
  inputs:
    script: ''   # Required.

    # --- Advanced ---
    #workingDirectory: ''
    #failOnStderr: false
```

| Parameter          | Type                                          | Required | Default                                       | Description                                                                     |
| -------------------- | ----------------------------------------------- | --------- | ------------------------------------------------- | ---------------------------------------------------------------------------------- |
| `script`            | <span style="color:DodgerBlue">string</span>  | Yes       | `echo Write your commands here\n\necho Hello world` | Contents of the script to run.                                                   |
| `workingDirectory`  | <span style="color:DodgerBlue">string</span>  | No        | `$(Build.SourcesDirectory)`                       | Working directory to run the command in.                                        |
| `failOnStderr`      | <span style="color:red">boolean</span>        | No        | `false`                                            | Fail the task if any errors are written to the `StandardError` stream.          |

### Shortcut

There's a YAML shortcut for inline scripts: 

```yaml
steps:
- script: dir
  workingDirectory: $(Agent.BuildDirectory)
  displayName: List contents of a folder
  env:
    aVarFromYaml: someValue
```

### Example of use

```yaml
steps:
- script: date /t
  displayName: Get the date
- script: |
    set MYVAR=foo
    set
  displayName: Set a variable and then display all
```

> Important: on Windows, running a `.cmd`/`.bat` file from another one requires `call`, otherwise the first script is terminated after the nested call. Tools like `npm` are actually batch files on Windows, so always use `call npm <command>` in a Command Line task on Windows.

For a Bash-only equivalent see [[Bash]].
