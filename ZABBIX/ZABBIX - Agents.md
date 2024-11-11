# ZABBIX Agents

The agent needs to be installed on monitored targets to actively monitor local resources and applications. 
The agent is in charge of reporting the metrics to the correspondent server. 
It gathers information locally and reports this data to the Zabbix server for processing.
In the event of failures, the Zabbix server can alert administrators of the issue.

Zabbix agents are highly efficient due to their use of native system calls for gathering statistical information.

### Passive and active

Zabbix agents can perform two types of checks:

- **Passive Checks**:
    The agent responds to data requests from the Zabbix server (or proxy).For example, when the server requests CPU load, the Zabbix agent sends back the result.
- **Active Checks**:
    These require more complex processing.
    The agent retrieves a list of items from the Zabbix server for independent processing and periodically sends new values back to the server.

To configure whether to perform passive or active checks, select the appropriate monitoring item type by setting in the agent `Server` or `ServerActive` respectively. 

Zabbix agent processes items of type `Zabbix agent` or `Zabbix agent (active)`.
