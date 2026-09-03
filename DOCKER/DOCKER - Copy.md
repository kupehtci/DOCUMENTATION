#DOCKER 

# DOCKER Copy 

You can copy files from the native operating system to the docker container with the `docker cp` built-in command in docker CLI. 

To do so, you can do it by specifiying the running container id and the destination path of the file. 

```bash
docker cp example.txt container_id:/path/to/destination
```

## Usage

```bash 
docker cp [OPTIONS] CONTAINER:SRC_PATH DEST_PATH   # Container -> Host
docker cp [OPTIONS] SRC_PATH CONTAINER:DEST_PATH   # Host -> Container
```

* options: 
	* `-L` or `--follow-link` follow any symbolic link in `SRC_PATH` (Copies the origin of the link)
	* `-a` or `--archive`sopy the user and group ID information from the source so it preserves the ownership.
	* `-q` or `--quiet` suppress the progress output during the copy.