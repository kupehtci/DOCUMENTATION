#EKS #AWS #CLOUD #VELERO 

# EKS Velero 

This is a basic introduction and setup of a basic Velero[^6] configuration for performing EKS[^1] kubernetes resources backups and restores. 

### Prerequisites

* A running EKS cluster with node groups[^2] / EC2[^3] or AWS fargate[^4] as cluster's workers
* `kubectl` tool installed
* kubeconfig or credential files of the EJS cluster to access the Kubernetes services
* `velero` cli tool installed
* A running and available S3 bucket in same VPC or with Private Link to the current EKS' VPC. 
* EBS or other persistent storage solution for the EKS' compute instances. In case of EBS, we will need EBS-CSI driver (EKS Addon) or other Container Storage Interface for having the API for storage in that cloud provider

We can make sure that the appropriate StorageClass kubernetes resource is created for the EBS CSI controller: 

```bash
❯ kubectl get StorageClass -A
NAME   PROVISIONER             RECLAIMPOLICY   VOLUMEBINDINGMODE     
gp2    kubernetes.io/aws-ebs   Delete          WaitForFirstConsumer   false   
```

# Velero deployment in AWS cloud

### Providers configuration 

To deploy Velero to the AWS cloud we are going to use velero helm release and deploy to the EKS cluster using terraform `helm` provider. 
Also because some resources of AWS need to be imported as data resources, we also need the `aws` provider for getting S3 bucket and declare other resources. 

For configuring `aws` provider, by default you can set some configuration in the `~/.aws/config` and use this configuration with SSO to login in AWS. 

```yaml
locals{
  aws_region                   = "eu-north-1"
  aws_shared_config_files      = ["/home/dlaplana/.aws/config"]
  aws_shared_credentials_files = ["/home/dlaplana/.aws/credentials"]
  # aws_access_key = ""
  # aws_secret_key = ""
  aws_profile = "hiberus-devops"
}

provider "aws" {
  region = local.aws_region

  ## Uncomment this for login using user access and secret key 
  ## 
  # access_key = local.aws_access_key
  # secret_key = local.aws_secret_key

  ## Uncomment this for login using Profiles
  ## 
  shared_config_files      = local.aws_shared_config_files
  shared_credentials_files = local.aws_shared_credentials_files

  profile = local.aws_profile

  default_tags {
    tags = {
      Environment = local.environment
      Project     = local.project
    }
  }
}
```

You can authenticate AWS provider to the AWS cloud by two different forms: 

* Set `access_key` and `secret_key` to a user login access and secret. 
* Having a configuration and credentials files in `~/.aws/` settled with the login credentials to the AWS Cloud. For this, `shared_config_files` and `shared_credentials_files` need to be set to the path to each one of this files. Also `profile` need to be set to the name of the profile set within the configuration file. 

The `default_tags` variable is a list of tags that will be added to all the objects created with the AWS provider.  

For configuring `helm`, we only need to get the `kubeconfig` of the correspondent EKS cluster stored in the device. If the path where the kubeconfig fie is placed must be set in `config_path` variable. 

```hcl
provider "helm" {
  kubernetes {
    config_path = "~/.kube/config"
    config_context = "<context-name>"      #(Optional)
  }
}
```

* `config_context` will take the context by default. In case you have more than one context using at the same time, set the context name in this variable. 
	* For getting the current settled context in the current kubeconfig file you can use `kubectl config get-contexts`. 
	* You can also set the kubernetes context by using `kubectl use-context <context-name>` before doing the `terraform apply`. 

### Related resources configuration 

For deploying Velero, it needs an S3 bucket to store the backups related files and EBS capabilities to create snapshots from the cluster Persistent Volumes. 

Also for doing so, S3 bucket permissions can be set to Node Group, but for a more granular permission attributions, its settled to an IAM Role that following IRSA AWS roles, Velero pod can be used to authenticate within AWS and manage S3 bucket and EBS files. 

Firstly, we need the data about the S3 bucket that is going to be used for the backups. For retrieving this `data` resource we only need the name of the S3 bucket that we are going to use: 

```hc
data "aws_s3_bucket" "s3" {
  bucket = local.s3_bucket_name
}
```

In the case of creating a new S3 bucket for this backups, we will need to assign it to the IAM Policy of Velero and the helm release: 

