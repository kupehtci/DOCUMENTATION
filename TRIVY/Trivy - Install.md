#Trivy 

# Install Trivy

[[Trivy]] can be installed as a native CLI tool using a package manager, using a docker image or as a kubernetes operator. 

# Windows

You can install Trivy as a CLI tool in a Windows system: 

1. Download the appropriate windows binary from github's releases: https://github.com/aquasecurity/trivy/releases/tag/v0.68.2
2. Place the binary under a program folder like `C:\Program Files\trivy` 
3. Add the path of the binary into the `PATH` environmental variable. 
4. Check that trivy is correctly installed opening a PowerShell console and executing command `trivy --version`

# Using package manager

Trivy can also be installed using package managers: 

* Windows (Chocolatey): 
```powershell
choco install trivy
```

* macOs (Homebrew): 
```bash
brew install aquasecurity/trivy/trivy
```

## Directly from GitHub

Trivy can be downloaded directly from github from the "releases" section in the official repository: https://github.com/aquasecurity/trivy/releases. 
