#DOCKER 

Docker is a lightweight way to build, package and run applications in containers. 

Containers are a lightweight, standalone environment that includes everything that an application needs to run (Code, dependencies, libraries and configuration). 

The main key benefits of running an application in a container are: 

* **Consistency** across environments. 
* **Isolation**: each container runs independently. 
* **Portability**: deploy the same container anywhere. 
* **Lightweight**: shares the host OS kernel. 
* **Easy to scale**: with tools like Docker Compose or Kubernetes. 


### How to work with Docker

1. Write a `DockerFile`that define how to build a container (A base image, dependencies and build commands). 
2. Build the image using: 
```bash
docker build -t myapp ./ 
```

3. Run the container using: 
```bash
docker run -d -p 8080:80 myapp
````

This will run the container in the background (by the `-d` flag) and maps the port `8080` on your machine to port `80` inside the container. 

You can take a look on the running containers: 
```bash
docker ps
```

And manipulate a container: 
```bash
# Stop a container
docker stop <container_id>
```