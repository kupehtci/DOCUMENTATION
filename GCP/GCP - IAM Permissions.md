#GCP #CLOUD 

# GCP IAM Permissions

This is a list of the most common IAM Permissions that can be granted to IAM Principals in Google Cloud Platform: 

Google Kubernetes Engine[^1]: 

- **`container.clusters.create`**: Create new GKE clusters.
- **`container.clusters.delete`**: Delete GKE clusters.
- **`container.clusters.get`**: View details of existing clusters.
- **`container.clusters.update`**: Update GKE cluster configurations.
- **`container.pods.create`**: Create new Kubernetes pods.
- **`container.pods.delete`**: Delete Kubernetes pods.
- **`container.pods.get`**: View details of Kubernetes pods.
- **`container.services.get`**: View Kubernetes services.
- **`container.services.create`**: Create Kubernetes services.
- **`container.nodePools.create`**: Create node pools within a GKE cluster.
- **`container.nodePools.delete`**: Delete node pools from a GKE cluster.

Compute Engine (VMs)[^2]: 

- **`compute.instances.create`**: Create new virtual machines (VMs).
- **`compute.instances.delete`**: Delete VMs.
- **`compute.instances.get`**: View details of VM instances.
- **`compute.instances.start`**: Start a stopped VM instance.
- **`compute.instances.stop`**: Stop a running VM instance.
- **`compute.instances.update`**: Update VM instance properties.
- **`compute.instances.attachDisk`**: Attach persistent disks to a VM instance.
- **`compute.instances.setMetadata`**: Modify instance metadata.
- **`compute.networks.create`**: Create new VPC networks.
- **`compute.networks.delete`**: Delete VPC networks.
- **`compute.subnetworks.create`**: Create subnetworks in a VPC.
- **`compute.subnetworks.delete`**: Delete subnetworks.
- **`compute.firewalls.create`**: Create firewall rules for VPC networks.
- **`compute.firewalls.delete`**: Delete firewall rules.
- **`compute.addresses.create`**: Allocate new external IP addresses.
- **`compute.addresses.delete`**: Release external IP addresses.

Cloud Storage[^3]: 

- **`storage.buckets.create`**: Create new Cloud Storage buckets.
- **`storage.buckets.delete`**: Delete Cloud Storage buckets.
- **`storage.buckets.get`**: View details of storage buckets.
- **`storage.buckets.update`**: Modify storage bucket properties.
- **`storage.objects.create`**: Upload new objects to Cloud Storage.
- **`storage.objects.delete`**: Delete objects from Cloud Storage.
- **`storage.objects.get`**: View object metadata.
- **`storage.objects.list`**: List objects in a storage bucket.

IAM Identity and Access Management[^4]: 

- **`iam.roles.create`**: Create new custom roles.
- **`iam.roles.delete`**: Delete custom roles.
- **`iam.roles.get`**: View details of existing roles.
- **`iam.roles.update`**: Modify existing roles.
- **`iam.roles.list`**: List all available roles in a project.
- **`iam.serviceAccounts.create`**: Create new service accounts.
- **`iam.serviceAccounts.delete`**: Delete service accounts.
- **`iam.serviceAccounts.get`**: View details of service accounts.
- **`iam.serviceAccounts.update`**: Modify service account properties.
- **`iam.serviceAccountKeys.create`**: Create keys for service accounts.
- **`iam.serviceAccountKeys.delete`**: Delete keys for service accounts.
- **`iam.serviceAccountKeys.get`**: View details of service account keys.

Cloud PUB and SUB

- **`pubsub.topics.create`**: Create new Pub/Sub topics.
- **`pubsub.topics.delete`**: Delete Pub/Sub topics.
- **`pubsub.topics.publish`**: Publish messages to a Pub/Sub topic.
- **`pubsub.topics.get`**: View details of Pub/Sub topics.
- **`pubsub.topics.list`**: List all Pub/Sub topics in a project.
- **`pubsub.subscriptions.create`**: Create new Pub/Sub subscriptions.
- **`pubsub.subscriptions.delete`**: Delete Pub/Sub subscriptions.
- **`pubsub.subscriptions.pull`**: Pull messages from a Pub/Sub subscription.
- **`pubsub.subscriptions.get`**: View details of Pub/Sub subscriptions.

Cloud Functions[^6]: 

