#AZURE_DEVOPS 

# UsePythonVersion

`UsePythonVersion@0` is an Azure DevOps pipeline task that downloads and selects an specific version of Python from the cache tool and configure the PATH variable. 

Basic syntax: 

```yaml
- task: UsePythonVersion@0
  inputs:
    versionSpec: '3.x'        # Required. Default: 3.x
    addToPath: true            # Optional. Default: true
    architecture: 'x64'        # Optional. Default: x64
```

* `versionSpec` indicates the version range using `3.x` or the exact version like `3.11.4` using SemVer ([[SemVer - Semantic Versioning]]). 
* `addToPath` is required for prepending the python version path to the `PATH` variable so any subsequent tasks use it without using output variables. 
* `architecture` defines the architecture of the system. (`x64` or `x86`). 

As an alternative to `addToPath`, the task `pythonLocation` output variable containing the directory of the installed python distribution. 

## Will have conflicts with the current installed Python version? 

Simple answer? No. 

If you already installed python in a self-hosted agent, this tasks with `addToPath: true` will **prepend** the python installation path in the `PATH` variable. 

This means that the retrieved version will appear first in `PATH` so it will be used before the currently server installation path defined in this environmental variable and its also **pipeline scoped**, so only applies to the current pipeline execution and doesn't persist on the agent after the pipeline completes. 

---
Date: 12/01/2025