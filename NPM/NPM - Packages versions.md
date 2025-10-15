
The basic format for dependencies inside the `package.json` file is: 

```json
{
  "dependencies": {
    "package_name": "version",
    "..."
  }
}
```

### Versions operands

The version operand has some variants for determining the version to install: 

* Exact version

```json
{
  "dependencies": {
    "lodash": "4.17.21"
  }
}
```

* (~) Allowing patchs: 

This will allow only to vary the patch version and maintain the Mayor and minor version, so it will accept: 4.18.0, 4.18.1, 4.18.2, etc.

```json
{
  "dependencies": {
    "express": "~4.18.0"  
  }
}
```

* Caret or minor compatible: 

Allow updates in minor version and in patch version, so it will accept 18.2.0, 18.3.0, 18.9.5, but no 19.0.0. 
```json
{
  "dependencies": {
    "react": "^18.2.0" 
  }
}
```

* Ranges: 

You can also define a range of versions allowed: 

```json
{
  "dependencies": {
    "moment": ">=2.24.0 <3.0.0",
    "axios": ">=0.21.0 <=1.0.0"
  }
}
```

And even wildcards: 

```json
{
  "dependencies": {
    "jquery": "3.x",      // All versions 3.x.x
    "bootstrap": "5.*"    // All versions 5.x.x
  }
}
```

* Special versions: 

You can also use special versions: 
```json
{
  "dependencies": {
    "latest-package": "latest",
    "alpha-package": "1.0.0-alpha.1",
    "beta-package": "2.0.0-beta",
    "git-package": "git+https://github.com/user/repo.git",
    "github-package": "github:user/repo",
    "file-package": "file:../local-package",
    "tarball-package": "https://registry.npmjs.org/package/-/package-1.0.0.tgz"
  }
}
```



>Note: same version operands works for [[NPM - DevDependencies]] , peerDependencies and optionalDependencies. 

