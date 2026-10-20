#DOCKER 

# DockerFile - Labels

The **labels** in a `Dockerfile` are metadata in key=value format that are attached to an image. 

They doesn't change how the container in executed, they are used for documentation, organization and filtering. 

Use cases: 
* Identify the image
* Track the image chain like git repository, commit, pipeline or build that generated it. 
* Automatization using filtering like `docker ps --filter`

> [!note] Take into account that the images inherit the base image labels (`FROM`), although you can overwrite them. 

> [!note] In OCI images its recommended to use the prefix `org.opencontainers.image.*` so they can be used in other tools like Docker, Podman, containerd, Kubernetes and others.


## Usage example

They are declared using the `LABEL` instruction: 

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0
ARG BUILD_VERSION=0.0.0
ARG GIT_COMMIT=unknown
ARG BUILD_DATE=unknown

LABEL org.opencontainers.image.title="My .NET API" \
      org.opencontainers.image.description="My shooping app" \
      org.opencontainers.image.version="${BUILD_VERSION}" \
      org.opencontainers.image.revision="${GIT_COMMIT}" \
      org.opencontainers.image.created="${BUILD_DATE}" \
      org.opencontainers.image.source="https://dev.azure.com/mi-org/MiProyecto/_git/MiApi" \
      org.opencontainers.image.vendor="Mi Empresa" \
      com.miempresa.pipeline="azure-devops"
```


## How to check the labels

```bash
docker inspect my-image:1.4.2 --format '{{json .Config.Labels}}'
```

## How to filter by label

```bash
docker images --filter "label=com.miempresa.environment=production"
```
