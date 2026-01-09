#AZURE_DEVOPS 

# JavaToolInstaller

`JavaToolInstaller` is an pipeline task that acquires the specific version of Java from an azure blob storage or from a local installation and manages the `JAVA_HOME` environmental variable accordingly. 

Its recommended to use this task at the begin of the pipeline, so the further tasks uses the appropriate java version and to include a 'check' task before it, so you can verify that the correct java version is being used: 

```yaml
- task: PowerShell@2
  targetType: 'inline'
  script: |
	  Write-Host "Verify Java version"
	  java -version
```

The basic syntax of this task is: 
```yaml
- task: JavaToolInstaller@0
  inputs:
    versionSpec: '8'           # Required. JDK version
    jdkArchitectureOption: x64  # Architecture
    jdkSourceOption: PreInstalled  # Source type
```

It has three different operating methods: 

* `PreInstalled`: (Only on windows agents) searches for a preinstalled java version, that need to be referenced in the environmental variables such as `JAVA_HOME_{version}_{architecture}` like `JAVA_HOME_11_X64` (X64 in Upper case): 

```yaml
- task: JavaToolInstaller@0
  inputs:
    versionSpec: '8'
    jdkArchitectureOption: 'x64'
    jdkSourceOption: 'PreInstalled'
```

* `LocalDirectory`: uses the compressed JDK specified in `jdkFile` variable that should contain `bin`, `lib`, `include` and other needed directories: 

```yaml
- task: JavaToolInstaller@0
    inputs:
      versionSpec: "11"
      jdkArchitectureOption: x64
      jdkSourceOption: LocalDirectory
      jdkFile: "/builds/openjdk-11.0.2_linux-x64_bin.tar.gz"
      jdkDestinationDirectory: "/builds/binaries/externals"
      cleanDestinationDirectory: true
```

* `AzureStorage`: pulls a JDK installation from a zip or gz compressed file that is stored in an Azure Storage Account ([[AZURE - Storage Account]]). 

```yaml
- task: JavaToolInstaller@0
  inputs:
    versionSpec: '6'
    jdkArchitectureOption: 'x64'
    jdkSourceOption: AzureStorage
    azureResourceManagerEndpoint: myARMServiceConnection
    azureStorageAccountName: myAzureStorageAccountName
    azureContainerName: myAzureStorageContainerName
    azureCommonVirtualFile: 'jdk1.6.0_45.zip'
    jdkDestinationDirectory: '$(agent.toolsDirectory)/jdk6'
    cleanDestinationDirectory: false
```


The source code of this task can be seen in: https://github.com/microsoft/azure-pipelines-tasks/blob/master/Tasks/JavaToolInstallerV0/javatoolinstaller.ts written in typescript. 



