#LINUX

# Debian - List services

We have the `systemctl` command for listing services and daemons.

### List all services and daemons

If we do `systemctl` we will get all the units present in the OS. 

To exit the list we can press `Q`. 

The columns displayed are: 
- **Unit**: The name of the service or daemon. The column is titled "Unit" because whatever is in this column was launched using information `systemd` found in a unit file.
- **Load**: The load state of the service or daemon. It can be loaded, not-found, bad-setting, error, or masked.
- **Active**: The overall state the service or daemon is in. It can be active, reloading, inactive, failed, activating, or deactivating.
- **SUB**: The sub-state of the service or daemon. It can be dead, exited, failed, inactive, or running.
- **Description**: A short description of the unit or the path where is running. 

If we want to only get the services: 

```bash
systemctl --type=service
```
### List active services

If we want to list only the active services, we can refine the command with the `--type` and `--status` flags. 

```bash
> systemctl --type=service --state=running
```