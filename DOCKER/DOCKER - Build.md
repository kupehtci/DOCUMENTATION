#DOCKER 

# DOCKER Build process

Once the Dockerfile[^1] its finished, you can build the Docker image with the configuration and the application inside it. 

The `docker build` command takes the Dockerfile and builds a docker image. 
```bash
docker image build <image-name>:<image-version>
```

By doing this, the image is built with the specified OS and packages installed. 
It runs the CMD command to start the application and the path specified in the build context, becomes the root directory for the container. 

To check if the image has been created successfully you can check its existence: 

```bash
docker image ls
```

### Tagging

When so much images are created with more versions, in order to remember and ease the use of them, docker allow to tag your images with better names. 

Its so useful to keep them and pulling them using this names and tags: 

To do so, follow this syntax: 
```bash
docker image tag <image-name>:<image-version> <docker-hub-username>/<image-name>:<image-version>
```

The docker hub username or other registry provider like `<acr-name>.azurecr.io/` for Azure container registry[^2], its useful for then pushing it to the container registry. 

### Push

You can then push the locally created docker image to a remote Docker registry. 
This allows to be able to pull the image from anywhere. 

An example for docker hub is: 
```bash
docker push <your-docker-hub-username>/<image-name>:<image-version>
```

[^1]: Dockerfile is a file that defines an Docker image, how its built and how to start the application inside [[Dockerfile]]
[^2]: Azure Container registry is an container registry service within Azure Cloud where you can pull, push and maintain docker images and retrieve them from the cloud. 