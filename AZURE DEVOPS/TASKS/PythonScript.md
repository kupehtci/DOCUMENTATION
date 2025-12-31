#AZURE_DEVOPS 

# PythonScript Azure DevOps task

`PythonScript` is an Azure DevOps task type for executing a python script file or inline script. 

```yaml
# Python script v0
# Run a Python file or inline script.
- task: PythonScript@0
  inputs:
    scriptSource: 'filePath' # 'filePath' | 'inline'.
    scriptPath: # string. Required when scriptSource = filePath. Script path. 
    #script: # string. Required when scriptSource = inline. Script. 
    #arguments: # string. Arguments. 
  # Advanced
    #pythonInterpreter: # string. Python interpreter. 
    #workingDirectory: # string. Working directory. 
    #failOnStderr: false # boolean. Fail on standard error. Default: false.
```

* `scriptSource`

Define `filePath` in case you want to reference an existing python script in the origin path or `inline` for an inline script in the task: 

* In case you defined `filePath`, also define `scriptPath` indicating the path to the file. 
* In case you defined `inline`, write the script in the `script` parameter. 

* `arguments`

Define the arguments that will be passed into the script. They can be accessed inside the script using `sys.argv` as if they were passed through the CLI while invoking the script. 

