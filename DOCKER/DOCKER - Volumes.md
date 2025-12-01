#DOCKER 

# DOCKER - Volumes



## Types

Docker has different types of storage solutions: 

### Volumes

Managed by docker and mounted under `/var/lib/docker/volumes` on the host. 
Allows: 
* Persistent Data that survive container restarts or removal. 
* Can be shared between different containers
* Work both in linux and windows containers. In MacOS is available but as Docker Desktop runs within a "VM", you cannot access freely the host's path. 

* Bind Mounts: mounts an specific host's directory or file to a container path. 
	* Usefull for development where you can see directly the live code updates. 
	* Full host system access.
* Tmpfs Mounts (Only in Linux): Stored in host memory only and never written into disc. 
	* Its temporary storage, as it is deleted when the container stops. 
	* Fast performance for temporary files
	* Limited by RAM. 
* Named Pipes 

Volumes's data persists once the associated container is removed using `docker rm` until its explicitly removed using `docker volume rm` or with a "prune" command. 

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

