#Linux 

# lsof

The `lsof` (*List Open Files*) command lists the files opened by the processes. In Linux "everything is a file", so it also shows directories, libraries, pipes, devices and network sockets. 

It is very useful to know which process is locking a file, why a disk can't be unmounted or which process is listening in a port. 

The basic syntax is: 
```bash
lsof [options] [file]
```

> [!info] 
> Run it with `sudo` to see the files of all the users' processes. 

## Flags

* `-p PID` files opened by a process. 
* `-u user` files opened by a user. `-u ^user` excludes a user. 
* `-c name` processes whose command starts with `name`. 
* `+D dir` files opened inside a directory (recursive). 
* `+d dir` files opened inside a directory (not recursive). 
* `-i` network files. Can be filtered: `-i :80`, `-i TCP`, `-i @10.0.0.5`, `-i TCP:22`. 
* `-n` doesn't resolve host names. 
* `-P` doesn't resolve port names. 
* `-t` prints only the PIDs (useful with `kill`). 
* `-a` ANDs the conditions (by default they are ORed). 
* `-r seconds` repeat mode. 

## Output columns

* `COMMAND` name of the process. 
* `PID` process id. 
* `USER` owner. 
* `FD` file descriptor: `cwd` current dir, `txt` program text, `mem` memory-mapped file, `0u`/`1w`/`2r` number + mode (`r` read, `w` write, `u` read/write). 
* `TYPE` `REG` regular file, `DIR`, `IPv4`, `IPv6`, `unix`, `FIFO`... 
* `NAME` file path or socket address. 

## Examples

```bash
# Who is listening in the port 3000
sudo lsof -i :3000 -sTCP:LISTEN

# Kill the process using a port
kill $(lsof -t -i :3000)

# Why can't I unmount this disk?
sudo lsof +D /mnt/data

# Network connections of a user
sudo lsof -a -u daniel -i

# Files opened by nginx
sudo lsof -c nginx

# Deleted files still using disk space (disk full but du doesn't show it)
sudo lsof +L1
```

> [!tip] 
> When `df` shows a full disk but `du` doesn't find the files, usually a process keeps a deleted file open (e.g. a rotated log). `lsof +L1` finds it and restarting the process frees the space. 

Related: [[ss]], [[find]], [[Linux - mounting]]
