
The `.npmrc` file in NPM allows to define private registries. 
NPM searches files the `.npmrc` file placed in different paths in order, so the place is important to determine which one will be used: 

- `.npmrc` in the project's directory
- `.npmrc` in user's home (`~/.npmrc`)
- `.npmrc` global (`/usr/local/etc/npmrc`)
- `.npmrc` incorporated in NPM. 

An example of configuration for a private Nexus Repository: 


```bash
@organization_name:registry=https://url-example.com:8443/repository/npm/
https://url-example.com:8443/repository/npm/:_authToken=NpmToken.c53b68d3-2dd7-3727-8412-b2csbbddc0a8
https://url-example.com:8443/repository/npm/:email=admin@example.org
https://url-example.com:8443/repository/npm/:username=admin
always-auth=true
```

This will tell NPM to all packages under the @organization_name will be search in the nexus repository. 