```hcl
resource "aws_s3_bucket" "s3"{
  bucket = "<bucket-name>"
  tags = {
	  Name = "<bucket-name>"
  }
}
```

For that, we need to define an IAM role for Velero and attach a custom policy for this permissions. 

```hcl
resource "aws_iam_user" "iam_user_velero" {
  name = "iam-user-velero"
}

resource "aws_iam_access_key" "iam_user_velero_access_key" {
  user = aws_iam_user.iam_user_velero.name
  status = "Active"
}

resource "aws_iam_user_policy" "iam_policy_velero" {
  name = "velero-iam-policy"
  user = aws_iam_user.iam_user_velero.name
  policy = jsonencode(
    {
    Version: "2012-10-17",
    Statement: [
        {
            Effect: "Allow",
            Action: [
                "ec2:DescribeVolumes",
                "ec2:DescribeSnapshots",
                "ec2:CreateTags",
                "ec2:CreateVolume",
                "ec2:CreateSnapshot",
                "ec2:DeleteSnapshot"
            ],
            Resource: "*"
        },
        {
            Effect: "Allow",
            Action: [
                "s3:GetObject",
                "s3:DeleteObject",
                "s3:PutObject",
                "s3:AbortMultipartUpload",
                "s3:ListMultipartUploadParts"
            ],
            Resource: [
                "arn:aws:s3:::${local.s3_bucket_name}/*"
            ]
        },
        {
            Effect: "Allow",
            Action: [
                "s3:ListBucket"
            ],
            Resource: [
                "arn:aws:s3:::${local.s3_bucket_name}"
            ]
        }
    ]
}
  )
}
```

In case you have created an S3 bucket for this solution, replace `${local.s3_bucket_name}` with your newly created S3 bucket's name. 

* The `aws_iam_access_key` resource is used to generate an access id and access secret to be able by Velero pod to authenticate in the AWS cloud. 
* The `aws_iam_user` resource is used to grant only access to the Velero pod and don't assign an Assumable Role to the EKS node group. 
* The `aws_iam_user_policy` resource sets the permissions allowed to the Velero IAM User. This policy grants permissions over the following resources: 
	* EC2: volumes and snapshots. This allows Velero for generating snapshots of the current persistent volumes
	* S3: Generate objects, delete and upload in order to store the backups related information. 

The `helm_release` for velero sets the values that need to be granted from other Terraform resources by replacing some values inside `values-velero.yaml` using `templatefile()` function. 

```yaml
resource "helm_release" "velero" {
  name = "velero"

  chart      = "velero"
  
  repository = "https://vmware-tanzu.github.io/helm-charts"
  version    = "7.2.1"

  namespace        = local.velero_namespace
  create_namespace = true
  
  atomic = true

  values = [
        "${templatefile("${path.module}/values-velero.yaml", {
    ACCESS_KEY = "${aws_iam_access_key.iam_user_velero_access_key.id}", 
    SECRET_ACCESS_KEY = "${aws_iam_access_key.iam_user_velero_access_key.secret}", 
    BUCKET = "${data.aws_s3_bucket.s3.id}", 
    REGION = "${local.aws_region}"
  })}"
 ]
}
```

In case you have created an S3 bucket for this solution, replace `${data.aws_s3_bucket.s3.id}` with your newly created S3 bucket's name. 

### Once its installed

Once it has been correctly deployed, we can check some resources in order to check that all has been deployed correctly. 

In the case of AWS and AZURE, a `secret/velero` with a data key named cloud must be created containing the previously defined provider authentication credentials. 

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
  Access Mode:  ReadWrite
  Config:
    Region:  <region>
  Default:   true
  Object Storage:
    Bucket:  <s3-bucket-name>
  Provider:  aws
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
#### Default backup and volume snapshot location

By default, velero will use the backup storage location and volume snapshot location that are called 'default'. 
In case of only declaring one location for each one, its recommended to name them as it and don't change the current default locations.

If you have set another name, take them into account of selecting them when doing a `velero backup create`

There need to exists a `default` backup storage location, but Velero can be deployed without an volume snapshot location or a `default` one. In the case that we define a newly location, we can set it as default with this command: 

```bash
# Using the Velero CLI you can set a new default Volume Snapshot Location
velero server --default-volume-snapshot-locations="<PROVIDER-NAME>:<LOCATION-NAME>,<PROVIDER2-NAME>:<LOCATION2-NAME>"
```

