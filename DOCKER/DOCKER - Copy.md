#DOCKER 

# DOCKER Copy 

You can copy files from the native operating system to the docker container with the `docker cp` built-in command in docker CLI. 

To do so, you can do it by specifiying the running container id and the destination path of the file. 

```bash

docker cp example.txt container_id:/path/to/destination
```