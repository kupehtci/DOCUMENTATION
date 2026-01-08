# Azure DevOps - Self-Hosted agent Install

## Windows

This section offers instructions for installing and configuring an Azure DevOps agent in a Windows OS machine. 
The agent will allow the projects to execute the pipelines compilation and deploy jobs in the local infrastructure. 

Requirements: 
* Windows 10, Windows 11, Windows Server 2016 or superior. 
* x64 bit Processor. 
* At least 4GB of RAM or recommended 8GB
* At least 10GB of free disk space.

Permissions and access required: 
* An Azure DevOps administrator account with enough permissions over the organization. 
	* Personal Access Token (PAT) of that account with at least the following permissions or Full Access: 
		* Agent Pools: read and manage
		* Deployment Groups: read and manage (Only needed if you will use deployment groups). 
* Local administrator permissions over the machine that you are going to install the agent. 

Firstly you will need to create the PAT in the administrator account in order to grant the agent an authentication method over the Azure DevOps platform: 
1. Login into the organization: `https://dev.azure.com/{organization}`
2. Click on the person icon next to the account in the superior right section. 
3. Go into `Personal Access Tokens`  section. 
4. Click in "+ New Token" and configure the token: 
	* **Name**: Assign a descriptive name for the token
	* **Organization**: select the current organization or the organizations that the PAT will grant access to. 
	* **Expiration**: configure a custom expiration, recommended is 90 days but normally is a head pain to renew the token once each 3 months so you can set it to 1 year maximum. 
	* **Scopes**: Recommended Full Access or at least %%TODO%%

In case you are reinstalling an agent and you don't want to lose all the previous job executions and logs, check on **Reinstall agent** section. 

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

Escriba Dirección URL del servidor. > https://dev.azure.com/organization
Escriba tipo de autenticación (presione Entrar para PAT). >
Escriba token de acceso personal. > ************************************************************************************
Conectando al servidor...

>> Registrar agente:

Escriba grupo de agentes (presione Entrar para default). >
Escriba nombre de agente (presione Entrar para LOCALHOST). >
Examinando las funcionalidades de la herramienta.
Conectando al servidor.
El agente se agregó correctamente.
Probando conexión del agente.
Escriba carpeta de trabajo (presione Entrar para _work). >
2025-12-31 10:18:08Z: Configuración guardada.
Escriba ¿Ejecutar agente como servicio? (S/N) (presione Entrar para N). > S
Escriba Cuenta de usuario que se utilizará para el servicio (presione Entrar para NT AUTHORITY\Servicio de red). > DOMAIN\USER
Escriba Contraseña para la cuenta DOMAIN\USER. > **********
Concesión de permisos de archivo a "DOMAIN\USER".
El servicio vstsagent.organization.Default.LOCALHOST se instaló correctamente
El servicio vstsagent.organization.Default.LOCALHOST estableció correctamente la opción de recuperación
El inicio automático retrasado se ha establecido correctamente para el servicio vstsagent.organization.Default.LOCALHOST.
El servicio vstsagent.organization.Default.LOCALHOST se configuró correctamente.
Escriba whether to prevent service starting immediately after configuration is finished? (Y/N) (presione Entrar para N). >
El servicio vstsagent.organization.Default.LOCALHOST se inició correctamente.
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

3. You also need to remove the following files to completely remove the current Azure DevOps agent installation and authentication: 
	+ `.agent`
	+ `.credentials`
	+ `.credentials_rsaparams`
	+ `.service` if has not been deleted by the service deletion.

4. Remove the agent manually from Azure DevOps platform: 
	1. Go into Azure DevOps > Organization settings > Agent Pools
	2. Select the pool
	3. Go into *Agents* tab
	4. Search the offline agent and clicking in the three dots > select delete
	5. Confirm that the agent is no longer visible in the agents section. 

5. Optionally, if you want a clear install of the new agent, you can delete the inner contents of `_work` and `_diag` directories or clear all the contents of the agent folder and copy the new dowloaded version ones. 


# Reinstall agent

When reinstalling an agent, in order to do a *manual update* or to *re-authenticate* the agent, and you want to preserve the previous job executions and logs, you can reinstall only the necessary directories: 

* In case you are manually updating the agent with a new version of the software 