Also if want to change the default backup storage location, can be done using Velero CLI: 

```bash
velero server --default-backup-storage-location "<backup-location-name>"

# example:
❯ velero backup-location get
NAME      PROVIDER   BUCKET/PREFIX        PHASE       LAST VALIDATED               
example-1 aws        example-pre-s3   Available 

velero server --default-backup-storage-location example-1
```
##### Namespace

Velero is installed by default in the `velero` namespace and its recommended to keep it within it. 

By default if using Velero CLI to do the backups and restores. will try to find the resources in this namespace. In case of changing the **namespace**, set the namespace that Velero CLI searches, using the following command:

```bash
velero client config set namespace=<NAMESPACE_VALUE>
```

##### Use IRSA ServiceAccount instead of IAM User

In case of granting the permissions using an IAM Role instead of an IAM User, you can follow this steps to grant Velero the IAM Assumable role: 

* Create the IAM Policy, you can keep the same that is currently created. 
* Create an IAM Role that can be assumed by a Web Entity
* Associate the IAM role with the correspondent Service Account using the `eks.amazonaws.com/role-arn: <velero-iam-role-arn>` annotation in the Service account associated with velero. 

To do this you can use this terraform code: 

```yaml

data "aws_caller_identity" "current" {}

data "aws_eks_cluster" "cluster" {
  name = var.cluster_name
}

resource "aws_iam_policy" "velero_policy" {
	# Same as previous 
}


resource "aws_iam_role" "velero_role" {
  name               = "velero-role"
  assume_role_policy = jsonencode({
    "Version": "2012-10-17",
    "Statement": [
      {
        "Effect": "Allow",
        "Principal": {
          "Federated": "arn:aws:iam::${data.aws_caller_identity.current.account_id}:oidc-provider/${data.aws_eks_cluster.cluster.identity[0].oidc.issuer}"
        },
        "Action": "sts:AssumeRoleWithWebIdentity",
        "Condition": {
          "StringEquals": {
            "${replace(data.aws_eks_cluster.cluster.identity[0].oidc.issuer, "https://", "")}:sub": "system:serviceaccount:velero:velero"
          }
        }
      }
    ]
  })
}

resource "aws_iam_role_policy_attachment" "velero_policy_attachment" {
  role       = aws_iam_role.velero_role.name
  policy_arn = aws_iam_policy.velero_policy.arn
}
```

And for setting the Service Account, complete this annotation for the ServiceAccount in the `values-velero.yaml` file to the correspondent IAM Role ARN. 
Also can be set to `serviceAccount.server.create: false` and create the ServiceAccount manually with the correspondent annotation. 

```yaml
serviceAccount:
  server:
    create: true
    name: "velero-irsa-service-account"
    annotations: 
      #  iam.amazonaws.com/role: "arn:aws:iam::<AWS_ACCOUNT_ID>:role/<VELERO_ROLE_NAME>"
```

##### Define schedules

Velero backups can be made on-demand or scheduled at certain time spans. 
This schedules can be set using velero cli, once it has been installed or let it pre-configured in the deploy. 

To define schedules, set them following this format in the `values-velero.yaml` file:

```yaml
schedules:
  <name-of-backup>:
    disabled: false
    labels:
      myenv: foo
    annotations:
      myenv: foo
    schedule: "0 0 * * *"
    useOwnerReferencesInBackup: false
    paused: false
    template:
      ttl: "240h"
      storageLocation: <name-of-backup-storage-location
      includedNamespaces:
      - <namespace-name-1>
      - <namespace-name-2>
      - ...
```

[^1]: Elastic Kubernetes Service [[AWS - EKS Elastic Kubernetes Service]]
[^2]: Node groups are auto managed Groups of EC2 machines with autoscaling and automatic Load Balancing between them. This is the most common compute instance used for EKS clusters [[AWS - EKS Compute instances]]
[^3]: Elastic Cloud Compute or EC2 is a virtual server within the AWS cloud. [[AWS - EC2]]
[^4]: AWS Fargate is a serverless solution for holding application within the cloud and running docker containers [[AWS - Fargate]]
[^6]: Velero Application for Kubernetes backup and restores cluster resources for Disaster Recovery