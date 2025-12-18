#Linux 

# Linux systemd

A linux service is normally defined as a `systemd` service. This is defined in an INI format file with `.service` extension that needs to define to systemd how to start, stop and monitor a process. 

A basic custom service is stored under `/etc/systemd/system/{SERVICE-NAME}.service` and contains an INI file with this sections: 

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
	 * `OnFailure`: Units to start in case of failure. 
* `[Service]`: Defines how to run and supervise a process. 
	* `Type`: Process the startup mechanic: 
		* `simple`: **ExecStart** defines the main process that is started immediately. 
		* `forking`: for classic daemons that are forked into the background. The parent exists when its ready. 
		* `oneshot`: short lived task. 
		* `notify`: service that signals a readiness using `sd_notify`.
		* `dbus`: considered ready once the `BusName` appears on the bus. 
		* `idle`: execution is like `simple` but its delayed until other jobs are dispatched. 
	* `ExecStart`: Main command to start the service. 
	* `ExecStartPre / ExecStartPro`: Commands to run before / after `ExecStart`.
	* `ExecReload`: Command used when `systemctl reload`
	* `ExecStop / ExecStopPost`: commands to used when the service is stopped or cleaned up. 
	* `Restart`: when to restart the service (`no`, `on-success`, `on-failure`, `on-abnormal`, `ob-abort`, `always`). 
	* `RestartSec`: Delay before the start. 
	* `RemainAfterExit`: Consider service active after processes exists (Recommended for `oneshot` tasks). 

* `[Install]`: Indicates how the system is integrated into boot: 
	* `WantedBy`: targets in whose `.wants` directory will be created when enabling. Typical for services like `multi-user.target` and `graphical.target`. 
	* `RequiredBy`: Similar to `WantedBy` but with hard dependencies. 
	* `Also`: other units to enable or disable together with this unit. 
	* `Alias`: other names for this unit. 
	* `DefaultInstance`: default instance name for templated units. 

## Systemctl

`systemctl` is the main CLI tool in linux to manage the `systemd` as it can start, stop, enable, disable and inspect units (services, timers, sockets, targets and more). 

Inspect all running units: 
* `systemctl list-units`

Inspect all the running units of a certain time like the services: 
* `systemctl list-units --type=service`
* `systemctl list-units --type=socket --all`

Start/stop/restart/reload: (only applied to current session): 

* `systemctl start NAME.service`
* `systemctl stop NAME.service`
* `systemctl restart NAME.service`
* `systemctl reload NAME.service`

Enable/disable at boot:

* `systemctl enable NAME.service`
* `systemctl disable NAME.service`
* `systemctl enable --now NAME.service (enable + start)`
* `systemctl disable --now NAME.service (disable + stop)`

Status and logs:

* `systemctl status NAME.service`
* `systemctl show NAME.service`

### Distros

The `.service` file and `systemctl` workflow is valid for the majority general-purpose distros: 

* Debian, Ubuntu, Mint, Pop_OS
* RHEL, CentOS, Rocky, Alma and Fedora
* openSUSE, SUSE Linux Enterprise
* Arch, Manjaro, Amazon Linux, Solus and Mageia. 