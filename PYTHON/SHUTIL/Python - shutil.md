# Python shutil

`shutil` is a python's module that provides functions for high-level file operations like copying, moving, delete files or directories. 

This module uses the lower level os module functions but offering more complex operations. 

The most useful functions are: 

* `shutil.copy(src, dst)`: copies a file and its contents from a path to another directory or file. 
* `shutil.copy2(src, dst)`: copies the files and preserves the metadata like timestamps and permissions. 
* `shutil.copymode(src,dst)`: copies permissions to another file. 
* `shutil.copystat(src, dst)`: copies permissions, times and flags. 
* `shutil.copytree(src, dst)`: recursively copies all the files and sub-directories of the sourcec into the target destination. 
* `shutil.move(src, dst)`: moves a file or renames it. Handles overwrites accordingly. 
* `shutil.rmtree(path)`: removes a directory and its contents. 


Also some utility functions: 
* `shutil.disk_usage(path)`: returns a python's tuple  containing `total`, `used` and `free` indicating the bytes of the filesystem. 
* `shutil.which(cmd)`: locates the executables defined in PATH, indicating the command, like for example: `shutil.which('python3')`
* `shutil.chown(path, user=NewUser, group=NewGroup)`: changes file ownership. Only available in UNIX filesystems. 
* `shutil.make_archive(base_name, format)`: creates a ZIP, tar, gzTar archives from a directory. 
	* Example: `shutil.make_archive('backup', 'gztar', root_dir='/app')`
* `shutil.unpack_archive(filename, extract_dir)`: Extract the files from an archive. 

