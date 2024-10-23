
# ZABBIX Install agent in a Debian machine 

This documentation gathers the steps that need to be followed to install a Zabbix agent to report metrics and status to a Zabbix Server taking as an example installation a Debian server linux distribution. 

You can get the different installation steps for different hosts in [Zabbix installation packages]([Download and install Zabbix](https://www.zabbix.com/download))

In this case for debian you can download the package using `wget` and then install it using `apt`: 

```bash
> wget https://repo.zabbix.com/zabbix/7.0/debian/pool/main/z/zabbix-release/zabbix-release_latest+debian12_all.deb  
> dpkg -i zabbix-release_latest+debian12_all.deb  
> apt update
> apt install zabbix-agent
```

Check that the service is created and active: 

```bash
systemctl list-units --type service
```

Once you have the agent service running, you will need to configure it to report to the server. 
The configuration file is placed in `/etc/zabbix/zabbix_agentd.conf` and it should have at least the following variables declared and correctly settled: 

```bash
> cat /etc/zabbix/zabbix_agentd.conf

Hostname=

PidFile=/run/zabbix/zabbix_agentd.pid


LogFile=/var/log/zabbix-agent/zabbix_agentd.log


LogFileSize=0


Server=127.0.0.1


ServerActive=127.0.0.1

Include=/etc/zabbix/zabbix_agentd.conf.d/*.conf

```

* `Server` and `ServerActive` should be pointing to the IP of the zabbix server. 
* `Hostname` must be the name of the host where the agent is running. Take into account that also the same hostname should be placed in the hostname when registering this host in the Zabbix server. 

Once the host is correctly running and we have make sure that the IP of the Zabbix server is reachable from the host to monitor, we need to add it in the server. 

##### Add new host

To add this new entity as a monitored host we need to go to *Monitoring > Hosts*. 

![[zabbix-monitoring-hosts.png]]

And in the upper section at the right, click on *Create Host*. 

![[zabbix-new-host.png]]

Here we have some things to configure to connect the host: 

*Host name* > Must be the hostname defined in the agent and the same as the hostname of the machine to monitor 
*Visible name* > Name that we will see in the host section of the server
*Templates* > we need to select a template that will create the correct dashboards and metrics watch for the type of device. In this case we select for a Linux machine **Linux by Zabbix agent**. *Host groups* > Groups to add this host for organization purposes. As an example can be added to **Linux servers** built-in group.  
*Interfaces* > Click to add interface (the element that report the metrics) and select the agent 
No interfaces are defined.
Add
Description
Monitored by
ServerProxyProxy group
Enabled
