#KUBERNETES 

### Storage in pods

Because Kubernetes treats each pod as ephemeral or disposable resources, the data is not persistent. 

A <span style="color:orange;">volume</span> is a way to store, retrieve and persist data across pods and in the application cycle. 

A volume mounted in a pod, is a directory which is accessible to the containers in a pod. 

In order to use a volume: 

* Specify the volume to provide in `.specs.volumes`
* Declare where to mount those volumes into containers in `.specs.containers[*].volumeMounts`. 

Format to mount volumes: 

```yaml
apiVersion: v1
kind: Pod
metadata:
  name: my-lamp-site
spec:
    containers:
    - name: mysql
      image: mysql
      volumeMounts:
      - mountPath: /var/lib/mysql
        name: site-data
        subPath: mysql
    - name: php
      image: php:7.0-apache
      volumeMounts:
      - mountPath: /var/www/html
        name: site-data
        subPath: html
    volumes:
    - name: site-data
      persistentVolumeClaim:
        claimName: my-lamp-site-data
```


A Persistent Volume can be mounted with any capabilities allowed by the provider and can have different access modes to limit or allows different write or read operations from all pods. 

* <span style="color:DodgerBlue";>ReadWriteOnce</span> (RWO) allows the volume to be mounted by a single node. If all pods belong to same node, they are all allowed to access. 
* <span style="color:DodgerBlue;">ReadWriteOncePod</span> (RWOP) same but restricted to only one pod. 
* <span style="color:DodgerBlue;">ReadOnlyMany</span> (ROX) limited to read-only to many nodes
* <span style="color:DodgerBlue;">ReadWriteMany</span> (RWX) allowed read-write by many nodes
