#GCP 

# GCP Workload Identity

Workload Identity helps to grant this access to Google Resources without needing to create a service account within Kubernetes and grant Pod's permissions using a secret. 

After workload identities, the process to grant access to a pod over GCloud resources was to create a Google Service account and access key and grant that IAM Service Account credentials to the pod using a secret.  

All this steps  are replaced with a more secure and easy way: 

* Create a **GCloud Service Account** and bind the `roles/iam.workloadIdentityUser` policy to it with member `"serviceAccount:$<project-id>.svc.id.goog[<namespace>/<k8s-service-account-name>]"`
* Create a **Kubernetes Service Account** and annotate with `iam.gke.io/gcp-service-account=<gcloud-service-account-name>@$PROJECT_ID.iam.gserviceaccount.com`. 

Example: 

```bash
PROJECT_ID = "..."
SA_NAMESPACE = "..."
kubectl create serviceaccount <k8s-sa-name>

gcloud iam service-accounts create <gcloud-sa-name> --description "SA for the GKE Demo Workload"

gcloud iam service-accounts add-iam-policy-binding workload-id-demo-gcp-sa@$PROJECT_ID.iam.gserviceaccount.com \
    --role roles/iam.workloadIdentityUser \
    --member "serviceAccount:${PROJECT_ID}.svc.id.goog[${SA_NAMESPACE}/<k8s-sa-name>]"

kubectl annotate serviceaccount <k8s-sa-name> \
    --namespace default \
    iam.gke.io/gcp-service-account=<gcloud-sa-name>@${PROJECT_ID}.iam.gserviceaccount.com
```

Take into account that, in order to use workload identity, the GKE node pool and indeed the node where the pod is running, must have the following annotation `iam.gke.io/gke-metadata-server-enabled=true` in order to use. 
This annotation is automatically added when the GKE cluster is created with an assigned workload pool and the node pool' workload metadata to use GKE_METADATA: 

``` bash
ZONE = "..."
PROJECT_ID = "..."

# The creation must have: 
gcloud container clusters update demo-gke-cluster \
    --zone=$ZONE \
    --workload-pool=$PROJECT_ID.svc.id.goog

gcloud container node-pools update default-pool \
    --cluster=demo-gke-cluster \
    --zone=$ZONE \
    --workload-metadata=GKE_METADATA
```