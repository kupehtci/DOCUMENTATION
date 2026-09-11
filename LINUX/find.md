#Linux 

# find

The `find` command searches for files and folders in a directory hierarchy and allow to apply criteria in the search and other actions recursively. 

The basic syntax is: 
```bash
find [path] (expression)
```

The command requires a certain **path** in order to search into. 

The **expression** include: 
* tests like `-name ""` in order to find the files / subfolders that match the criteria. 
* actions like `-print`. 
* logical operators like `-a` (AND), `-o` (OR) and `!` (NOT) for grouping tests and actions. 

## Test flags

* `-name "pattern"` match case-sensitive exact name. 
* `-iname "pattern"` case-insensitive name match. 
* `-type X` With X: `f` for file, `d` dir, `l` symlink, `b` block, `c`char, `p` pipe and `s` for socket. 
	* Example `find . -type f`
* `-size n` exact size or `+n` /`-n` for greater or less than a size. 
* `-user name` owned by a certain user. 
* `-group name` owned by a certain group. 
* `-perm mode` match certain permissions mode. 
* `-empty` searches for empty files or folders. 

### Path and depths flags

* `-path pattern` matches full path. 
* `-maxdepth level` descent limit in sub-directories. 
* `-mindepth level` minimum level. 
* `-prune` excludes directories from traversal. 
* `-depth` dirs first. 

### Action flags

* `-print` prints the full path. 
* `-print0` prints with null separator. 
* `-ls` list with `ls -ils` format. 
* `exec command {} \;`execs a command on each match. `{}` filename and `\;` terminates. 
* `-exec command {} +` batches multiple files per `command` call. 
* `-delete` delete the empty files and sub-command. 

## Other flags

* `-H` follows the symlinks at command line arguments. 
* `-L` follows all symlinks. 
* `-P`never follows symlinks (By default). 
* `-xdev` stays in the same filesystem. 
* `-warn` warnings about questionable arguments. 
* `-nowarn` no warnings. 

