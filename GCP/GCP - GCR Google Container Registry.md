#GCP #DOCKER 

# GCR Google Container Registry

GCR or Google Container Registry is a private and secure container registry for holding the workloads Docker images that can be pulled from within the same project. 

Take into account that google container registry have an unique name and can only be one per each project 


### Versus Artifact Registry

Artifact Registry is the evolution of Container registry that is able to contain container images and language packages like Maven or NPM. 


### How to push an image

To push an image to the GCR, the most common pattern is: 

```bash
PROJECT=[[YOUR-PROJECT]]
docker tag $(whoami)/my-image gcr.io/${PROJECT}/my-image
gcloud docker -- push gcr.io/${PROJECT}/my-image
```

And to avoid using `gcloud` for pushing the image and do it with docker: 

```bash
## authenticate to gcloud
PASSWORD=$(gcloud auth application-default print-access-token)  
docker login \  
--username=oauth2accesstoken \  
--password=${PASSWORD} \  
https://gcr.io

## Push image
docker tag $(whoami)/my-image gcr.io/${PROJECT}/my-image
docker push gcr.io/${PROJECT}/my-image
```

### Create a GCR using terraform

You can create an GCR using the `google_container_registrty` resource: 

```hcl
resource "google_container_registry" "registry" {
  project  = "my-project"
  location = "EU"
}
```

It only has that two attributes (`project` and `location`) where `project` is the ID of the project where the resource will be created. 

The `location` parameter must be set to `ASIA`, `EU` or `US`. Can also be nor specified.  