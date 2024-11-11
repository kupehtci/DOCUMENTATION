
# ZABBIX - Overview

The Zabbix architecture consist in various components: 

* **Server** central hub to where agents report data . Stores the configuration for the Zabbix application. 
* **Database storage**: all the configuration information and recollected metrics are stored in the Database. In zabbix 6.0, the following databases are supported: 
	* MySQL 
	* MariaDB
	* PostgreSQL
	* Oracle
	* TimeScaleDB
	* SQLite
* **Web Interface**: easy access to Zabbix through web from anywhere and from any platform. 
* **Proxy**: collect performande and availability data on behalf of zabbix server. (Its an optional part). Can distribute the load of a single Zabbix server. 
* **Agent**: Installed in each monitoring targets to actively monitor local resources and applications and report this data to Zabbix server.

