#powershell 

# Compress-Archive

`Compress-Archive` is a PowerShell cmdlet([[cmdlet]]) to create a compressed archive file from one or more files or directories. 

The basic syntax of the command is: 
```powershell
Compress-Archive -Path C:\path\folder -DestinationPath C:\destination\archive.zip
```

To compress multiple files or folders, enumerate them using coma `,`: 
```powershell
Compress-Archive -Path C:\path\folder,C:\path\file.txt -DestinationPath C:\destination\archive.zip
```

To compress the files within a folder but no the folder itself, you can use Regex: 
```powershell
# All files
Compress-Archive -Path C:\path\*.* -DestinationPath C:\destination\archive.zip

# All files and subfolders
Compress-Archive -Path C:\path\*.* -DestinationPath C:\destination\archive.zip
```

Add or update a current existing ZIP using `-Update` flag: 
```powershell
Compress-Archive -Path C:\origin\*.txt -Update -DestinationPath archive.zip
```

## Compression levels

You can specify the compression levels using `-CompressionLevel` flag: 
```powershell
Compress-Archive -Path C:\source -CompressionLevel Fastest -DestinationPath C:\archive.zip
```

You can choose the compression level from one of this available options: 
* `Fastest`:the quickest compression but with less compression rate (larger archive file size)
* `Optimal`: best compression ratio but takes more time than `Fastest`
* `NoCompression`: No compression is applied into the ZIP file. 

