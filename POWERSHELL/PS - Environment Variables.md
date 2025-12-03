#POWERSHELL 

# PowerShell - Environment Variables

**Environment variables** are key-value pairs in the Windows OS and applications that define values in the Operating System (OS) and affect how programs and software behave at runtime.  

Variables like PATH[^1]

**PowerShell** manages environment variables through `Env:` variable drive and `System.Environment` .Net class. 
Also the environmental variables can be exposed and manipulated through `GetEnvironmentalVaraible` and `SetEnvironmentVariable` methods. 

In **PowerShell** you can set the environmental variables of the system using: 

```powershell
[Environment]::SetEnvironmentVariable('<variable>', <new-value>,'<scope>');
```

The scopes can be: 



[^1]: Windows's PATH environment variable 