
# ZABBIX Proxy configuration

This is a quick summary about how to install and configure a Zabbix proxy in a server and communicate with the main server to buffer and send data to it. 

Firstly is recommended to check if we have connection to the server and its port. 
For testing so, we can make a `telnet` connection to it and if connect, it will verify to us that the connection can be done: 

```bash
telnet <server-ip> 10050
telnet <server-ip> 10051
```

Once the service is correctly installed, stop the service in order to modify its configuration: 

```bash
systemctl stop zabbix-proxy
```

And configure the zabbix proxy: 

```bash
vim /etc/zabbix/
```

| Key       | Value                | Notes                                                                                                                                                   |
| --------- | -------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Proxymode | 0                    | 0 = Active. This is the default already.                                                                                                                |
| Server    | _domain name or IP_  | The DNS name or IP address of your Zabbix server.                                                                                                       |
| Hostname  | *hostnane*           | Use whatever hostname you desire.                                                                                                                       |
| DBName    | /tmp/zabbix_proxy.db | Database name, recommended to keep the same if the proxy downloaded is the one appropriated for the type of database used, in PSQL will be zabbix_proxy |