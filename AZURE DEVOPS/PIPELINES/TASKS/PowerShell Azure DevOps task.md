#AZURE_DEVOPS 

# PowerShell Azure DevOps task

The PowerShell Azure DevOps tasks is a built-in pipeline task that allows to run PowerShell scripts on the build / release agent. 

It can execute an inline script placed inside the task definition or a `.ps1` file located in the repository or agent. 

It can run in any Agent OS independently whether is Linux or Windows. 

Also the script can be integrated with pipeline variables and parameters, environmental variables and Azure DevOps REST APIs. 

The basic syntax of this task is: 

* For **inline scripts**, define the script in the `script` variable using multiline `|`: 

```yaml
- task: PowerShell@2
  inputs:
    targetType: 'inline'
    script: |
      Write-Host "Multi-line script"
      $variable = "example"
```

* For an **existing script**, indicate the path in the `filePath` variable and optionally pass arguments to the script with `arguments`: 

```yaml
- task: PowerShell@2
  inputs:
    targetType: 'filePath'
    filePath: '$(System.DefaultWorkingDirectory)/script.ps1'
    arguments: '-param1 value1 -param2 value2'
```

## Shortcut

You can also add powershell simple commands directly using `pwsh` shortcut: 

```yaml
# file path
steps:
- pwsh: test.ps1

#inline script
steps:
- pwsh: Write-Host "Hello World"
```