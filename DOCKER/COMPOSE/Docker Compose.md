#DOCKER 

# Docker Compose

**Docker compose** is a docker tool for defining and managing multi-container docker applications using YAMl configuration files. 

Instead of managing each docker container independently using the command line tool, you define all the services, networks and volumes with their configuration in a single `docker-compose.yaml` or `compose.yaml` file. 

This allows to: 
* All the services are started together with `docker compose up` and turned down with `docker compose down`. 
* The configuration of the services is stored in a compose file, instead of in the docker run command. 

The basic workflow of Docker compose is: 

* You define your application environment and encapsulation in a docker container in `Dockerfile`. 
* Define all the services around the application, include a link to the application docker container in the `docker-compose.yaml`. 
* Run the `docker compose up` to start the application and all the resources around it. 

Take a look into `docker-compose.yaml`

