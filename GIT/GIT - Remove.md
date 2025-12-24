#GIT

### GIT remove

Git rm command let you delete files or directories from a *Git repository*. 

Can delete the git files from the repository but also from the *filesystem*. 

The deletion of the file from the file system can be made by other methodologies depending of the system, but deleting from the repository can be done with this command. 

```bash
git rm <filename> <options>
```

`<filename>` is the file or multiple files by providing the name and path to it / them. 

`<options>` can be combined or single between the following ones: 

* `--chached` Removes the file only from the Git repository. 
* `-r` recursively removes files from folders. need to be combined in: 
		`git rm<folder_path>/* -r`
* `--dry-run` No actually files are removed. Show in the prompt the files that would be removed with the command, but the files are not actually removed. 

### Examples 

Remove a single file in both, git repository and file system: 

```bash
git rm file.md   
```

Remove a single file only from the git repository only: 

```bash 
git rm file.md --cached
```

Remove all recursively from a folder with a `--dry-run` first to check the files that would be removed: 

```bash
git rm lib/* --dry-run
```
