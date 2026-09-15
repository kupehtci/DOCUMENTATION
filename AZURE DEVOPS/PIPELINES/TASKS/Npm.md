#AZURE_DEVOPS #NODE 

# Npm

`Npm` is an [[Azure DevOps]] task that installs or publishes npm packages, or runs an arbitrary `npm` command. Supports npmjs.com and authenticated registries like [[Azure Artifacts]].

> Note: to authenticate with an Azure Artifacts feed without installing/publishing (e.g. before a plain `npm install` in a script step), use the `npmAuthenticate@0` task instead. 

Syntax template:

```yaml
- task: Npm@1
  inputs:
    command: 'install'   # 'ci' | 'install' | 'publish' | 'custom'. Required. Default: install.
    #workingDir: ''
    #customCommand: ''   # Required when command = custom.

    # --- Advanced ---
    #verbose: false      # Use when command = install || ci || publish.
    #publishPackageMetadata: true  # Use when command = publish && publishRegistry = useFeed.

    # --- Custom registries and authentication ---
    #customRegistry: 'useNpmrc'    # 'useNpmrc' | 'useFeed'. Use when command = install || ci || custom. Default: useNpmrc.
    #customFeed: ''                # Required when customRegistry = useFeed.
    #customEndpoint: ''            # Use when customRegistry = useNpmrc.

    # --- Destination registry and authentication ---
    #publishRegistry: 'useExternalRegistry'  # 'useExternalRegistry' | 'useFeed'. Use when command = publish. Default: useExternalRegistry.
    #publishFeed: ''               # Required when publishRegistry = useFeed.
    #publishEndpoint: ''           # Required when publishRegistry = useExternalRegistry.
```

| Parameter                  | Type                                          | Required    | Default                 | Description                                                                                                                              |
| ----------------------------- | ----------------------------------------------- | ------------ | --------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------ |
| `command`                    | <span style="color:DodgerBlue">string</span>  | Yes          | `install`                   | Command to pass to npm: `ci`, `install`, `publish` or `custom`. To install globally use `install -g` as the command.                    |
| `workingDir`                 | <span style="color:DodgerBlue">string</span>  | No           | -                            | Path to the folder containing the target `package.json` and `.npmrc` files (select the folder, not the file).                            |
| `customCommand`              | <span style="color:DodgerBlue">string</span>  | Conditional  | -                            | Custom command and arguments, e.g. `dist-tag ls mypackage`. Required when `command: custom`.                                             |
| `verbose`                    | <span style="color:red">boolean</span>        | No           | -                            | Print more information to the console. Used when `command: install`, `ci` or `publish`.                                                 |
| `customRegistry`             | <span style="color:DodgerBlue">string</span>  | No           | `useNpmrc`                   | Registries to use: `useNpmrc` (registries in the repo's `.npmrc`) or `useFeed` (a registry selected here). Used with `install`, `ci` or `custom`. |
| `customFeed`                 | <span style="color:DodgerBlue">string</span>  | Conditional  | -                            | Azure Artifacts/TFS feed to include in the generated `.npmrc`, as `ProjectName/FeedName` (project-scoped) or `FeedName` (organization-scoped). Required when `customRegistry: useFeed`. |
| `customEndpoint`             | <span style="color:DodgerBlue">string</span>  | No           | -                            | Credentials for external registries listed in the project's `.npmrc`. Leave empty for registries in this organization (auto-authenticated). |
| `publishRegistry`            | <span style="color:DodgerBlue">string</span>  | No           | `useExternalRegistry`        | Registry to publish to: `useExternalRegistry` or `useFeed`. Used when `command: publish`.                                                |
| `publishFeed`                | <span style="color:DodgerBlue">string</span>  | Conditional  | -                            | Feed hosted in the organization to publish to (requires Package Management). Required when `publishRegistry: useFeed`.                   |
| `publishPackageMetadata`     | <span style="color:red">boolean</span>        | No           | `true`                       | Associate the pipeline's metadata (run # and source info) with the published package. Used when `publishRegistry: useFeed`.              |
| `publishEndpoint`            | <span style="color:DodgerBlue">string</span>  | Conditional  | -                            | Credentials for publishing to an external registry. Required when `publishRegistry: useExternalRegistry`.                                |

### Example of use

Install dependencies from the default registries in `.npmrc`: 

```yaml
- task: Npm@1
  inputs:
    command: 'install'
    workingDir: '$(System.DefaultWorkingDirectory)/app'
```

Install using a specific Azure Artifacts feed: 

```yaml
- task: Npm@1
  inputs:
    command: 'install'
    customRegistry: 'useFeed'
    customFeed: 'MyProject/MyFeed'
```

Publish a package to an Azure Artifacts feed: 

```yaml
- task: Npm@1
  inputs:
    command: 'publish'
    publishRegistry: 'useFeed'
    publishFeed: 'MyProject/MyFeed'
```

For Node build tooling like gulp, see [[Gulp]].

For running unit tests and publishing test results/coverage from npm-based projects (Jest, Mocha, nyc), see [[Azure Pipelines - Unit Testing and Code Coverage]].
