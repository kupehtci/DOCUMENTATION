#GIT 

In order to remove changes in the local working directory that are not in the index of the .git you can folow the next commands: 


```bash
# Cleans all the untracked files
git clean -df

#Clears the unstaged changes
git checkout -- .
```