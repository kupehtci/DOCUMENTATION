#DOTNET

# DOTNET - Authenticate to Azure Artifacts

In order to authenticate to azure artifacts to upload and use packages and dependencies stored in a feed you need to follow this steps: 

Firstly you need to add the feed or repository to the source list: 
```bash
# add the source
dotnet nuget add source "https://pkgs.dev.azure.com/{ORGANIZATION_NAME}/{PROJECT_NAME}/_packaging/{FEED_NAME}/nuget/v3/index.json" --name "{SOURCE_NAME}" --configfile ./nuget.config

# Login
dotnet restore --interactive --configfile ./nuget.config
```

With `dotnet restore --interactive` it should print in the console a login webpage to login with your azure devops credentials. 

```bash
# Compile the project
dotnet build --configuration Release

# Pack the project
dotnet pack 

# Push the package
dotnet nuget push "folder/bin/Release/{PACKAGE_NAME}.X.Y.Z.nupkg" --source "{SOURCE_NAME}"

# If requires ApiKey in previous command
dotnet nuget push "folder/bin/Release/{PACKAGE_NAME}.X.Y.Z.nupkg" --source "{SOURCE_NAME}" --api-key "{PAT_TOKEN}"
```