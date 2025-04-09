#SHELL #LINUX 

Zone.Identifier is a file that Windows File System creates when files are downloaded from internet. This file gathers metadata from the files that has been downloaded. 

In some cases, when downloading a git repository, or other huge downloads it can be hideous to handle all the Zone.Identifier files that windows has been created: 

You can remove all the `:Zone.Identifier` files that are created unintentionally with the following command invoked in the top repository where you can delete the files: 

```bash
find . -type f -name '*:Zone.Identifier' -exec rm -f {} \;
```

You can also use other commands for do so in powershell: 

```powershell
Get-ChildItem -Path . -Recurse -File -Filter "*:Zone.Identifier" | Remove-Item -Force
```

