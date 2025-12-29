#Linux 

# Linux symlink

A **linux symlink** or **symbolic link** is a special file that stores the path to another file or a directory. 
Its like a shortcut, alias but its not the real copy of the data, as data is stored in another directory / path. 

When you access a symlink opening it, execute or using `cd` command the kernel traverses to the target path defined in the symlink. 

You can create symlinks using `ln` command with `-s` flag: 

```bash
ln -s /target/path /symlink/path/link
```

This will makes `/symlink/path/link` a symlink to `/target/path`. 

Under an `ls -l` its shown as `xxxxxxxxxx <user> <group> link -> target` like for example: 

```bash
ls -l
-rw-r--r--@ 1 daniel  group   123456  6 oct.  image.PNG
lrwxr-xr-x  1 daniel  group        30 6 dic. link -> /Users/.../Desktop/
```

