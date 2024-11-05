
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
