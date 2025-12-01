#DOCKER 

# DOCKER - CheatSheet

This is a docker's command cheat sheet: 

For overall management of Docker: 

| Command        | Description                                                                                                      |
| -------------- | ---------------------------------------------------------------------------------------------------------------- |
| `docker stats` | Provides a dynamic and real-time dashboard view of resource consumption for all the currently running containers |

| Command                           | Description                              |
| --------------------------------- | ---------------------------------------- |
| `docker images`                   | List all images                          |
| `docker pull <image>`             | Download an image from Docker Hub        |
| `docker build -t <name> .`        | Build an image from `Dockerfile`         |
| `docker rmi <image_id>`           | Remove an image                          |
| `docker tag <image> <repo>:<tag>` | Tag an image for a repository            |
| `docker push <repo>:<tag>`        | Push image to registry (e.g. Docker Hub) |

| Command                               | Description                                                                                                                          |
| ------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------ |
| `docker ps`                           | List running containers                                                                                                              |
| `docker ps -a`                        | List all containers (running + stopped)                                                                                              |
| `docker run -d -p 8080:80 <image>`    | Run container detached and map port                                                                                                  |
| `docker run -it <image> sh`           | Run container interactively                                                                                                          |
| `docker stop <container_id>`          | Stop a running container                                                                                                             |
| `docker start <container_id>`         | Start a stopped container                                                                                                            |
| `docker restart <container_id>`       | Restart a container                                                                                                                  |
| `docker rm <container_id>`            | Remove a container                                                                                                                   |
| `docker exec -it <container_id> bash` | Execute shell inside container                                                                                                       |
| `docker logs -f <container_id>`       | View logs (follow mode)                                                                                                              |
| `docker inspect <container_id>`       | Retrieved low-level information (JSON Format) metadata about the Docker objects around a container like image, volumes and networks. |
|                                       |                                                                                                                                      |
To clean the docker environment (Docker elements):

| Command                          | Description                                                    |
| -------------------------------- | -------------------------------------------------------------- |
| `docker system prune`            | Remove stopped containers, unused networks and dangling images |
| `docker system prune -a`         | ⚠️ Remove **all** unused containers, images, networks          |
| `docker rm $(docker ps -aq)`     | Remove all containers                                          |
| `docker rmi $(docker images -q)` | Remove all images                                              |
| `docker volume prune`            | Remove unused volumes                                          |

For volume management: 

| Command                                    | Description                                                           |
| ------------------------------------------ | --------------------------------------------------------------------- |
| `docker volume ls`                         | List volumes                                                          |
| `docker volume create <name>`              | Create a named volume to ensure it exists before container start up.  |
| `docker run -v <volume>:/path <image>`     | Mount volume to container                                             |
| `docker network ls`                        | List networks                                                         |
| `docker network create <name>`             | Create network                                                        |
| `docker network rm <name>`                 | Remove network                                                        |
| `docker network connect <net> <container>` | Attach container to network                                           |

For build and run: 

| Command                          | Description                 |
| -------------------------------- | --------------------------- |
| `docker build -t myapp .`        | Build image from Dockerfile |
| `docker run -d -p 3000:80 myapp` | Run built image             |
| `docker exec -it <id> bash`      | Access running container    |
| `docker logs -f <id>`            | Follow logs                 |
|                                  |                             |
|                                  |                             |

## Special commands

This commands has less usage in Docker environments: 

| Command                                  | Description                                  |
| :--------------------------------------- | -------------------------------------------- |
| `docker run --memory` or `docker run -m` | Limit or cap the memory usage of a container |
|                                          |                                              |
 

# Docker Compose

For docker compose, here its a guide of the most common commands: 

| Command                     | Description                                                                                                                                    |
| :-------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------- |
| `docker compose up`         | Primmary command that orchestrates the entire compose lifecycle: building images, creating networks, attach volumes and starting the services. |
| `docker compose up --build` | If an image is already built, using `--build` forces the build step again only if the Docker file or context has changed.                      |
| `docker compose start`      | Start an existing and stopped containers that has been built previously                                                                        |
| `docker compose build`      | Builds the images but doesn't start the services                                                                                               |