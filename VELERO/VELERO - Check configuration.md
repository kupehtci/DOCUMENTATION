#VELERO #AWS #AZURE #EKS #AKS 

# VELERO Check configuration 

This is a documentation about how to check if Velero has been correctly deployed within a Cloud managed Cluster (EKS, AKS or GKE)

Take into account that Velero[^1] is modular and independent from an provider, so for configuring each provider dependent configuration, some init containers configuration is provided. 

This checks and validation instructions are not dependent of the provider where the Cluster is.

The steps to follow are: 

* Validate Secret creation for cloud credentials
* deployment, replicaset, daemon set and service validation
* Check main pod logs to check that there is no relevant errors about BackupStorageLocation[^2] or VolumeSnapshotLocation[^3] creation errors
* Check locations to check that has been created correctly and are marked as AVAILABLE
* Check that velero can see the different resources for the backups and restores using `velero cli`
### Validation 

Once it has been correctly deployed, we can check some resources in order to check that all has been deployed correctly. 

In the case of AWS, AZURE and GOOGLE, a `secret/velero` with a data key named cloud must be created containing the previously defined provider authentication credentials. 

We can make sure that this secret has been created successfully: 

```bash
> kubectl get secret -n velero

sh.helm.release.v1.velero.v1   helm.sh/release.v1   1      23h
velero                         Opaque               1      23h
velero-repo-credentials        Opaque               1      24h

> kubectl describe secret/velero -n velero
Name:         velero
Namespace:    velero
Labels:       app.kubernetes.io/instance=velero
              app.kubernetes.io/managed-by=Helm
              app.kubernetes.io/name=velero
              helm.sh/chart=velero-7.2.1
Annotations:  meta.helm.sh/release-name: velero
              meta.helm.sh/release-namespace: velero

Type:  Opaque

Data
====
cloud:  112 bytes
```

The deployment should create the following resources:

```bash
❯ kubectl get all -n velero
NAME                          READY   STATUS    RESTARTS   AGE
pod/node-agent-xxxxx          1/1     Running   0          24h
pod/velero-xxxxxxxxxx-xxxx    1/1     Running   0          24h

NAME             TYPE        CLUSTER-IP       EXTERNAL-IP   PORT(S)    AGE
service/velero   ClusterIP   XXX.XXX.XXX.XXX   <none>        8085/TCP   24h

NAME                        DESIRED   CURRENT   READY   UP-TO-DATE   AVAILABLE 
daemonset.apps/node-agent   1         1         1       1            1           

NAME                     READY   UP-TO-DATE   AVAILABLE   AGE
deployment.apps/velero   1/1     1            1           24h

NAME                                DESIRED   CURRENT   READY   AGE
replicaset.apps/velero-xxxxxxxxxx   1         1         1       24h
```

Make sure that all resources and mainly the `pod/velero-xxxxxxxxx-xxxx` its ready. 

If its not ready or want to make sure that all the backup storage location and volume snapshot location has been created successfully, we can describe it or get its logs to check that has not been any errors: 

```bash
❯ kubectl logs pod/velero-xxxxxxxxxx-xxxxx -n velero | grep error
```

Make sure that the defined backup storage locations has been created and if one was named as 'default' check that has been set as DEFAULT: true

```bash
❯ kubectl get backupstoragelocations.velero.io -n velero
NAME      PHASE       LAST VALIDATED   AGE   DEFAULT
default   Available   34s              24h   true

❯ kubectl describe backupstoragelocations.velero.io/default -n velero
Name:         default
Namespace:    velero
Labels:       app.kubernetes.io/instance=velero
              app.kubernetes.io/managed-by=Helm
              app.kubernetes.io/name=velero
              helm.sh/chart=velero-7.2.1
Annotations:  meta.helm.sh/release-name: velero
              meta.helm.sh/release-namespace: velero
API Version:  velero.io/v1
Kind:         BackupStorageLocation
Metadata:
  Creation Timestamp:  XXXX-XX-XXTXX:XX:XXZ
  Generation:          xxxxx
  Resource Version:    xxxxxxxx
  UID:                 c92963ba-8881-4b5d-82ed-b42b49b497dd
Spec:
 # PROVIDER RELATED
Status:
  Last Synced Time:      2024-09-19T09:09:11Z
  Last Validation Time:  2024-09-19T09:08:37Z
  Phase:                 Available
Events:                  <none>
```

Make sure that the defined volume snapshot locations has been created. 

```
❯ kubectl get volumesnapshotlocations.velero.io -n velero
NAME      AGE
default   24h
```

After we have made at least one backup, we can make sure that the Kubernetes resource has been correctly created

```
❯ kubectl get backups.velero.io -n velero
NAME           AGE
example-bk     22h
example-bk-1   22h
```

Once we have deployed the service, by having the appropriate kubeconfig file, you can automatically manage velero using the Velero CLI. 

Also we need to check that through Velero CLI, the pod is able to recognize the created resources: 

```bash
# Check the created backup storage locations
❯ velero backup-location get
NAME      PROVIDER   BUCKET/PREFIX        PHASE       LAST VALIDATED               
default   aws        boilerplate-pre-s3   Available   2024-09-19 11:17:37

# Check the created snapshot locations
❯ velero snapshot-location get
NAME      PROVIDER
default   aws

# Check the created schedules
> velero schedule get
```


[^1]: Velero is a Disaster Recovery tool created by vmware to backup, restore and migrate Kubernetes clusters and its resources. [[VELERO]]
[^2]: BackupStorageLocation is a CustomResourceDefinition for holding  the configuration regarding to a Backup files and its information about snapshots created. [[VELERO - BackupStorageLocation]]
[^3]: VolumeSnapshotLocation is a CustomResourceDefinition for abstracting an provider specific snapshot location within a file system. [[VELERO - VolumeSnapshotLocation]] 