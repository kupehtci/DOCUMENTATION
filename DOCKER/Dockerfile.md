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

###### `RUN`

This will execute a Linux command on the image command line and create a new layer. 
The command is executed when the image is built and its used to install dependencies and packages to do the code work. 

###### `CMD`

This command is what runs the code in your image with its arguments and its run when you run the image to create the container. 

You can use it in 3 different ways: 

* `CMD["executable", "parameter1", "parameter2"]`
* `CMD["parameter1", "parameter2"]` used as default parameters for `ENTRYPOINT`. It will run the command specified in `ENTRYPOINT` with the parameters specified in this line. 
* `CMD command parameter1 parameter2` in a shell format. 
###### `ENTRYPOINT`

Allows to configure a container to run as an executable
