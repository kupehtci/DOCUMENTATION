#VELERO 

# VELERO Hooks 

Velero hooks serve for adding commands or actions that need to be executed in a pod after and before doing a backup. 

This annotations can be made into the pod like the following: 

```yaml
kubectl annotate pod -n <namespace> -l <key>=<label> \
    <pre/pro>.hook.backup.velero.io/command='["command", "flag", "value"]' \
    <pre/pro>.hook.backup.velero.io/container=<container-name>
```

Example: 

```yaml
kubectl annotate pod -n nginx-example -l app=nginx \
    pre.hook.backup.velero.io/command='["/sbin/fsfreeze", "--freeze", "/var/log/nginx"]' \
    pre.hook.backup.velero.io/container=fsfreeze \
    post.hook.backup.velero.io/command='["/sbin/fsfreeze", "--unfreeze", "/var/log/nginx"]' \
    post.hook.backup.velero.io/container=fsfreeze
```

To make sure that the hook have been executed correctly, the details about them will be filled in the backup description: 

```bash
> velero backup describe <backup name>
# ...
# HooksAttempted:   1
# HooksFailed:      0
# ...
```

If anyone of them fails, the error will be included in the `Errors` section of the backup/restore description. 