- **`cloudfunctions.functions.create`**: Create new Cloud Functions.
- **`cloudfunctions.functions.delete`**: Delete Cloud Functions.
- **`cloudfunctions.functions.get`**: View details of Cloud Functions.
- **`cloudfunctions.functions.update`**: Update existing Cloud Functions.
- **`cloudfunctions.functions.call`**: Invoke a Cloud Function.
- **`cloudfunctions.functions.list`**: List all available Cloud Functions in a project.

Cloud SQL: 

- **`cloudsql.instances.create`**: Create new Cloud SQL instances.
- **`cloudsql.instances.delete`**: Delete Cloud SQL instances.
- **`cloudsql.instances.get`**: View details of Cloud SQL instances.
- **`cloudsql.instances.update`**: Modify Cloud SQL instance configurations.
- **`cloudsql.instances.connect`**: Connect to a Cloud SQL instance.
- **`cloudsql.instances.list`**: List all Cloud SQL instances in a project.

Big Query: 

- **`bigquery.datasets.create`**: Create new BigQuery datasets.
- **`bigquery.datasets.delete`**: Delete BigQuery datasets.
- **`bigquery.datasets.get`**: View details of BigQuery datasets.
- **`bigquery.datasets.update`**: Modify BigQuery dataset properties.
- **`bigquery.tables.create`**: Create new tables in BigQuery datasets.
- **`bigquery.tables.delete`**: Delete BigQuery tables.
- **`bigquery.tables.get`**: View details of BigQuery tables.
- **`bigquery.jobs.create`**: Start new BigQuery jobs (e.g., queries, exports).
- **`bigquery.jobs.get`**: View details of BigQuery jobs.
- **`bigquery.jobs.list`**: List all jobs in a BigQuery project. 

Monitoring: 

- **`monitoring.alertPolicies.create`**: Create new alerting policies.
- **`monitoring.alertPolicies.delete`**: Delete alerting policies.
- **`monitoring.alertPolicies.get`**: View alerting policy configurations.
- **`monitoring.timeSeries.list`**: View time-series data for monitoring metrics.
- **`monitoring.dashboards.create`**: Create new dashboards in Cloud Monitoring.
- **`monitoring.dashboards.update`**: Update Cloud Monitoring dashboards.

Cloud Logging

- **`logging.logEntries.create`**: Write log entries to Cloud Logging.
- **`logging.logEntries.list`**: List log entries in Cloud Logging.
- **`logging.logEntries.get`**: View details of log entries.
- **`logging.sinks.create`**: Create new log sinks.
- **`logging.sinks.delete`**: Delete log sinks.
- **`logging.sinks.update`**: Modify log sink configurations.

IAM Policies and projects: 

- **`resourcemanager.projects.create`**: Create new Google Cloud projects.
- **`resourcemanager.projects.delete`**: Delete Google Cloud projects.
- **`resourcemanager.projects.get`**: View details of Google Cloud projects.
- **`resourcemanager.projects.update`**: Modify project settings.
- **`resourcemanager.projects.setIamPolicy`**: Set IAM policies on a project.
- **`resourcemanager.organizations.get`**: View details of organizations.
- **`resourcemanager.organizations.setIamPolicy`**: Set IAM policies on an organization.


Cloud Build: 

- **`cloudbuild.builds.create`**: Start new builds in Cloud Build.
- **`cloudbuild.builds.get`**: View details of a build.
- **`cloudbuild.builds.list`**: List all builds in a project.
- **`cloudbuild.builds.cancel`**: Cancel an ongoing build.

Cloud Spanner: 

- **`spanner.instances.create`**: Create new Cloud Spanner instances.
- **`spanner.instances.delete`**: Delete Cloud Spanner instances.
- **`spanner.instances.get`**: View details of Cloud Spanner instances.
- **`spanner.databases.create`**: Create new databases in a Spanner instance.
- **`spanner.databases.delete`**: Delete databases in a Spanner instance.
- **`spanner.databases.read`**: Read from Spanner databases.

[^1]: GKE or Google Kubernetes Engine [[GCP - GKE - Google Kubernetes Engine]]
[^2]: Compute engines or virtual machines within Google Cloud [[GCP - CEVM Computer Engine Virtual Machine[[GCP - Compute engine instances]]]]
[^3]: Cloud Storage using buckets [[GCP - Cloud Storage]]
[^4]: IAM or Identity and Access management [[GCP - IAM Permissions]]

[^6]: Cloud Functions [[GCP - Cloud Functions]]