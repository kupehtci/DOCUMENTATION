#GCP 

# GCP Artifact Repository

The artifact repository is the successor of the Google Container Registry that apart of granting a registry for storing docker images, also can store other artifacts such as YUM, NPM, Maven packages and others. 

You can declare an Artifact Repository using terraform:  

```hcl
resource "google_artifact_registry_repository" "my-repo" {
  location      = "<location>"  # Example: "us-central1"
  repository_id = "<repository-name>"  # Example: "test-example"
  description   = "example docker repository" 
  format        = "DOCKER"
}
```

You can set the docker parameters for the artifact repository using `docker_config` block within the `google_artifact_registry_repository` resource. Only contains <span style="color:MediumSlateBlue;">inmutable_tags</span> that specify if the contained tags must be protected against being modified, moved or deleted. 
This tag is recommended to be set as true for production environments. 

`repository_id` is required and will be the last part of the repository name
`format` parameter is necessary and must be one of Docker, Maven, npm, Python, Apt, Yum, Kubeflow, Go or Generic. 


### Docker

The images that must be pushed to the repository must have a name accordingly to the repository where its being created. 

To determine the name of the image, you must follow this format:
```bash
<LOCATION>-docker.pkg.dev/<PROJECT-ID>/<REPOSITORY>/<IMAGE>
```

In order to be able to push the image to the registry you will have to tag the image as so: 

```bash
docker tag <src-image> <location>-docker.pkg.dev/<project-id>/<repo>/<image>:<tag>
```

And then push the image to the repository: 

```bash
docker push <location>-docker.pkg.dev/<project-id>/<repo>/<image>
```

You can check the artifact repository details: 

```bash
gcloud artifacts repositories describe <repository-name> \
    --project=<project-id> \
    --location=<location>
```