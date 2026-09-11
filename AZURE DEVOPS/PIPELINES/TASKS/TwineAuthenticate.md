#AZURE_DEVOPS #PYTHON 

# TwineAuthenticate

`TwineAuthenticate` is an Azure DevOps task that authenticates `twine` to upload Python distributions to a package feed. It writes a `.pypirc` file and exposes its path as the `PYPIRC_PATH` variable for the rest of the job.

After running this task, add `-r <FeedName/EndpointName> --config-file $(PYPIRC_PATH)` to the `twine upload` command: use the feed name as the repository (`-r`) for feeds in this organization, or the service connection name for external registries.

> Note: this task only handles authentication; build the distribution beforehand (e.g. `python setup.py bdist_wheel` or `python -m build`) and install `twine` with a script step. Multiple runs of this task don't stack credentials — each run replaces any previously stored ones.

Syntax template:

```yaml
- task: TwineAuthenticate@1
  inputs:
    # --- Feeds and Authentication ---
    #azureDevOpsServiceConnection: ''    # Alias: workloadIdentityServiceConnection.
    #feedUrl: ''
    #artifactFeed: ''
    #pythonUploadServiceConnection: ''
```

| Parameter                        | Type                                          | Required | Default | Description                                                                                                                                            |
| ----------------------------------- | ----------------------------------------------- | --------- | -------- | ------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `azureDevOpsServiceConnection`      | <span style="color:DodgerBlue">string</span>  | No        | -        | Azure DevOps service connection using workload identity federation. If set, `feedUrl` is required and every other input is ignored.                    |
| `feedUrl`                           | <span style="color:DodgerBlue">string</span>  | No        | -        | Azure Artifacts feed upload URL, in the form `https://pkgs.dev.azure.com/{ORG}/{PROJECT}/_packaging/{FEED}/pypi/upload/`. Requires `azureDevOpsServiceConnection`; not compatible with `pythonUploadServiceConnection`. |
| `artifactFeed`                     | <span style="color:DodgerBlue">string</span>  | No        | -        | Name of an Azure Artifacts feed within this organization to authenticate with. Use `projectName/feedName` for project-scoped feeds, or just `feedName` for organization-scoped ones. |
| `pythonUploadServiceConnection`    | <span style="color:DodgerBlue">string</span>  | No        | -        | Name of a Python package upload service connection for an external registry (e.g. PyPI). Its stored credentials need package-upload permissions.       |

> Exactly one authentication method is needed: `azureDevOpsServiceConnection` + `feedUrl` (workload identity), `artifactFeed` (feeds in this organization), or `pythonUploadServiceConnection` (external registries such as pypi.org).

### Example of use

Publish to an Azure Artifacts feed: 

```yaml
- script: |
    pip install wheel twine
    python setup.py bdist_wheel
  displayName: 'Build distribution'

- task: TwineAuthenticate@1
  displayName: 'Twine Authenticate'
  inputs:
    artifactFeed: 'MyProject/MyFeed'   # projectName/feedName for project-scoped feeds, or just feedName

- script: |
    python -m twine upload -r MyFeed --config-file $(PYPIRC_PATH) dist/*.whl
  displayName: 'Upload package with Twine'
```

Publish to the official PyPI registry using a service connection: 

```yaml
- task: TwineAuthenticate@1
  displayName: 'Twine Authenticate'
  inputs:
    pythonUploadServiceConnection: 'pypi-connection'

- script: |
    python -m twine upload -r "pypi-connection" --config-file $(PYPIRC_PATH) dist/*.whl
  displayName: 'Upload package with Twine'
```

For provisioning the Python interpreter or running scripts, see [[UsePythonVersion]] and [[PythonScript]].
