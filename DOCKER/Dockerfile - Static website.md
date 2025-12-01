#DOCKER 

# Dockerfile - Static website

For serving an static website with docker, you can use a simple Dockerfile based on the `nginx:alpine`[^1]

For serving the application you must configure in local the `nginx.conf` file with the necessary configuration for serving the application and just copy the website into `/usr/share/nginx/html`. 

Example of the Dockerfile: 
```Dockerfile
FROM nginx:alpine

COPY ./html /usr/share/nginx/html
```


* Copy the static website files like index.html from a directory named `/html` next to the Dockerfile. 
* Copy the files into NGINX's default web root so the requests over port 80 (HTTP) serve the site. 

[^1]: NGINX [[NGINX]]