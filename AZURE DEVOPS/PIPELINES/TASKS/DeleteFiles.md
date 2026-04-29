#AZURE_DEVOPS 

# DeleteFiles

`DeleteFiles` is an Azure DevOps pipeline task that can be used to delete files and folders from the build's agent working directory. 

Its typically used to clean unnecessary: 

```yaml
- task: DeleteFiles@1
  displayName: 'Remove unneeded files'
  inputs:
    SourceFolder: '$(Build.SourcesDirectory)'   # optional
    Contents: '**/*'                            # required
    RemoveSourceFolder: false                   # optional
    RemoveDotFiles: false                       # optional
```

| Parameter            | Type                                         | Required | Default                     | Description                                                                  |
| -------------------- | -------------------------------------------- | -------- | --------------------------- | ---------------------------------------------------------------------------- |
| `SourceFolder`       | <span style="color:DodgerBlue">string</span> | No       | `$(Build.SourcesDirectory)` | Root folder to delete.                                                       |
| `Contents`           | <span style="color:DodgerBlue">string        | Yes      | `myFilesShare`              | Minimatch patterns for files and folders to delete. Supports multiline.      |
| `RemoveSourceFolder` | <span style="color:red">boolean</span>       | No       | `false`                     | Removes the `SourceFolder` after deleting the contents                       |
| `RemoveDotFiles`     | <span style="color:red">boolean</span>       | No       | `false`                     | Also deletes the files with `.` as prefix like `.gitignore` or `.dockerfile` |


### `Contents`

`Content` accept minimatch glob patterns like: 
* `**/*` deletes all files and folders recursively, 
* `temp` deletes temp folder placed in the root (`SourceFolder`). 
* `temp*` deletes using a wildcard so all files starting with `temp`. 
* `**/temp/*` deletes all files within each folder called `temp`. 
* `!(*.xml)` deletes all files except `*.xml` files. 
* `**/*.log` deletes all `.log` files within each folder recursively. 

You can concatenate more than one pattern using `|` in the YAML task: 

```yaml
- task: DeleteFiles@1
  inputs:
    SourceFolder: '$(Build.Repository.LocalPath)'
    Contents: |
      folder1/delete.json
      folder1/example.txt
      **/*.log
```

