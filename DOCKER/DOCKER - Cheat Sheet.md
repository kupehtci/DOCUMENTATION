#DOCKER 

# DOCKER - CheatSheet

This is a docker's command cheat sheet: 

| Command                           | Description                              |
| --------------------------------- | ---------------------------------------- |
| `docker images`                   | List all images                          |
| `docker pull <image>`             | Download an image from Docker Hub        |
| `docker build -t <name> .`        | Build an image from `Dockerfile`         |
| `docker rmi <image_id>`           | Remove an image                          |
| `docker tag <image> <repo>:<tag>` | Tag an image for a repository            |
| `docker push <repo>:<tag>`        | Push image to registry (e.g. Docker Hub) |

|Command|Description|
|---|---|
|`docker ps`|List running containers|
|`docker ps -a`|List all containers (running + stopped)|
|`docker run -d -p 8080:80 <image>`|Run container detached and map port|
|`docker run -it <image> sh`|Run container interactively|
|`docker stop <container_id>`|Stop a running container|
|`docker start <container_id>`|Start a stopped container|
|`docker restart <container_id>`|Restart a container|
|`docker rm <container_id>`|Remove a container|
|`docker exec -it <container_id> bash`|Execute shell inside container|
|`docker logs -f <container_id>`|View logs (follow mode)|

| Command                          | Description                                                    |
| -------------------------------- | -------------------------------------------------------------- |
| `docker system prune`            | Remove stopped containers, unused networks and dangling images |
| `docker system prune -a`         | ⚠️ Remove **all** unused containers, images, networks          |
| `docker rm $(docker ps -aq)`     | Remove all containers                                          |
| `docker rmi $(docker images -q)` | Remove all images                                              |
| `docker volume prune`            | Remove unused volumes                                          |

For volume management: 

| Command                                    | Description                 |
| ------------------------------------------ | --------------------------- |
| `docker volume ls`                         | List volumes                |
| `docker volume create <name>`              | Create volume               |
| `docker run -v <volume>:/path <image>`     | Mount volume to container   |
| `docker network ls`                        | List networks               |
| `docker network create <name>`             | Create network              |
| `docker network rm <name>`                 | Remove network              |
| `docker network connect <net> <container>` | Attach container to network |

For build and run: 

| Command                          | Description                 |
| -------------------------------- | --------------------------- |
| `docker build -t myapp .`        | Build image from Dockerfile |
| `docker run -d -p 3000:80 myapp` | Run built image             |
| `docker exec -it <id> bash`      | Access running container    |
| `docker logs -f <id>`            | Follow logs                 |