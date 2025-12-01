# Linux - File permissions

Linux permissions over the file system controls who can read, modify or execute files or directories. 

When a user creates a file, automatically its property belongs to it and the group property to the main group that the user belongs to. 

## Core concepts

Linux define permissions for three different categories or three parties: 

* User (u) the owner of the file
* Group (g) group (Users) who belong to the file group. 
* Others (o) everyone else in the file system that is not the owner or in the group. 

And the permissions are defined using 3 basic permissions: 

* Read (r) allows to view the file contents and list the directories contents. 
* Write (w) modify the file or add / delete elements in a directory. 
* Execute (x) run a file or enter a directory. 

Permissions are grouped together as  3 letters: `rwx` and depending on permissions can be exchanged with a `-` like read and execute permissions are: `r-x`. 

Permissions can also be represented in Numeric (Octal) permissions: 
* R is 4
* W is 2
* X is 1
The permission set is represented with the sum of each of this single action permissions like: 
```txt
774 imply 7 = RWX for User, 7 = RWX for Group and 4 = R-- for Others. 
```

The permissions can be displayed using the `-l` flag in the `ls` command: 
```bash
ls -l
drwx------+ 15 daniel  staff   480 25 nov.  12:49 Desktop
drwx------+  4 daniel  staff   128 16 may.   2025 Documents
drwx------@ 82 daniel  staff  2624 27 nov.  10:16 Downloads
```

Showing: 
* Permissions in AAABBBCCC meaning A is the User permissions, B is the group permissions and C is the others permissions. 
* Owner of the file
* Group owner of the file
* Name of the file / directory

# Key commands

* `chmod <new-permissions> <file-or-dir>`: Change permissions of the file, indicating the new permissions in octal format: 
```bash
chmod 644 notes.txt
```

Also permissions can be added using the `+` operator like: 
* Using `u`, `g` or `o` and `+` or `-` the permission you can add/remove a permission to user, group or others respectively: 
```bash
# Add execute permission to owner user
chmod u+x compile.sh

# Remove execute permission 
chmod u-x compile.sh
```

* `chown <user> <file-or-dir>`: change the owner of a file or directory. 
* `chgrp <group> <file-or-dir>`: change the group owner of the file or directory. 
