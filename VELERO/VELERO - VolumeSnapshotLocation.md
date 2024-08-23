#VELERO #KUBERNETES

## VolumeSnapshotLocation

A VolumeSnapshotLocation is the Kubernetes[^k] CRD resource used by velero to represent the configuration used for storing volume snapshots. 

Velero can optionally have this resource in order to be able to generate snapshots of the storage used in the kubernetes cluster via PVC. 

VolumeSnapshotLocation manifest don't need to be defined manually, they are deployed through Helm while deploying the velero charts. 

### Example

The different VolumeSnapshotLocation CRDs created by velero will have the following format: 

```yaml
apiVersion: velero.io/v1
kind: VolumeSnapshotLocation
metadata:
  annotations:
    meta.helm.sh/release-name: velero
    meta.helm.sh/release-namespace: velero
  creationTimestamp: '20XX-XX-XXTHH:MM:SSZ'
  generation: 1
  labels:
    app.kubernetes.io/instance: velero
    app.kubernetes.io/managed-by: Helm # In case of being deployed with Helm 
    app.kubernetes.io/name: velero
    helm.sh/chart: velero-7.0.0
  managedFields:
    - apiVersion: velero.io/v1
      fieldsType: FieldsV1
      fieldsV1:
        f:metadata:
          f:annotations:
            .: {}
            f:meta.helm.sh/release-name: {}
            f:meta.helm.sh/release-namespace: {}
          f:labels:
            .: {}
            f:app.kubernetes.io/instance: {}
            f:app.kubernetes.io/managed-by: {}
            f:app.kubernetes.io/name: {}
            f:helm.sh/chart: {}
        f:spec:
          .: {}
          f:config:
            .: {}
            f:resourceGroup: {}
            f:subscriptionId: {}
          f:provider: {}
      manager: terraform-provider-helm_v2.13.0_x5
      operation: Update
      time: '20XX-XX-XXTHH:MM:SSZ'
  name: default
  namespace: velero
  resourceVersion: 'XXXX'
  uid: XXXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXXX
  selfLink: /apis/velero.io/v1/namespaces/velero/volumesnapshotlocations/<snapshot-location-name>
spec:
  config:
    resourceGroup: <resource-group-name>
    subscriptionId: XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX
  provider: <provider-name>

```

### Providers

Depending on the provider of the infrastructure it will store the snapshots in different resources: 

```txt
+------------------------+-----------------------------+
|        Provider        |      Volume Snapshoter      |
+------------------------+-----------------------------+
| Amazon Web Service     | AWS EBS                     |
| Google Cloud Platform  | Google Compute Engine Disks |
| Azure                  | Azure managed disks         |
+------------------------+-----------------------------+
```
