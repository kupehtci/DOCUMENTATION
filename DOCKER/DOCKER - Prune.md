#DOCKER 

### Clean docker 

The `prune` command removes all unused containers, networks, images (dangling and unused) and optionally removes the volumes (`--volumes`)

```bash 
docker system prune -a [--volumes]
```


A dangling image is the one that you have created a new build of the image and give the same name. So this dangling images are the previous versions of this build, that become untagged and display `<none>` on its name

An unused image is the one that has not been assigned or used in a container 