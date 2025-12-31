# Azure DevOps - Self-Hosted agent Install

## Windows


```powershell
PS D:\agent> .\config.cmd

  ___                      ______ _            _ _
 / _ \                     | ___ (_)          | (_)
/ /_\ \_____   _ _ __ ___  | |_/ /_ _ __   ___| |_ _ __   ___  ___
|  _  |_  / | | | '__/ _ \ |  __/| | '_ \ / _ \ | | '_ \ / _ \/ __|
| | | |/ /| |_| | | |  __/ | |   | | |_) |  __/ | | | | |  __/\__ \
\_| |_/___|\__,_|_|  \___| \_|   |_| .__/ \___|_|_|_| |_|\___||___/
                                   | |
        agent v2.202.1             |_|          (commit a12c15b)


>> Conectar:

Escriba Dirección URL del servidor. > https://dev.azure.com/serviciosmin-adc
Escriba tipo de autenticación (presione Entrar para PAT). >
Escriba token de acceso personal. > ************************************************************************************
Conectando al servidor...

>> Registrar agente:

Escriba grupo de agentes (presione Entrar para default). >
Escriba nombre de agente (presione Entrar para VSRV939). >
Examinando las funcionalidades de la herramienta.
Conectando al servidor.
El agente se agregó correctamente.
Probando conexión del agente.
Escriba carpeta de trabajo (presione Entrar para _work). >
2025-12-31 10:18:08Z: Configuración guardada.
Escriba ¿Ejecutar agente como servicio? (S/N) (presione Entrar para N). > S
Escriba Cuenta de usuario que se utilizará para el servicio (presione Entrar para NT AUTHORITY\Servicio de red). > MITYC\LS_ACC_DevOpsComp
Escriba Contraseña para la cuenta MITYC\LS_ACC_DevOpsComp. > **********
Concesión de permisos de archivo a "MITYC\LS_ACC_DevOpsComp".
El servicio vstsagent.serviciosmin-adc.Default.VSRV939 se instaló correctamente
El servicio vstsagent.serviciosmin-adc.Default.VSRV939 estableció correctamente la opción de recuperación
El inicio automático retrasado se ha establecido correctamente para el servicio vstsagent.serviciosmin-adc.Default.VSRV939.
El servicio vstsagent.serviciosmin-adc.Default.VSRV939 se configuró correctamente.
Escriba whether to prevent service starting immediately after configuration is finished? (Y/N) (presione Entrar para N). >
El servicio vstsagent.serviciosmin-adc.Default.VSRV939 se inició correctamente.
PS D:\agent>
```

## Linux



# Replace a current agent

Sometimes in order to renew the authentication of a current agent or reinstall it, removing the actual service is needed. 

In order to remove the current service: 

1. Execute the following command: 
```powershell
.\config.cmd remove
```

2. The config script will prompt for the PAT used when the service was configured and it will automatically remove the service from the local machine and the agent in the Azure DevOps organization. 
	1. In case you don't posses the old PAT, check on **Alternative without PAT** section. 

## Alternative without PAT

In case you cannot complete the previous step because you don't have the previous PAT, you can manually remove the services: 
1. Retrieve the current running service and stop it: 
	* The service will be named as `vstsagent.{organizacion}.{pool}.{agente}` but you can search for it using Powershell or in the services window. 
```powershell
# Get the current Azure DevOps pipelines services
Get-Service | Where-Object {$_.DisplayName -like "*Azure Pipelines*"}

# Stop the service
Stop-Service -Name "vstsagent.{organizacion}.{pool}.{agente}" -Force
```

2. Remove the service: 
```powershell
sc.exe delete "vstsagent.{organizacion}.{pool}.{agente}"
```

3. Remove the agent manually from Azure DevOps platform: 
	1. Go into Azure DevOps > Organization settings > Agent Pools
	2. Select the pool
	3. Go into *Agents* tab
	4. Search the offline agent and clicking in the three dots > select delete
	5. Confirm that the agent is no longer visibnle in the agents section. 

4. Optionally, if you want a clear install of the new agent, you can delete the inner contents of `_work` and `_diag` directories or clear all the contents of the agent folder and copy the new dowloaded version ones. 