
## ZABBIX High Availability Mode

ZABBIX has an HA or High Availability mode where multiple Zabbix servers runs as nodes in a cluster. 

One server acts as the main and active one while the rest keep in suspension waiting for the active one to fail or deactivate to start running. 

Zabbix High Availability (HA) mode is a setup designed to make Zabbix more resilient by ensuring the system remains available even in the event of a server failure. It doesn't reduce the workload of the active server.  

In HA mode, Zabbix Server runs in a cluster of two or more nodes, where only one node is active at a time (active-passive configuration). If the active node fails, another node in the cluster takes over, minimizing downtime and ensuring continuous monitoring.

The basic requirements to deploy an HA Mode's zabbix cluster are: 

* Two or more zabbix server nodes deployed
* A single Database that would be shared between all the nodes. 
* A shared storage 

And the  steps to configure it: 

* Install zabbix server in all the servers. 
* Configure `zabbix_server.conf` with the same database configuration to point to this DB and be able to authenticate to it.
* Configure HA Mode in the configuration of the server: 
	* Set `HANodeName` to a unique node identifier within the cluster
	* Set `NodeAddress` as `address:port` that need to match the IP or FQDM of the server where is running. This reports to the Web where it need to connect to retrieve the data. 