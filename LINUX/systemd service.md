#Linux 

# systemd service

A linux service is normally defined as a `systemd`[^1] service. This is defined in an INI format file with `.service` extension that needs to define to systemd how to start, stop and monitor a process. 

A basic custom service is stored under `/etc/systemd/system/{SERVICE-NAME}.service` and contains an INI file with this sections: 

* `[Service]`: Defines how to run and supervise a process. 
	* `User`: 
	* `Group`: 
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


Also some extra configurations that can be done that are less common: 
* `SecureBits`: controls the linux `securebits`[^2] flag 
* `AmbientCapabilities`: defines the linux capabilities that are placed into the ambient capability set that process can use even when its not a root user. 
* `CapabilityBoundingSet`: defines the linux capabilities that a service
	* This capabilities are also applied to the child processes. 
	* Can also be `CapabilityBoundingSet~=` so capabilities are substracted instead of added. 

[^1]: systemd is the main service and process manager in Linux operating systems. [[systemd]]
[^2]: secure bits flag controls the root <-> non-root user changes capabilities. [[Linux Secure bits]]