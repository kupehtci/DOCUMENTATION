#GCP 

### GCloud  List available regions

You can list all the available regions for deploying GCP resources by using the Google Cloud CLI, run the following command: 

```bash
gcloud compute regions list
```

It will get an output like this: 

```bash
gcloud compute regions list
NAME             CPUS   DISKS_GB     ADDRESSES  RESERVED_ADDRESSES  STATUS
asia-east1       0/24   0/10240           0/23       0/7                 UP
asia-northeast1  0/24   0/10240           0/23       0/7                 UP
asia-southeast1  0/24   0/10240           0/23       0/7                 UP
europe-west1     0/24   0/10240           2/23       0/7                 UP
us-central1      0/24   0/10240           0/23       0/7                 UP
us-east1         0/24   0/10240           0/23       0/7                 UP
us-west1         0/24   0/10240           0/23       0/7                 UP
```

Once you get the regions you can describe the decided region using also the Google Cloud CLI: 

```bash
gcloud compute regions describe <region>
```

And you should get a response like this with the region information: 

```yaml
creationTimestamp: '2013-09-06T17:54:12.193-07:00'
description: us-central1
id: 'XXXXXXXXXXXXXXXXXXX'
kind: compute#region
name: us-central1
quotas:
- limit: 24.0
    metric: CPUS
    usage: 5.0
- limit: 5120.0
    metric: DISKS_TOTAL_GB
    usage: 650.0
- limit: 7.0
    metric: STATIC_ADDRESSES
    usage: 4.0
- limit: 23.0
    metric: IN_USE_ADDRESSES
    usage: 5.0
- limit: 1024.0
    metric: SSD_TOTAL_GB
    usage: 0.0
selfLink: https://www.googleapis.com/compute/v1/projects/PROJECT_ID/regions/us-central1
status: UP
zones:
- https://www.googleapis.com/compute/v1/projects/PROJECT_ID/zones/us-central1-a
- https://www.googleapis.com/compute/v1/projects/PROJECT_ID/zones/us-central1-b
- https://www.googleapis.com/compute/v1/projects/PROJECT_ID/zones/us-central1-c
- https://www.googleapis.com/compute/v1/projects/PROJECT_ID/zones/us-central1-f
```