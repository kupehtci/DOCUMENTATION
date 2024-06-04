#MongoDB #DATABASES 

### MongoDB Access control 

In MongoDB you can create users and roles in order to control the access to different database sections or even limit the operations that can be done over them. 

Users can be created by using the following commands:  

```txt
db.createUser()
db.createRole()
```

Priviledges can be assigned by: 

* Database privileges
* Collection privileges
* Cluster Management privileges
* Backup and restore privileges
```
db.runCommand({ rolesInfo: { role: "<role_name>", showPrivileges: true, showBuiltinRoles: true } })
```


Privileges can also be assigned: 

* Role-Based Access Control (RBAC)
* Views
