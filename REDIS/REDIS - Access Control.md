#REDIS #DATABASES 

Redis ACL or Redis Access Control List is an interface list of users with: 

* Authentication properties
* Restricted **commands**
* Restricted **keys**

Redis has not roles, but this privileges can be granted at user-level

Users can be created as: 
```redis
ACL SETUSER <username> [rule [rule...]]
```

Authenticate as: 
```redis
AUTH <user> <password>
```

List all users: 
```
ACL LIST
```

We can grant the privileges of some commands some various users by adding (+) or substracting (-) them: 

![[redis_acl_1.png]]