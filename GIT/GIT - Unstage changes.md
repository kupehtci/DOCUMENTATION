#GIT 

# GIT Unstage changes

In GIT, some changes can be added into the staging index but you want to remove them from the changes that is going to be committed. 

In order to do so, using the CLI, there isn't a command `unstage` but can be done in two different ways: 

* The "traditional" way
```bash
git reset HEAD /path/to/file
```

* The modern way: 
```bash
git restore --staged /path/to/file
```

Both command will remove the file from the index and keep the local changes done to the file. 

If you want to reset the file in the working tree back to `HEAD` and loose all the local edits to the file, you can use: 
```bash
git restore /path/to/file
```

If you want to remove the changes applied or remove the file completely from git tracking, take a look to [[GIT - Remove]]. 


