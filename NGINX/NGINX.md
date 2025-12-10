#NGINX 

# NGINX

NGINX is a Web Server Software for serving static content efficiently managing large number of concurrent connections. 

It also has the following capabilities: 
* **Web Server**: can serve static files like HTML, CSS, images and javascript. 
* **Reverse proxy**: route and balance incoming requests to one or more backend services. 
	* Adds scalability and security for web infrastructure. 
* **Load balancer**: NGINX distributes incoming traffic among multiple servers. 
* **HTTP Cache**: caches HTTP content to improve speed and reduce server load. 
* **SSL / TLS offloading**[^1]: handles the secure connections between client and server by terminating the HTTPS connection and forwarding plain HTTP to backend servers. 

It can also proxy and balance TCP or UDP traffic as well as mail protocols like IMAP, POP3 and SMTP. 

# Architecture

Uses an asynchronous and event-driven architecture so a single process can manage multiple simultaneous connections without creating a new process / thread for each request.  


[^1]: SSL / TLS offloading or terminating [[SSL - One line]]
