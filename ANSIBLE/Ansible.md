#Ansible

# Ansible

Ansible is an open-source platform for IT systems automatization and administration that allows to manage multiple servers, networking resources and systems without installing agents directly in each device. 

It uses **SSH** or **WinRP** to connect to the remote devices, avoiding using agents directly. 

It uses YAML files known as **"playbooks"** that define the tasks to automate. 

It allows to: 
* **Manage configurations**: automatizes the configuration of OS, applications and services maintaining an homogeneous state. 
* **Application deploy**: allows to deploy applications and software directly into different nodes and environments. 
* **Infrastructure provisioning**: create and configure servers, virtual machines, containers and more. 
	* Can be paired with **terraform**[^1] so it handles the infrastructure and Ansible the post-provision configuration. 
* **Workflows** allow to define and execute workflows with tasks dependencies and conditional execution. 

In networking allows to: 
* **Networking automation**:  configure networking devices like routers, switches, , NX-OS. 
