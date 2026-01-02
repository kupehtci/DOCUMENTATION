#Ansible 

# Ansible - Authentication

Ansible uses SSH or WinRM to perform the tasks so the authentication methods are related with this connection types. 

For Unix / Linux targets, as uses SSH, you need in the managed node to: 

* Create an `ansible` user
	* Add the user to the `wheel` group to have sudo permissions. 
* Allow the `wheel` group to execute any command without password
* Generate a password for the `ansible` user. 

Also the authentication can be done using SSH Keys. 