#Linux 

# Linux systemd

**systemd** is the linux's system and service manager for this OS. Its run as the first process (PID 1) and enabled and maintain all the services. 

This manager is mainly controlled using `systemctl` command line tool (CLI)[^1]

## systemd units 

A **unit file**[^2] is a plain text ini-style file that encodes information about a service[^3], a socket, a device, a mount point, an automount point[^4], a swap file or partition, a start-up target, a watched file system path, a timer controlled and supervised by the systemd. 

All systemd units's files share `[]` and `[Install]` sections: 

* `[Unit]`: Metadata and dependencies of the service
	 * `Description`: human readable description of the service. 
	 * `Documentation`: URLs or pages within the system with documentation for the service. 
	 * `Requires`: Hard dependency that is its failed or stopped, this unit is stoped as well. 
	 * `Wants`: Soft dependency, its pulled but doesn't fail if the dependency fails. 
	 * `BindsTo`: Stronger than `Requires`, for linking to a device. 
	 * `PartOf`: the unit is stopped and started together with the linked units. 
	 * `Before / After`:  define starting order or various dependencies.
	 * `Conflicts`: units that cannot be active at the same time as this unit. 
	 * `Condition* / Assert*`: Start only if some conditions are met. 
		 * `ConditionFileNotEmpty`: Checks whether a file exists and its not empty. 
		 * `ConditionDirectoryNotEmpty`: Checks whether a directory exists and its not empty. 
	 * `OnFailure`: Units to start in case of failure. 

* `[Install]`: Indicates how the system is integrated into boot: 
	* `WantedBy`: targets in whose `.wants` directory will be created when enabling. Typical for services like `multi-user.target` and `graphical.target`. 
		* specified which other units or target will trigger this unit when its enabled. 
		* It will create a symlink[^5] in the wants dependency of that units / target. 
		* `multi-user.target` indicates the normal multi user boot without GUI. 
	* `RequiredBy`: Similar to `WantedBy` but with hard dependencies. 
	* `Also`: other units to enable or disable together with this unit. 
	* `Alias`: other names for this unit. 
	* `DefaultInstance`: default instance name for templated units. 

### Distros

The `.service` file and `systemctl` workflow is valid for the majority general-purpose distros[^d]: 

* Debian, Ubuntu, Mint, Pop_OS
* RHEL, CentOS, Rocky, Alma and Fedora
* openSUSE, SUSE Linux Enterprise
* Arch, Manjaro, Amazon Linux, Solus and Mageia. 


[^1]: systemctl command line tool for managing the systemd units [[systemctl]]
[^2]: systemd unit file [[Sistemd Units]]. 
[^3]: systemd services are systemd units that manage and control a daemon process. 
[^4]: Linux mount points [[Linux - mounting]]
[^5]: symlink or symbolic link [[Linux symlink]]
[^d]: Distros / Distributions are different versions of the linux operating system that "share" the original kernel [[Linux - Distros]]
