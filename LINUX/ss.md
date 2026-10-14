#Linux 

# ss

The `ss` (*Socket Statistics*) command shows information about the sockets of the system: open ports, established connections, listening services... It is part of the `iproute2` package and it is the modern replacement of `netstat`, being faster because it reads the information directly from the kernel. 

The basic syntax is: 
```bash
ss [options] [filter]
```

Without options it lists all the established non-listening connections. 

## Flags

* `-t` TCP sockets. 
* `-u` UDP sockets. 
* `-x` Unix sockets. 
* `-l` only listening sockets. 
* `-a` all sockets (listening and non-listening). 
* `-n` numeric, doesn't resolve service names nor hosts (faster). 
* `-p` shows the process using the socket (requires `sudo` for other users' processes). 
* `-e` extended info (uid, inode...). 
* `-s` summary statistics. 
* `-o` timer information. 
* `-i` internal TCP info (rtt, congestion window...). 
* `-4` / `-6` only IPv4 / IPv6. 

## Filters

`ss` allows filtering by state, port and address: 

* `state <state>`: `established`, `listening`, `time-wait`, `close-wait`, `syn-sent`... 
* `sport` / `dport`: source / destination port. 
* `src` / `dst`: source / destination address. 

## Examples

```bash
# Listening TCP and UDP ports with the process (the classic one)
sudo ss -tulpn

# Who is using the port 8080
sudo ss -ltnp 'sport = :8080'

# Established connections to a remote PostgreSQL
ss -tn state established '( dport = :5432 )'

# Connections from a certain network
ss -tn dst 10.0.0.0/24

# Count connections by state
ss -tan | awk 'NR>1 {print $1}' | sort | uniq -c

# Summary
ss -s
```

## netstat equivalences

| netstat | ss |
| ------- | -- |
| `netstat -tulpn` | `ss -tulpn` |
| `netstat -an` | `ss -an` |
| `netstat -s` | `ss -s` |
| `netstat -r` | `ip route` |
| `netstat -i` | `ip -s link` |

Related: [[lsof]], [[curl]]
