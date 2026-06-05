#powershell 

# `Invoke-Command`


`Invoke-Command` is a powershell cmdlet[^1] that executes commands or scripts on a local or remote computer and returns the outputs and results (also the errors) to the own console. 

Its the most useful command in **remote administration**. 


The basic syntax of this command is: 

```powershell
Invoke-Command -ComputerName "{computer-name}" -ScriptBlock{
	[command]
}
```

Arguments: 
* `-ComputerName`: Specifies the remote hosts. 
* `-ScriptBlock`: contains the command to execute remotely. 
* `-FilePath`: indicates a `.ps1` local file to execute remotely. 
* `-Credential`: Specifies credentials to connect to the remote host. 
	* Example: `-Credential Domain01\User01`
* `-AsJob`: executes the remote command as a background job on the local computer. 
* `-InDisconnectedSession`: runs the command in a disconnected session in the remote host. 
* `-ArgumentList`: used to pass arguments to the cmdlet in the script block. 

## Requirements

Take into account that the usage of this command requires: 
* Remote Powershell must be enabled in the remote machines (port 5985 and WinRM service). 
	* To enable the remote powershell in the remote host: `Enable-PSRemoting`. It not only enables the service, also create an exception rule in the firewall. 
* You need appropriate permissions in order to connect to the target machine. 
	* This works well in Active Directory environments where both host share users. 

## Parallel execution

Allows parallel execution of commands in more than one server at once. 
To indicate the servers or remote hosts to execute the command use a string list separated with commas: 

```powershell
Invoke-Command -ComputerName "{host1}","host2","host3" -ScriptBlock{
	Get-Service -Name w3svc
}
```

## Passing arguments

Arguments cannot be passed as normal inside the ScriptBlock, as the remote host doesn't know its value. 

In order to pass variables to the ScriptBlock you need to use the `Using` modifier, so it indicates the variable is in the local session and not in the remote one: 

```powershell
$serv_name = "w3svc"

Invoke-Command -ComputerName "host1" -ScriptBlock {
	Get-Service -Name $Using:serv_name
}
```

Arguments can also be passed in the `-ArgumentList` and retrieved using `$Param1`, `$Param2` and so on: 
```powershell
$serv_name = "w3svc"

Invoke-Command -ComputerName "host1" -ScriptBlock {
	Get-Service -Name $Param1
} -ArgumentList  $serv_name
```

## Store Script Block

The script block can be stored in a variable and used in the cmdlet: 

```powershell
$command = {
	Get-Service -Name $Using:serv_name
}

Invoke-Command -ComputerName "host1" -ScriptBlock $command
```

[^1]: cmdlet [[cmdlet]]

