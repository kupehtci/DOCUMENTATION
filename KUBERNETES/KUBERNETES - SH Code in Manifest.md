#KUBERNETES 

Within the Manifest of the Kubernetes API object, some code can be specified. 

As an example, some **SH** code can be executed by specifying it following this format using `command` and the "sh" option: 

```yaml
 command: [ "sh", "-c"]
      args:
      - while true; do
          echo -en '\n';
          printenv MY_NODE_NAME MY_POD_NAME MY_POD_NAMESPACE;
          printenv MY_POD_IP MY_POD_SERVICE_ACCOUNT;
          sleep 10;
        done;
```