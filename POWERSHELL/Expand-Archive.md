#powershell 

# Expand-Archive

`Expand-Archive` is a PowerShell cmdlet ([[cmdlet]]) that decompress an ZIP file and extracts its contents. 

The basic syntax is: 
```powershell
Expand-Archive
	-Path <String>   # Required
	-DestinationPath # Optional, by default "." 
	-Force           # Optional
	-PassThru        # Optional
	-WhatIf          # Optional
	-Confirm         # Optional
```

The parameters: 

* `-Path`: mandatory. Indicates the path to the archive file. 
* `-DestinationPath`: Specify the path to the destination folder for the extracted contents. By default, the command will create a folder in the same directory with the same name as the compressed archive. 
* `-Force`: overwrite existing file, as by default it prompts an error if tries to overwrite. 
* `-PassThru`: the cmdlet will prompt a list of the files from the archive. 
* `-WhatIf`: shows what would happen if the cmdlet is executed and the archive decompressed. 
* `-Confirm`: prompts you for confirmation before decompressing the archive. 