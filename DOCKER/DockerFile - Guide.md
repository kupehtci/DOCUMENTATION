#DOCKER 

# DockerFile - Guide

This document summarizes a guide to build a `DockerFile`:

A DockerFile is a text file that contains the instructions to build a **Docker Image**. 

The base structure of a `DockerFile` consist of: 
```DockerFile
# Use a base image
FROM <base-image>

# Set the working directory inside a container
WORKDIR /app

# Copy files
COPY . . 

# Run commands to install dependencies or build the application
RUN <command>

# Expose a port for external access
EXPOSE <port>

# Define the startup command
CMD ["<command>", "arg1", "arg2"]
```

Each instruction or line in the `DockerFile` creates a layer in the image. This layers are cached so are taken into account for rebuilds. 



