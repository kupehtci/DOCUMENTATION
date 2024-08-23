#ATLANTIS 

### GIT Safe directory problem 

When encountering the following error related with Git safe directories problem: 
```txt
running 'git ls-files . --others' in '/path/to/git_directory' directory: fatal: detected dubious ownership in repository at '/path/to/git_directory'
: exit status 128
```

You can make the following command in the atlantis server:  

```bash
git config --global --add safe.directory /path/to/git_directory
```