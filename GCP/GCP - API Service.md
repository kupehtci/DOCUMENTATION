#GCP 

# GCP Api Service


In GCP, Google API Services are essential component that provide access to various functionalities of GCP.  

An API Service must be enabled in order to use some resources within the Google Solution and some implementations. 

THis is a list of the most common API services for some Google Cloud Integrations: 

* `compute API` or `compute.googleapis.com` is the one needed for creating and run GKE nodes and VM resources. 
* `container API` or `container.googleapis.com` allows to build and manage container-based applications powered by Kubernetes technologies. 
* App engine Admin API enables the configuration of App Engine[^1] applications and services
* Cloud Run API: manages containerized applications on a serverless platform. 

### Get available services

You can list the available services using `gcloud` CLI tool: 

```bash
gcloud services list --available
```

Take into account that before making this command, project must be set: 

```bash
gcloud config set project  
```