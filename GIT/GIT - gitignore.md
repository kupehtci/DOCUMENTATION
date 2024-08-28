#GIT 

## GITIGNORE file

The `.gitignore` file is a file written following a certain format that indicates the files or directories that are excluded from being committed to the local or remote repository. 

The pattern format is the following: 

* A blank line matches no files, so can be used as separator
* A comment is started with `#`. 
* A `!` prefix negates the patter so can be used to exclude files that match a certain pattern 
* All the files or directories indicated in the file are relative to the `.gitignore` file path, this means that the pattern `docs/example` excludes `docs/example/hello.txt` but no `abc/docs/example/`
* An `*` asterisk indicates all pattern except a slash, so the asterisk means all pattern until a slash is find. 
* An `?` question mark indicates any one character except `/`

Two consecutive asterisks `**` indicates everything but has certain meanings: 

* An starting `**` matches everything, so `**/hello` matches a directory called `./hello` and `./world/hello`. 
* An end `**` indicates everything inside it. So `hello/**` indicates everything under the `hello` directory. 

Differences between single asterisk `*` and double `**` are like: 

* The pattern `hello/*` matches `hello/example.txt` but not `hello/world/example.txt`. 
* The pattern `hello/*` matches `hello/example.txt` and also `hello/world/example.txt`. 

### Force git to update following `.gitignore`

If the `.gitignore` file has been created before some files has  been added to the repo, its possible that they are cached tobe as untracked and still being as candidates for commit. 

To force the `.gitignore` patterns to be taken into consideration, you need to clear the cache

To remove the cache of all the files: 

`git rm -r --cached .`

Otherwise, you can remove the cache of a single file: 

`git rm -r --cached <file_name.ext>`

Once you clear the existing cache, add/stage file/files in the current directory and commit

- `git add .` // To add all the files
- `git add <file_name.ext>` // To add specific file
- `git commit -m "Suitable Message"`