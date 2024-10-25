
### Review port connection

When reviewing the logs of the service that are placed by default in `/var/log/zabbix-agent/zabbix_agentd.log`: 

```log
  3709:20241024:104010.688 **** Enabled features ****
  3709:20241024:104010.688 IPv6 support:          YES
  3709:20241024:104010.688 TLS support:           YES
  3709:20241024:104010.688 **************************
  3709:20241024:104010.688 using configuration file: /etc/zabbix/zabbix_agentd.conf
  3709:20241024:104010.689 agent #0 started [main process]
  3710:20241024:104010.689 agent #1 started [collector]
  3711:20241024:104010.690 agent #2 started [listener #1]
  3712:20241024:104010.690 agent #3 started [listener #2]
  3713:20241024:104010.690 agent #4 started [listener #3]
  3714:20241024:104010.690 agent #5 started [active checks #1]
  
  3714:20241024:104010.695 Unable to connect to [XXX.XXX.XXX.XXX]:10051 [cannot connect to [[XXX.XXX.XXX.XXX]:10051]: [111] Connection refused]
  3714:20241024:104010.695 Active check configuration update started to fail
```

In case that agent cannot connect to the server, we can check the error here in the logs. 

In the shown case, it cannot connect to the 10051 port, which is the one used by Zabbix to send data from the agent to the server. Review if this port is open and can be reached from the agent with a `telnet <ip> <port>`
