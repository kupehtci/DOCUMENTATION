#NGINX 

# NGINX - Configuration

NGINX is normally configured in a text file `nginx.conf` using directives grouped in nested blocks. 

This blocks define how NGINX listens for connections, virtual hosts, serves content and proxy the requests. 

This file is normally placed under `/etc/nginx/nginx.conf` with other files such as `conf.d/*.conf` or `sitess-enabled/*` for modular configuration. 


# Server

The `server` block defines a virtual host and defines which sites handles a IP and port request. 

The directives to configure a `server` block are: 

* `listen <port>` port listening
* `server_name example.com www.example.com` host headers that the server handles. 
* `root /var/www/example`: site root for serving the content
* `index index.html` default index file for the website. 


## Locations 

`location` blocks can be placed inside `server` block in order to define how to handle specific URL paths or patterns. 

Common configurations for this block: 
* `location /... {...}` define the `location` block and the site behaior 