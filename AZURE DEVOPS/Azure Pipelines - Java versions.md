#AZURE_DEVOPS 

# Pipelines - Java versions

Self-hosted agents normally needs to support **multiple Java versions**, as projects and applications have different JDK requirements. 

In order to do so, its normal to maintain in an organization a sort of "portfolio" of Java applications developed across the time that have different Java versions and uses various build tools like Maven or Gradle. 

Self-Hosted agents doesn't automatically detect the java installations (OpenJDK distributions) which causes incompatibility issues when compiling. 

# How to install Java

You can manually download and install the java version in a centralized directory, recommended: 
* `C:\ProgramFiles\Java` on Windows. 
* `/usr/lib/jvm` on Linux systems. 

## How to switch versions on the go

With multiple java versions installed, you can switch versions directly in the pipeline, so the project's pipeline can choose which version is compatible with its compilation. 

Its **hardly recommended**, independently of the method of handling the java version to use; to set an environmental variable for each java version installed, following the `JAVA_HOME_{version}_{architecture}` name: 

```powershell
JAVA_HOME_11_X64: 'C:\ProgramFiles\jdk-11'
JAVA_HOME_25_X64: 'C:\ProgramFiles\jdk-25'
# And so on...
```

As an example in Windows: 
![[./IMAGES/java_home_envs.png]]

You can set the current version to use in different ways: 

## Manually

Azure DevOps uses the `JAVA_HOME` environmental variable to select the JDK used for the further tasks: 

```yaml
# Set JAVA_HOME
- script: |
    echo ##vso[task.setvariable variable=JAVA_HOME]$(JAVA_HOME_11_X64)
    echo ##vso[task.setvariable variable=PATH]$(JAVA_HOME_11_X64)\bin;$(PATH)
  displayName: 'Set Java 11'
```

## JavaToolInstaller 

`JavaToolInstaller` ([[JavaToolInstaller]]) is an pipeline task that acquires the specific version of Java from an azure blob storage or from a local installation and manages the `JAVA_HOME` environmental variable accordingly. 

By using `PreInstalled`, you can select an installed version of Java that is defined in `JAVA_HOME_{version}_{architecture}` variable and the task will automatically set the necessary environmental variables for you. 


## Maven or Gradle tasks

Maven or Gradle tasks allows to specify the JDK version to use directly in the task configuration. It will automatically search for the corresponding `JAVA_HOME_{version}_{architecture}` environmental variable: 

```yaml
- task: Maven@3
  inputs:
    mavenPomFile: 'pom.xml'
    javaHomeOption: 'JDKVersion'
    jdkVersionOption: '1.17'
    jdkArchitectureOption: 'x64'
```



