#AZURE_DEVOPS #DOTNET 

# NuGetCommand

**NuGetCommand** is an Azure DevOps pipeline task to execute `nuget` commands in order to restore, pack or insert NuGet packages for .Net applications. 

This task allows to interact with public `nuget.org` as well as Azure Artifacts[^1] or other repositiories like Nexus [^2]. 


Basic syntax: 
```yaml
- task: NuGetCommand@2
  inputs:
    command: 'restore' # 'restore' | 'pack' | 'push' | 'custom'. Required. 
    restoreSolution: '**/*.sln' 
    #packagesToPush: # required with command: 'push'
    #nuGetFeedType: # required with command: 'push' 
    #publishVstsFeed: # string. Alias: feedPublish. Required when command = push && nuGetFeedType = internal. Target feed. 
    #allowPackageConflicts: false # boolean. Optional. Use when command = push && nuGetFeedType = internal. Allow duplicates to be skipped. Default: false.
    #publishFeedCredentials: # string. Alias: externalEndpoint. Required when command = push && nuGetFeedType = external. NuGet server. 
    #packagesToPack: '**/*.csproj' # string. Alias: searchPatternPack. Required when command = pack. Path to csproj or nuspec file(s) to pack. Default: **/*.csproj.
    #configuration: '$(BuildConfiguration)' # string. Alias: configurationToPack. Optional. Use when command = pack. Configuration to package. Default: $(BuildConfiguration).
    #packDestination: '$(Build.ArtifactStagingDirectory)' # string. Alias: outputDir. Optional. Use when command = pack. Package folder. Default: $(Build.ArtifactStagingDirectory).
    #arguments: # string. Required when command = custom. Command and arguments. 
  # Feeds and authentication
    feedsToUse: 'select' # 'select' | 'config'. Alias: selectOrConfig. Required when command = restore. Feeds to use. Default: select.
    #vstsFeed: # string. Alias: feedRestore. Optional. Use when selectOrConfig = select && command = restore. Use packages from this Azure Artifacts/TFS feed. Select from the dropdown or enter [project name/]feed name. 
    #includeNuGetOrg: true # boolean. Optional. Use when selectOrConfig = select && command = restore. Use packages from NuGet.org. Default: true.
    #nugetConfigPath: # string. Optional. Use when selectOrConfig = config && command = restore. Path to NuGet.config. 
    #externalFeedCredentials: # string. Alias: externalEndpoints. Optional. Use when selectOrConfig = config && command = restore. Credentials for feeds outside this organization/collection. 
  # Advanced
    #noCache: false # boolean. Optional. Use when command = restore. Disable local cache. Default: false.
    #disableParallelProcessing: false # boolean. Optional. Use when command = restore. Disable parallel processing. Default: false.
    #restoreDirectory: # string. Alias: packagesDirectory. Optional. Use when command = restore. Destination directory. 
    #verbosityRestore: 'Detailed' # 'Quiet' | 'Normal' | 'Detailed'. Optional. Use when command = restore. Verbosity. Default: Detailed.
  # Advanced
    #publishPackageMetadata: true # boolean. Optional. Use when command = push && nuGetFeedType = internal. Publish pipeline metadata. Default: true.
    #verbosityPush: 'Detailed' # 'Quiet' | 'Normal' | 'Detailed'. Optional. Use when command = push. Verbosity. Default: Detailed.
  # Pack options
    #versioningScheme: 'off' # 'off' | 'byPrereleaseNumber' | 'byEnvVar' | 'byBuildNumber'. Required when command = pack. Automatic package versioning. Default: off.
    #includeReferencedProjects: false # boolean. Optional. Use when versioningScheme = off && command = pack. Include referenced projects. Default: false.
    #versionEnvVar: # string. Required when versioningScheme = byEnvVar && command = pack. Environment variable. 
    #majorVersion: '1' # string. Alias: requestedMajorVersion. Required when versioningScheme = byPrereleaseNumber && command = pack. Major. Default: 1.
    #minorVersion: '0' # string. Alias: requestedMinorVersion. Required when versioningScheme = byPrereleaseNumber && command = pack. Minor. Default: 0.
    #patchVersion: '0' # string. Alias: requestedPatchVersion. Required when versioningScheme = byPrereleaseNumber && command = pack. Patch. Default: 0.
    #packTimezone: 'utc' # 'utc' | 'local'. Optional. Use when versioningScheme = byPrereleaseNumber && command = pack. Time zone. Default: utc.
    #includeSymbols: false # boolean. Optional. Use when command = pack. Create symbols package. Default: false.
    #toolPackage: false # boolean. Optional. Use when command = pack. Tool Package. Default: false.
  # Advanced
    #buildProperties: # string. Optional. Use when command = pack. Additional build properties. 
    #basePath: # string. Optional. Use when command = pack. Base path. 
    #verbosityPack: 'Detailed' # 'Quiet' | 'Normal' | 'Detailed'. Optional. Use when command = pack. Verbosity. Default: Detailed.
```


* `command`: Required, by default `restore`. Nuget command to execute. 
* `restoreSolution`: Required when `command: restore`. Path to the solution, packages.config, or project.json to execute the command over. Default: `**/*.sln` to select each solution.
	* recommended to set it as: `'$(Build.Repository.LocalPath)/${{ parameters.SolutionPath }}'` using `Build.Repositor.LocalPath`. 

For `command: 'push'` its mandatory to define: 
* `packagesToPush`: Path to the nuget packages to publish. By default: `'$(Build.ArtifactStagingDirectory)/**/*.nupkg;!$(Build.ArtifactStagingDirectory)/**/*.symbols.nupkg'`
* `nuGetFeedType`:(`'internal'` | `'external'`) Target feed location. Default: internal.
	* `internal`: the target NuGet feed is hosted in the Azure DevOps organization (Azure Artifacts[^1]). In this case, define `publishVstsFeed` to specify the feed name
	* `external`: the target NuGet feed is outside the Azure DevOps organization.

[^1]: Azure Artifacts [[Azure Artifacts]]
[^2]: Nexus [[Nexus]]

