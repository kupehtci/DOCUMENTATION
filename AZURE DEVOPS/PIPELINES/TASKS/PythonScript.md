#AZURE_DEVOPS 

# PythonScript Azure DevOps task

`PythonScript` is an Azure DevOps task type for executing a python script file or inline script. 

Basic syntax of the task: 
```yaml
# Python script v0
# Run a Python file or inline script.
- task: PythonScript@0
  inputs:
    scriptSource: 'filePath' # 'filePath' | 'inline'.
    scriptPath: # string. Required when scriptSource = filePath. Script path. 
    script: # string. Required when scriptSource = inline. Script. 
    #arguments: # string. Arguments. 
  # Advanced
    #pythonInterpreter: # string. Python interpreter. 
    #workingDirectory: # string. Working directory. 
    #failOnStderr: false # boolean. Fail on standard error. Default: false.
```

| Parameter            | Type                                          | Required    | Default                       | Description                                                                                                          |
| ---------------------- | ----------------------------------------------- | ------------ | -------------------------------- | ------------------------------------------------------------------------------------------------------------------- |
| `scriptSource`        | <span style="color:DodgerBlue">string</span>  | No           | `filePath`                       | Origin of the script: `filePath` (existing `.py` file) or `inline` (script embedded in the task).                   |
| `scriptPath`          | <span style="color:DodgerBlue">string</span>  | Conditional  | -                                 | Path to the script. Required when `scriptSource: filePath`. Take into account the checkout repository paths.       |
| `script`              | <span style="color:DodgerBlue">string</span>  | Conditional  | -                                 | Script in multiline string format. Required when `scriptSource: inline`.                                            |
| `arguments`           | <span style="color:DodgerBlue">string</span>  | No           | -                                 | Arguments passed into the script. Accessed inside the script using `sys.argv`, as if passed through the CLI.       |
| `pythonInterpreter`   | <span style="color:DodgerBlue">string</span>  | No           | -                                 | Python interpreter to use, either a path like `/usr/bin/python3.9` or a command like `python3`.                     |
| `workingDirectory`    | <span style="color:DodgerBlue">string</span>  | No           | `$(System.DefaultWorkingDirectory)` | Directory where the script executes.                                                                              |
| `failOnStderr`        | <span style="color:red">boolean</span>        | No           | `false`                          | Fail the task if the script writes anything into stderr. Set this for strict error detection in the script execution. |



