#SONARQUBE 

# SonarQube - User, Groups and permission management

SonarQube provides a comprehensive permission management system that administer who can can access to projects, execute the analysis and manage the platform using users, groups and permission structures. 

## Users

You can manage the users in *Administration* > *Security* > *Users*: 



## Groups

Groups are collections or set of users that share common permissions. This provides a simplified permission management allowing to assign permissions directly to groups instead of individual users. 


You can manage the groups in *Administration* > *Security* > *Groups*. 



## Permissions

SonarQube allows to manage permissions at two levels: 

* **Global**: affect all projects
* **Project**: permissions over a single project

### Global Permissions

This **global permissions** affect the current permissions of users and groups over **administer the system**, **Quality gates**, **Quality Profiles**, **Execute analysis** and **Create projects**. It doesn't affect project level permissions. 

You can manage the Global Permissions in *Administration* > *Security* > *Global Permissions*.
This options shows a table with the users and groups available in SonarQube and the possible Permissions: 

* **Administer system**: Allows the user or group to perform all administration functions for the sonarqube server. 
* **Administer**: 
	* **Quality Gates**: Allows the user or group to perform any action over the Quality Gates of the projects. 
	* **Quality Profiles**: Allows the user or group to modify the Quality Profile. 
* **Execute Analysis**: Allows the user or group to execute the analysis for a project. 
* **Create: Projects**: Allows the entity to create new projects. 
![[global_permissions.png]]
### Permission Template

A **permission template** is a set of permissions that defines the users and groups that have permissions over projects and the actions that they can perform. Its a permission scheme, as instead of defining the projects, you define a project key (regular expression) that a project name should match so the permission template affects over that project. 

Example: Project key pattern: `AD_*` all projects that starts with `AD_` should met the permission template and the users and groups with permissions should be able to perform that actions over this project. 

The permission templates **only applies at project creation time**, meaning that if you modify a template, the changes won't be automatically propagated to projects that are already in use.

You can manage the permission templates in *Administration* > *Security* > *Permission Templates*.  