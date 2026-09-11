#AZURE_DEVOPS 

# Bash

`Bash` is an Azure DevOps task that runs a Bash script on macOS, Linux, or Windows.

> Note: on a Windows host this runs bash from the WSL default distribution (WSL must be installed, and is preinstalled on Microsoft-hosted Windows agents). Classic pipelines on Windows agents use Git Bash instead.

Syntax template:

```yaml
- task: Bash@3
  inputs:
    #targetType: 'filePath'   # 'filePath' | 'inline'. Default: filePath.
    filePath: ''              # Required when targetType = filePath.
    #arguments: ''            # Optional. Use when targetType = filePath.
    #script: ''               # Required when targetType = inline.

    # --- Advanced ---
    #workingDirectory: ''
    #failOnStderr: false
    #bashEnvValue: ''
```

| Parameter          | Type                                          | Required    | Default                                   | Description                                                                                                                 |
| -------------------- | ----------------------------------------------- | ------------ | ---------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------- |
| `targetType`        | <span style="color:DodgerBlue">string</span>  | No           | `filePath`                                     | Type of script to run: `filePath` (existing script) or `inline`.                                                            |
| `filePath`          | <span style="color:DodgerBlue">string</span>  | Conditional  | -                                               | Path of the script to execute. Fully qualified or relative to `$(System.DefaultWorkingDirectory)`. Required when `targetType: filePath`. |
| `arguments`         | <span style="color:DodgerBlue">string</span>  | No           | -                                               | Arguments passed to the shell script, ordinal or named. Used when `targetType: filePath`.                                   |
| `script`            | <span style="color:DodgerBlue">string</span>  | Conditional  | `# Write your commands here\n\necho 'Hello world'` | Contents of the script. Required when `targetType: inline`.                                                                 |
| `workingDirectory`  | <span style="color:DodgerBlue">string</span>  | No           | `$(Build.SourcesDirectory)`                    | Working directory to run the command in.                                                                                    |
| `failOnStderr`      | <span style="color:red">boolean</span>        | No           | `false`                                        | Fail the task if any errors are written to the `StandardError` stream.                                                      |
| `bashEnvValue`      | <span style="color:DodgerBlue">string</span>  | No           | -                                               | Path of a startup file to execute before running the script, expanded and used as the `BASH_ENV` environment variable for this task. |

### Shortcut

There's a YAML shortcut for inline scripts: 

```yaml
steps:
- bash: echo 'Hello world'
  displayName: 'Say hello'
```

### Example of use

Run a script file with arguments: 

```yaml
- task: Bash@3
  inputs:
    targetType: 'filePath'
    filePath: '$(System.DefaultWorkingDirectory)/scripts/deploy.sh'
    arguments: '-env prod -verbose'
```

Run an inline script and map a secret variable into the environment (secret variables aren't mapped automatically): 

```yaml
- task: Bash@3
  inputs:
    targetType: 'inline'
    script: echo $MYSECRET
  env:
    MYSECRET: $(Foo)
```

### Bash startup files (`BASH_ENV`)

The task invokes Bash as a non-interactive, non-login shell, so profile files like `~/.bash_profile` aren't sourced automatically. To run commands before the script (e.g. load a virtual environment), set the `BASH_ENV` variable, either as a pipeline variable, via `bashEnvValue`, or via the task's `env`: 

```yaml
- task: Bash@3
  inputs:
    targetType: 'inline'
    script: env
    bashEnvValue: '~/.profile'
```

> Note: scripts checked into the repo should be executable (`chmod +x`); otherwise the task shows a warning and `source`s the file instead.
