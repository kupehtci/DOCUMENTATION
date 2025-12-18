#Linux 

# Linux systemd Units

Units in the Linux's Systemd are object that this system uses to control the resources and state of the Linux OS. 

Various things are represented as units: 

* `.service`: background daemon and oneshot scripts
* `.timer`: scheduled triggers similar to cronjobs that normally activate a service. 
* `.socket`: socket activation endpoints that can start services on demand. 
* `.target`: logical groups or synchronization points for boot or run states. 

And non-service resources: 
* `.mount / .automount`: filesystem mounts like on-demand mounts. 
* `.device`: devices connected to the system. 
* `.swap`: swap areas. 

Each Unit is defined in an unit file, with the extension defined previously and its an INI format file that define its behavior. 

