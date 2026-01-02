#Ansible 

# Ansible - Components

Ansible centralizes and automates systems administration tasks. take into account the main two aspects: 
* Its **agentless** so doesn't require specific software installed in the clients. 
* Its **idempotent** meaning that will have the same effect each time that is executed. 

It has different components involved in the automations and Ansible ecosystem: 
* The management machine is the central device where ansible is installed and as its **agentless** no other software is deployed in other devices. 
* The **managed nodes** are the targets or hosts that Ansible manages that can be servers, network appliances or any other computer. 
* The **inventory** is the file that contains all the information about the **managed nodes**. 
* A **module** abstracts a task. 
* A **playbook** is a YAML format file that define the tasks performed. 
* A **role** allows to organize the playbooks under it. 
* A **collection** is a logical set of playbooks, roles, modules and plugins. 
* The **facts** are global variables containing information about the system. 
* The **Handlers** are used to make a service to be stopped or restarted in the event of a change. 