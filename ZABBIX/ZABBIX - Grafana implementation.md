# ZABBIX Grafana implementation

This is a quick step through about the implementation of grafana as dashboard and observability tool for zabbix server. 

For doing this we need to have Zabbix and grafana running and connectivity between them.

### Steps

In grafana, we will need to enable the Zabbix plugin that will be used as proxy between grafana dashboards and zabbix server database. 

For this, we need to go to grafana > Administration > Plugins and data > Plugins. 

![[zabbix-grafana-plugin.png]]

Then, search for Zabbix plugin and select in. Then click *install* and once its installed click on *Enable*.

![[zabbix-grafana-enable.png]]

