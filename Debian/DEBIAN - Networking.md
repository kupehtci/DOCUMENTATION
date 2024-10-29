#LINUX 

# DEBIAN Networking commands

This are some commands for common networking operations that can be done in a Debian OS machine: 

##### Get information

| Command                                   | Description                                           |
| ----------------------------------------- | ----------------------------------------------------- |
| `ip a`                                    | Show all IP addresses and network interfaces          |
| `ip link`                                 | Display or modify network interface status            |
| `ifconfig`                                | Show network interface details (requires `net-tools`) |
| `ip route`                                | Show and modify the IP routing table                  |
| `hostname -I`                             | Display the IP address of the host                    |
| `ip addr add <IP>/<mask> dev <interface>` | Assign IP to an interface                             |
| `ip addr del <IP>/<mask> dev <interface>` | Remove IP from an interface                           |

##### Diagnosis

| Command                          | Description                                       |
|----------------------------------|---------------------------------------------------|
| `ping <host>`                    | Test network connectivity to a host               |
| `traceroute <host>`              | Show route packets take to a network host (install `traceroute`) |
| `mtr <host>`                     | Combined traceroute and ping (install `mtr`)      |
| `nslookup <domain>`              | Query DNS to resolve a domain name                |
| `dig <domain>`                   | Detailed DNS query (requires `dnsutils`)          |
| `whois <domain>`                 | Get information about a domain                    |
| `ip neigh`                       | Show or manipulate neighbor objects (ARP cache)   |

##### Ports and connection mamagement

| Command                 | Description                                             |
| ----------------------- | ------------------------------------------------------- |
| `netstat -tuln`         | Show listening ports and services (install `net-tools`) |
| `ss -tuln`              | Show listening ports (alternative to `netstat`)         |
| `lsof -i :<port>`       | Show processes using a specific port                    |
| `nmap <IP or hostname>` | Scan open ports on a server (install `nmap`)            |
| `telnet <host> <port>`  | Check connection to a specific port                     |
| `nc -zv <host> <port>`  | Test if a port is open (netcat)                         |

##### Interface Management

| Command                                    | Description                                  |
|--------------------------------------------|----------------------------------------------|
| `ifdown <interface>`                       | Bring down a network interface               |
| `ifup <interface>`                         | Bring up a network interface                 |
| `ip link set <interface> up`               | Enable a network interface                   |
| `ip link set <interface> down`             | Disable a network interface                  |
| `ethtool <interface>`                      | Display Ethernet device information (requires `ethtool`) |
| `iwconfig <interface>`                     | Configure wireless network interface (install `wireless-tools`) |

##### Network Traffic

| Command                  | Description                                                     |
| ------------------------ | --------------------------------------------------------------- |
| `tcpdump -i <interface>` | Capture packets on an interface (requires `tcpdump`)            |
| `iftop -i <interface>`   | Monitor bandwidth usage by host (install `iftop`)               |
| `nload <interface>`      | Monitor incoming and outgoing network traffic (install `nload`) |
| `vnstat`                 | Monitor network traffic usage (install `vnstat`)                |
| `iptraf`                 | Network monitoring utility (install `iptraf-ng`)                |

##### SSH and Remote Connections

| Command                                        | Description                                       |
|------------------------------------------------|---------------------------------------------------|
| `ssh user@host`                                | Connect to a remote server via SSH                |
| `scp <file> user@host:/path/to/destination`    | Copy files over SSH                               |
| `ssh-keygen -t rsa`                            | Generate SSH key pair                             |
| `ssh-copy-id user@host`                        | Copy SSH public key to a server for key-based login |
| `sftp user@host`                               | Connect to remote server for file transfer over SSH |
| `rsync -avz <source> user@host:/destination`   | Sync files over SSH with compression              |

> **Note**: Some commands require `sudo` for administrative privileges.
