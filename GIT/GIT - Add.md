#GIT

### `git add`

Git add command is used in order to add untracked files to the GIT file: 
```bash
git add <file_path>
```

This command also have several options to perform the addition: 

`--dry-run`

Perform a test of how the files would be added, but without currently adding them. 

`--all` or `-A`

Add all the files untracked or not updated that are in the `<git_root_path>` or in the path specified in the command.

* `-u` or update

Similar to add all but only update the tracked files, not all. This takes into consideration the files excluded by the `.gitignore` 

`--refresh`

Don't all the files to the tracking, but only refresh their index. 

### `<file_path>`

File path attribute need to be the file name and the relative path to the root path of the git repository. 

This file path also allows REGEX to add files that met certain parameters: 

```bash
# This will add all the ".txt" files under Documentation/ path. 
git add Documentation/\*.txt
```


