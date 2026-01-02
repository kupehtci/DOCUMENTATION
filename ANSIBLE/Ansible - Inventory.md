#Ansible 

# Ansible - Inventory

An Inventory is the set of managed nodes that can be managed and automated using Ansible. 

In order to configure all the hosts into a inventory file, by default located under `/etc/ansible/hosts` that is by default an **ini** file. 

The composition of this file is based in different concepts: 
* You can either enter hostnames or ip addresses for each managed node. 
* You can **group** hosts into logical group names: 
	* You can also group other groups using `[<group-name>:children]` followed by the groups. 
* You can declare variables associated with individual hosts or entire groups in the inventory.
	* variables are normally defined in `host_vars` and `group_vars`
* You can mix various inventories defined each one in one file. 

Example of grouping: 

```ini
[linux:children]
debian13
debian11
ubuntu22

[debian:children]
debian13
debian11

[debian13]
10.0.0.2

[debian11]
10.0.0.3
10.0.0.4

[ubuntu22]
10.0.0.5

```

The commands over the hosts will follow the format: 
```bash
ansible <host> [-m module] [-a args] [options]
```

Like: 
* `ansible debian13 --list-hosts`: list all the hosts in the group
* `ansible debian11 -m ping`: uses ping module to ping a host group