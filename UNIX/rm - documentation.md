#UNIX 

## `rm` command

`rm` command is use to <span style="color:IndianRed;">remove</span> files or directories from the specified path. 

You won't be able to r

The syntax is: 

```bash
rm [option] [filename] 
```

The options allowed by the command are: 

* `-i` or interactive allows to confirm each process of the removing. It asks for a confirmation of each single folder to remove. 
* `-f` or force allows to force all the removing process and don't asks for confirmations. This is not recommended because is a source of future errors. 
* `-r` or recursive allows to delete all files within a specified directory, in a recursive way. Take into account that removes all the files and the sub-folders within, so be careful with it. 
* `-v` or verbose shows the command steps but don't asks for confirmations like with interactive option

Examples of how to use it: 

Delete a single file: 
```bash
rm file1.txt
```

If you want to delete more than one file: 
```bash
rm file1.txt file2.txt file3.txt
```

To delete a folder and all the files within it: 
```bash
rm -r ./folder/
```

Delete the folder and the files but checking the files to delete in interactive format: 
```bash
rm -ri ./folder/
```
