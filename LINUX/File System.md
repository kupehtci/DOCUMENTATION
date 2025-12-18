#Linux
# FILE SYSTEM

In a Linux there is a hierarchical structure for holding the data known as the file system. 
In this directory: 

* `/` is the root directory. 
* Some several files belonging to partitions, disks, removable devices can be mounted in this directory. 

This directory needs to meet an standard known as FHS or Filesystem Hierarchy Standard Linux file hierarchy. 

* `/bin`: essential commands that may by used by system administrator and other users. 
* `/usr/bin`: non essential commands of the system
* `/usr/local/bin`: local binaries installed by administrator. Not managed by system packages. 
* `/lib`: shared libraries images needed to boot the system and run commands in the run filesystem. The binaries must be in /bin or /sbin, /usr/lib or /usr/local/lib
* `/etc`: Contains the system configuration files. (System initialization, users and groups, network, Xwindows and third party applications)
* `/boot`: everything required for boot process except some configuration files. Data that is executed before kernel executes user-mode programs. Programs must be in /sbin and configurations in /etc. Kernel can be in `/` or in `/boot`
* `/dev`: Special device files used to interact with physical or virtual devices attached to the service. /dev/sda or /dev/sda are hard drives, partitions are `/dev/sda1`, `/dev/sdb1`
* `/mnt`: Mount point for removable devices as a temporarily mount file system. 
* `/media`: Mount point for removable media like cdrooms, zip disks and so. 
* `/root`: home directory for root user
* `/home` home directory for other users like `/home/user1`
* `/usr`: secondary major section of the file system which is read only: 
	* bin → Most user commands
	* include → Header files included by C programs
	* lib → Libraries
	* local → Local hierarchy (empty after main installation)
	* sbin → Non-vital system binaries
	* share → Architecture-independent data

* `/sbin`: essential commands for the system administrator and root-only use. 
* `/usr/sbin`: non-essential binaries for system administrator
* `/usr/local/sbin`: local binaries not installed by system packages for system administrator. 
* `/tmp`: contains temporary files and directories. Programs must take into account that in next invocation files must not be. 
* `/var`: contains variable data files: 
	* `lock`: lock files to block devices between applications
	* `log`: stores log files and directories
	* `mail`: mail files by the user
	* `run`: daemon PIDs
* `/proc`: mounted during system boot and acts as an interface to the kernet data: 
	* `/proc/cpuinfo`: information about the CPU
	* `/proc/meminfo`: information about the system's memory usage
	* `/proc/uptime`: system's uptime
	* `/processor /cmdline`: command line parameters passed to the kernel during the boot. 
	* `/proc/sys`: directory containing various kernel parameters and settings. 
	* `/proc/net`: information about network-related parameters. 
	* `/proc/<PID>`: directory for each running process that contains information about that specific process. 
* `/sys/`: exposes information about kernel parameters. 
	* `/sys/block`: Information about block devices.
	* `/sys/class`: Information about various classes of devices, such as network devices, input devices (e.g., keyboards, mice), and more.
	* `/sys/devices`: Detailed information about individual hardware devices.
	* `/sys/bus`: Information about different buses on the system, such as PCI or USB.
	* `/sys/module`: Information about kernel modules.
	* `/sys/kernel`: Various kernel-related parameters and settings.
	* `/sys/power`: Power management settings.
	* `/sys/firmware`: Information related to firmware, such as ACPI tables.
* `/opt`: installation of add-on application software. If aplication is in single-binary it will be placed in /usr/local/bin and if its composed of several files, will be placed in /opt. 
