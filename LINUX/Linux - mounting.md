#Linux

# LINUX Mounting

Mounting consist in associating a file system or storage device with an specific directory (mount point). 
This association makes the content of the filesystem or device accesible at that specified mount point. 

```bash
mount <device> <directory>
```

Unmounting is the opposite process, detach the filesystem and its no longer available at that mount point: 

```bash
unmount {device|directory}
```

The automated mounting in the boot operation of the system is made in `/etc/fstab`. 

 