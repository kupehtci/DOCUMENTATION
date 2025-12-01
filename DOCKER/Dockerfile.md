#DOCKER 

# Dockerfile

A <span style="color:DodgerBlue;">Dockerfile</span> its a set of instructions and configuration parameters that tell Docker how to set the image together. 

This file describes the application, its code and dependencies. 

It follows the following format: 

```dockerfile
FROM image_name
WORKDIR directory_on_image
COPY local_files image_files
ADD source image_destination
RUN command

ENV env_name=env_value
EXPOSE port_number
USER username
ENTRYPOINT command_in_image[options]
CMD command_in_image[options]
```

\* env is an environmental variable that can be use to set some configurations of the execution of the code inside the container. 

This are the most fundamental ones: 

###### `FROM`

All docker files starts with this one and specify an existing layer to build the new layer over it. 

###### `WORKDIR`

It sets the working directory inside the image filesystem. It doesn't add a new layer. 

###### `COPY`

It creates a new layer by copying the files and directories from the local Docker client to the image. 

###### `ADD`
This command also copies files and directories into a Docker image. They can be copied from a tarball, an URL or the local storage. 

###### `EXPOSE`

Exposes the ports that the application within the container listens to. 
Take into account that it doesn't publish the ports on the host's machine, for that the ports needs to be mapped on image run or using the `-p` flag on `docker run`. 

###### `RUN`

This will execute a Linux command on the image command line and create a new layer. 
The command is executed when the image is built and its used to install dependencies and packages to do the code work. 

###### `CMD`

CMD is the default command for the container to run the services within it. 
It runs automatically on container start up.  

You can use it in 3 different ways: 

* `CMD["executable", "parameter1", "parameter2"]`
* `CMD["parameter1", "parameter2"]` used as default parameters for `ENTRYPOINT`. It will run the command specified in `ENTRYPOINT` with the parameters specified in this line. 
* `CMD command parameter1 parameter2` in a shell format. 

###### `ENTRYPOINT`

Allows to configure a container to run as an executable

###### `ARG`

Creates a build-time variable. 


## Multi-Stage Build

A Multi-Stage build is a way of writing the Dockerfile by defining different **stages** with multiple **FROM** instructions. 
Each stage only copies the artifacts needed from the earlier stages into a final and *minimal image*. 

At the start of each stage you use a `COPY --from=<stage-name>` to bring for example only the compiled binary of the application into the final stage. This leaves behind compilers, caches and other unnecessary elements. 

Multi-Stage builds allow to use a large image (For example with compilers) in one stage and bring only the necessary artifact to the minimal final image. 

A common pattern for a multi-stage dockerfile is: 
 * **Stage 1: builder / compiler** that uses a SDK image to install dependencies, run test and build the app
 * **Stage 2 runtime**: uses a lightweight image and a `COPY --from` to copy the binaries and define the `ENTRYPOINT` / `CMD` to run it. 

Its necessary to name a stage to call the `COPY --from=<stage>` command: 
```Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# ... build ...

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
COPY --from=build /app .
# ... runtime ...
```
 
