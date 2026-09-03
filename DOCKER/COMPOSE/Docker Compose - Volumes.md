#DOCKER 

# Docker Compose - Volumes


In **Docker** there are three main types of volumes used to persist or manipulate data from the containers ( For more information take a look into: [[DOCKER - Volumes]]). 

These three volumes can be declared in a docker compose file as follows: 

## Volumes
### Named volumes

There are docker-managed volumes identified with a user-defined name. 
They are stored under `/var/lib/docker/volumes/`) in a linux host. 

```yaml
services: 
	db: 
		image: postgres:15
		volumes: 
			- pgdata:/var/lib/postgresql/data

volumes: 
	pgdata: 
		driver: local
```

Defined as: 
* Inside `service.{service-name}.volumes` array of volumes following: 
	* `{volume-name}:{container-path}[:options]`: 
		* `volume-name`: name of the volume. 
		* `container-path`: path inside the container to store in the volume. 
		* `options`: (optional): 
			* `ro`: Read-only
			* `rw`: Read-write (default)
			* `z` / `Z`: SELinux labels. 
* Inside `volumes` define the volume configuration: 
	* By default: `driver: local` for local storage. 


### Bind mounts

Bind mounts allows to mount an specific directory or file from the host directly into the container. 

This is useful for live editing source code or to mount a local configuration file. 

```yaml
services:
  {service-name}:
    volumes:
      - {host-path}:{container-path}[:<options>]
```

* `host-path` path inside the host to a file or a directory to mount it to the container. 
	* This path can be relative to the Docker Compose file like `./config.yaml` or absolute like `/var/data`. 
* Doesn't require a volumes top-level section. 

A good example its the common mounts in an NGINX file: 

```yaml
services:
  web:
    image: nginx:latest
    volumes:
      # Relative path
      # Load the initial HTMLs to the NGINX serving path
      - ./html:/usr/share/nginx/html:ro
      
      # Absolute path
      # Mounts a directory to be able to access the NGINX logs
      - /var/log/app:/var/log/app
      
      # Single file
      # Loads the configuration
      - ./config/nginx.conf:/etc/nginx/nginx.conf:ro
```


### tmpfs mount

Tmpfs mount store data exclusively in the host's memory and its not written into disk. They disappear when the container stops. 

This type of volumes are only available in Linux hosts. 

```yaml
services:
  {service-name}: 
    tmpfs:
      - {container-path}
      - {container-path}:<options>
```

Allows to pass `options` such as: 
* `size`: maximum size such as `100m`, `1g` or `64m`. 
* `mode`: file permissions as octal, such as `1777` or `770`. 
* `uid`: Owner user ID. 
* `gid`: Owner group ID. 


## Volumes top-level section

Inside the volume section you can define some properties or configuration: 

* `driver`: driver selects the volume driver. This driver needs to be installed in order to configure NFS, cloud storage, distributed storage or other vendor specific storages. 
	* By default `local`
* `driver_opts`: Passes driver specific options, like for example for an NFS volume: 

```yaml
volumes:
  shared-data:
    driver: local
    driver_opts:
      type: nfs
      o: addr=10.0.0.10,rw,nfsvers=4
      device: ":/exports/shared"
```

* `external: true` uses an existing volume managed outside the current Docker Compose file. This will search for a volume with same name as defined. If it doesn't exists the deployment of the compose file fails. 
	* With `external: true` other configurations different than `driver: local` are not valid except name. 
* `name`: by default, docker will create the volume as: {project-name}\_{volume-name}. By defining `name: {container-name}` prevents the automatic prefix and forces a custom name. 
* `labels`: used to add custom metadata to a named volume. Example: 

```yaml
volumes:
  postgres-data:
    labels:
      com.example.description: "PostgreSQL persistent data"
      com.example.environment: "production"
      com.example.owner: "platform-team"
```