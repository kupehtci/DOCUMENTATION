#Linux 

# grep

The `grep` (*Global Regular Expression Print*) command searches for lines that match a pattern in files or in the standard input and prints them. 

The basic syntax is: 
```bash
grep [options] pattern [file...]
```

If no file is given, `grep` reads from stdin, so it is commonly used with pipes: 
```bash
ps aux | grep nginx
```

## Pattern flags

* `-E` extended regular expressions (`+`, `?`, `|`, `()` without escaping). Same as `egrep`. 
* `-F` fixed strings, no regex interpretation. Faster. Same as `fgrep`. 
* `-P` Perl compatible regular expressions (`\d`, lookaheads...). Only GNU grep. 
* `-i` case-insensitive. 
* `-w` matches whole words only. 
* `-x` matches the whole line. 
* `-v` inverts the match, prints the lines that do **not** match. 
* `-e pattern` specifies a pattern. Can be used multiple times. 
* `-f file` reads the patterns from a file. 

## Output flags

* `-n` shows the line number. 
* `-c` counts the matching lines. 
* `-l` prints only the names of the files with matches. 
* `-L` prints the names of the files without matches. 
* `-o` prints only the matched part of the line. 
* `-h` / `-H` hides / shows the file name. 
* `-q` quiet, no output. Only the exit code (useful in scripts). 
* `-s` suppresses errors about unreadable files. 
* `-m n` stops after `n` matches. 
* `--color=auto` highlights the matches. 

### Context flags

* `-A n` prints `n` lines **after** the match. 
* `-B n` prints `n` lines **before** the match. 
* `-C n` prints `n` lines of context around the match. 

## File and directory flags

* `-r` recursive search in directories. 
* `-R` recursive following symlinks. 
* `--include="*.md"` only searches files matching the glob. 
* `--exclude="*.log"` skips files matching the glob. 
* `--exclude-dir=node_modules` skips directories. 
* `-I` ignores binary files. 
* `-Z` / `--null` null separator after file names (to use with `xargs -0`). 

## Exit codes

* `0` at least one match. 
* `1` no matches. 
* `2` error. 

## Examples

```bash
# Search a word in all the markdown files of the current folder recursively
grep -rn --include="*.md" "kubernetes" .

# Errors with 3 lines of context
grep -C 3 -i "error" /var/log/syslog

# Remove comments and empty lines of a config file
grep -vE "^\s*(#|$)" /etc/ssh/sshd_config

# Extract all the IPs from a log
grep -oE "\b([0-9]{1,3}\.){3}[0-9]{1,3}\b" access.log | sort | uniq -c | sort -rn

# Several patterns
grep -e "WARN" -e "ERROR" app.log

# Check if a user exists in a script
if grep -q "^daniel:" /etc/passwd; then echo "exists"; fi

# Avoid matching the grep process itself
ps aux | grep "[n]ginx"
```

> [!tip] 
> For big codebases, `ripgrep` (`rg`) is a faster alternative that respects `.gitignore` by default. 

Related: [[find]], [[curl]]
