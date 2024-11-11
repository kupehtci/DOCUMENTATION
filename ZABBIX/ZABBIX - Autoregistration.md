
# ZABBIX Autoregistration

The autoregistration in Zabbix allow host to automatically register them based on some predefined rules and actions. 

For allowing hosts to auto register to the zabbix server, some autoregistration actions must be defined and if the host meet the trigger actions, it will be assigned as a new host with some properties defined in it. 

For creating this actions, we need to go to **Configuration > Actions > Autoregistration actions**: 

![[zabbix-autoregistration-actions.png|350]]

An **autoregistration action** is a set of conditions, that if they are meet when a host is connected to the zabbix server it register the host and set some properties to it. 

As this example, if a linux host's hostname meet the pattern `(.*?)` or that is equal to any hostname it will add the host, add to Linux Server host group and attach it the template `Linux by Zabbix agent active`. 

![[zabbix-autoregistration-action-conditions.png]]

To define an autoregistration action, we only need to set a condition that new host need to met and a set of operations or actions to do with the host. 


The host in order to autoregister to the zabbix server it need to have zabbix agent installed and configured as: 

* `Server` or `ServerActive` pointing to the zabbix server IP or FQDN name. 
* `Hostname` set as the hostname in the Operating System. 

When a new host try to register to the zabbix server it sends its hostname only, so the conditions that can meet are restricted by `hostname`, `hostmetadata` or `proxy` that the hostname uses. 

Using `proxy` as condition can be used to filter and autoregister hosts that are monitored by a certain proxy. 

