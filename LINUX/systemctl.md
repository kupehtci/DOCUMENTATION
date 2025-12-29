#Linux 

# systemctl

`systemctl` is the main CLI tool in linux to manage the `systemd`[^1] as it can start, stop, enable, disable and inspect units (services, timers, sockets, targets and more). 

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

[^1]: systemd is the main service manager of the linux operating system [[systemd]]. 