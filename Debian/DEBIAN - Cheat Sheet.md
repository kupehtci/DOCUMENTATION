#LINUX 

# DEBIAN Cheat sheet


# Debian Command Cheat Sheet

## System Information

| Command          | Description                              |
| ---------------- | ---------------------------------------- |
| `uname -a`       | Show kernel information                  |
| `hostnamectl`    | Get hostname and OS details              |
| `lsb_release -a` | Get Debian version                       |
| `df -h`          | Show disk usage in human-readable form   |
| `free -h`        | Show memory usage                        |
| `top`            | Show active processes and resource usage |

## Package Management

| Command                 | Description                |
| ----------------------- | -------------------------- |
| `apt update`            | Refresh package list       |
| `apt upgrade`           | Upgrade all packages       |
| `apt install <package>` | Install a specific package |
| `apt remove <package>`  | Remove a specific package  |
| `apt autoremove`        | Remove unused packages     |
| `dpkg -i <package>.deb` | Install a .deb file        |
| `dpkg -l`               | List installed packages    |

## File Management

| Command                                   | Description                                  |
|-------------------------------------------|----------------------------------------------|
| `ls -l`                                   | List files in long format                    |
| `cd <directory>`                          | Change directory                             |
| `cp <source> <destination>`               | Copy files or directories                    |
| `mv <source> <destination>`               | Move files or directories                    |
| `rm <file>`                               | Remove a file                                |
| `rm -r <directory>`                       | Remove a directory and its contents          |
| `chmod 755 <file>`                        | Change file permissions                      |
| `chown user:group <file>`                 | Change file owner and group                  |

## Disk and Storage

| Command                        | Description                              |
|--------------------------------|------------------------------------------|
| `fdisk -l`                     | List all partitions                      |
| `mount /dev/<partition> <dir>` | Mount a partition                        |
| `umount /dev/<partition>`      | Unmount a partition                      |
| `lsblk`                        | List all block devices                   |

## User and Group Management

| Command                            | Description                                  |
|------------------------------------|----------------------------------------------|
| `adduser <username>`               | Create a new user                            |
| `passwd <username>`                | Change user password                         |
| `deluser <username>`               | Delete a user                                |
| `groupadd <groupname>`             | Create a new group                           |
| `usermod -aG <groupname> <user>`   | Add a user to a group                        |

## Networking

| Command                          | Description                                  |
|----------------------------------|----------------------------------------------|
| `ip a`                           | Display all IP addresses                     |
| `ping <host>`                    | Test connectivity to a host                  |
| `ifconfig`                       | Display network interfaces (requires net-tools) |
| `netstat -tuln`                  | List open ports and listening connections    |
| `ss -tuln`                       | List open ports (preferred over netstat)     |
| `curl <url>`                     | Make a web request to a URL                  |
| `wget <url>`                     | Download a file from a URL                   |

## System Monitoring and Performance

| Command                       | Description                                  |
|-------------------------------|----------------------------------------------|
| `ps aux`                      | List all running processes                   |
| `htop`                        | Interactive process viewer (requires htop)   |
| `dmesg`                       | Kernel ring buffer messages                  |
| `uptime`                      | Show system uptime                           |
| `iostat`                      | Display CPU and I/O statistics               |
| `sar`                         | Collect and report system activity (requires sysstat) |

## System Services

| Command                               | Description                                  |
|---------------------------------------|----------------------------------------------|
| `systemctl start <service>`           | Start a service                              |
| `systemctl stop <service>`            | Stop a service                               |
| `systemctl restart <service>`         | Restart a service                            |
| `systemctl status <service>`          | Check status of a service                    |
| `systemctl enable <service>`          | Enable a service to start on boot            |
| `systemctl disable <service>`         | Disable a service from starting on boot      |

## SSH and Remote Connections

| Command                                        | Description                                  |
|------------------------------------------------|----------------------------------------------|
| `ssh user@host`                                | Connect to a remote server via SSH           |
| `scp <file> user@host:/path/to/destination`    | Copy files over SSH                          |
| `ssh-keygen -t rsa`                            | Generate SSH keys                            |
| `ssh-copy-id user@host`                        | Copy public key to a server for passwordless login |

## Text Processing

| Command                        | Description                    |
| ------------------------------ | ------------------------------ |
| `cat <file>`                   | Display file contents          |
| `grep <pattern> <file>`        | Search for a pattern in a file |
| `sed 's/<old>/<new>/g' <file>` | Replace text in a file         |
| `awk '{print $1}' <file>`      | Print first column in a file   |

## System Updates and Maintenance

| Command                               | Description                                  |
|---------------------------------------|----------------------------------------------|
| `reboot`                              | Restart the system                           |
| `shutdown now`                        | Shutdown the system                          |
| `shutdown -r +5`                      | Schedule a reboot in 5 minutes               |
| `timedatectl set-timezone <timezone>` | Set system timezone                          |
| `journalctl -u <service>`             | View logs for a specific service             |

> **Note**: Some commands may require `sudo` for administrative privileges.
