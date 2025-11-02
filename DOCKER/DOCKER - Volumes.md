#DOCKER 

# DOCKER - Volumes



## Command cheat sheet

This is a set of commands to interact with docker's volumes: 

* To  create a new volume: 
```bash
docker volume create <name>
```

* To delete an existing volume: 
```bash
docker volume rm <name>
```

* List all existing volumes: 
```bash
docker volume ls
docker volume list
```

* Mount an existing volume:
```bash
docker run -d -v <volume_name>:<path_inside_container> <image>
# Example
docker run -d -v my_data:/var/lib/mysql mysql:latest
```

Use `-v` flag to indicate that a volume is mounted

* Inspect metadata from an existing volume: 
```bash
docker volume inspect <name>
```

* Remove unused local volumes
```bash
docker volume prune
# It accept the following flags: 
#   -f for force so it won't prompt for confirmation
#   -a remove all unused volumes, not just the anonymous ones. 
#   --filter provides filtering values
```

