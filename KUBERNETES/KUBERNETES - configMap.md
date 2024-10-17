#KUBERNETES 

## Kubernetes configMap

A <span style="color:orange;">configMap</span> is an API object used to store <span style="color:lightseagreen;">non-confidential data</span> in key value pairs. 

This allows to decouple environment specific configurations from the container images. 

The configMap has some keys with single values and others like a fragment of a configuration format. 

An example of the format of a configMap: 

```yaml
apiVersion: v1
kind: ConfigMap
metadata:
  creationTimestamp: 2022-02-18T18:52:05Z
  name: game-config
  namespace: default
  resourceVersion: "516"
  uid: b4952dc3-d670-11e5-8cd0-68f728db1985
data:
  game.properties: |
    enemies=aliens
    lives=3
    enemies.cheat=true
    enemies.cheat.level=noGoodRotten
    secret.code.passphrase=UUDDLRLRBABAS
    secret.code.allowed=true
    secret.code.lives=30    
  ui.properties: |
    color.good=purple
    color.bad=yellow
    allow.textmode=true
    how.nice.to.look=fairlyNice  
```


