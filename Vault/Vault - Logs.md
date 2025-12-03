#VAULT 

# Vault - Logs

Vault exposes two types of logs: 
* **Vault server logs**: operative logs from the Vault server itself that describe that the internal server behavior: 
	* Check state
	* Review errors
* **Audit logs**: register each request made to Vault and its response in a JSON format that specify who made the request, from where, what type of actions and credentials / leases used. 

Audit Logs need to be enabled using `vault audit` command: 

```bash
vault audit enable file \
   file_path=/vault/logs/vault.log \
   mode=0640 \
   format=json \
   prefix=""
```

This wil make the logs to be exported in the `file_path` specified log file in JSON format, prompting logs like: 

```json
{
   "request":{
      "id":"a36e4781-368c-62c2-7e11-cb614a5925a6",
      "namespace":{
         "id":"root"
      },
      "operation":"update",
      "path":"sys/audit/test"
   },
   "time":"2025-11-14T09:32:21.364441011Z",
   "type":"request"
}{
   "auth":{
      "accessor":"hmac-sha256:7fb27dec49a1asdd9380e15e9e3853b42c95214a3aaac0e1d1f316a19344c2d7",
      "client_token":"hmac-sha256:363d108asdwaqqedbabcb4e44eed7e1ab428c2b73fc743f41cdcc6e618a3c9b5f1f5a",
      "display_name":"root",
      "policies":[
         "root"
      ],
      "policy_results":{
         "allowed":true,
         "granting_policies":[
            {
               "type":""
            },
            {
               "name":"root",
               "namespace_id":"root",
               "type":"acl"
            }
         ]
      },
      "token_policies":[
         "root"
      ],
      "token_issue_time":"2025-11-04T10:59:16Z",
      "token_type":"service"
   },
   "request":{
      "client_id":"0DHqasd2D77kL2/JTPSZkTMJbkFVmUu0TzMi0jiXcFy8=",
      "client_token":"hmac-sha256:363d108b660babcb4e44eed7e1ab428c2b73fc743f41cdccaaaqwe18a3c9b5f1f5a",
      "client_token_accessor":"hmac-sha256:7fb27dec49a1b67d9380e15e9e3853b42c95214a3aaac0e1d1f316a19344c2d7",
      "data":{
         "description":"hmac-sha256:f601a67c4a83e3bd11b04aa587e2d01f7abe57ce4e7f38c7ffad42050b02475c",
         "local":false,
         "options":{
            "file_path":"hmac-sha256:d2fb069680d0a6b4402f416c13e4136f31b1433c685fef67bcc40a4e425b2373",
            "format":"hmac-sha256:2ba1405fdd0d56950a9fa198c17b33390592fdddec29955b61d009832fd2b1cb",
            "mode":"hmac-sha256:cdc4c5e7272854f656dqwe1285f19a74fd194bc551cf3ba8cc649f14c81fab59d3",
            "prefix":"hmac-sha256:f601a67c4a83e3bd11b04aa587e2d01f7abe57ce4e7f38c7ffad42050b02475c"
         },
         "type":"hmac-sha256:89ec3073ee14715f293d09b6155a34db2b57da97cd717b6edbc1c4f8afa874bf"
      },
      "headers":{
         "user-agent":[
            "Go-http-client/1.1"
         ]
      },
      "id":"02dade39-ASc6-82ba-cc37-505cd3009130",
      "mount_accessor":"system_ac732fc5",
      "mount_class":"secret",
      "mount_point":"sys/",
      "mount_running_version":"v1.21.0+builtin.vault",
      "mount_type":"system",
      "namespace":{
         "id":"root"
      },
      "operation":"update",
      "path":"sys/audit/file",
      "remote_address":"127.0.0.1",
      "remote_port":52446
   },
   "time":"2025-11-14T09:32:21.364832928Z",
   "type":"response"
}
```