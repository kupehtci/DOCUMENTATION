
This is a quick summary of the installation of Zabbix agent in an Ubuntu 18.0 server. 

##### Steps

In order to be able to install the deb packages, become a root user: 

```bash
sudo -s 
sudo su
```

Install the agent from the original repository: 

```bash
wget https://repo.zabbix.com/zabbix/7.0/ubuntu/pool/main/z/zabbix-release/zabbix-release_latest+ubuntu18.04_all.deb
dpkg -i zabbix-release_latest+ubuntu18.04_all.deb
apt update

apt install zabbix-agent
```

Once it is installed, stop the service before configuring it: 

```bash
systemctl stop zabbix-agent
```

And in the agent configuration file, you need to set: 

* For **passive** checks, configure `Server` to the Zabbix server IP or Zabbix proxy
* For **active** checks, configure `ServerActive` to the Zabbix server IP or Zabbix proxy
* Set `Hostname` to the current name of the host. 

Once it has been configured, restart and enable the service:

```bash
systemctl restart zabbix-agent
systemctl enable zabbix-agent
```
