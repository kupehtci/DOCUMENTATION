#DOCKER 

# Docker Images

An <span style="color:DodgerBlue;">Docker image</span> is a basic unit of a container. 

Is an inmutable file that is essentially an snapshot of a container. Its created using `docker build` and they produce a running container using `docker run`. 

This images can be stored in Docker Registries, pulled from it and run it on demand. 

With this image, you can run as many containers from it as you want by running multiple instances. And whether you run the container from the image you will run the code inside the way its intended to do. 


When the docker image is built, all the configurations and instructions defined in the Dockerfile[^1] are applied and embedded within the image. 
The code of the application and its dependencies are bind into the application because its copied into it when doing the `COPY` in dockerfile when the image its built. 

[^1]: Dockerfile is the main instruction and configuration defined when creating a Docker image. [[Dockerfile]]